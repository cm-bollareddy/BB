REM XSD
fc %1\xsd\ListDealsByMasterDealDataSet.xsd  %2\xsd\ListDealsByMasterDealDataSet.xsd
fc %1\xsd\MasterDealDataSet.xsd  %2\xsd\MasterDealDataSet.xsd

REM XSLT
fc %1\xslt\ListDealsByMasterDeal.xslt  %2\xslt\ListDealsByMasterDeal.xslt
fc %1\xslt\GetMasterDeal.xslt  %2\xslt\GetMasterDeal.xslt

REM XSLTClass
fc %1\xsltclass\ListDealsByMasterDealClass.cs  %2\xsltclass\ListDealsByMasterDealClass.cs
fc %1\xsltclass\GetMasterDealClass.cs  %2\xsltclass\GetMasterDealClass.cs
