<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="StationsDataSet" targetNamespace="http://localhost/BVWebService/xsd/LoadStationsDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/LoadStationsDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/LoadStationsDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="StationsDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="STATION"><xs:complexType><xs:sequence><xs:element name="CHA_ID" type="xs:int" /><xs:element name="CHA_CODE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="CHA_DESC"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="CHA_ISARCHIVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_STATION" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:STATION" /><xs:field xpath="mstns:CHA_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<StationsDataSet xmlns="http://localhost/BVWebService/xsd/LoadStationsDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<STATION>
				<xsl:attribute name="diffgr:id">STATION<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<CHA_ID><xsl:value-of select="@CHA_ID" /></CHA_ID>
					<xsl:if test="@CHA_CODE != ''">
						<CHA_CODE><xsl:value-of select="@CHA_CODE" /></CHA_CODE>
					</xsl:if>
					<CHA_DESC><xsl:value-of select="@CHA_DESC" /></CHA_DESC>
					<xsl:if test="@CHA_ISARCHIVED != ''">
						<CHA_ISARCHIVED><xsl:value-of select="@CHA_ISARCHIVED" /></CHA_ISARCHIVED>
					</xsl:if>
				</STATION>
			</xsl:for-each>
		</StationsDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
