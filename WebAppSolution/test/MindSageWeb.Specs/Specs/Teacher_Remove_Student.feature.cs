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
    public partial class Teacher_Remove_StudentFeature : Xunit.IClassFixture<Teacher_Remove_StudentFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Teacher_Remove_Student.feature"
#line hidden
        
        public Teacher_Remove_StudentFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Teacher_Remove_Student", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
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
 testRunner.And("System have UserProfile collection with JSON format are", @"[
{
""id"": ""teacher@mindsage.com"",
""Name"": ""teacher"",
""ImageProfileUrl"": ""teacher.jpg"",
""Subscriptions"":
[
{
	""id"": ""Subscription01"",
	""Role"": ""Teacher"",
	""ClassRoomId"": ""ClassRoom01"",
	""ClassCalendarId"": ""ClassCalendar01"",
},
]
},
{
""id"": ""student@mindsage.com"",
""Name"": ""student"",
""ImageProfileUrl"": ""student.jpg"",
""Subscriptions"":
[
{
	""id"": ""Subscription02"",
	""Role"": ""Student"",
	""ClassRoomId"": ""ClassRoom01"",
	""ClassCalendarId"": ""ClassCalendar01"",
},
]
},
{
""id"": ""teacherWithDeletedSubscription@mindsage.com"",
""Name"": ""teacher"",
""ImageProfileUrl"": ""teacher.jpg"",
""Subscriptions"":
[
{
	""id"": ""Subscription03"",
	""Role"": ""Teacher"",
	""ClassRoomId"": ""ClassRoom01"",
	""ClassCalendarId"": ""ClassCalendar01"",
	""DeletedDate"": ""1/1/2016""
},
]
},
]", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 56
 testRunner.And("System have ClassCalendar collection with JSON format are", @"[
    {
        ""id"": ""ClassCalendar01"",
        ""BeginDate"": ""2/1/2016"",
        ""ClassRoomId"": ""ClassRoom01"",
        ""LessonCalendars"":
        [
            {
                ""Id"": ""LessonCalendar01"",
                ""LessonId"": ""Lesson01"",
                ""BeginDate"": ""2/1/2016"",
                ""LessonCatalogId"": ""LessonCatalog01""
            },
        ]
    },
]", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 75
 testRunner.And("System have ClassRoom collection with JSON format are", @"[
    {
        ""id"": ""ClassRoom01"",
        ""Name"": ""Emotional literacy"",
""Grade"": ""7"",
        ""CourseCatalogId"": ""CourseCatalog01"",
        ""CreatedDate"": ""2/1/2016"",
""Message"": ""Don't forget to comment a lesson!"",
        ""Lessons"":
        [
            {
                ""id"": ""Lesson01"",
                ""TotalLikes"": 0,
                ""LessonCatalogId"": ""LessonCatalog01""
            },
        ]
    }
]", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 96
 testRunner.And("System have StudentKey collection with JSON format are", "[\r\n\t{\r\n\t\t\"id\": \"StudentKey01\",\r\n\t\t\"Code\": \"StudentCode01\",\r\n\t\t\"Grade\": \"7\",\r\n\t\t\"C" +
                    "ourseCatalogId\": \"CourseCatalog01\",\r\n\t\t\"ClassRoomId\": \"ClassRoom01\",\r\n\t\t\"Created" +
                    "Date\": \"2/1/2016\",\r\n\t}\r\n]", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 109
 testRunner.And("System have UserActivity collection with JSON format are", @"[
{
""id"": ""UserActivity01"",
""UserProfileId"": ""teacher@mindsage.com"",
""ClassRoomId"": ""ClassRoom01"",
""LessonActivities"":
[
{
	""id"": ""LessonActivity01"",
	""LessonId"": ""Lesson01"",
	""TotalContentsAmount"": 1,
	""SawContentIds"": 
	[
		""Content01""
	],
	""CreatedCommentAmount"": 1,
	""ParticipationAmount"": 1
}
]
},
{
""id"": ""UserActivity02"",
""UserProfileId"": ""student@mindsage.com"",
""ClassRoomId"": ""ClassRoom01"",
""LessonActivities"":
[
{
	""id"": ""LessonActivity02"",
	""LessonId"": ""Lesson01"",
	""TotalContentsAmount"": 1,
	""SawContentIds"": [],
	""CreatedCommentAmount"": 0,
	""ParticipationAmount"": 0
}
]
}
]", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        public virtual void SetFixture(Teacher_Remove_StudentFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Teacher_Remove_Student")]
        [Xunit.TraitAttribute("Description", "Teacher remove a student Then system remove the student from the course")]
        [Xunit.TraitAttribute("Category", "mock")]
        public virtual void TeacherRemoveAStudentThenSystemRemoveTheStudentFromTheCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Teacher remove a student Then system remove the student from the course", new string[] {
                        "mock"});
#line 151
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 152
    testRunner.Given("Today is \'2/8/2016 00:00 am\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 153
    testRunner.When("UserProfile \'teacher@mindsage.com\' remove StudentId \'student@mindsage.com\' from C" +
                    "lassRoom \'ClassRoom01\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 154
    testRunner.Then("System upsert UserProfile with JSON format is", @"{
""id"": ""student@mindsage.com"",
""Name"": ""student"",
""ImageProfileUrl"": ""student.jpg"",
""Subscriptions"":
[
{
""id"": ""Subscription02"",
""Role"": ""Student"",
""ClassRoomId"": ""ClassRoom01"",
""ClassCalendarId"": ""ClassCalendar01"",
""DeletedDate"": ""2/8/2016 00:00 am""
}
]
}", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 172
 testRunner.And("System upsert UserActivity collection with JSON format is", @"{
""id"": ""UserActivity02"",
""UserProfileId"": ""student@mindsage.com"",
""ClassRoomId"": ""ClassRoom01"",
""DeletedDate"": ""2/8/2016 00:00 am"",
""LessonActivities"":
[
{
""id"": ""LessonActivity02"",
""LessonId"": ""Lesson01"",
""TotalContentsAmount"": 1,
""SawContentIds"": [],
""CreatedCommentAmount"": 0,
""ParticipationAmount"": 0
}
]
}", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Teacher_Remove_Student")]
        [Xunit.TraitAttribute("Description", "Teacher remove a student but the student doesn\'t existing (unknow) Then system do" +
            "esn\'t remove the student from the course")]
        [Xunit.TraitAttribute("Category", "mock")]
        public virtual void TeacherRemoveAStudentButTheStudentDoesnTExistingUnknowThenSystemDoesnTRemoveTheStudentFromTheCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Teacher remove a student but the student doesn\'t existing (unknow) Then system do" +
                    "esn\'t remove the student from the course", new string[] {
                        "mock"});
#line 194
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 195
    testRunner.Given("Today is \'2/8/2016 00:00 am\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 196
    testRunner.When("UserProfile \'teacher@mindsage.com\' remove StudentId \'unknow@mindsage.com\' from Cl" +
                    "assRoom \'ClassRoom01\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 197
    testRunner.Then("System doesn\'t upsert UserProfile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 198
 testRunner.And("System doesn\'t upsert UserActivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Teacher_Remove_Student")]
        [Xunit.TraitAttribute("Description", "Teacher remove a student but the student doesn\'t existing (empty) Then system doe" +
            "sn\'t remove the student from the course")]
        [Xunit.TraitAttribute("Category", "mock")]
        public virtual void TeacherRemoveAStudentButTheStudentDoesnTExistingEmptyThenSystemDoesnTRemoveTheStudentFromTheCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Teacher remove a student but the student doesn\'t existing (empty) Then system doe" +
                    "sn\'t remove the student from the course", new string[] {
                        "mock"});
#line 201
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 202
    testRunner.Given("Today is \'2/8/2016 00:00 am\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 203
    testRunner.When("UserProfile \'teacher@mindsage.com\' remove StudentId \'\' from ClassRoom \'ClassRoom0" +
                    "1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 204
    testRunner.Then("System doesn\'t upsert UserProfile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 205
 testRunner.And("System doesn\'t upsert UserActivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Teacher_Remove_Student")]
        [Xunit.TraitAttribute("Description", "Teacher remove a student but the student doesn\'t existing (null) Then system does" +
            "n\'t remove the student from the course")]
        [Xunit.TraitAttribute("Category", "mock")]
        public virtual void TeacherRemoveAStudentButTheStudentDoesnTExistingNullThenSystemDoesnTRemoveTheStudentFromTheCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Teacher remove a student but the student doesn\'t existing (null) Then system does" +
                    "n\'t remove the student from the course", new string[] {
                        "mock"});
#line 208
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 209
    testRunner.Given("Today is \'2/8/2016 00:00 am\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 210
    testRunner.When("UserProfile \'teacher@mindsage.com\' remove StudentId \'NULL\' from ClassRoom \'ClassR" +
                    "oom01\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 211
    testRunner.Then("System doesn\'t upsert UserProfile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 212
 testRunner.And("System doesn\'t upsert UserActivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Teacher_Remove_Student")]
        [Xunit.TraitAttribute("Description", "Teacher remove a student but the ClassRoom doesn\'t existing (unknow) Then system " +
            "doesn\'t remove the student from the course")]
        [Xunit.TraitAttribute("Category", "mock")]
        public virtual void TeacherRemoveAStudentButTheClassRoomDoesnTExistingUnknowThenSystemDoesnTRemoveTheStudentFromTheCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Teacher remove a student but the ClassRoom doesn\'t existing (unknow) Then system " +
                    "doesn\'t remove the student from the course", new string[] {
                        "mock"});
#line 215
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 216
    testRunner.Given("Today is \'2/8/2016 00:00 am\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 217
    testRunner.When("UserProfile \'teacher@mindsage.com\' remove StudentId \'student@mindsage.com\' from C" +
                    "lassRoom \'UnknowClassRoom\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 218
    testRunner.Then("System doesn\'t upsert UserProfile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 219
 testRunner.And("System doesn\'t upsert UserActivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Teacher_Remove_Student")]
        [Xunit.TraitAttribute("Description", "Teacher remove a student but the ClassRoom doesn\'t existing (empty) Then system d" +
            "oesn\'t remove the student from the course")]
        [Xunit.TraitAttribute("Category", "mock")]
        public virtual void TeacherRemoveAStudentButTheClassRoomDoesnTExistingEmptyThenSystemDoesnTRemoveTheStudentFromTheCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Teacher remove a student but the ClassRoom doesn\'t existing (empty) Then system d" +
                    "oesn\'t remove the student from the course", new string[] {
                        "mock"});
#line 222
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 223
    testRunner.Given("Today is \'2/8/2016 00:00 am\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 224
    testRunner.When("UserProfile \'teacher@mindsage.com\' remove StudentId \'student@mindsage.com\' from C" +
                    "lassRoom \'\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 225
    testRunner.Then("System doesn\'t upsert UserProfile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 226
 testRunner.And("System doesn\'t upsert UserActivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Teacher_Remove_Student")]
        [Xunit.TraitAttribute("Description", "Teacher remove a student but the ClassRoom doesn\'t existing (null) Then system do" +
            "esn\'t remove the student from the course")]
        [Xunit.TraitAttribute("Category", "mock")]
        public virtual void TeacherRemoveAStudentButTheClassRoomDoesnTExistingNullThenSystemDoesnTRemoveTheStudentFromTheCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Teacher remove a student but the ClassRoom doesn\'t existing (null) Then system do" +
                    "esn\'t remove the student from the course", new string[] {
                        "mock"});
#line 229
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 230
    testRunner.Given("Today is \'2/8/2016 00:00 am\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 231
    testRunner.When("UserProfile \'teacher@mindsage.com\' remove StudentId \'student@mindsage.com\' from C" +
                    "lassRoom \'NULL\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 232
    testRunner.Then("System doesn\'t upsert UserProfile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 233
 testRunner.And("System doesn\'t upsert UserActivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Teacher_Remove_Student")]
        [Xunit.TraitAttribute("Description", "Incorrect user (unknow) remove a student Then system doesn\'t remove the student f" +
            "rom the course")]
        [Xunit.TraitAttribute("Category", "mock")]
        public virtual void IncorrectUserUnknowRemoveAStudentThenSystemDoesnTRemoveTheStudentFromTheCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Incorrect user (unknow) remove a student Then system doesn\'t remove the student f" +
                    "rom the course", new string[] {
                        "mock"});
#line 236
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 237
    testRunner.Given("Today is \'2/8/2016 00:00 am\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 238
    testRunner.When("UserProfile \'unknow@mindsage.com\' remove StudentId \'student@mindsage.com\' from Cl" +
                    "assRoom \'ClassRoom01\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 239
    testRunner.Then("System doesn\'t upsert UserProfile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 240
 testRunner.And("System doesn\'t upsert UserActivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Teacher_Remove_Student")]
        [Xunit.TraitAttribute("Description", "Incorrect user (empty) remove a student Then system doesn\'t remove the student fr" +
            "om the course")]
        [Xunit.TraitAttribute("Category", "mock")]
        public virtual void IncorrectUserEmptyRemoveAStudentThenSystemDoesnTRemoveTheStudentFromTheCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Incorrect user (empty) remove a student Then system doesn\'t remove the student fr" +
                    "om the course", new string[] {
                        "mock"});
#line 243
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 244
    testRunner.Given("Today is \'2/8/2016 00:00 am\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 245
    testRunner.When("UserProfile \'\' remove StudentId \'student@mindsage.com\' from ClassRoom \'ClassRoom0" +
                    "1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 246
    testRunner.Then("System doesn\'t upsert UserProfile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 247
 testRunner.And("System doesn\'t upsert UserActivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Teacher_Remove_Student")]
        [Xunit.TraitAttribute("Description", "Incorrect user (null) remove a student Then system doesn\'t remove the student fro" +
            "m the course")]
        [Xunit.TraitAttribute("Category", "mock")]
        public virtual void IncorrectUserNullRemoveAStudentThenSystemDoesnTRemoveTheStudentFromTheCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Incorrect user (null) remove a student Then system doesn\'t remove the student fro" +
                    "m the course", new string[] {
                        "mock"});
#line 250
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 251
    testRunner.Given("Today is \'2/8/2016 00:00 am\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 252
    testRunner.When("UserProfile \'NULL\' remove StudentId \'student@mindsage.com\' from ClassRoom \'ClassR" +
                    "oom01\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 253
    testRunner.Then("System doesn\'t upsert UserProfile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 254
 testRunner.And("System doesn\'t upsert UserActivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Teacher_Remove_Student")]
        [Xunit.TraitAttribute("Description", "Incorrect user (Role = student) remove a student Then system doesn\'t remove the s" +
            "tudent from the course")]
        [Xunit.TraitAttribute("Category", "mock")]
        public virtual void IncorrectUserRoleStudentRemoveAStudentThenSystemDoesnTRemoveTheStudentFromTheCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Incorrect user (Role = student) remove a student Then system doesn\'t remove the s" +
                    "tudent from the course", new string[] {
                        "mock"});
#line 257
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 258
    testRunner.Given("Today is \'2/8/2016 00:00 am\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 259
    testRunner.When("UserProfile \'student@mindsage.com\' remove StudentId \'student@mindsage.com\' from C" +
                    "lassRoom \'ClassRoom01\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 260
    testRunner.Then("System doesn\'t upsert UserProfile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 261
 testRunner.And("System doesn\'t upsert UserActivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Teacher_Remove_Student")]
        [Xunit.TraitAttribute("Description", "Incorrect user (Subscription was deleted) remove a student Then system doesn\'t re" +
            "move the student from the course")]
        [Xunit.TraitAttribute("Category", "mock")]
        public virtual void IncorrectUserSubscriptionWasDeletedRemoveAStudentThenSystemDoesnTRemoveTheStudentFromTheCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Incorrect user (Subscription was deleted) remove a student Then system doesn\'t re" +
                    "move the student from the course", new string[] {
                        "mock"});
#line 264
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 265
    testRunner.Given("Today is \'2/8/2016 00:00 am\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 266
    testRunner.When("UserProfile \'teacherWithDeletedSubscription@mindsage.com\' remove StudentId \'stude" +
                    "nt@mindsage.com\' from ClassRoom \'ClassRoom01\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 267
    testRunner.Then("System doesn\'t upsert UserProfile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 268
 testRunner.And("System doesn\'t upsert UserActivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Teacher_Remove_Student")]
        [Xunit.TraitAttribute("Description", "Teacher try to remove himself from the class room Then system doesn\'t remove the " +
            "student from the course")]
        [Xunit.TraitAttribute("Category", "mock")]
        public virtual void TeacherTryToRemoveHimselfFromTheClassRoomThenSystemDoesnTRemoveTheStudentFromTheCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Teacher try to remove himself from the class room Then system doesn\'t remove the " +
                    "student from the course", new string[] {
                        "mock"});
#line 271
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 272
    testRunner.Given("Today is \'2/8/2016 00:00 am\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 273
    testRunner.When("UserProfile \'teacher@mindsage.com\' remove StudentId \'teacher@mindsage.com\' from C" +
                    "lassRoom \'ClassRoom01\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 274
    testRunner.Then("System doesn\'t upsert UserProfile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 275
 testRunner.And("System doesn\'t upsert UserActivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Teacher_Remove_Student")]
        [Xunit.TraitAttribute("Description", "Teacher remove a student but the student\'s subscription was deleted Then system d" +
            "oesn\'t remove the student from the course")]
        [Xunit.TraitAttribute("Category", "mock")]
        public virtual void TeacherRemoveAStudentButTheStudentSSubscriptionWasDeletedThenSystemDoesnTRemoveTheStudentFromTheCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Teacher remove a student but the student\'s subscription was deleted Then system d" +
                    "oesn\'t remove the student from the course", new string[] {
                        "mock"});
#line 278
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 279
    testRunner.Given("Today is \'2/8/2016 00:00 am\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 280
 testRunner.And("System have UserProfile collection with JSON format are", @"[
{
""id"": ""teacher@mindsage.com"",
""Name"": ""teacher"",
""ImageProfileUrl"": ""teacher.jpg"",
""Subscriptions"":
[
{
	""id"": ""Subscription01"",
	""Role"": ""Teacher"",
	""ClassRoomId"": ""ClassRoom01"",
	""ClassCalendarId"": ""ClassCalendar01"",
},
]
},
{
""id"": ""student@mindsage.com"",
""Name"": ""student"",
""ImageProfileUrl"": ""student.jpg"",
""Subscriptions"":
[
{
	""id"": ""Subscription02"",
	""Role"": ""Student"",
	""ClassRoomId"": ""ClassRoom01"",
	""ClassCalendarId"": ""ClassCalendar01"",
	""DeletedDate"": ""1/1/2016""
},
]
}
]", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 314
    testRunner.When("UserProfile \'teacher@mindsage.com\' remove StudentId \'teacher@mindsage.com\' from C" +
                    "lassRoom \'ClassRoom01\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 315
    testRunner.Then("System doesn\'t upsert UserProfile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 316
 testRunner.And("System doesn\'t upsert UserActivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Teacher_Remove_Student")]
        [Xunit.TraitAttribute("Description", "Teacher remove a student but the student doesn\'t existing Then system doesn\'t rem" +
            "ove the student from the course")]
        [Xunit.TraitAttribute("Category", "mock")]
        public virtual void TeacherRemoveAStudentButTheStudentDoesnTExistingThenSystemDoesnTRemoveTheStudentFromTheCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Teacher remove a student but the student doesn\'t existing Then system doesn\'t rem" +
                    "ove the student from the course", new string[] {
                        "mock"});
#line 319
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 320
    testRunner.Given("Today is \'2/8/2016 00:00 am\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 321
 testRunner.And("System have UserProfile collection with JSON format are", "[\r\n{\r\n\"id\": \"teacher@mindsage.com\",\r\n\"Name\": \"teacher\",\r\n\"ImageProfileUrl\": \"teac" +
                    "her.jpg\",\r\n\"Subscriptions\":\r\n[\r\n{\r\n\t\"id\": \"Subscription01\",\r\n\t\"Role\": \"Teacher\"," +
                    "\r\n\t\"ClassRoomId\": \"ClassRoom01\",\r\n\t\"ClassCalendarId\": \"ClassCalendar01\",\r\n},\r\n]\r" +
                    "\n}\r\n]", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 340
    testRunner.When("UserProfile \'teacher@mindsage.com\' remove StudentId \'teacher@mindsage.com\' from C" +
                    "lassRoom \'ClassRoom01\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 341
    testRunner.Then("System doesn\'t upsert UserProfile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 342
 testRunner.And("System doesn\'t upsert UserActivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                Teacher_Remove_StudentFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                Teacher_Remove_StudentFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion