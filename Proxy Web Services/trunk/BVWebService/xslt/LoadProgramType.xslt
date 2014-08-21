<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="ProgramTypeDataSet" targetNamespace="http://localhost/BVWebService/xsd/LoadProgramTypeDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/LoadProgramTypeDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/LoadProgramTypeDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="ProgramTypeDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="ProgramType"><xs:complexType><xs:sequence><xs:element name="ACA_ID" type="xs:int" /><xs:element name="ACA_DESC"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ACA_ISARCHIVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_PROGRAMTYPE" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:ProgramType" /><xs:field xpath="mstns:ACA_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<ProgramTypeDataSet xmlns="http://localhost/BVWebService/xsd/LoadProgramTypeDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<ProgramType>
				<xsl:attribute name="diffgr:id">ProgramType<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<ACA_ID><xsl:value-of select="@ACA_ID" /></ACA_ID>
					<ACA_DESC><xsl:value-of select="@ACA_DESC" /></ACA_DESC>
					<xsl:if test="@ACA_ISARCHIVED != ''">
						<ACA_ISARCHIVED><xsl:value-of select="@ACA_ISARCHIVED" /></ACA_ISARCHIVED>
					</xsl:if>
				</ProgramType>
			</xsl:for-each>
		</ProgramTypeDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
