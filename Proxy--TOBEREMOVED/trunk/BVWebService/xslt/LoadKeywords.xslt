<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="KeywordsDataSet" targetNamespace="http://localhost/BVWebService/xsd/LoadKeywordsDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/LoadKeywordsDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/LoadKeywordsDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="KeywordsDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="Keyword"><xs:complexType><xs:sequence><xs:element name="PBSPK_ID" type="xs:int" /><xs:element name="PBSPK_CLASS"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="3" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PBSPK_CODE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="6" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PBSPK_DESC"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PBSPK_ISARCHIVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_KEYWORD" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:Keyword" /><xs:field xpath="mstns:PBSPK_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<KeywordsDataSet xmlns="http://localhost/BVWebService/xsd/LoadKeywordsDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<Keyword>
				<xsl:attribute name="diffgr:id">Keyword<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<PBSPK_ID><xsl:value-of select="@PBSPK_ID" /></PBSPK_ID>
					<PBSPK_CLASS><xsl:value-of select="@PBSPK_CLASS" /></PBSPK_CLASS>
					<xsl:if test="@PBSPK_CODE != ''">
						<PBSPK_CODE><xsl:value-of select="@PBSPK_CODE" /></PBSPK_CODE>
					</xsl:if>
					<PBSPK_DESC><xsl:value-of select="@PBSPK_DESC" /></PBSPK_DESC>
					<xsl:if test="@PBSPK_ISARCHIVED != ''">
						<PBSPK_ISARCHIVED><xsl:value-of select="@PBSPK_ISARCHIVED" /></PBSPK_ISARCHIVED>
					</xsl:if>
				</Keyword>
			</xsl:for-each>
		</KeywordsDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
