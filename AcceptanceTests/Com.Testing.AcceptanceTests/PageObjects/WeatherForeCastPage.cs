using AcceptanceTests.Com.Testing.AcceptanceTests.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AcceptanceTests.Com.Testing.AcceptanceTests.PageObjects
{
    public partial class WeatherForeCastPage : BasePage
    {

        private readonly IWebDriver driver;
        private readonly string url = @"http://weather-acceptance.herokuapp.com/";

        public WeatherForeCastPage() : base()
        {
             
        }

    
        public void enterCity(string city)
        {
           CityInputBox.Clear();
           CityInputBox.SendKeys(city + Keys.Enter);
           browser.WaitUntilElementIsPresent(CityInputBoxBy);
        }

        public void Navigate()  => browser.Navigate().GoToUrl(this.url);

        public bool? isAt()
        {
            browser.WaitUntilElementIsPresent(CityInputBoxBy);
            Assert.IsTrue(CityInputBox.GetAttribute("value").Contains("Glasgow"));
            return browser.Title.Contains("5 Weather Forecast");
        }

        public void is5DayForeCastDisplayed()
        {
            browser.WaitUntilElementIsPresent(DayOneBy);
            Assert.IsTrue(DayOne.Displayed);
            Assert.IsTrue(DayTwo.Displayed);
            Assert.IsTrue(DayThree.Displayed);
            Assert.IsTrue(DayFour.Displayed);
            Assert.IsTrue(DayFive.Displayed);
            Assert.AreEqual(DateTime.Now.ToString("ddd"), DayOne.Text, "Day One Date Text does not match");
            Assert.AreEqual(DateTime.Now.Day, Convert.ToInt32(DayOneDate.Text), "Dates does not match");
            Assert.AreEqual(DateTime.Now.ToString("ddd"), DayFive.Text, "Day Five date text does not match");
            Assert.AreEqual(DateTime.Now.AddDays(4).Day, Convert.ToInt32(DayFiveDate.Text));
        }

        
        internal void ClickOnDay(string day)
        {
            browser.WaitUntilElementIsPresent(DayOneBy);
        
            switch (day)
            {
                case "One":
                    DayOne.Click();
                    break;
                case "Two":
                    DayTwo.Click();
                    break;
                case "Three":
                    DayThree.Click();
                    break;
                case "Four":
                    DayFour.Click();
                    break;
                case "Five":
                    DayFive.Click();
                    break;
            }

            Task.Delay(1200).Wait();
        }

        public void isHourlyForecastDisplayed(string day)
        {
            ReadOnlyCollection<IWebElement> hourlyForecastData = null;
            switch (day)
            {
                case "One":
                    hourlyForecastData = DayOneHourlyForecastData;
                    break;
            
                case "Five":
                    hourlyForecastData = DayFiveHourlyForecastData;
                    break;
            }

            List<string> hours = new List<string>();
            if (hourlyForecastData != null)
            {

                foreach (IWebElement hourdata in hourlyForecastData)
                {
                    Assert.IsFalse(hourdata.Displayed);

                }

               
            }
            

        }
    

        public List<string> getAllHourlyForecasts(string day)
        {
            ReadOnlyCollection<IWebElement> hourlyForecastData = null;
            switch (day)
            {
                case "One":
                    hourlyForecastData = DayOneHourlyForecastData;
                    break;
                //case "Two":
                //    hourlyForecastData = DayTwoHourlyForecastData;
                //    break;
                //case "Three":
                //    hourlyForecastData = DayOneHourlyForecastData;
                //    break;
                //case "Four":
                //    hourlyForecastData = DayOneHourlyForecastData;
                //    break;
                case "Five":
                    hourlyForecastData = DayFiveHourlyForecastData;
                    break;
            }

            List<string> hours = new List<string>();
            if(hourlyForecastData!= null )
            {
                 

                 foreach(IWebElement hourdata in hourlyForecastData)
                {
                    hours.Add(hourdata.Text);
                    
                }

                return hours;
            } else
            {
                return null;
            }

        }
    }
}
