reg add HKLM\SOFTWARE\FujitsuGeneral\Saas /v ServerUrl /t REG_SZ /d "http://127.0.0.1:8080/SaaS"
reg add HKLM\SOFTWARE\FujitsuGeneral\Saas\DataCom /v TenantCode /t REG_SZ /d FB8F615F190E1925
reg add HKLM\SOFTWARE\FujitsuGeneral\Saas\DataCom /v UserCode /t REG_SZ /d D81B2E5BFD51706CBBF7ED545F548797
reg add HKLM\SOFTWARE\FujitsuGeneral\Saas\DataCom /v Password /t REG_SZ /d D81B2E5BFD51706CBBF7ED545F548797
reg add HKLM\SOFTWARE\FujitsuGeneral\Saas\DataCom /v TimeOut /t REG_SZ /d 100


mkdir C:\Interstage\J2EE\var\deployment\ijserver\SaaS\apps\SaaS.war\ClientToolUpdate\

echo off

echo ^<?xml version="1.0" encoding="utf-8"?^>^<Config^>^<version^>1.1.1^</version^>^</Config^> > "C:\Interstage\J2EE\var\deployment\ijserver\SaaS\apps\SaaS.war\ClientToolUpdate\Config.xml"


psuse