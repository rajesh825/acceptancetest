using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace AcceptanceTests.Com.Testing.AcceptanceTests.PageObjects
{
    public partial class WeatherForeCastPage : BasePage
    {
       
        public By CityInputBoxBy => By.Id("city");
        public IWebElement CityInputBox => browser.FindElement(CityInputBoxBy);

        public By DayOneBy => By.CssSelector(("#root > div > div > div.summary > span > span.name[data-test='day-1']"));
        public IWebElement DayOne => browser.FindElement(DayOneBy);
        public IWebElement DayTwo => browser.FindElement(By.CssSelector(("#root > div > div > div.summary > span > span.name[data-test='day-2']")));
        public IWebElement DayThree => browser.FindElement(By.CssSelector(("#root > div > div > div.summary > span > span.name[data-test='day-3']")));
        public IWebElement DayFour => browser.FindElement(By.CssSelector(("#root > div > div > div.summary > span > span.name[data-test='day-4']")));
        public IWebElement DayFive => browser.FindElement(By.CssSelector(("#root > div > div > div.summary > span > span.name[data-test='day-5']")));

        public IWebElement DayOneDate => browser.FindElement(By.CssSelector("#root > div > div:nth-child(2) > div.summary > span:nth-child(1) > span.rmq-5ea3c959.date"));
        
        public IWebElement DayFiveDate => browser.FindElement(By.CssSelector("#root > div > div:nth-child(6) > div.summary > span:nth-child(1) > span.rmq-5ea3c959.date"));
        public By DayOneHourlyForecastDataContainerBy => By.CssSelector("#root > div > div:nth-child(2) > div.details");
        public ReadOnlyCollection<IWebElement> DayOneHourlyForecastData => browser.FindElement(DayOneHourlyForecastDataContainerBy).FindElements(By.CssSelector("span.hour"));
        public By DayFiveHourlyForecastContainerBy => By.CssSelector("#root > div > div:nth-child(6) > div.details");
        public ReadOnlyCollection<IWebElement> DayFiveHourlyForecastData => browser.FindElement(DayFiveHourlyForecastContainerBy).FindElements(By.CssSelector("span.hour"));


    }
       
}
