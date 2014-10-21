<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="PlayRuleDataSet" targetNamespace="http://localhost/BVWebService/xsd/LoadPlayRuleDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/LoadPlayRuleDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/LoadPlayRuleDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="PlayRuleDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="PlayRule"><xs:complexType><xs:sequence><xs:element name="ARR_ID" type="xs:int" /><xs:element name="ARR_DESC"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ARR_ISARCHIVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_PLAYRULE" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:PlayRule" /><xs:field xpath="mstns:ARR_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<PlayRuleDataSet xmlns="http://localhost/BVWebService/xsd/LoadPlayRuleDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<PlayRule>
				<xsl:attribute name="diffgr:id">PlayRule<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<ARR_ID><xsl:value-of select="@ARR_ID" /></ARR_ID>
					<ARR_DESC><xsl:value-of select="@ARR_DESC" /></ARR_DESC>
					<xsl:if test="@ARR_ISARCHIVED != ''">
						<ARR_ISARCHIVED><xsl:value-of select="@ARR_ISARCHIVED" /></ARR_ISARCHIVED>
					</xsl:if>
				</PlayRule>
			</xsl:for-each>
		</PlayRuleDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
