<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="MissingEpisodeFormDeadlineDataSet" targetNamespace="http://localhost/BVWebService/xsd/ListMissingEpisodeFormDeadlineDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/ListMissingEpisodeFormDeadlineDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/ListMissingEpisodeFormDeadlineDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="MissingEpisodeFormDeadlineDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="EPISODE_DEADLINE_TEMP"><xs:complexType><xs:sequence><xs:element name="DEA_ID" type="xs:int" /><xs:element name="ASS_ID" type="xs:int" /><xs:element name="TABTYPE"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="3" /></xs:restriction></xs:simpleType></xs:element></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_EPISODE_DEADLINE_TEMP" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:EPISODE_DEADLINE_TEMP" /><xs:field xpath="mstns:DEA_ID" /><xs:field xpath="mstns:ASS_ID" /><xs:field xpath="mstns:TABTYPE" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<MissingEpisodeFormDeadlineDataSet xmlns="http://localhost/BVWebService/xsd/ListMissingEpisodeFormDeadlineDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<EPISODE_DEADLINE_TEMP>
				<xsl:attribute name="diffgr:id">EPISODE_DEADLINE_TEMP<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<DEA_ID><xsl:value-of select="@DEA_ID" /></DEA_ID>
					<ASS_ID><xsl:value-of select="@ASS_ID" /></ASS_ID>
					<TABTYPE><xsl:value-of select="@TABTYPE" /></TABTYPE>
				</EPISODE_DEADLINE_TEMP>
			</xsl:for-each>
		</MissingEpisodeFormDeadlineDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
