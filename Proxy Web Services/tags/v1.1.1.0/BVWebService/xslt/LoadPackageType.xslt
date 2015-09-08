<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="PackageTypeDataSet" targetNamespace="http://localhost/BVWebService/xsd/LoadPackageTypeDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/LoadPackageTypeDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/LoadPackageTypeDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="PackageTypeDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="PACKAGETYPE"><xs:complexType><xs:sequence><xs:element name="VET_ID" type="xs:int" /><xs:element name="VET_DESC"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="VET_SLU_ID_VIDEO_FORMAT" type="xs:int" minOccurs="0" /><xs:element name="VET_ISARCHIVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_PACKAGETYPE" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:PACKAGETYPE" /><xs:field xpath="mstns:VET_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<PackageTypeDataSet xmlns="http://localhost/BVWebService/xsd/LoadPackageTypeDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<PACKAGETYPE>
				<xsl:attribute name="diffgr:id">PACKAGETYPE<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<VET_ID><xsl:value-of select="@VET_ID" /></VET_ID>
					<VET_DESC><xsl:value-of select="@VET_DESC" /></VET_DESC>
					<xsl:if test="@VET_SLU_ID_VIDEO_FORMAT != ''">
						<VET_SLU_ID_VIDEO_FORMAT><xsl:value-of select="@VET_SLU_ID_VIDEO_FORMAT" /></VET_SLU_ID_VIDEO_FORMAT>
					</xsl:if>
					<xsl:if test="@VET_ISARCHIVED != ''">
						<VET_ISARCHIVED><xsl:value-of select="@VET_ISARCHIVED" /></VET_ISARCHIVED>
					</xsl:if>
				</PACKAGETYPE>
			</xsl:for-each>
		</PackageTypeDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
