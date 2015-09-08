<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="VCHIPValuesDataSet" targetNamespace="http://localhost/BVWebService/xsd/LoadVCHIPValuesDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/LoadVCHIPValuesDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/LoadVCHIPValuesDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="VCHIPValuesDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="VCHIP"><xs:complexType><xs:sequence><xs:element name="VCH_ID" type="xs:int" /><xs:element name="VCH_CODE"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="10" /></xs:restriction></xs:simpleType></xs:element><xs:element name="VCH_DESCRIPTION" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="VCH_ISARCHIVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_VCHIP" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:VCHIP" /><xs:field xpath="mstns:VCH_ID" /><xs:field xpath="mstns:VCH_CODE" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<VCHIPValuesDataSet xmlns="http://localhost/BVWebService/xsd/LoadVCHIPValuesDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<VCHIP>
				<xsl:attribute name="diffgr:id">VCHIP<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<VCH_ID><xsl:value-of select="@VCH_ID" /></VCH_ID>
					<VCH_CODE><xsl:value-of select="@VCH_CODE" /></VCH_CODE>
					<xsl:if test="@VCH_DESCRIPTION != ''">
						<VCH_DESCRIPTION><xsl:value-of select="@VCH_DESCRIPTION" /></VCH_DESCRIPTION>
					</xsl:if>
					<xsl:if test="@VCH_ISARCHIVED != ''">
						<VCH_ISARCHIVED><xsl:value-of select="@VCH_ISARCHIVED" /></VCH_ISARCHIVED>
					</xsl:if>
				</VCHIP>
			</xsl:for-each>
		</VCHIPValuesDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
