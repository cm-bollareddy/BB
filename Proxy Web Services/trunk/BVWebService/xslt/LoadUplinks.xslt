<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="UplinksDataSet" targetNamespace="http://localhost/BVWebService/xsd/LoadUplinksDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/LoadUplinksDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/LoadUplinksDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="UplinksDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="Uplinks"><xs:complexType><xs:sequence><xs:element name="PBSUP_ID" type="xs:int" /><xs:element name="PBSUP_CODE"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="6" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PBSUP_DESC" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PBSUP_ISARCHIVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_UPLINKS" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:Uplinks" /><xs:field xpath="mstns:PBSUP_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<UplinksDataSet xmlns="http://localhost/BVWebService/xsd/LoadUplinksDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<Uplinks>
				<xsl:attribute name="diffgr:id">Uplinks<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<PBSUP_ID><xsl:value-of select="@PBSUP_ID" /></PBSUP_ID>
					<PBSUP_CODE><xsl:value-of select="@PBSUP_CODE" /></PBSUP_CODE>
					<xsl:if test="@PBSUP_DESC != ''">
						<PBSUP_DESC><xsl:value-of select="@PBSUP_DESC" /></PBSUP_DESC>
					</xsl:if>
					<xsl:if test="@PBSUP_ISARCHIVED != ''">
						<PBSUP_ISARCHIVED><xsl:value-of select="@PBSUP_ISARCHIVED" /></PBSUP_ISARCHIVED>
					</xsl:if>
				</Uplinks>
			</xsl:for-each>
		</UplinksDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
