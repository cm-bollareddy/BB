<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="DisclaimerDataSet" targetNamespace="http://localhost/BVWebService/xsd/LoadDisclaimerDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/LoadDisclaimerDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/LoadDisclaimerDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="DisclaimerDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="Disclaimer"><xs:complexType><xs:sequence><xs:element name="DIS_ID" type="xs:int" /><xs:element name="DIS_DESC" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="252" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DIS_ISARCHIVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_DISCLAIMER" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:Disclaimer" /><xs:field xpath="mstns:DIS_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<DisclaimerDataSet xmlns="http://localhost/BVWebService/xsd/LoadDisclaimerDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<Disclaimer>
				<xsl:attribute name="diffgr:id">Disclaimer<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<DIS_ID><xsl:value-of select="@DIS_ID" /></DIS_ID>
					<xsl:if test="@DIS_DESC != ''">
						<DIS_DESC><xsl:value-of select="@DIS_DESC" /></DIS_DESC>
					</xsl:if>
					<xsl:if test="@DIS_ISARCHIVED != ''">
						<DIS_ISARCHIVED><xsl:value-of select="@DIS_ISARCHIVED" /></DIS_ISARCHIVED>
					</xsl:if>
				</Disclaimer>
			</xsl:for-each>
		</DisclaimerDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
