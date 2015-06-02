REM XSD
fc %1\xsd\AssetAppliesToRangeByTabDataSet.xsd  %2\xsd\AssetAppliesToRangeByTabDataSet.xsd
fc %1\xsd\ListTabMapByDealDataSet.xsd  %2\xsd\ListTabMapByDealDataSet.xsd
fc %1\xsd\PackageAppliesToRangeByTabDataSet.xsd  %2\xsd\PackageAppliesToRangeByTabDataSet.xsd

REM XSLT
fc %1\xslt\GetAssetAppliesToRangeByTab.xslt  %2\xslt\GetAssetAppliesToRangeByTab.xslt
fc %1\xslt\GetPackageAppliesToRangeByTab.xslt  %2\xslt\GetPackageAppliesToRangeByTab.xslt
fc %1\xslt\ListTabMapByDeal.xslt  %2\xslt\ListTabMapByDeal.xslt
fc %1\xslt\PutAssetAppliesToRangeByTab.xslt  %2\xslt\PutAssetAppliesToRangeByTab.xslt
fc %1\xslt\PutPackageAppliesToRangeByTab.xslt  %2\xslt\PutPackageAppliesToRangeByTab.xslt


REM XSLTClass

fc %1\xsltclass\GetAssetAppliesToRangeByTabClass.cs  %2\xsltclass\GetAssetAppliesToRangeByTabClass.cs
fc %1\xsltclass\GetPackageAppliesToRangeByTabClass.cs  %2\xsltclass\GetPackageAppliesToRangeByTabClass.cs
fc %1\xsltclass\ListTabMapByDealClass.cs  %2\xsltclass\ListTabMapByDealClass.cs
fc %1\xsltclass\PutAssetAppliesToRangeByTabClass.cs  %2\xsltclass\PutAssetAppliesToRangeByTabClass.cs
fc %1\xsltclass\PutPackageAppliesToRangeByTabClass.cs  %2\xsltclass\PutPackageAppliesToRangeByTabClass.cs


