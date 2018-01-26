::Deploy Parcial
@echo off
for /f "tokens=2 delims==" %%a in ('wmic OS Get localdatetime /value') do set "dt=%%a"
set "YYYY=%dt:~0,4%" & set "MM=%dt:~4,2%" & set "DD=%dt:~6,2%"
set "datestamp=%YYYY%%MM%%DD%"
set "rootpath=C:\RootSitesARGDesa"

robocopy C:\Arg\Backend\BackEnd\Main\SmartixBack\bin %rootpath%\FRTSXBK\SmartixBack\bin *.dll *.pdb /S /MAXAGE:%datestamp%
robocopy C:\Arg\SOA\Hub\Main\SmartixHub\bin %rootpath%\SOASX\SmartixHub\bin *.dll *.pdb /S /MAXAGE:%datestamp%
robocopy C:\Arg\SOA\SmartixV5Orchestration\Main\SmartixV5Orchestration\bin %rootpath%\SOASX\SmartixV5Orchestration\bin *.dll *.pdb /S /MAXAGE:%datestamp%
robocopy C:\Arg\SOA\V5New\Main\V5NewProduccionSite\bin %rootpath%\SOASX\V5BackNew\bin *.dll *.pdb /S /MAXAGE:%datestamp%
robocopy C:\Arg\Front\Ventas\Main\Smartix\bin %rootpath%\FRTSXVTA\Ventas\bin *.dll *.pdb /S /MAXAGE:%datestamp%

::CONECTOR Boston
REM robocopy C:\Arg\SOA\Conectores\Boston\Main\SmartixHub.ConectorBoston\bin\Debug %rootpath%\SOASX\SmartixHub\bin SmartixHub.ConectorBoston.dll SmartixHub.ConectorBoston.pdb /S /MAXAGE:%datestamp%

::CONECTOR BOSTON
robocopy C:\Arg\SOA\Conectores\Boston\Main\Boston\bin\Debug %rootpath%\SOASX\SmartixHub\bin SmartixHub.ConectorBoston.dll SmartixHub.ConectorBoston.pdb /S /MAXAGE:%datestamp%

	
cd c:\RootSitesARGDesa\
start cmd /k ""C:\Program Files (x86)\IIS Express\iisexpress.exe" /config:".\AppHost-RootSitesARGDesa.config"  /site:"SOASX""
start cmd /k ""C:\Program Files (x86)\IIS Express\iisexpress.exe" /config:".\AppHost-RootSitesARGDesa.config"  /site:"FRTSXVTA""
start cmd /k ""C:\Program Files (x86)\IIS Express\iisexpress.exe" /config:".\AppHost-RootSitesARGDesa.config"  /site:"FRTSXBK""

REM start cmd /k ""C:\Program Files (x86)\IIS Express\iisexpress.exe" /config:".\AppHost-RootSitesARGDesa.config"  /site:"FRTHITN""
REM start cmd /k ""C:\Program Files (x86)\IIS Express\iisexpress.exe" /config:".\AppHost-RootSitesARGDesa.config"  /site:"INBKV5""

start http://localhost:11080/Ventas/Login
start http://localhost:10080/BackEnd/

PowerShell -ExecutionPolicy Bypass -File .\SmartixIISProcess.ps1

