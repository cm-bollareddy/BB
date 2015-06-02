REM XSD
fc %1\xsd\ListPAADeadlineDataSet.xsd  %2\xsd\ListPAADeadlineDataSet.xsd
fc %1\xsd\ListFormDeadlineDataSet.xsd  %2\xsd\ListFormDeadlineDataSet.xsd
fc %1\xsd\ListMissingEpisodeFormDeadlineDataSet.xsd  %2\xsd\ListMissingEpisodeFormDeadlineDataSet.xsd
fc %1\xsd\ListMissingVersionFormDeadlineDataSet.xsd  %2\xsd\ListMissingVersionFormDeadlineDataSet.xsd

REM XSLT
fc %1\xslt\ListPAADeadline.xslt  %2\xslt\ListPAADeadline.xslt
fc %1\xslt\ListFormDeadline.xslt  %2\xslt\ListFormDeadline.xslt
fc %1\xslt\ListMissingEpisodeFormDeadline.xslt  %2\xslt\ListMissingEpisodeFormDeadline.xslt
fc %1\xslt\ListMissingVersionFormDeadline.xslt  %2\xslt\ListMissingVersionFormDeadline.xslt

REM XSLTClass
fc %1\xsltclass\ListPAADeadlineClass.cs  %2\xsltclass\ListPAADeadlineClass.cs
fc %1\xsltclass\ListFormDeadlineClass.cs  %2\xsltclass\ListFormDeadlineClass.cs
fc %1\xsltclass\ListMissingEpisodeFormDeadlineClass.cs  %2\xsltclass\ListMissingEpisodeFormDeadlineClass.cs
fc %1\xsltclass\ListMissingVersionFormDeadlineClass.cs  %2\xsltclass\ListMissingVersionFormDeadlineClass.cs