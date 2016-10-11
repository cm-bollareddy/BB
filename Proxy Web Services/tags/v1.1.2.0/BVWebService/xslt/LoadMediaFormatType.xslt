<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="MediaFormatTypeDataSet" targetNamespace="http://localhost/BVWebService/xsd/LoadMediaFormatTypeDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/LoadMediaFormatTypeDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/LoadMediaFormatTypeDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="MediaFormatTypeDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="MEDIAFORMATTYPE"><xs:complexType><xs:sequence><xs:element name="MET_ID" type="xs:int" /><xs:element name="MET_CODE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="6" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MET_DESC"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MET_ISARCHIVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_MEDIAFORMATTYPE" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:MEDIAFORMATTYPE" /><xs:field xpath="mstns:MET_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<MediaFormatTypeDataSet xmlns="http://localhost/BVWebService/xsd/LoadMediaFormatTypeDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<MEDIAFORMATTYPE>
				<xsl:attribute name="diffgr:id">MEDIAFORMATTYPE<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<MET_ID><xsl:value-of select="@MET_ID" /></MET_ID>
					<xsl:if test="@MET_CODE != ''">
						<MET_CODE><xsl:value-of select="@MET_CODE" /></MET_CODE>
					</xsl:if>
					<MET_DESC><xsl:value-of select="@MET_DESC" /></MET_DESC>
					<xsl:if test="@MET_ISARCHIVED != ''">
						<MET_ISARCHIVED><xsl:value-of select="@MET_ISARCHIVED" /></MET_ISARCHIVED>
					</xsl:if>
				</MEDIAFORMATTYPE>
			</xsl:for-each>
		</MediaFormatTypeDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
