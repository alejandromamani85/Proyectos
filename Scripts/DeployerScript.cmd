::FULL DEPLOY
set "rootpath=C:\RootSitesARGDesa"

robocopy C:\DesarrolloSmartix\Deploys\Argentina\FRONTBACK\SmartixBack %rootpath%\FRTSXBK\SmartixBack /s /xf web.config
robocopy C:\DesarrolloSmartix\Deploys\Argentina\SOA\SmartixHub %rootpath%\SOASX\SmartixHub /s /xf web.config
robocopy C:\DesarrolloSmartix\Deploys\Argentina\SOA\SmartixV5Orchestration %rootpath%\SOASX\SmartixV5Orchestration /s /xf web.config
robocopy C:\DesarrolloSmartix\Deploys\Argentina\SOA\V5New %rootpath%\SOASX\V5BackNew /s /xf web.config
robocopy C:\DesarrolloSmartix\Deploys\Argentina\FRONT\Ventas %rootpath%\FRTSXVTA\Ventas /s /xf web.config
robocopy C:\DesarrolloSmartix\Deploys\Argentina\SOA\HubCore %rootpath%\SOASX\HubServices /s /xf web.config

