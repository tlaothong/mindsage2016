// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.0.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SpecFlow.GeneratedTests.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class Add_New_Course_By_Teacher_CodeFeature : Xunit.IClassFixture<Add_New_Course_By_Teacher_CodeFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Add_New_Course_By_Teacher_Code.feature"
#line hidden
        
        public Add_New_Course_By_Teacher_CodeFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Add_New_Course_By_Teacher_Code", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
                    "f two numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
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
 testRunner.And("System have UserProfile collection with JSON format are", "[\r\n{\r\n\"id\": \"sakul@mindsage.com\",\r\n\"Name\": \"Sakul\",\r\n\"ImageProfileUrl\": \"sakul.jp" +
                    "g\",\r\n\"Subscriptions\": []\r\n}\r\n]", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 19
 testRunner.And("System have Contract collection with JSON format are", @"[
	{
		""id"": ""Contract01"",
		""SchoolName"": ""SchoolName01"",
		""State"": ""CA"",
		""ZipCode"": ""95123"",
		""CreatedDate"": ""1/1/2016"",
		""Licenses"": [
			{
				""id"": ""License01"",
				""CourseCatalogId"": ""CourseCatalog01"",
				""Grade"": 7,
				""TeacherKeys"": [
					{
						""id"": ""TeacherKey01"",
						""Grade"": 7,
						""Code"": ""07CA95123U48PSchoolName"",
						""CreatedDate"": ""1/1/2016""
					}
				]
			}
		]
	}
]", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 46
 testRunner.And("System have CourseCatalog collection with JSON format are", "[\r\n\t{\r\n\t\t\"id\": \"CourseCatalog01\",\r\n\t\t\"Grade\": 7,\r\n\t\t\"SideName\": \"COMPLETE 7th GRA" +
                    "DE COURSE\",\r\n\t\t\"CreatedDate\": \"1/1/2016\"\r\n\t}\r\n]", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 57
 testRunner.And("System have LessonCatalog collection with JSON format are", @"[
    {
        ""id"": ""LessonCatalog01"",
""Order"": 1,
""SemesterName"": ""A"",
""CourseCatalogId"": ""CourseCatalog01"",
        ""Title"": ""What Is Emotional Literacy?"",
        ""ShortTeacherLessonPlan"": ""short teacher lesson plan01"",
        ""FullTeacherLessonPlan"": ""full teacher lesson plan01"",
""PrimaryContentUrl"": ""PrimaryContent01"",
""ExtraContents"": [ 
{
	""id"": ""Extra01"",
	""ContentURL"": ""www.extracontent01.com"",
	""Description"": ""description01"",
	""IconURL"": ""extra01.jpg""
},
{
	""id"": ""Extra02"",
	""ContentURL"": ""www.extracontent02.com"",
	""Description"": ""description03"",
	""IconURL"": ""extra02.jpg""
},
{
	""id"": ""Extra03"",
	""ContentURL"": ""www.extracontent03.com"",
	""Description"": ""description03"",
	""IconURL"": ""extra03.jpg""
}
],
""TopicOfTheDays"": []
    },
]", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 93
    testRunner.And("System have StudentKey collection with JSON format are", "[\r\n\t{\r\n\t\t\"id\": \"StudentKey01\",\r\n\t\t\"Code\": \"StudentCode01\",\r\n\t\t\"Grade\": \"Grade01\"," +
                    "\r\n\t\t\"CourseCatalogId\": \"CourseCatalog01\",\r\n\t\t\"ClassRoomId\": \"ClassRoom01\",\r\n\t\t\"C" +
                    "reatedDate\": \"2/1/2016\",\r\n\t}\r\n]", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        public virtual void SetFixture(Add_New_Course_By_Teacher_CodeFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Add_New_Course_By_Teacher_Code")]
        [Xunit.TraitAttribute("Description", "User add new course by using the right teacher code Then system add new course to" +
            " the user\'s subscription")]
        [Xunit.TraitAttribute("Category", "mock")]
        public virtual void UserAddNewCourseByUsingTheRightTeacherCodeThenSystemAddNewCourseToTheUserSSubscription()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User add new course by using the right teacher code Then system add new course to" +
                    " the user\'s subscription", new string[] {
                        "mock"});
#line 108
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 109
    testRunner.Given("Today is \'2/8/2016 00:00 am\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 110
    testRunner.When("UserProfile \'sakul@mindsage.com\' Add new course by using teteacher code \'07CA9512" +
                    "3U48PSchoolName\' and grade \'7\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 111
    testRunner.Then("System create new ClassRoom with JSON format is", @"{
	""Name"": ""COMPLETE 7th GRADE COURSE"",
	""CourseCatalogId"": ""CourseCatalog01"",
	""CreatedDate"": ""2/8/2016 00:00 am"",
	""LastUpdatedMessageDate"": ""2/8/2016 00:00 am"",
	""Lessons"": [
		{
			""id"": ""LessonCatalog01"",
			""LessonCatalogId"": ""LessonCatalog01"",
		}
	]
}", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 126
 testRunner.And("System create new ClassCalendar with JSON format is", @"{
	""CreatedDate"": ""2/8/2016 00:00 am"",
	""LessonCalendars"": [
		{
			""Order"": 1,
			""SemesterGroupName"": ""A"",
			""BeginDate"": ""2/8/2016 00:00 am"",
			""CreatedDate"": ""2/8/2016 00:00 am"",
			""LessonId"": ""LessonCatalog01"",
			""TopicOfTheDays"": []
		}
	]
}", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 142
 testRunner.And("System upsert user id \'sakul@mindsage.com\' UserActivity\'s LessonActivities collec" +
                    "tion with JSON format are", "[\r\n{\r\n\"LessonId\": \"LessonCatalog01\",\r\n\"TotalContentsAmount\": 4,\r\n\"SawContentIds\":" +
                    " [],\r\n\"CreatedCommentAmount\": 0,\r\n\"ParticipationAmount\": 0,\r\n\"BeginDate\": \"2/8/2" +
                    "016 00:00 am\",\r\n}\r\n]", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 155
 testRunner.And("System add new teacher subscription for user id \'sakul@mindsage.com\' collection w" +
                    "ith JSON format are", "[\r\n{\r\n\"Role\": \"Teacher\",\r\n\"ClassRoomName\": \"COMPLETE 7th GRADE COURSE\",\r\n\"License" +
                    "Id\": \"License01\",\r\n\"CourseCatalogId\": \"CourseCatalog01\",\r\n\"CreatedDate\": \"2/8/20" +
                    "16 00:00 am\",\r\n\"LastActiveDate\": \"2/8/2016 00:00 am\",\r\n}\r\n]", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 168
 testRunner.And("System create new StudentKey with JSON format is", "{\r\n\t\"Grade\": 7,\r\n\t\"CourseCatalogId\": \"CourseCatalog01\",\r\n\t\"CreatedDate\": \"2/8/201" +
                    "6 00:00 am\",\r\n}", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                Add_New_Course_By_Teacher_CodeFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                Add_New_Course_By_Teacher_CodeFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
