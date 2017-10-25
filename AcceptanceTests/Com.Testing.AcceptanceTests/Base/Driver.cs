using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;

namespace AcceptanceTests.Com.Testing.AcceptanceTests.Base
{
    public static class Driver
    {
        private static WebDriverWait browserWait;
        private static IWebDriver browser;

        public static IWebDriver Browser
        {
            get
            {
                if (browser == null)
                {
                    throw new NullReferenceException("The WebDriver browser instance was not initialized.You should first call the method Start.");
                }
                return browser;
            }
            private set
            {
                browser = value;
            }
        }
        public static WebDriverWait BrowserWait
        {
            get
            {
                if (browserWait == null || browser == null)
                {
                    throw new NullReferenceException("The WebDriver browser wait instance was not initialized.You should first call the method Start.");
                }
                return browserWait;
            }
            private set
            {
                browserWait = value;
            }
        }

        public static IWebDriver StartBrowser(BrowserTypes browserType = BrowserTypes.InternetExplorer, int defaultTimeOut = 30)
        {
            switch (browserType)
            {
              
                case BrowserTypes.InternetExplorer:
                    string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    string ieDriverLocation = Path.Combine(executableLocation, @"..\\..\\Com.Testing.AcceptanceTests\\Drivers\\IE11_Win7");
                    var service = InternetExplorerDriverService.CreateDefaultService(ieDriverLocation);
                    var options = new InternetExplorerOptions
                    {
                        IgnoreZoomLevel = true
                    };
                    Driver.Browser = new InternetExplorerDriver(service, options);
                    break;
                case BrowserTypes.Chrome:
                    string driverLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\Com.Testing.AcceptanceTests\\Drivers\\Chrome_Win7");
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("no-sandbox");
                    Browser = new ChromeDriver(driverLocation, chromeOptions, TimeSpan.FromMinutes(3));
                    break;

            }
            BrowserWait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(defaultTimeOut));
            Driver.Browser.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            Browser.Manage().Window.Maximize();
            return Driver.browser;
        }
        public static void StopBrowser()
        {
            Browser.Quit();
            Browser = null;
            BrowserWait = null;
        }


    }
}
