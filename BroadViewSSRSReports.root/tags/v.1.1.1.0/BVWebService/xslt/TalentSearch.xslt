<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="TalentDataSet" targetNamespace="http://localhost/BVWebService/xsd/TalentSearchDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/TalentSearchDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/TalentSearchDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="TalentDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="TALENTSEARCH"><xs:complexType><xs:sequence><xs:element name="TAL_ID" type="xs:int" /><xs:element name="TAL_NAME" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_TALENTSEARCH" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:TALENTSEARCH" /><xs:field xpath="mstns:TAL_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<TalentDataSet xmlns="http://localhost/BVWebService/xsd/TalentSearchDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<TALENTSEARCH>
				<xsl:attribute name="diffgr:id">TALENTSEARCH<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<TAL_ID><xsl:value-of select="@TAL_ID" /></TAL_ID>
					<xsl:if test="@TAL_NAME != ''">
						<TAL_NAME><xsl:value-of select="@TAL_NAME" /></TAL_NAME>
					</xsl:if>
				</TALENTSEARCH>
			</xsl:for-each>
		</TalentDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
