<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="PackageDataSet" targetNamespace="http://localhost/BVWebService/xsd/PackageDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/PackageDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/PackageDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="PackageDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="PACKAGE"><xs:complexType><xs:sequence><xs:element name="VER_ID" type="xs:int" /><xs:element name="VER_ASS_ID" type="xs:int" /><xs:element name="VER_VET_ID" type="xs:int" /><xs:element name="VER_SLATE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="VER_PFS_ID" type="xs:int" minOccurs="0" /><xs:element name="VER_PIWT_ID" type="xs:int" minOccurs="0" /><xs:element name="VER_POAC_ID" type="xs:int" minOccurs="0" /><xs:element name="VER_PUCC_ID" type="xs:int" minOccurs="0" /><xs:element name="DCO_OBDATE" type="xs:dateTime" minOccurs="0" /><xs:element name="VER_PACKAGENUMBER" type="xs:int" minOccurs="0" /><xs:element name="VER_REVISIONNO" type="xs:short" minOccurs="0" /><xs:element name="VER_ISARCHIVED" type="xs:short" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_PACKAGE" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:PACKAGE" /><xs:field xpath="mstns:VER_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<PackageDataSet xmlns="http://localhost/BVWebService/xsd/PackageDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<PACKAGE>
				<xsl:attribute name="diffgr:id">PACKAGE<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<VER_ID><xsl:value-of select="@VER_ID" /></VER_ID>
					<VER_ASS_ID><xsl:value-of select="@VER_ASS_ID" /></VER_ASS_ID>
					<VER_VET_ID><xsl:value-of select="@VER_VET_ID" /></VER_VET_ID>
					<xsl:if test="@VER_SLATE != ''">
						<VER_SLATE><xsl:value-of select="@VER_SLATE" /></VER_SLATE>
					</xsl:if>
					<xsl:if test="@VER_PFS_ID != ''">
						<VER_PFS_ID><xsl:value-of select="@VER_PFS_ID" /></VER_PFS_ID>
					</xsl:if>
					<xsl:if test="@VER_PIWT_ID != ''">
						<VER_PIWT_ID><xsl:value-of select="@VER_PIWT_ID" /></VER_PIWT_ID>
					</xsl:if>
					<xsl:if test="@VER_POAC_ID != ''">
						<VER_POAC_ID><xsl:value-of select="@VER_POAC_ID" /></VER_POAC_ID>
					</xsl:if>
					<xsl:if test="@VER_PUCC_ID != ''">
						<VER_PUCC_ID><xsl:value-of select="@VER_PUCC_ID" /></VER_PUCC_ID>
					</xsl:if>
					<xsl:if test="@DCO_OBDATE != ''">
						<DCO_OBDATE>
							<xsl:call-template name="DateConverter">
								<xsl:with-param name="InDate"><xsl:value-of select="@DCO_OBDATE" /></xsl:with-param>
							</xsl:call-template>
						</DCO_OBDATE>
					</xsl:if>
					<xsl:if test="@VER_PACKAGENUMBER != ''">
						<VER_PACKAGENUMBER><xsl:value-of select="@VER_PACKAGENUMBER" /></VER_PACKAGENUMBER>
					</xsl:if>
					<xsl:if test="@VER_REVISIONNO != ''">
						<VER_REVISIONNO><xsl:value-of select="@VER_REVISIONNO" /></VER_REVISIONNO>
					</xsl:if>
					<VER_ISARCHIVED><xsl:value-of select="@VER_ISARCHIVED" /></VER_ISARCHIVED>
				</PACKAGE>
			</xsl:for-each>
		</PackageDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
