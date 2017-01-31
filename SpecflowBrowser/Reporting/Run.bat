echo "Execute test from Nunit.Console"
..\..\packages\NUnit.ConsoleRunner.3.6.0\tools\nunit3-console.exe --labels=On --output=TestResult.txt --result=TestResult.xml;format=nunit2 ..\bin\Debug\SpecFlowNUnitDemo.dll

IF NOT EXIST TestResult.txt GOTO FAIL
EXIT 
:FAIL
echo ##teamcity[buildStatus status='FAILURE']
exit /b
