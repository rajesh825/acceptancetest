using AcceptanceTests.Com.Testing.AcceptanceTests.Base;
using AcceptanceTests.Com.Testing.AcceptanceTests.Config;
using System;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Com.Testing.AcceptanceTests.Hooks
{
    [Binding]
    public class Hooks
    {

        [BeforeScenario]
        public static void InitializeDriverForEveryTest()
        {
            string browserToTest = AppConfigHandler.GetValue("browser");
            BrowserTypes browser = (BrowserTypes)Enum.Parse(typeof(BrowserTypes), browserToTest);
            Driver.StartBrowser(browser);

        }
        [AfterTestRun]
        public static void AfterTest()
        {

        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.StopBrowser();
        }

    }
}
