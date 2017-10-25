 # UI Test Automation
 
 This repository contains UI Automated tests for test website 


# Installation

#### Rest Sharp, NUnit, Selenium Webdriver 

This Project depends on  *NuGet* package manager to install Specflow, Selenium Webdriver, Rest Sharp, JSON.NET, NUnit 
For more information on how to achieve this, see ['Managing NuGet packages using the dialog'](http://docs.nuget.org/docs/start-here/managing-nuget-packages-using-the-dialog).

# Test Configuration

a. app settings designed to run tests under different test environemnts eg: DEV, TEST
	<appSettings>
		<add key="environment" value="TEST" />
	</appSettings>


# Usage

User can run the tests either from Command Line or using Visual Studio
To Run smoke Tests run - "RunSmokeTests.bat"  
To Run Full Tests       - "RunFullTests.bat"  
