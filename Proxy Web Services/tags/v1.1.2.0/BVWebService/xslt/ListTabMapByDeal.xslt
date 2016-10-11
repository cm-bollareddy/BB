<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="TabMapByDealDataSet" targetNamespace="http://localhost/BVWebService/xsd/ListTabMapByDealDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/ListTabMapByDealDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/ListTabMapByDealDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="TabMapByDealDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="TABMAP"><xs:complexType><xs:sequence><xs:element name="TABID" type="xs:int" /><xs:element name="TABTYPE"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="3" /></xs:restriction></xs:simpleType></xs:element></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_TABMAP" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:TABMAP" /><xs:field xpath="mstns:TABID" /><xs:field xpath="mstns:TABTYPE" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<TabMapByDealDataSet xmlns="http://localhost/BVWebService/xsd/ListTabMapByDealDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<TABMAP>
				<xsl:attribute name="diffgr:id">TABMAP<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<TABID><xsl:value-of select="@TABID" /></TABID>
					<TABTYPE><xsl:value-of select="@TABTYPE" /></TABTYPE>
				</TABMAP>
			</xsl:for-each>
		</TabMapByDealDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
