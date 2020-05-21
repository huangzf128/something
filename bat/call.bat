
@echo off

del storedlist.txt

for /f "tokens=* delims=" %%i  in ('dir /b /a-d ^| findstr /i "PKG_.*\.sql$"') do (
    echo @%%i>> storedlist.txt
)

chcp 65001
set NLS_LANG=.AL32UTF8
sqlplus KAMPO02/KAMPO@192.168.246.212/orcl @storedlist.txt

pause
