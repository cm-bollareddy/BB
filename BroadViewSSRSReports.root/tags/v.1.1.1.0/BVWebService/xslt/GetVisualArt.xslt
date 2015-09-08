<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="VisualArtDataSet" targetNamespace="http://localhost/BVWebService/xsd/VisualArtDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/VisualArtDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/VisualArtDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="VisualArtDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="VISUALART"><xs:complexType><xs:sequence><xs:element name="PVA_ID" type="xs:int" /><xs:element name="PVA_DEA_ID" type="xs:int" minOccurs="0" /><xs:element name="PVA_FORMSTATUS" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_VISUALART" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:VISUALART" /><xs:field xpath="mstns:PVA_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<VisualArtDataSet xmlns="http://localhost/BVWebService/xsd/VisualArtDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<VISUALART>
				<xsl:attribute name="diffgr:id">VISUALART<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<PVA_ID><xsl:value-of select="@PVA_ID" /></PVA_ID>
					<xsl:if test="@PVA_DEA_ID != ''">
						<PVA_DEA_ID><xsl:value-of select="@PVA_DEA_ID" /></PVA_DEA_ID>
					</xsl:if>
					<xsl:if test="@PVA_FORMSTATUS != ''">
						<PVA_FORMSTATUS><xsl:value-of select="@PVA_FORMSTATUS" /></PVA_FORMSTATUS>
					</xsl:if>
				</VISUALART>
			</xsl:for-each>
		</VisualArtDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
