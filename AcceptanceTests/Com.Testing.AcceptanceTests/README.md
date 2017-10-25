 UI Test Automation
=============================================
This repository contains UI Automated tests for test website 


Installation
============

#### Rest Sharp, NUnit, Selenium Webdriver 

The *UI Automation Tests* project depends on RestSharp, JSON.NET, NUnit which can be installed using the *NuGet* package manager.
For more information on how to achieve this, see ['Managing NuGet packages using the dialog'](http://docs.nuget.org/docs/start-here/managing-nuget-packages-using-the-dialog).

Test Configuration
==================
a. app settings designed to run tests under different test environemnts eg: DEV, TEST
	<appSettings>
		<add key="environment" value="TEST" />
	</appSettings>


Usage
=====
User can run the tests either from Command Line or using Visual Studio
To Run smoke Tests run - "RunUITestSmoke.bat"  
To Run Full API Tests  - "RunUITest.bat"  
