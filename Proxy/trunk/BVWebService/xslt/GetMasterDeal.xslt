<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="MasterDealDataSet" targetNamespace="http://localhost/BVWebService/xsd/MasterDealDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/MasterDealDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/MasterDealDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="MasterDealDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="MasterDeal"><xs:complexType><xs:sequence><xs:element name="MDL_ID" type="xs:int" /><xs:element name="MDL_DESC" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_MASTERDEAL" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:MasterDeal" /><xs:field xpath="mstns:MDL_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<MasterDealDataSet xmlns="http://localhost/BVWebService/xsd/MasterDealDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<MasterDeal>
				<xsl:attribute name="diffgr:id">MasterDeal<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<MDL_ID><xsl:value-of select="@MDL_ID" /></MDL_ID>
					<xsl:if test="@MDL_DESC != ''">
						<MDL_DESC><xsl:value-of select="@MDL_DESC" /></MDL_DESC>
					</xsl:if>
				</MasterDeal>
			</xsl:for-each>
		</MasterDealDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
