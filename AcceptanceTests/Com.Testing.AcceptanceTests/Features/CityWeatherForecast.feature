Feature: CityWeatherForecast
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@smoke
Scenario Outline: Get 5 day forecast
	Given I have navigated to test site
	When I have entered <city> name
	Then I should see 5 day weather forecast

Examples:
| city      |
| Edinburgh | 

@Full
Scenario Outline: Get hourly forecast
	Given I have navigated to test site
	When I have entered <city> name
	And I Click on a Day "<day>"  
	Then I should see 3 hourly forecast for same "<day>"
	When I Click on a Day "<day>" 
	Then I should not see 3 hourly forecast for same "<day>"

Examples:
| city      | day   |
| Edinburgh | One   |
| Edinburgh | Five  |