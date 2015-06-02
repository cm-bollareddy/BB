REM XSD
fc %1\xsd\EpisodeTalentDataSet.xsd  %2\xsd\EpisodeTalentDataSet.xsd
fc %1\xsd\TalentDataSet.xsd  %2\xsd\TalentDataSet.xsd
fc %1\xsd\EpisodeAppliesToDataSet.xsd  %2\xsd\EpisodeAppliesToDataSet.xsd

REM XSLT
fc %1\xslt\GetDataEpisodeAppliesTo.xslt  %2\xslt\GetDataEpisodeAppliesTo.xslt
fc %1\xslt\PutDataEpisodeAppliesTo.xslt  %2\xslt\PutDataEpisodeAppliesTo.xslt
fc %1\xslt\GetDataEpisodeTalent.xslt  %2\xslt\GetDataEpisodeTalent.xslt
fc %1\xslt\PutDataEpisodeTalent.xslt  %2\xslt\PutDataEpisodeTalent.xslt
fc %1\xslt\GetDataTalent.xslt  %2\xslt\GetDataTalent.xslt
fc %1\xslt\PutDataTalent.xslt  %2\xslt\PutDataTalent.xslt


REM XSLTClass

fc %1\xsltclass\GetTalentClass.cs  %2\xsltclass\GetTalentClass.cs
fc %1\xsltclass\PutTalentClass.cs  %2\xsltclass\PutTalentClass.cs

