<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="AlliantContractModelsDataSet" targetNamespace="http://localhost/BVWebService/xsd/LoadAlliantContractModelsDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/LoadAlliantContractModelsDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/LoadAlliantContractModelsDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="AlliantContractModelsDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="ALLIANTCONTRACTMODEL"><xs:complexType><xs:sequence><xs:element name="ACM_ID" type="xs:int" /><xs:element name="ACM_DESC"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ACM_CODE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="34" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ACM_ISARCHIVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_ALLIANTCONTRACTMODEL" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:ALLIANTCONTRACTMODEL" /><xs:field xpath="mstns:ACM_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<AlliantContractModelsDataSet xmlns="http://localhost/BVWebService/xsd/LoadAlliantContractModelsDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<ALLIANTCONTRACTMODEL>
				<xsl:attribute name="diffgr:id">ALLIANTCONTRACTMODEL<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<ACM_ID><xsl:value-of select="@ACM_ID" /></ACM_ID>
					<ACM_DESC><xsl:value-of select="@ACM_DESC" /></ACM_DESC>
					<xsl:if test="@ACM_CODE != ''">
						<ACM_CODE><xsl:value-of select="@ACM_CODE" /></ACM_CODE>
					</xsl:if>
					<xsl:if test="@ACM_ISARCHIVED != ''">
						<ACM_ISARCHIVED><xsl:value-of select="@ACM_ISARCHIVED" /></ACM_ISARCHIVED>
					</xsl:if>
				</ALLIANTCONTRACTMODEL>
			</xsl:for-each>
		</AlliantContractModelsDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
