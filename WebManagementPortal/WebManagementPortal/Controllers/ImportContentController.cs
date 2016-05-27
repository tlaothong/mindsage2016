﻿using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebManagementPortal.EF;
using WebManagementPortal.ViewModels;

namespace WebManagementPortal.Controllers
{
    public class ImportContentController : Controller
    {
        // GET: ImportContent
        public ActionResult Index()
        {
            EF.ImportContentConfiguration importContent;
            using (var dctx = new EF.MindSageDataModelsContainer())
            {
                importContent = dctx.ImportContentConfigurations.Where(it => !it.RecLog.DeletedDate.HasValue).ToList().OrderBy(it => it.RecLog.CreatedDate).LastOrDefault();
            }

            var isImportSettingAvailable = importContent != null;
            var result = new ImportContentViewModel
            {
                Id = isImportSettingAvailable ? importContent.Id : -1,
                BaseURL = isImportSettingAvailable ? importContent.BaseURL : string.Empty,
                HomePageURL = isImportSettingAvailable ? importContent.HomePageURL : string.Empty,
                PagesURLs = isImportSettingAvailable ? JsonConvert.DeserializeObject<IEnumerable<string>>(importContent.PagesURLs) : Enumerable.Empty<string>(),
                ReferenceFileURLs = isImportSettingAvailable ? JsonConvert.DeserializeObject<IEnumerable<string>>(importContent.ReferenceFileURLs) : Enumerable.Empty<string>(),
                ReplaceSections = isImportSettingAvailable ? JsonConvert.DeserializeObject<List<ReplaceSectionInformation>>(importContent.ReplaceSections) : new List<ReplaceSectionInformation>(),
                StorageInfo = isImportSettingAvailable ? JsonConvert.DeserializeObject<StorageInformation>(importContent.StorageInfo) : new StorageInformation(),
            };
            return View(result);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(ImportContentViewModel model)
        {
            cleanModel(model);
            var configuration = updateDatabase(model);
            string ReferenceOldName = null;
            string ReferenceName = null;

            //var credential = $"DefaultEndpointsProtocol=https;AccountName={ model.StorageInfo.AccountName };AccountKey={ model.StorageInfo.StorageKey }";
            //var storageAccount = CloudStorageAccount.Parse(credential);
            //var tableClient = storageAccount.CreateCloudTableClient();
            //var table = tableClient.GetTableReference("Configuration");
            //table.CreateIfNotExists();
            foreach (var item in model.ReferenceFileURLs)
            {
                if (item.IndexOf("style.css") > -1)
                {
                    var ReferHttp = new HttpDownloader(item);
                    var styleText = ReferHttp.GetPage();
                    ReferenceOldName = item;
                    ReferenceName = item.Replace("?", "/").Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last(element => element.IndexOf("style.css") > -1);
                    using (var steam = System.IO.File.CreateText($@"d:\{ReferenceName}"))
                    {
                        steam.WriteLine(styleText);
                    }
                }
                else {
                    var fontsHttp = new HttpDownloader(item);
                    var fontsText = fontsHttp.GetPage();
                    var fontsName = item.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
                    using (var steam = System.IO.File.CreateText($@"d:\{fontsName}"))
                    {
                        steam.WriteLine(fontsText);
                    }
                }
            }

            // HACK: Create home page
            //var client = new WebClient();
            //var fileName = model.HomePageURL.Replace(".php", string.Empty).Replace(".html", string.Empty).Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
            //client.Encoding = Encoding.UTF8;
            //var dataText = client.DownloadData($"{model.BaseURL}{model.HomePageURL}");
            //var rawText = client.DownloadString($"{model.BaseURL}{model.HomePageURL}");
            //var replacedText = replaceContent(rawText, model.ReplaceSections);
            var Http = new HttpDownloader($"{model.BaseURL}{model.HomePageURL}");
            var rawText = Http.GetPage();
            var replacedText = replaceContent(rawText, model.ReplaceSections);
            replacedText = replaceLink(replacedText, model.BaseURL, model.PagesURLs);
            replacedText = replaceReference(replacedText, ReferenceOldName, ReferenceName);

            int a = 3;
            using (var steam = System.IO.File.CreateText(@"d:\home.html"))
            {
                steam.WriteLine(replacedText);
            }


            // Other pages
            //foreach (var item in model.PagesURLs)
            //{
            //    var client = new WebClient();
            //    var rawText = client.DownloadString($"{model.BaseURL}{item}");
            //}

            //var data = new ImportContentTableEntity
            //{
            //    PartitionKey = model.BaseURL,
            //    RowKey = model.HomePageURL,
            //    BaseURL = model.BaseURL,
            //    HomePageURL = model.HomePageURL,
            //    PagesURLs = JsonConvert.SerializeObject(model.PagesURLs),
            //    ReferenceFileURLs = JsonConvert.SerializeObject(model.ReferenceFileURLs),
            //    ReplaceSections = JsonConvert.SerializeObject(model.ReplaceSections),
            //    StorageInfo = JsonConvert.SerializeObject(model.StorageInfo),
            //    Timestamp = DateTime.Now
            //};
            //var insertOperation = TableOperation.InsertOrReplace(data);
            //table.Execute(insertOperation);
            return RedirectToAction("Index");
        }

        private void cleanModel(ImportContentViewModel model)
        {
            model.PagesURLs = model.PagesURLs.Where(it => !string.IsNullOrEmpty(it) && !string.IsNullOrWhiteSpace(it)).ToList();
            model.ReferenceFileURLs = model.ReferenceFileURLs.Where(it => !string.IsNullOrEmpty(it) && !string.IsNullOrWhiteSpace(it)).ToList();
            model.ReplaceSections = model.ReplaceSections.Where(it => it != null
                && !string.IsNullOrEmpty(it.Original) && !string.IsNullOrWhiteSpace(it.Original))
                .ToList();
        }
        private ImportContentConfiguration updateDatabase(ImportContentViewModel model)
        {
            using (var dctx = new EF.MindSageDataModelsContainer())
            {
                var selectedObj = dctx.ImportContentConfigurations.FirstOrDefault(it => it.Id == model.Id);
                if (selectedObj == null)
                {
                    selectedObj = new EF.ImportContentConfiguration
                    {
                        BaseURL = model.BaseURL,
                        HomePageURL = model.HomePageURL,
                        PagesURLs = JsonConvert.SerializeObject(model.PagesURLs),
                        ReferenceFileURLs = JsonConvert.SerializeObject(model.ReferenceFileURLs),
                        ReplaceSections = JsonConvert.SerializeObject(model.ReplaceSections),
                        StorageInfo = JsonConvert.SerializeObject(model.StorageInfo),
                        RecLog = new EF.RecordLog { CreatedDate = DateTime.Now }
                    };
                    dctx.ImportContentConfigurations.Add(selectedObj);
                }
                else
                {
                    selectedObj.BaseURL = model.BaseURL;
                    selectedObj.HomePageURL = model.HomePageURL;
                    selectedObj.PagesURLs = JsonConvert.SerializeObject(model.PagesURLs);
                    selectedObj.ReferenceFileURLs = JsonConvert.SerializeObject(model.ReferenceFileURLs);
                    selectedObj.ReplaceSections = JsonConvert.SerializeObject(model.ReplaceSections);
                    selectedObj.StorageInfo = JsonConvert.SerializeObject(model.StorageInfo);
                    selectedObj.RecLog = new EF.RecordLog { CreatedDate = DateTime.Now };
                }
                dctx.SaveChanges();
                return selectedObj;
            }
        }
        private string replaceContent(string rawHtml, IEnumerable<ReplaceSectionInformation> sections)
        {
            foreach (var item in sections)
            {
                rawHtml = rawHtml.Replace(item.Original, item.ReplacedBy);
            }
            return rawHtml;
        }
        private string replaceLink(string html, string BaseURL,IEnumerable<string> links)
        {
            foreach (var item in links)
            {
                var fileName = item.Replace(".php", string.Empty).Replace(".html", string.Empty).Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
                var replaceWith = $"www.mindsage.org/xxxxx/{ fileName }";
                var original = $"{BaseURL}{item}";
                html = html.Replace(original, replaceWith);
            }
            return html;
        }
        private string replaceReference(string html, string oldReference ,string newReference)
        {
            html = html.Replace(oldReference, newReference);
            return html;
        }

        public class HttpDownloader
        {

            public Encoding Encoding { get; set; }
            public WebHeaderCollection Headers { get; set; }
            public Uri Url { get; set; }

            public HttpDownloader(string url)
            {
                Encoding = Encoding.GetEncoding("ISO-8859-1");
                Url = new Uri(url); // verify the uri
            }

            public string GetPage()
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);

                request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Headers = response.Headers;
                    Url = response.ResponseUri;
                    return ProcessContent(response);
                }

            }

            private string ProcessContent(HttpWebResponse response)
            {
                SetEncodingFromHeader(response);

                Stream s = response.GetResponseStream();
                if (response.ContentEncoding.ToLower().Contains("gzip"))
                    s = new GZipStream(s, CompressionMode.Decompress);
                else if (response.ContentEncoding.ToLower().Contains("deflate"))
                    s = new DeflateStream(s, CompressionMode.Decompress);

                MemoryStream memStream = new MemoryStream();
                int bytesRead;
                byte[] buffer = new byte[0x1000];
                for (bytesRead = s.Read(buffer, 0, buffer.Length); bytesRead > 0; bytesRead = s.Read(buffer, 0, buffer.Length))
                {
                    memStream.Write(buffer, 0, bytesRead);
                }
                s.Close();
                string html;
                memStream.Position = 0;
                using (StreamReader r = new StreamReader(memStream, Encoding))
                {
                    html = r.ReadToEnd().Trim();
                    html = CheckMetaCharSetAndReEncode(memStream, html);
                }

                return html;
            }

            private void SetEncodingFromHeader(HttpWebResponse response)
            {
                string charset = null;
                if (string.IsNullOrEmpty(response.CharacterSet))
                {
                    Match m = Regex.Match(response.ContentType, @";\s*charset\s*=\s*(?<charset>.*)", RegexOptions.IgnoreCase);
                    if (m.Success)
                    {
                        charset = m.Groups["charset"].Value.Trim(new[] { '\'', '"' });
                    }
                }
                else
                {
                    charset = response.CharacterSet;
                }
                if (!string.IsNullOrEmpty(charset))
                {
                    try
                    {
                        Encoding = Encoding.GetEncoding(charset);
                    }
                    catch (ArgumentException)
                    {
                    }
                }
            }

            private string CheckMetaCharSetAndReEncode(Stream memStream, string html)
            {
                Match m = new Regex(@"<meta\s+.*?charset\s*=\s*(?<charset>[A-Za-z0-9_-]+)", RegexOptions.Singleline | RegexOptions.IgnoreCase).Match(html);
                if (m.Success)
                {
                    string charset = m.Groups["charset"].Value.ToLower() ?? "iso-8859-1";
                    if ((charset == "unicode") || (charset == "utf-16"))
                    {
                        charset = "utf-8";
                    }

                    try
                    {
                        Encoding metaEncoding = Encoding.GetEncoding(charset);
                        if (Encoding != metaEncoding)
                        {
                            memStream.Position = 0L;
                            StreamReader recodeReader = new StreamReader(memStream, metaEncoding);
                            html = recodeReader.ReadToEnd().Trim();
                            recodeReader.Close();
                        }
                    }
                    catch (ArgumentException)
                    {
                    }
                }

                return html;
            }
        }
    }
}