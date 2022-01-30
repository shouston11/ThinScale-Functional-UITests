using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ThinScaleFunctionalTests.Factories;
using ThinScaleFunctionalTests.Fixtures;
using ThinScaleFunctionalTests.SharedLibrary.Extensions;
using SeleniumExtras.WaitHelpers;

namespace ThinScaleFunctionalTests.SharedLibrary.Services
{
    public class HeaderToolbarHelper
    {
        private readonly EnvironmentFixture _environmentFixture;
        private readonly WebDriverContext _webDriverContext;
        private WebDriverWait _wait;

        public HeaderToolbarHelper(WebDriverContext webDriverContext, EnvironmentFixture environmentFixture)
        {
            _webDriverContext = webDriverContext;
            var environmentName = System.Environment.GetEnvironmentVariable(Constants.EnvironmentName);
            _environmentFixture = environmentFixture;
            _wait = new WebDriverWait(webDriverContext.Driver, TimeSpan.FromSeconds(10));
        }

        #region Locators
        private readonly By _challengingDomHeader = By.CssSelector("#content > div > h3");
        private readonly By _blueBtn = By.XPath(("//div[@class='large-2 columns']/a[@class='button']"));
        private readonly By _redBtn = By.XPath("//div[@class='large-2 columns']/a[@class='button alert']");
        private readonly By _greenBtn = By.XPath("//div[@class='large-2 columns']/a[@class='button success']");
        private readonly By _editBtn = By.XPath("//div[@class='large-10 columns']/table/tbody/tr[1]/td[7]/a[1]");
        private readonly By _deleteBtn = By.XPath("//div[@class='large-10 columns']/table/tbody/tr[1]/td[7]/a[2]");
        #endregion


        #region PageElements
        private IWebElement PageHeader => _webDriverContext.Driver.FindElement(_challengingDomHeader);
        private IWebElement EditButton => _webDriverContext.Driver.FindElement(_editBtn);
        private IWebElement DeleteButton => _webDriverContext.Driver.FindElement(_deleteBtn);
        private IWebElement BlueButton => _webDriverContext.Driver.FindElement(_blueBtn);
        private IWebElement RedButton => _webDriverContext.Driver.FindElement(_redBtn);
        private IWebElement GreenButton => _webDriverContext.Driver.FindElement(_greenBtn);
        private IWebElement Header => _webDriverContext.Driver.FindElement(_challengingDomHeader);
        #endregion

        public void ClickBlueButton()
        {
            ExpectedConditions.ElementIsVisible(_blueBtn);
            var attributeIdBefore = BlueButton.GetAttribute("id");
            BlueButton.Click();
            var attributeIdAfterClick = BlueButton.GetAttribute("id");
            Assert.True(attributeIdBefore != null && attributeIdBefore != attributeIdAfterClick);
        }

        public void ClickRedAlertButton()
        {
            ExpectedConditions.ElementIsVisible(_redBtn);
            var attributeIdBefore = RedButton.GetAttribute("id");
            RedButton.Click();
            var attributeIdAfterClick = RedButton.GetAttribute("id");
            Assert.True(attributeIdBefore != null && attributeIdBefore != attributeIdAfterClick);
        }

        public void ClickGreenButton()
        {
            ExpectedConditions.ElementIsVisible(_greenBtn);
            var attributeIdBefore = GreenButton.GetAttribute("id");
            GreenButton.Click();
            var attributeIdAfterClick = GreenButton.GetAttribute("id");
            Assert.True(attributeIdBefore != null && attributeIdBefore != attributeIdAfterClick);
        }

        public void ChallengingDomHeaderIsDisplayed(string header)
        {
            bool ele = Header.IsElementDisplayed();
            Assert.IsTrue(ele);
            Assert.True(PageHeader.Text == header);
        }

        public void CheckTableHeaderVisibility(string tableHeader)
        {
            Assert.IsTrue(_webDriverContext.Driver.PageSource.Contains(tableHeader));
        }

        public void CheckUrlContains(string item)
        {
            Assert.True(_webDriverContext.Driver.Url.Contains(item));
        }

        public void ClickEditButton()
        {
            ExpectedConditions.ElementIsVisible(_editBtn);
            EditButton.Click();
        }

        public void ClickDeleteButton()
        {
            ExpectedConditions.ElementIsVisible(_deleteBtn);
            DeleteButton.Click();
        }

        public void ValidateOnCorrectPage(string title)
        {
            try
            {
                var wait = new WebDriverWait(_webDriverContext.Driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.TitleIs(title));

            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception("Page Title not found!!!");
            }
        }
    }
}