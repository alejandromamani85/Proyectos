;Deploy Parcial

robocopy C:\Arg\SOA\Hub\Main\SmartixHub\bin C:\RootSitesARGDesa\SOASX\SmartixHub\bin *.dll *.pdb /S /MAXAGE:20171005
robocopy C:\Arg\SOA\SmartixV5Orchestration\Main\SmartixV5Orchestration\bin C:\RootSitesARGDesa\SOASX\SmartixV5Orchestration\bin *.dll *.pdb /S /MAXAGE:20171005
robocopy C:\Arg\SOA\V5New\Main\V5NewProduccionSite\bin C:\RootSitesARGDesa\SOASX\V5BackNew\bin *.dll *.pdb /S /MAXAGE:20171005
robocopy C:\Arg\Front\Ventas\Main\Smartix\bin C:\RootSitesARGDesa\FRTSXVTA\Ventas\bin *.dll *.pdb /S /MAXAGE:20171005