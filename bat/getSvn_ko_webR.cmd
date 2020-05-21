@echo off
setlocal enabledelayedexpansion
set svnUrl=https://10.83.240.217/svn/kobutsu/Rest/src
rem set startDate=2020-02-10
set startDate=2020-05-15
set "preA=A       "
set "preM=M       "
set "preM1= M      "

set localJavaPath=D:\Develop\Tools\STS-3.9.11\workspace\sizppWebR\src
set localClassPath=D:\Develop\Tools\STS-3.9.11\workspace\sizppWebR\target
set outputPath=Rest

rem ~~~~~~~~~~~~~~~~~~~~~~~
rem		get svn history
rem ~~~~~~~~~~~~~~~~~~~~~~
svn diff %svnUrl% --summarize -r {%startDate%}:HEAD > weblog.txt

rem ~~~~~~~~~~~~~~~~~~~~~~~
rem		java
rem ~~~~~~~~~~~~~~~~~~~~~~
for /f "tokens=*delims=" %%a in ('findstr /R "^[^D].*src.*[.java|.xml]$" weblog.txt') do (
rem	echo %%a
	set filePath=%%a
	set realPath=!filePath:%preA%%svnUrl%=!
	if !realPath! == !filePath! (
		set realPath=!filePath:%preM%%svnUrl%=!
	)
	if !realPath! == !filePath! (
		set realPath=!filePath:%preM1%%svnUrl%=!
	)
	set realPath=!realPath:/=\!
	rem get java source file
 	echo f | xcopy /y !localJavaPath!!realPath! !outputPath!\src!realPath!
	rem get java class file
	set realPath=!realPath:.java=.class!	
 	rem echo f | xcopy /y !localClassPath!!realPath:src\main\java=classes! !outputPath!!realPath:src\main\java=classes!

	set realPath=!realPath:main\java=classes!	
	echo f | xcopy /y !localClassPath!!realPath! !outputPath!!realPath!
	echo f | xcopy /y !localClassPath!!realPath:.class=$*.class! !outputPath!!realPath:.class=$*.class!
)
