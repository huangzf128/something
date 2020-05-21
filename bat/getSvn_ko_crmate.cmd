@echo off
setlocal enabledelayedexpansion
set svnUrl=https://10.83.240.217/svn/kobutsu/sizpp_crmate
rem set startDate=2020-02-10
set startDate=2020-05-19
set "preA=A       "
set "preM=M       "
set "preM1= M      "

set localJavaPath=D:\Develop\Tools\STS-3.9.11\workspace\CRMate
set outputPath=CRMATE

rem ~~~~~~~~~~~~~~~~~~~~~~~
rem		get svn history
rem ~~~~~~~~~~~~~~~~~~~~~~
svn diff %svnUrl% --summarize -r {%startDate%}:HEAD > crmatelog.txt

rem ~~~~~~~~~~~~~~~~~~~~~~~
rem		java
rem ~~~~~~~~~~~~~~~~~~~~~~
for /f "tokens=*delims=" %%a in ('findstr /R "^[^D].*[.java|.xml|.js|.sql]$" crmatelog.txt') do (
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
 	echo f | xcopy /y !localJavaPath!!realPath! !outputPath!!realPath!
	rem get java class file
	set realPath=!realPath:.java=.class!	
 	rem echo f | xcopy /y !localClassPath!!realPath:src\main\java=classes! !outputPath!!realPath:src\main\java=classes!
	
)
