::Build All
call "%vs140comntools%vsvars32.bat"

::V5BACKNEW
msbuild.exe C:\Arg\SOA\V5New\Main\V5BackNew.sln /t:rebuild
robocopy C:\Arg\SOA\V5New\Main\V5NewProduccionSite\bin C:\Arg\References\V5New V5NewProduccion.Contracts.dll V5NewProduccion.Logic.dll V5NewProduccionSite.dll V5NewProduccion.HubServicesClientFactory.dll 
timeout /t 3
::SMARTIXHUB
msbuild.exe C:\Arg\SOA\Hub\Main\SmartixHub.sln /t:rebuild
robocopy C:\Arg\SOA\Hub\Main\SmartixHub\bin C:\Arg\References\Hub SmartixHub.ConnectorBase.dll SmartixHub.Contracts.dll SmartixHub.Persistence.dll SmartixHub.Services.dll
timeout /t 3
::SMARTIXV5ORCHESTRATION
msbuild.exe C:\Arg\SOA\SmartixV5Orchestration\Main\SmartixV5Orchestration.sln /t:rebuild
robocopy C:\Arg\SOA\SmartixV5Orchestration\Main\SmartixV5Orchestration\bin C:\Arg\References\Logic Smartix.Contracts.dll Smartix.V5Activities.dll Smartix.Services.dll
timeout /t 3
::CONECTORBASE
msbuild.exe C:\Arg\SOA\Conectores\Base\Main\Base.sln /t:rebuild
robocopy C:\Arg\SOA\Conectores\Base\Main\Base\bin C:\Arg\References\Conectores Smartix.Base.dll
timeout /t 3

::VENTAS
msbuild.exe C:\Arg\Front\Ventas\Main\VentasArg.sln /t:rebuild
::robocopy C:\Arg\Front\Ventas\Main\Smartix\bin C:\Arg\References\Logic Smartix.Contracts.dll Smartix.V5Activities.dll Smartix.Services.dll
timeout /t 3
::SMARTIX BACKEND
msbuild.exe C:\Arg\Backend\BackEnd\Main\SmartixBack.sln /t:rebuild
REM robocopy C:\Arg\SOA\Hub\Main\SmartixHub\bin C:\Arg\References\Hub SmartixHub.ConnectorBase.dll SmartixHub.Contracts.dll SmartixHub.Persistence.dll SmartixHub.Services.dll
REM timeout /t 5
