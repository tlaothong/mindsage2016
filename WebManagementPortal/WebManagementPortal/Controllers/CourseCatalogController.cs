﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebManagementPortal.EF;
using System.Data.Entity;
using WebManagementPortal.Repositories.Models;

namespace WebManagementPortal.Controllers
{
    [RoutePrefix("api/coursecatalog")]
    public class CourseCatalogController : ApiController
    {
        // GET: api/CourseCatalog/{course-catalog-id}/detail
        [Route("{id}/detail")]
        public async Task<GetCourseDetailRespond> GetDetail(int id)
        {
            EF.CourseCatalog courseCatalog;
            var relatedCourseList = Enumerable.Empty<EF.CourseCatalog>();
            using (var dctx = new EF.MindSageDataModelsContainer())
            {
                courseCatalog = await dctx.CourseCatalogs
                    .Include("Semesters.Units.Lessons.Advertisements")
                    .Include("Semesters.Units.Lessons.TopicOfTheDays")
                    .Include("Semesters.Units.Lessons.TeacherLessonItems")
                    .Include("Semesters.Units.Lessons.StudentLessonItems")
                    .Include("Semesters.Units.Lessons.PreAssessments.Assessments.Choices")
                    .Include("Semesters.Units.Lessons.PostAssessments.Assessments.Choices")
                    .FirstOrDefaultAsync(it => it.Id == id);

                if (courseCatalog != null)
                {
                    relatedCourseList = dctx.CourseCatalogs
                        .Where(it => it.GroupName == courseCatalog.GroupName)
                        .Where(it => it.Id != courseCatalog.Id)
                        .Where(it => !it.RecLog.DeletedDate.HasValue)
                        .ToList();
                }
            }
            if (courseCatalog == null) return null;

            var semesterQry = courseCatalog.Semesters.Where(it => !it.RecLog.DeletedDate.HasValue);
            var unitQry = semesterQry.SelectMany(it => it.Units).Where(it => !it.RecLog.DeletedDate.HasValue);
            var lessonQry = unitQry.SelectMany(it => it.Lessons).Where(it => !it.RecLog.DeletedDate.HasValue);

            var lessonIdRunner = 1;
            var unitIdRunner = 1;
            var semesterNameRunner = (byte)65;
            var semesters = semesterQry.Select(semester => new GetCourseDetailRespond.Semester
            {
                Title = semester.Title,
                Description = semester.Description,
                Name = string.Format("{0}", (char)semesterNameRunner++),
                TotalWeeks = semester.TotalWeeks,
                Units = unitQry.Where(unit => unit.SemesterId == semester.Id).Select(unit => new GetCourseDetailRespond.Unit
                {
                    Title = unit.Title,
                    Description = unit.Description,
                    UnitNo = unitIdRunner++,
                    Lessons = lessonQry.Where(it => it.UnitId == unit.Id).Select(lesson =>
                    {
                        var studentContentQry = lesson.StudentLessonItems
                                .Where(it => !it.RecLog.DeletedDate.HasValue)
                                .Select(it => new GetCourseDetailRespond.LessonContent
                                {
                                    ContentUrl = it.ContentURL,
                                    ImageUrl = it.IconURL,
                                    Description = it.Description,
                                    IsPreviewable = it.IsPreviewable,
                                });
                        return new GetCourseDetailRespond.Lesson
                        {
                            id = lesson.Id.ToString(),
                            Order = lessonIdRunner++,
                            Contents = studentContentQry
                        };
                    }),
                    TotalWeeks = unit.TotalWeeks
                }),
            });

            var relatedCourses = (relatedCourseList ?? Enumerable.Empty<EF.CourseCatalog>())
                .Select(it => new GetCourseDetailRespond.RelatedCourse
                {
                    CourseId = it.Id.ToString(),
                    Name = it.SideName
                });
            var result = new GetCourseDetailRespond
            {
                id = courseCatalog.Id.ToString(),
                CreatedDate = courseCatalog.RecLog.CreatedDate,
                DescriptionImageUrl = courseCatalog.DescriptionImageUrl,
                FullDescription = courseCatalog.FullDescription,
                Grade = courseCatalog.Grade.ToString(),
                GroupName = courseCatalog.GroupName,
                PriceUSD = courseCatalog.PriceUSD,
                Semesters = semesters,
                Series = courseCatalog.Series,
                SideName = courseCatalog.SideName,
                Title = courseCatalog.Title,
                RelatedCourses = relatedCourses,
                TotalWeeks = courseCatalog.TotalWeeks
            };
            return result;
        }

        [HttpGet]
        [Route("{id}/ads")]
        public async Task<OwnCarousel> GetAds(int id)
        {
            EF.CourseCatalog courseCatalog;
            using (var dctx = new EF.MindSageDataModelsContainer())
            {
                courseCatalog = await dctx.CourseCatalogs
                    .Include("Semesters.Units.Lessons.Advertisements")
                    .Include("Semesters.Units.Lessons.TopicOfTheDays")
                    .FirstOrDefaultAsync(it => it.Id == id);
            }
            if (courseCatalog == null) return null;
            var adsUrls = courseCatalog?.Advertisements?.Split(new string[] { "#;" }, StringSplitOptions.RemoveEmptyEntries) ?? Enumerable.Empty<string>();
            var result = new OwnCarousel
            {
                owl = adsUrls.Select(it => new OwnCarousel.OwnItem
                {
                    item = $"<div class='item'><img src='{ it }' /></div>"
                })
            };
            return result;
        }
    }
}
