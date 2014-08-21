<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="MediaInventoryTypeDataSet" targetNamespace="http://localhost/BVWebService/xsd/LoadMediaInventoryTypeDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/LoadMediaInventoryTypeDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/LoadMediaInventoryTypeDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="MediaInventoryTypeDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="MEDIAINVENTORYTYPE"><xs:complexType><xs:sequence><xs:element name="MIT_ID" type="xs:int" /><xs:element name="MIT_DESC" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MIT_MFC_ID" type="xs:int" minOccurs="0" /><xs:element name="MIT_ISARCHIVED" type="xs:short" minOccurs="0" /><xs:element name="MIT_ISFEATUREONLY" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_MEDIAINVENTORYTYPE" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:MEDIAINVENTORYTYPE" /><xs:field xpath="mstns:MIT_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<MediaInventoryTypeDataSet xmlns="http://localhost/BVWebService/xsd/LoadMediaInventoryTypeDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<MEDIAINVENTORYTYPE>
				<xsl:attribute name="diffgr:id">MEDIAINVENTORYTYPE<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<MIT_ID><xsl:value-of select="@MIT_ID" /></MIT_ID>
					<xsl:if test="@MIT_DESC != ''">
						<MIT_DESC><xsl:value-of select="@MIT_DESC" /></MIT_DESC>
					</xsl:if>
					<xsl:if test="@MIT_MFC_ID != ''">
						<MIT_MFC_ID><xsl:value-of select="@MIT_MFC_ID" /></MIT_MFC_ID>
					</xsl:if>
					<xsl:if test="@MIT_ISARCHIVED != ''">
						<MIT_ISARCHIVED><xsl:value-of select="@MIT_ISARCHIVED" /></MIT_ISARCHIVED>
					</xsl:if>
					<xsl:if test="@MIT_ISFEATUREONLY != ''">
						<MIT_ISFEATUREONLY><xsl:value-of select="@MIT_ISFEATUREONLY" /></MIT_ISFEATUREONLY>
					</xsl:if>
				</MEDIAINVENTORYTYPE>
			</xsl:for-each>
		</MediaInventoryTypeDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
