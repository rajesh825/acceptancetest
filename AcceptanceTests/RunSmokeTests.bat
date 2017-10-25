@echo Starting of the file on %date% at %time%

@echo Developers: Rajesh Yarlagadda & echo.

("..\packages\NUnit.ConsoleRunner.3.6.1\tools\nunit3-console.exe" /work:".\Reporting\reportUnitReport" --where cat='smoke' --result="TestResults.xml" ".\bin\Debug\AcceptanceTests.dll")

@echo Running report

..\packages\\ReportUnit.1.2.1\tools\reportunit ".\Reporting\reportUnitReport" ".\Reporting\reportUnitReport\Result\%mydate%_%mytime%"


start "" ".\Reporting\reportUnitReport\Result\_\index.html"

PAUSE

