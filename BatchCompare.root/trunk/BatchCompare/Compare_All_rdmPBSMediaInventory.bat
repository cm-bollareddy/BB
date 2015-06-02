
REM XSD
fc %1\xsd\FeatureMediaInventoryDataSet.xsd  %2\xsd\FeatureMediaInventoryDataSet.xsd
fc %1\xsd\MediaInventoryRevisionDataSet.xsd  %2\xsd\MediaInventoryRevisionDataSet.xsd

REM XSLT
fc %1\xslt\GetFeatureMediaInventory.xslt  %2\xslt\GetFeatureMediaInventory.xslt
fc %1\xslt\GetMediaInventoryRevision.xslt  %2\xslt\GetMediaInventoryRevision.xslt
fc %1\xslt\PutFeatureMediaInventory.xslt  %2\xslt\PutFeatureMediaInventory.xslt
fc %1\xslt\PutMediaInventoryRevision.xslt  %2\xslt\PutMediaInventoryRevision.xslt

REM XSLTClass
fc %1\xsltclass\CreateMediaInventoryRevisionClass.cs  %2\xsltclass\CreateMediaInventoryRevisionClass.cs
fc %1\xsltclass\GetBarCodeClass.cs  %2\xsltclass\GetBarCodeClass.cs
fc %1\xsltclass\GetFeatureMediaInventoryClass.cs  %2\xsltclass\GetFeatureMediaInventoryClass.cs
fc %1\xsltclass\GetMediaInventoryRevisionClass.cs  %2\xsltclass\GetMediaInventoryRevisionClass.cs
fc %1\xsltclass\PutFeatureMediaInventoryClass.cs  %2\xsltclass\PutFeatureMediaInventoryClass.cs
fc %1\xsltclass\PutMediaInventoryRevisionClass.cs  %2\xsltclass\PutMediaInventoryRevisionClass.cs


