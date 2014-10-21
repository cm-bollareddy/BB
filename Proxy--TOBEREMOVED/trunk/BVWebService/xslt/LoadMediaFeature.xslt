<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="MediaFeatureDataSet" targetNamespace="http://localhost/BVWebService/xsd/LoadMediaFeatureDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/LoadMediaFeatureDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/LoadMediaFeatureDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="MediaFeatureDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="MEDIAFEATURE"><xs:complexType><xs:sequence><xs:element name="MEF_ID" type="xs:int" /><xs:element name="MEF_MFC_ID" type="xs:int" /><xs:element name="MEF_LAN_ID" type="xs:int" minOccurs="0" /><xs:element name="MEF_CODE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="6" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MEF_DESC"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MEF_ISARCHIVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_MEDIAFEATURE" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:MEDIAFEATURE" /><xs:field xpath="mstns:MEF_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<MediaFeatureDataSet xmlns="http://localhost/BVWebService/xsd/LoadMediaFeatureDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<MEDIAFEATURE>
				<xsl:attribute name="diffgr:id">MEDIAFEATURE<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<MEF_ID><xsl:value-of select="@MEF_ID" /></MEF_ID>
					<MEF_MFC_ID><xsl:value-of select="@MEF_MFC_ID" /></MEF_MFC_ID>
					<xsl:if test="@MEF_LAN_ID != ''">
						<MEF_LAN_ID><xsl:value-of select="@MEF_LAN_ID" /></MEF_LAN_ID>
					</xsl:if>
					<xsl:if test="@MEF_CODE != ''">
						<MEF_CODE><xsl:value-of select="@MEF_CODE" /></MEF_CODE>
					</xsl:if>
					<MEF_DESC><xsl:value-of select="@MEF_DESC" /></MEF_DESC>
					<xsl:if test="@MEF_ISARCHIVED != ''">
						<MEF_ISARCHIVED><xsl:value-of select="@MEF_ISARCHIVED" /></MEF_ISARCHIVED>
					</xsl:if>
				</MEDIAFEATURE>
			</xsl:for-each>
		</MediaFeatureDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
