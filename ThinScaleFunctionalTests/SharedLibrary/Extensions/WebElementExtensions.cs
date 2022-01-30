using System;
using OpenQA.Selenium;

namespace ThinScaleFunctionalTests.SharedLibrary.Extensions
{
    public static class WebElementExtensions
    {
        public static bool IsElementDisplayed(this IWebElement element)
        {
            try
            {
                bool ele = element.Displayed;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
