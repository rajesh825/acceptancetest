using AcceptanceTests.Com.Testing.AcceptanceTests.PageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Com.Testing.AcceptanceTests.StepDefinitions
{
    [Binding]
    class WeatherForecastStepDefinitions
    {

        [Given(@"I have navigated to test site")]
        public void GivenIHaveNavigatedToTestSite()
        {
            WeatherForeCastPage forecastPage = new WeatherForeCastPage();
            forecastPage.isAt();
            ScenarioContext.Current["forecastPage"] = forecastPage;
        }

        [When(@"I have entered Edinburgh name")]
        public void WhenIHaveEnteredEdinburghName()
        {
            WeatherForeCastPage forecastPage = (WeatherForeCastPage)ScenarioContext.Current["forecastPage"];
            forecastPage.enterCity("Edinburgh");
            
        }

        [Then(@"I should see (.*) day weather forecast")]
        public void ThenIShouldSeeDayWeatherForecast(int p0)
        {
            WeatherForeCastPage forecastPage = (WeatherForeCastPage)ScenarioContext.Current["forecastPage"];
            forecastPage.is5DayForeCastDisplayed();
        }

        [When(@"I Click on a Day ""(.*)""")]
        public void WhenIClickOnADay(string day)
        {
            WeatherForeCastPage forecastPage = (WeatherForeCastPage)ScenarioContext.Current["forecastPage"];
            forecastPage.ClickOnDay(day);
            //ScenarioContext.Current["hours"] = hours;
         }


        [Then(@"I should see (.*) hourly forecast for same ""(.*)""")]
        public void ThenIShouldSeeHourlyForecastForSame(int p0, string day)
        {
            WeatherForeCastPage forecastPage = (WeatherForeCastPage)ScenarioContext.Current["forecastPage"];
            //List<string> hours = (List<string>)ScenarioContext.Current["hours"];
            List<string> hours = forecastPage.getAllHourlyForecasts(day);
            for ( int i=0; i< hours.Count -1  ; i++)
            {
                Assert.AreEqual((Convert.ToInt32(hours[i + 1])) - (Convert.ToInt32(hours[i])), 0300);
            }

        }



        [Then(@"I should not see (.*) hourly forecast for same ""(.*)""")]
        public void ThenIShouldNotSeeHourlyForecastForSame(int p0, string day)
        {
            WeatherForeCastPage forecastPage = (WeatherForeCastPage)ScenarioContext.Current["forecastPage"];
            forecastPage.isHourlyForecastDisplayed(day);
        }



    }
}
