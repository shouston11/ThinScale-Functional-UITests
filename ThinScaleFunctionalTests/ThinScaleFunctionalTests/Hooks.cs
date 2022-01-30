using BoDi;
using ThinScaleFunctionalTests.Factories;
using TechTalk.SpecFlow;

namespace ThinScaleFunctionalTests
{
    [Binding]
    public sealed class Hooks
    {

            private static IObjectContainer _objectContainer;
            private static ScenarioContext _scenarioContext;
            private static WebDriverContext _webDriverContext;

            public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
            {
                _objectContainer = objectContainer;
                _scenarioContext = scenarioContext;
            }


            [BeforeScenario]
            public void BeforeScenario()
            {
                _objectContainer.RegisterInstanceAs<WebDriverContext>(_webDriverContext);
            }


            [BeforeTestRun]
            public static void RunBeforeAllTests()
            {
                _webDriverContext = new WebDriverContext();
            }


            [AfterScenario()]
            public static void AfterScenario()
            {
            }


            [AfterTestRun(Order = 0)]
            private static void KillProcess()
            {
                string taskKill = "taskkill.exe";
                string chrome = "/F /IM chrome.exe*";
                //string chromeDriver = "/F /IM chromedriver.exe*";
                //Process.Start(taskKill, chrome);
                //Process.Start(taskKill, chromeDriver);
            }  
    }

}
