<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="CaptionVendorDataSet" targetNamespace="http://localhost/BVWebService/xsd/LoadCaptionVendorDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/LoadCaptionVendorDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/LoadCaptionVendorDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="CaptionVendorDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="CaptionVendor"><xs:complexType><xs:sequence><xs:element name="PBSCV_ID" type="xs:int" /><xs:element name="PBSCV_CODE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="6" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PBSCV_DESC" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PBSCV_ISARCHIVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_CAPTIONVENDOR" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:CaptionVendor" /><xs:field xpath="mstns:PBSCV_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<CaptionVendorDataSet xmlns="http://localhost/BVWebService/xsd/LoadCaptionVendorDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<CaptionVendor>
				<xsl:attribute name="diffgr:id">CaptionVendor<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<PBSCV_ID><xsl:value-of select="@PBSCV_ID" /></PBSCV_ID>
					<xsl:if test="@PBSCV_CODE != ''">
						<PBSCV_CODE><xsl:value-of select="@PBSCV_CODE" /></PBSCV_CODE>
					</xsl:if>
					<xsl:if test="@PBSCV_DESC != ''">
						<PBSCV_DESC><xsl:value-of select="@PBSCV_DESC" /></PBSCV_DESC>
					</xsl:if>
					<xsl:if test="@PBSCV_ISARCHIVED != ''">
						<PBSCV_ISARCHIVED><xsl:value-of select="@PBSCV_ISARCHIVED" /></PBSCV_ISARCHIVED>
					</xsl:if>
				</CaptionVendor>
			</xsl:for-each>
		</CaptionVendorDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
