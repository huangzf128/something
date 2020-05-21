@echo off
setlocal enabledelayedexpansion
set svnUrl=https://192.168.246.150/svn/02_DAIWA_NEW/04_PG/Java/workspace_daiwaNew/HOTEL/src
set startDate=2019-10-01
set "preA=A       "
set "preM=M       "
set "preM1= M      "

set localJavaPath=D:\Projects\java_wk_old\HOTEL\src
set localClassPath=D:\Projects\java_wk_old\HOTEL\WebContent\WEB-INF\classes
set outputPath=新しいフォルダー

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
