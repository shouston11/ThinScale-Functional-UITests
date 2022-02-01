using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using ThinScaleFunctionalTests.Steps;
using TechTalk.SpecFlow;

namespace ThinScaleFunctionalTests.Factories
{
    [Binding]
    public class WebDriverContext : BaseSteps
    {
        public IWebDriver Driver { get; set; }


        public WebDriverContext()
        {
            SwitchToBrowser();
        }

        #region WebDrivers


        private WebDriverContext Chrome()
        {

            var options = new ChromeOptions();
            // options.AddArgument("--incognito");
            options.AddArgument("--start-maximized");
            options.AddArgument("--lang=en");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-dev-shm-usage");
            //options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--enable-logging");
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var directoryPath = Path.GetDirectoryName(path);
            this.Driver = new ChromeDriver(directoryPath + "\\drivers", options, TimeSpan.FromSeconds(60));
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Window.Maximize();
            return this;
        }
        #endregion

        private WebDriverContext SwitchToBrowser()
        {
            var browser = Environment.GetEnvironmentVariable("Browser") ?? EnvironmentFixture.Environment.Browser;

            switch (browser.ToLower())
            {
                case "chrome":
                    Console.WriteLine("starting browser session in {0}", browser);
                    return Chrome();
                default:
                    throw new Exception(
                        $"{browser} browser is not supported in this test framework");
            }
        }

    }
}
