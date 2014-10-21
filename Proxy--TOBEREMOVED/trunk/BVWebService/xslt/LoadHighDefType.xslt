<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="HighDefTypeDataSet" targetNamespace="http://localhost/BVWebService/xsd/LoadHighDefTypeDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/LoadHighDefTypeDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/LoadHighDefTypeDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="HighDefTypeDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="HIGHDEF"><xs:complexType><xs:sequence><xs:element name="SLU_ID" type="xs:int" /><xs:element name="SLU_DESC"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="IS_ARCHIVED" msdata:ReadOnly="true" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_HIGHDEF" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:HIGHDEF" /><xs:field xpath="mstns:SLU_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<HighDefTypeDataSet xmlns="http://localhost/BVWebService/xsd/LoadHighDefTypeDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<HIGHDEF>
				<xsl:attribute name="diffgr:id">HIGHDEF<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<SLU_ID><xsl:value-of select="@SLU_ID" /></SLU_ID>
					<SLU_DESC><xsl:value-of select="@SLU_DESC" /></SLU_DESC>
					<xsl:if test="@IS_ARCHIVED != ''">
						<IS_ARCHIVED><xsl:value-of select="@IS_ARCHIVED" /></IS_ARCHIVED>
					</xsl:if>
				</HIGHDEF>
			</xsl:for-each>
		</HighDefTypeDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
