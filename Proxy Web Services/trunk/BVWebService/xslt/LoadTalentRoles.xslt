<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="TalentRolesDataSet" targetNamespace="http://localhost/BVWebService/LoadTalentRolesDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/LoadTalentRolesDataSet.xsd" xmlns="http://localhost/BVWebService/LoadTalentRolesDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="TalentRolesDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="TALENTROLES"><xs:complexType><xs:sequence><xs:element name="TRO_ID" type="xs:int" /><xs:element name="TRO_CODE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="3" /></xs:restriction></xs:simpleType></xs:element><xs:element name="TRO_DESC" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="TRO_ISARCHIVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_TALENTROLES" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:TALENTROLES" /><xs:field xpath="mstns:TRO_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<TalentRolesDataSet xmlns="http://localhost/BVWebService/LoadTalentRolesDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<TALENTROLES>
				<xsl:attribute name="diffgr:id">TALENTROLES<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<TRO_ID><xsl:value-of select="@TRO_ID" /></TRO_ID>
					<xsl:if test="@TRO_CODE != ''">
						<TRO_CODE><xsl:value-of select="@TRO_CODE" /></TRO_CODE>
					</xsl:if>
					<xsl:if test="@TRO_DESC != ''">
						<TRO_DESC><xsl:value-of select="@TRO_DESC" /></TRO_DESC>
					</xsl:if>
					<xsl:if test="@TRO_ISARCHIVED != ''">
						<TRO_ISARCHIVED><xsl:value-of select="@TRO_ISARCHIVED" /></TRO_ISARCHIVED>
					</xsl:if>
				</TALENTROLES>
			</xsl:for-each>
		</TalentRolesDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
