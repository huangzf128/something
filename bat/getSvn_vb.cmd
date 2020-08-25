@echo off
setlocal enabledelayedexpansion
set svnUrl=https://192.168.246.150/svn/ramla/PG/Recipe
rem set startDate=2020-02-10
set startDate=2020-04-06
set "preA=A       "
set "preM=M       "
set "preM1= M      "

set localJavaPath=D:\Projects\vb\Recipe
set outputPath=Recipe

rem ~~~~~~~~~~~~~~~~~~~~~~~
rem		get svn history
rem ~~~~~~~~~~~~~~~~~~~~~~
svn diff %svnUrl% --summarize -r {%startDate%}:HEAD > ramlalog.txt

rem ~~~~~~~~~~~~~~~~~~~~~~~
rem		VB
rem ~~~~~~~~~~~~~~~~~~~~~~
for /f "tokens=*delims=" %%a in ('findstr /R "^[^D].*[.java|.xml|.resx|.vb]$" ramlalog.txt') do (
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
)
