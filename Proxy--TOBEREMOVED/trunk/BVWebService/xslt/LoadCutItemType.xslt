<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="CutItemTypeDataSet" targetNamespace="http://localhost/BVWebService/xsd/LoadCutItemTypeDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/LoadCutItemTypeDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/LoadCutItemTypeDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="CutItemTypeDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="CUTITEMTYPE"><xs:complexType><xs:sequence><xs:element name="MICT_ID" type="xs:int" /><xs:element name="MICT_DESC" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MICT_CODE"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="6" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MICT_CLASS" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="3" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MICT_ACA_ID" type="xs:int" minOccurs="0" /><xs:element name="MICT_ISARCHIVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_CUTITEMTYPE" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:CUTITEMTYPE" /><xs:field xpath="mstns:MICT_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<CutItemTypeDataSet xmlns="http://localhost/BVWebService/xsd/LoadCutItemTypeDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<CUTITEMTYPE>
				<xsl:attribute name="diffgr:id">CUTITEMTYPE<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<MICT_ID><xsl:value-of select="@MICT_ID" /></MICT_ID>
					<xsl:if test="@MICT_DESC != ''">
						<MICT_DESC><xsl:value-of select="@MICT_DESC" /></MICT_DESC>
					</xsl:if>
					<MICT_CODE><xsl:value-of select="@MICT_CODE" /></MICT_CODE>
					<xsl:if test="@MICT_CLASS != ''">
						<MICT_CLASS><xsl:value-of select="@MICT_CLASS" /></MICT_CLASS>
					</xsl:if>
					<xsl:if test="@MICT_ACA_ID != ''">
						<MICT_ACA_ID><xsl:value-of select="@MICT_ACA_ID" /></MICT_ACA_ID>
					</xsl:if>
					<xsl:if test="@MICT_ISARCHIVED != ''">
						<MICT_ISARCHIVED><xsl:value-of select="@MICT_ISARCHIVED" /></MICT_ISARCHIVED>
					</xsl:if>
				</CUTITEMTYPE>
			</xsl:for-each>
		</CutItemTypeDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
