// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SpecFlow.GeneratedTests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class Show_DiscussionsFeature : Xunit.IClassFixture<Show_DiscussionsFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Show_Discussions.feature"
#line hidden
        
        public Show_DiscussionsFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Show_Discussions", "In order to avoid silly mistakes\r\nAs a math idiot\r\nI want to be told the sum of t" +
                    "wo numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 6
#line 7
 testRunner.Given("Initialize mocking data", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 8
    testRunner.And("System have ClassCalendar collection with JSON format are", @"[
    {
        ""id"": ""ClassCalendar01"",
        ""BeginDate"": ""2/1/2016"",
        ""ClassRoomId"": ""ClassRoom01"",
        ""LessonCalendars"":
        [
            {
                ""Id"": ""ClassCalendar01"",
                ""LessonId"": ""Lesson01"",
                ""BeginDate"": ""2/1/2016"",
                ""LessonCatalogId"": ""LessonCatalog01""
            },
            {
                ""Id"": ""LC02"",
                ""LessonId"": ""Lesson02"",
                ""BeginDate"": ""2/8/2016"",
                ""LessonCatalogId"": ""LessonCatalog02""
            },
            {
                ""Id"": ""LC03"",
                ""LessonId"": ""Lesson03"",
                ""BeginDate"": ""2/15/2016"",
                ""LessonCatalogId"": ""LessonCatalog03""
            },
        ]
    },
]", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 39
 testRunner.And("System have UserProfile collection with JSON format are", "[\r\n{\r\n\"id\": \"sakul@mindsage.com\",\r\n\"Subscriptions\":\r\n[\r\n{\r\n\t\"id\": \"Subscription01" +
                    "\",\r\n\t\"Role\": \"Teacher\",\r\n\t\"ClassRoomId\": \"ClassRoom01\",\r\n\t\"ClassCalendarId\": \"Cl" +
                    "assCalendar01\",\r\n},\r\n]\r\n},\r\n]", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 56
    testRunner.And("System have FriendRequest collection with JSON format are", "[\r\n    {\r\n        \"id\": \"FriendRequest01\",\r\n\"FromUserProfileId\": \"sakul@mindsage." +
                    "com\",\r\n\"ToUserProfileId\": \"earn@mindsage.com\",\r\n\"Status\": \"Friend\",\r\n\"AcceptedDa" +
                    "te\": \"2/1/2016\",\r\n\"CreatedDate\": \"2/1/2016\",\r\n    }\r\n]", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 69
    testRunner.And("System have Comment collection with JSON format are", "[\r\n    {\r\n        \"id\": \"Comment01\",\r\n        \"ClassRoomId\": \"ClassRoom01\",\r\n    " +
                    "    \"CreatedByUserProfileId\": \"sakul@mindsage.com\",\r\n        \"Description\": \"Msg" +
                    "01\",\r\n        \"TotalLikes\": 0,\r\n        \"LessonId\": \"Lesson01\",\r\n\"CreatedDate\": " +
                    "\"2/1/2016 01:00 am\",\r\n\"Discussions\": []\r\n    },\r\n    {\r\n        \"id\": \"Comment02" +
                    "\",\r\n        \"ClassRoomId\": \"ClassRoom01\",\r\n        \"CreatedByUserProfileId\": \"sa" +
                    "kul@mindsage.com\",\r\n        \"Description\": \"Msg02\",\r\n        \"TotalLikes\": 5,\r\n " +
                    "       \"LessonId\": \"Lesson02\",\r\n\"CreatedDate\": \"2/1/2016 02:00 am\",\r\n        \"Di" +
                    "scussions\":\r\n        [\r\n            {\r\n                \"Id\": \"DiscussionId01\",\r\n" +
                    "                \"Description\": \"Discussion01\",\r\n                \"TotalLikes\": 10" +
                    "0,\r\n                \"CreatedByUserProfileId\": \"sakul@mindsage.com\",\r\n\t\"CreatedDa" +
                    "te\": \"2/1/2016 02:01 am\",\r\n            }\r\n        ]\r\n    },\r\n    {\r\n        \"id\"" +
                    ": \"Comment03\",\r\n        \"ClassRoomId\": \"ClassRoom01\",\r\n        \"CreatedByUserPro" +
                    "fileId\": \"earn@mindsage.com\",\r\n        \"Description\": \"Msg03\",\r\n        \"TotalLi" +
                    "kes\": 10,\r\n        \"LessonId\": \"Lesson02\",\r\n\"CreatedDate\": \"2/1/2016 03:00 am\",\r" +
                    "\n        \"Discussions\":\r\n        [\r\n            {\r\n                \"Id\": \"Discus" +
                    "sionId02\",\r\n                \"Description\": \"Discussion02\",\r\n                \"Tot" +
                    "alLikes\": 200,\r\n                \"CreatedByUserProfileId\": \"someone@mindsage.com\"" +
                    ",\r\n\t\"CreatedDate\": \"2/1/2016 03:01 am\",\r\n            },\r\n            {\r\n        " +
                    "        \"Id\": \"DiscussionId03\",\r\n                \"Description\": \"Discussion03\",\r" +
                    "\n                \"TotalLikes\": 300,\r\n                \"CreatedByUserProfileId\": \"" +
                    "sakul@mindsage.com\",\r\n\t\"CreatedDate\": \"2/1/2016 03:02 am\",\r\n            }\r\n     " +
                    "   ]\r\n    },\r\n    {\r\n        \"id\": \"Comment04\",\r\n        \"ClassRoomId\": \"ClassRo" +
                    "om01\",\r\n        \"CreatedByUserProfileId\": \"someone@mindsage.com\",\r\n        \"Desc" +
                    "ription\": \"Msg04\",\r\n        \"TotalLikes\": 15,\r\n        \"LessonId\": \"Lesson02\",\r\n" +
                    "\"CreatedDate\": \"2/1/2016 04:00 am\",\r\n        \"Discussions\":\r\n        [\r\n        " +
                    "    {\r\n                \"Id\": \"DiscussionId04\",\r\n                \"Description\": \"" +
                    "Discussion04\",\r\n                \"TotalLikes\": 400,\r\n\t\"CreatedByUserProfileId\": \"" +
                    "someone@mindsage.com\",\r\n\t\"CreatedDate\": \"2/1/2016 04:01 am\",\r\n            }\r\n   " +
                    "     ]\r\n    },\r\n]", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        public virtual void SetFixture(Show_DiscussionsFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Show_Discussions")]
        [Xunit.TraitAttribute("Description", "User request comment\'s discussion Then system send the comment\'s discussion back")]
        public virtual void UserRequestCommentSDiscussionThenSystemSendTheCommentSDiscussionBack()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User request comment\'s discussion Then system send the comment\'s discussion back", new string[] {
                        "mock"});
#line 150
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 151
    testRunner.Given("Today is \'2/8/2016 00:00 am\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 152
    testRunner.When("UserProfile \'sakul@mindsage.com\' request discussion from comment \'Comment03\' in t" +
                    "he lesson \'Lesson02\' of ClassRoom: \'ClassRoom01\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 153
    testRunner.Then("System send comment\'s discussion with JSON format are", @"[
    {
        ""Id"": ""DiscussionId03"",
""CommentId"": ""Comment03"",
        ""Description"": ""Discussion03"",
        ""TotalLikes"": 300,
        ""CreatedByUserProfileId"": ""sakul@mindsage.com"",
""CreatedDate"": ""2/1/2016 03:02 am"",
    },
{
        ""Id"": ""DiscussionId02"",
""CommentId"": ""Comment03"",
        ""Description"": ""Discussion02"",
        ""TotalLikes"": 200,
        ""CreatedByUserProfileId"": ""someone@mindsage.com"",
""CreatedDate"": ""2/1/2016 03:01 am"",
    },
]", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                Show_DiscussionsFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                Show_DiscussionsFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
