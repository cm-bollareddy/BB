<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="FunderDataSet" targetNamespace="http://localhost/BVWebService/xsd/LoadFundersDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/LoadFundersDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/LoadFundersDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="FunderDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="Funders"><xs:complexType><xs:sequence><xs:element name="COM_ID" type="xs:int" /><xs:element name="COM_NAME"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="COM_ADDRESSLINE1" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="COM_ADDRESSLINE2" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="COM_ADDRESSLINE3" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="COM_CITY" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="COM_PROVINCE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="COM_POSTALCODE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="COM_COUNTRY" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="COM_PHONE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="COM_FAX" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="COM_NAMESHORT" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="COM_ISARCHIVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_FUNDER" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:Funders" /><xs:field xpath="mstns:COM_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<FunderDataSet xmlns="http://localhost/BVWebService/xsd/LoadFundersDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<Funders>
				<xsl:attribute name="diffgr:id">Funders<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<COM_ID><xsl:value-of select="@COM_ID" /></COM_ID>
					<COM_NAME><xsl:value-of select="@COM_NAME" /></COM_NAME>
					<xsl:if test="@COM_ADDRESSLINE1 != ''">
						<COM_ADDRESSLINE1><xsl:value-of select="@COM_ADDRESSLINE1" /></COM_ADDRESSLINE1>
					</xsl:if>
					<xsl:if test="@COM_ADDRESSLINE2 != ''">
						<COM_ADDRESSLINE2><xsl:value-of select="@COM_ADDRESSLINE2" /></COM_ADDRESSLINE2>
					</xsl:if>
					<xsl:if test="@COM_ADDRESSLINE3 != ''">
						<COM_ADDRESSLINE3><xsl:value-of select="@COM_ADDRESSLINE3" /></COM_ADDRESSLINE3>
					</xsl:if>
					<xsl:if test="@COM_CITY != ''">
						<COM_CITY><xsl:value-of select="@COM_CITY" /></COM_CITY>
					</xsl:if>
					<xsl:if test="@COM_PROVINCE != ''">
						<COM_PROVINCE><xsl:value-of select="@COM_PROVINCE" /></COM_PROVINCE>
					</xsl:if>
					<xsl:if test="@COM_POSTALCODE != ''">
						<COM_POSTALCODE><xsl:value-of select="@COM_POSTALCODE" /></COM_POSTALCODE>
					</xsl:if>
					<xsl:if test="@COM_COUNTRY != ''">
						<COM_COUNTRY><xsl:value-of select="@COM_COUNTRY" /></COM_COUNTRY>
					</xsl:if>
					<xsl:if test="@COM_PHONE != ''">
						<COM_PHONE><xsl:value-of select="@COM_PHONE" /></COM_PHONE>
					</xsl:if>
					<xsl:if test="@COM_FAX != ''">
						<COM_FAX><xsl:value-of select="@COM_FAX" /></COM_FAX>
					</xsl:if>
					<xsl:if test="@COM_NAMESHORT != ''">
						<COM_NAMESHORT><xsl:value-of select="@COM_NAMESHORT" /></COM_NAMESHORT>
					</xsl:if>
					<xsl:if test="@COM_ISARCHIVED != ''">
						<COM_ISARCHIVED><xsl:value-of select="@COM_ISARCHIVED" /></COM_ISARCHIVED>
					</xsl:if>
				</Funders>
			</xsl:for-each>
		</FunderDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
