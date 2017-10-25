using AcceptanceTests.Com.Testing.AcceptanceTests.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcceptanceTests.Com.Testing.AcceptanceTests.Extensions
{
    public static class WebElementExtensions
    {

        public static void ClearAndSendKeys(this IWebElement element, string keysToSend)
        {
            element.Clear();
            element.SendKeys(keysToSend);
        }

        /// <summary>
        /// Moves focus to the desired element
        /// </summary>
        /// <param name="element"></param>
        public static void MoveToElement(this IWebElement element)
        {
            var actions = new Actions(Driver.Browser);
            actions.MoveToElement(element).Perform();
        }


        /// <summary>
        /// Focuses on an element before clicking
        /// </summary>
        /// <param name="element"></param>
        public static void MoveAndClick(this IWebElement element)
        {
            MoveToElement(element);

            element.Click();
        }

        public static bool WaitUntilText(this IWebElement element, string expectedText, int timeOut = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(timeOut));
                return wait.Until(ExpectedConditions.TextToBePresentInElement(element, expectedText));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Waits for an element to be displayed and interacted with
        /// </summary>
        /// <param name="element"></param>
        /// <param name="objectName"></param>
        /// <param name="timeOut"></param>
        /// <returns>boolean</returns>
        public static bool WaitForElementToBeDisplayed(this IWebElement element, string objectName, int timeOut = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(timeOut));
                return wait.Until(ExpectedConditions.ElementToBeClickable(element)).Displayed;
            }
            catch
            {
                return false;
            }
        }

   
    }
}
