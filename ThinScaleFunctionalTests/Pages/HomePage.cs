using System;
using OpenQA.Selenium.Support.UI;
using ThinScaleFunctionalTests.Factories;
using ThinScaleFunctionalTests.Fixtures;
using ThinScaleFunctionalTests.Steps;

namespace ThinScaleFunctionalTests.Pages
{
    public class HomePage : BaseSteps
    {
        private readonly EnvironmentFixture _environmentFixture;
        private readonly WebDriverContext _webDriverContext;
        private readonly WebDriverWait _wait;

        public HomePage(WebDriverContext webDriverContext, EnvironmentFixture environmentFixture)
        {
            _webDriverContext = webDriverContext;
            _environmentFixture = environmentFixture;
            _wait = new WebDriverWait(webDriverContext.Driver, TimeSpan.FromSeconds(10));
        }

        #region Locators

        #endregion
        
        #region PageElements

        #endregion

        public HomePage GoToChallengingDomPage()
        {
            _webDriverContext.Driver.Navigate().GoToUrl(_environmentFixture.Environment.Url);
            return this;
        }
    }
}