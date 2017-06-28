@echo off
set /p pgid="プロジェクトIDを入力してください　: "

WMIC /node:"192.168.255.201" /user:administrator /password:amc4715116 /output:stdout process call create "cmd.exe /c isstopwu %pgid% & isstartwu %pgid% > c:\aaa\result.txt" 
pause