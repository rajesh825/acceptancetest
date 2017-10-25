using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace AcceptanceTests.Com.Testing.AcceptanceTests.Extensions
{
    public static class WebDriverExtensions
    {

        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static void WaitUntilElementIsPresent(this IWebDriver driver, By by, int timeoutInSeconds = 15)
        {
           new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(ExpectedConditions.ElementExists((by)));

        }

        public static bool isElementClickable(this IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(d => d.isElementClickable(by));

            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}
