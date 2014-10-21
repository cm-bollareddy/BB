<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="DealSearchDataSet" targetNamespace="http://localhost/BVWebService/xsd/DealSearchDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/DealSearchDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/DealSearchDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="DealSearchDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="DealSearch"><xs:complexType><xs:sequence><xs:element name="DEA_ID" type="xs:int" /><xs:element name="DEA_DESC"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PRESENTERID" msdata:ReadOnly="true" type="xs:int" minOccurs="0" /><xs:element name="MDL_SEASON" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_PBSDS_ID" type="xs:int" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_DEALSEARCH" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:DealSearch" /><xs:field xpath="mstns:DEA_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<DealSearchDataSet xmlns="http://localhost/BVWebService/xsd/DealSearchDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<DealSearch>
				<xsl:attribute name="diffgr:id">DealSearch<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<DEA_ID><xsl:value-of select="@DEA_ID" /></DEA_ID>
					<DEA_DESC><xsl:value-of select="@DEA_DESC" /></DEA_DESC>
					<xsl:if test="@PRESENTERID != ''">
						<PRESENTERID><xsl:value-of select="@PRESENTERID" /></PRESENTERID>
					</xsl:if>
					<xsl:if test="@MDL_SEASON != ''">
						<MDL_SEASON><xsl:value-of select="@MDL_SEASON" /></MDL_SEASON>
					</xsl:if>
					<xsl:if test="@DEA_PBSDS_ID != ''">
						<DEA_PBSDS_ID><xsl:value-of select="@DEA_PBSDS_ID" /></DEA_PBSDS_ID>
					</xsl:if>
				</DealSearch>
			</xsl:for-each>
		</DealSearchDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
