// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace AudiMarket.Tests
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class MessageServiceTestsFeature : object, Xunit.IClassFixture<MessageServiceTestsFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "MessageServiceTests.feature"
#line hidden
        
        public MessageServiceTestsFeature(MessageServiceTestsFeature.FixtureData fixtureData, AudiMarket_Tests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "", "MessageServiceTests", "As a Developer\r\nI want to add new Message through API\r\nSo that I can be available" +
                    " for applications.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 6
    #line hidden
#line 7
        testRunner.Given("the Endpoint https://localhost:5001/api/v1/messages is available", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Firstname",
                        "Lastname",
                        "Dni",
                        "Entrydate",
                        "User",
                        "Password"});
            table5.AddRow(new string[] {
                        "1",
                        "Cesar",
                        "Torres",
                        "72243434",
                        "0001-01-01T00:00:00",
                        "cesarxa14",
                        "1234"});
#line 8
        testRunner.And("A MusicProducer for Message is already stored", ((string)(null)), table5, "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Firstname",
                        "Lastname",
                        "Dni",
                        "Entrydate",
                        "User",
                        "Password"});
            table6.AddRow(new string[] {
                        "1",
                        "Jorge",
                        "Navarro",
                        "74582556",
                        "0001-01-01T00:00:00",
                        "jorgevill",
                        "asdf"});
#line 11
        testRunner.And("A VideoProducer for Message is already stored", ((string)(null)), table6, "And ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                MessageServiceTestsFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                MessageServiceTestsFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
