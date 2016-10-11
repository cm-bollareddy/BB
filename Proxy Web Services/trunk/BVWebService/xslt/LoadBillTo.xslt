<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="BillToDataSet" targetNamespace="http://localhost/BVWebService/xsd/LoadBillToDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/LoadBillToDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/LoadBillToDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="BillToDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="MASTER"><xs:complexType><xs:sequence><xs:element name="PBSBT_ID" type="xs:int" /><xs:element name="PBSBT_CODE"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="6" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PBSBT_DESC"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="120" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PBSBT_PBSOPERATINGUNIT" type="xs:int" minOccurs="0" /><xs:element name="PBSBT_ISARCHIVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_MASTER" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:MASTER" /><xs:field xpath="mstns:PBSBT_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<BillToDataSet xmlns="http://localhost/BVWebService/xsd/LoadBillToDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<MASTER>
				<xsl:attribute name="diffgr:id">MASTER<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<PBSBT_ID><xsl:value-of select="@PBSBT_ID" /></PBSBT_ID>
					<PBSBT_CODE><xsl:value-of select="@PBSBT_CODE" /></PBSBT_CODE>
					<PBSBT_DESC><xsl:value-of select="@PBSBT_DESC" /></PBSBT_DESC>
					<xsl:if test="@PBSBT_PBSOPERATINGUNIT != ''">
						<PBSBT_PBSOPERATINGUNIT><xsl:value-of select="@PBSBT_PBSOPERATINGUNIT" /></PBSBT_PBSOPERATINGUNIT>
					</xsl:if>
					<xsl:if test="@PBSBT_ISARCHIVED != ''">
						<PBSBT_ISARCHIVED><xsl:value-of select="@PBSBT_ISARCHIVED" /></PBSBT_ISARCHIVED>
					</xsl:if>
				</MASTER>
			</xsl:for-each>
		</BillToDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
