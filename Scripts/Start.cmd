cd c:\RootSitesARGDesa\
start cmd /k ""C:\Program Files (x86)\IIS Express\iisexpress.exe" /config:".\AppHost-RootSitesARGDesa.config"  /site:"SOASX""
start cmd /k ""C:\Program Files (x86)\IIS Express\iisexpress.exe" /config:".\AppHost-RootSitesARGDesa.config"  /site:"FRTSXVTA""
start cmd /k ""C:\Program Files (x86)\IIS Express\iisexpress.exe" /config:".\AppHost-RootSitesARGDesa.config"  /site:"FRTSXBK""

REM start cmd /k ""C:\Program Files (x86)\IIS Express\iisexpress.exe" /config:".\AppHost-RootSitesARGDesa.config"  /site:"FRTHITN""
REM start cmd /k ""C:\Program Files (x86)\IIS Express\iisexpress.exe" /config:".\AppHost-RootSitesARGDesa.config"  /site:"INBKV5""

PowerShell -ExecutionPolicy Bypass -File .\SmartixIISProcess.ps1