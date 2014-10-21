<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="MusicCueDataSet" targetNamespace="http://localhost/BVWebService/xsd/MusicCueDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/MusicCueDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/MusicCueDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="MusicCueDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="MUSICCUE"><xs:complexType><xs:sequence><xs:element name="PMC_ID" type="xs:int" /><xs:element name="PMC_DEA_ID" type="xs:int" minOccurs="0" /><xs:element name="PMC_FORMSTATUS" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_MUSICCUE" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:MUSICCUE" /><xs:field xpath="mstns:PMC_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<MusicCueDataSet xmlns="http://localhost/BVWebService/xsd/MusicCueDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<MUSICCUE>
				<xsl:attribute name="diffgr:id">MUSICCUE<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<PMC_ID><xsl:value-of select="@PMC_ID" /></PMC_ID>
					<xsl:if test="@PMC_DEA_ID != ''">
						<PMC_DEA_ID><xsl:value-of select="@PMC_DEA_ID" /></PMC_DEA_ID>
					</xsl:if>
					<xsl:if test="@PMC_FORMSTATUS != ''">
						<PMC_FORMSTATUS><xsl:value-of select="@PMC_FORMSTATUS" /></PMC_FORMSTATUS>
					</xsl:if>
				</MUSICCUE>
			</xsl:for-each>
		</MusicCueDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
