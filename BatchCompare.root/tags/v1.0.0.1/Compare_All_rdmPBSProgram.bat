REM XSD
fc %1\xsd\AdCopyDataSet.xsd  %2\xsd\AdCopyDataSet.xsd
fc %1\xsd\PackageDataSet.xsd  %2\xsd\PackageDataSet.xsd
fc %1\xsd\ListProgramPackagesByProgramDataSet.xsd  %2\xsd\ListProgramPackagesByProgramDataSet.xsd
fc %1\xsd\ListProgramsByDealDataSet.xsd  %2\xsd\ListProgramsByDealDataSet.xsd
fc %1\xsd\ProgramDetailsDataSet.xsd  %2\xsd\ProgramDetailsDataSet.xsd

REM XSLT
fc %1\xslt\GetAdCopy.xslt  %2\xslt\GetAdCopy.xslt
fc %1\xslt\GetPackage.xslt  %2\xslt\GetPackage.xslt
fc %1\xslt\GetProgramDetails.xslt  %2\xslt\GetProgramDetails.xslt
fc %1\xslt\ListProgramPackagesByProgram.xslt  %2\xslt\ListProgramPackagesByProgram.xslt
fc %1\xslt\ListProgramsByDeal.xslt  %2\xslt\ListProgramsByDeal.xslt
fc %1\xslt\PutAdCopy.xslt  %2\xslt\PutAdCopy.xslt
fc %1\xslt\PutProgramDetails.xslt  %2\xslt\PutProgramDetails.xslt

REM XSLTClass

fc %1\xsltclass\GetAdCopyClass.cs  %2\xsltclass\GetAdCopyClass.cs
fc %1\xsltclass\GetPackageClass.cs  %2\xsltclass\GetPackageClass.cs
fc %1\xsltclass\GetProgramDetailsClass.cs  %2\xsltclass\GetProgramDetailsClass.cs
fc %1\xsltclass\ListProgramPackagesByProgramClass.cs  %2\xsltclass\ListProgramPackagesByProgramClass.cs
fc %1\xsltclass\ListProgramsByDealClass.cs  %2\xsltclass\ListProgramsByDealClass.cs
fc %1\xsltclass\PutAdCopyClass.cs  %2\xsltclass\PutAdCopyClass.cs
fc %1\xsltclass\PutProgramDetailsClass.cs  %2\xsltclass\PutProgramDetailsClass.cs
