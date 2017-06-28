@echo off
setlocal enabledelayedexpansion
set svnUrl=https://10.83.240.210/svn/sizpp_web/trunk/sizppWeb
set startDate=2017-03-17
set "preA=A       "
set "preM=M       "
set "preM1= M      "

set localJavaPath=D:\pleiades\workspace\sizppWeb
set localClassPath=D:\pleiades\workspace\sizppWeb\target
set outputPath=C:\Users\FULONG\Desktop\新しいフォルダー

rem ~~~~~~~~~~~~~~~~~~~~~~~
rem		get svn history
rem ~~~~~~~~~~~~~~~~~~~~~~
svn diff %svnUrl% --summarize -r {%startDate%}:HEAD > log.txt

rem ~~~~~~~~~~~~~~~~~~~~~~~
rem		java
rem ~~~~~~~~~~~~~~~~~~~~~~
for /f "tokens=*delims=" %%a in ('findstr /R "^[^D].*src.*[.java|.xml]$" log.txt') do (
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
 	echo f | xcopy /y !localClassPath!!realPath:src\main\java=classes! !outputPath!!realPath:src\main\java=classes!
)