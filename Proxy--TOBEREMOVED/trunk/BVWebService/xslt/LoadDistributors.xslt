<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="DistributorsDataSet" targetNamespace="http://localhost/BVWebService/LoadDistributorsDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/LoadDistributorsDataSet.xsd" xmlns="http://localhost/BVWebService/LoadDistributorsDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="DistributorsDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="Distributors"><xs:complexType><xs:sequence><xs:element name="PBSFDS_ID" type="xs:int" /><xs:element name="PBSFDS_CODE"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="6" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PBSFDS_DESC" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PBSFDS_ISPBSDISTRIBUTOR" type="xs:short" minOccurs="0" /><xs:element name="PBSFDS_ISARCHIVED" type="xs:short" minOccurs="0" /><xs:element name="PBSFDS_OPERATINGUNIT" type="xs:int" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_MASTER" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:Distributors" /><xs:field xpath="mstns:PBSFDS_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<DistributorsDataSet xmlns="http://localhost/BVWebService/LoadDistributorsDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<Distributors>
				<xsl:attribute name="diffgr:id">Distributors<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<PBSFDS_ID><xsl:value-of select="@PBSFDS_ID" /></PBSFDS_ID>
					<PBSFDS_CODE><xsl:value-of select="@PBSFDS_CODE" /></PBSFDS_CODE>
					<xsl:if test="@PBSFDS_DESC != ''">
						<PBSFDS_DESC><xsl:value-of select="@PBSFDS_DESC" /></PBSFDS_DESC>
					</xsl:if>
					<xsl:if test="@PBSFDS_ISPBSDISTRIBUTOR != ''">
						<PBSFDS_ISPBSDISTRIBUTOR><xsl:value-of select="@PBSFDS_ISPBSDISTRIBUTOR" /></PBSFDS_ISPBSDISTRIBUTOR>
					</xsl:if>
					<xsl:if test="@PBSFDS_ISARCHIVED != ''">
						<PBSFDS_ISARCHIVED><xsl:value-of select="@PBSFDS_ISARCHIVED" /></PBSFDS_ISARCHIVED>
					</xsl:if>
					<xsl:if test="@PBSFDS_OPERATINGUNIT != ''">
						<PBSFDS_OPERATINGUNIT><xsl:value-of select="@PBSFDS_OPERATINGUNIT" /></PBSFDS_OPERATINGUNIT>
					</xsl:if>
				</Distributors>
			</xsl:for-each>
		</DistributorsDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
