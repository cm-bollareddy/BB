<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="LanguageDataSet" targetNamespace="http://localhost/BVWebService/xsd/LoadLanguageDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/LoadLanguageDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/LoadLanguageDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="LanguageDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="Language"><xs:complexType><xs:sequence><xs:element name="LAN_ID" type="xs:int" /><xs:element name="LAN_DESC"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="LAN_ISARCHIVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_LANGUAGE" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:Language" /><xs:field xpath="mstns:LAN_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<LanguageDataSet xmlns="http://localhost/BVWebService/xsd/LoadLanguageDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<Language>
				<xsl:attribute name="diffgr:id">Language<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<LAN_ID><xsl:value-of select="@LAN_ID" /></LAN_ID>
					<LAN_DESC><xsl:value-of select="@LAN_DESC" /></LAN_DESC>
					<xsl:if test="@LAN_ISARCHIVED != ''">
						<LAN_ISARCHIVED><xsl:value-of select="@LAN_ISARCHIVED" /></LAN_ISARCHIVED>
					</xsl:if>
				</Language>
			</xsl:for-each>
		</LanguageDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
