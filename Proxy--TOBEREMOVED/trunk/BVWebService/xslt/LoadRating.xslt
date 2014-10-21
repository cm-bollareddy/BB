<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="RatingDataSet" targetNamespace="http://localhost/BVWebService/xsd/LoadRatingDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/LoadRatingDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/LoadRatingDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="RatingDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="Rating"><xs:complexType><xs:sequence><xs:element name="RAT_ID" type="xs:int" /><xs:element name="RAT_DESC"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="RAT_ISARCHIVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_RATING" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:Rating" /><xs:field xpath="mstns:RAT_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<RatingDataSet xmlns="http://localhost/BVWebService/xsd/LoadRatingDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<Rating>
				<xsl:attribute name="diffgr:id">Rating<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<RAT_ID><xsl:value-of select="@RAT_ID" /></RAT_ID>
					<RAT_DESC><xsl:value-of select="@RAT_DESC" /></RAT_DESC>
					<xsl:if test="@RAT_ISARCHIVED != ''">
						<RAT_ISARCHIVED><xsl:value-of select="@RAT_ISARCHIVED" /></RAT_ISARCHIVED>
					</xsl:if>
				</Rating>
			</xsl:for-each>
		</RatingDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
