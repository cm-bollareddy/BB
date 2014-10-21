<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="FormatSheetDataSet" targetNamespace="http://localhost/BVWebService/xsd/FormatSheetDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/FormatSheetDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/FormatSheetDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="FormatSheetDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="FORMATSHEET"><xs:complexType><xs:sequence><xs:element name="PFS_ID" type="xs:int" /><xs:element name="PFS_DEA_ID" type="xs:int" minOccurs="0" /><xs:element name="PFS_FORMSTATUS" type="xs:short" minOccurs="0" /><xs:element name="PREMIEREDATE" msdata:ReadOnly="true" type="xs:dateTime" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_FORMATSHEET" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:FORMATSHEET" /><xs:field xpath="mstns:PFS_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<FormatSheetDataSet xmlns="http://localhost/BVWebService/xsd/FormatSheetDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<FORMATSHEET>
				<xsl:attribute name="diffgr:id">FORMATSHEET<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<PFS_ID><xsl:value-of select="@PFS_ID" /></PFS_ID>
					<xsl:if test="@PFS_DEA_ID != ''">
						<PFS_DEA_ID><xsl:value-of select="@PFS_DEA_ID" /></PFS_DEA_ID>
					</xsl:if>
					<xsl:if test="@PFS_FORMSTATUS != ''">
						<PFS_FORMSTATUS><xsl:value-of select="@PFS_FORMSTATUS" /></PFS_FORMSTATUS>
					</xsl:if>
					<xsl:if test="@PREMIEREDATE != ''">
						<PREMIEREDATE>
							<xsl:call-template name="DateConverter">
								<xsl:with-param name="InDate"><xsl:value-of select="@PREMIEREDATE" /></xsl:with-param>
							</xsl:call-template>
						</PREMIEREDATE>
					</xsl:if>
				</FORMATSHEET>
			</xsl:for-each>
		</FormatSheetDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
