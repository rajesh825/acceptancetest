using AcceptanceTests.Com.Testing.AcceptanceTests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcceptanceTests.Com.Testing.AcceptanceTests.PageObjects
{
    public class BasePage
    {
        public readonly IWebDriver browser;
        public BasePage()
        {
            this.browser = Driver.Browser;
            browser.Navigate().GoToUrl("http://weather-acceptance.herokuapp.com/");
        }
    }
}
