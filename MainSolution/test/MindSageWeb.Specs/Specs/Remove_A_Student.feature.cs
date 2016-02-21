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
    public partial class Remove_A_StudentFeature : Xunit.IClassFixture<Remove_A_StudentFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Remove_A_Student.feature"
#line hidden
        
        public Remove_A_StudentFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Remove_A_Student", "In order to avoid silly mistakes\r\nAs a math idiot\r\nI want to be told the sum of t" +
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
 testRunner.And("System have UserProfile collection with JSON format are", @"[
{
""id"": ""sakul@mindsage.com"",
""Name"": ""Sakul"",
""ImageProfileUrl"": ""sakul.jpg"",
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
""id"": ""earn@mindsage.com"",
""Name"": ""Earn"",
""ImageProfileUrl"": ""earn.jpg"",
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
]", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        public virtual void SetFixture(Remove_A_StudentFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Remove_A_Student")]
        [Xunit.TraitAttribute("Description", "Teacher remove a student Then system remove the student from class room")]
        public virtual void TeacherRemoveAStudentThenSystemRemoveTheStudentFromClassRoom()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Teacher remove a student Then system remove the student from class room", new string[] {
                        "mock"});
#line 43
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 44
    testRunner.Given("Today is \'2/8/2016 00:00 am\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
    testRunner.When("UserProfile \'sakul@mindsage.com\' remove student \'earn@mindsage.com\' from class ro" +
                    "om \'ClassRoom01\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 46
    testRunner.Then("System upsert UserProfile with JSON format is", @"{
""id"": ""earn@mindsage.com"",
""Name"": ""Earn"",
""ImageProfileUrl"": ""earn.jpg"",
""Subscriptions"":
[
{
""id"": ""Subscription02"",
""Role"": ""Student"",
""ClassRoomId"": ""ClassRoom01"",
""ClassCalendarId"": ""ClassCalendar01"",
""DeletedDate"": ""2/8/2016 00:00 am""
},
]
}", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                Remove_A_StudentFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                Remove_A_StudentFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
