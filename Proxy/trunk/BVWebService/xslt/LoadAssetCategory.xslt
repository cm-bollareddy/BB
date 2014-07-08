<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="AssetCategoryDataSet" targetNamespace="http://localhost/BVWebService/xsd/LoadAssetCategoryDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/LoadAssetCategoryDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/LoadAssetCategoryDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="AssetCategoryDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="ASSETCATEGORY"><xs:complexType><xs:sequence><xs:element name="ACA_ID" type="xs:int" /><xs:element name="ACA_CODE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="6" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ACA_DESC"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ACA_ISARCHIVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_ASSETCATEGORY" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:ASSETCATEGORY" /><xs:field xpath="mstns:ACA_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<AssetCategoryDataSet xmlns="http://localhost/BVWebService/xsd/LoadAssetCategoryDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<ASSETCATEGORY>
				<xsl:attribute name="diffgr:id">ASSETCATEGORY<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<ACA_ID><xsl:value-of select="@ACA_ID" /></ACA_ID>
					<xsl:if test="@ACA_CODE != ''">
						<ACA_CODE><xsl:value-of select="@ACA_CODE" /></ACA_CODE>
					</xsl:if>
					<ACA_DESC><xsl:value-of select="@ACA_DESC" /></ACA_DESC>
					<xsl:if test="@ACA_ISARCHIVED != ''">
						<ACA_ISARCHIVED><xsl:value-of select="@ACA_ISARCHIVED" /></ACA_ISARCHIVED>
					</xsl:if>
				</ASSETCATEGORY>
			</xsl:for-each>
		</AssetCategoryDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
