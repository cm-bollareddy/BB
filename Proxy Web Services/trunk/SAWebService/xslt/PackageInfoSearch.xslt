<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="DataSet" targetNamespace="http://localhost/SAWebService/PackageInfoSearchDataSet.xsd" xmlns:mstns="http://localhost/SAWebService/PackageInfoSearchDataSet.xsd" xmlns="http://localhost/SAWebService/PackageInfoSearchDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="DataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="PACKAGEINFO"><xs:complexType><xs:sequence><xs:element name="VER_ID" type="xs:int" /><xs:element name="PACKAGENUMBER" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PACKAGENAME" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PACKAGEDESCRIPTION" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="EPISODENO" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="EPISODETITLE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PACKAGETYPE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PACKAGEDURATION" msdata:ReadOnly="true" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PACKAGESTATUS" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MEDIASTATUS" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ISARCHIVED" msdata:ReadOnly="true" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="1" /></xs:restriction></xs:simpleType></xs:element><xs:element name="NOLACODE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ISCC" msdata:ReadOnly="true" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="1" /></xs:restriction></xs:simpleType></xs:element><xs:element name="CCLANGUAGE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ISDVI" msdata:ReadOnly="true" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="1" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DVILANGUAGE" msdata:ReadOnly="true" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="1" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ISSAP" msdata:ReadOnly="true" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="1" /></xs:restriction></xs:simpleType></xs:element><xs:element name="SAPLANGUAGE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASPECTRATIO" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ISBILLABLE" msdata:ReadOnly="true" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="1" /></xs:restriction></xs:simpleType></xs:element><xs:element name="BILLTO" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ISPLUSPROGRAM" msdata:ReadOnly="true" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="1" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ISNPSPROGRAM" msdata:ReadOnly="true" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="1" /></xs:restriction></xs:simpleType></xs:element></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<DataSet xmlns="http://localhost/SAWebService/PackageInfoSearchDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<PACKAGEINFO>
				<xsl:attribute name="diffgr:id">PACKAGEINFO<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<VER_ID><xsl:value-of select="@VER_ID" /></VER_ID>
					<xsl:if test="@PACKAGENUMBER != ''">
						<PACKAGENUMBER><xsl:value-of select="@PACKAGENUMBER" /></PACKAGENUMBER>
					</xsl:if>
					<xsl:if test="@PACKAGENAME != ''">
						<PACKAGENAME><xsl:value-of select="@PACKAGENAME" /></PACKAGENAME>
					</xsl:if>
					<xsl:if test="@PACKAGEDESCRIPTION != ''">
						<PACKAGEDESCRIPTION><xsl:value-of select="@PACKAGEDESCRIPTION" /></PACKAGEDESCRIPTION>
					</xsl:if>
					<xsl:if test="@EPISODENO != ''">
						<EPISODENO><xsl:value-of select="@EPISODENO" /></EPISODENO>
					</xsl:if>
					<xsl:if test="@EPISODETITLE != ''">
						<EPISODETITLE><xsl:value-of select="@EPISODETITLE" /></EPISODETITLE>
					</xsl:if>
					<xsl:if test="@PACKAGETYPE != ''">
						<PACKAGETYPE><xsl:value-of select="@PACKAGETYPE" /></PACKAGETYPE>
					</xsl:if>
					<xsl:if test="@PACKAGEDURATION != ''">
						<PACKAGEDURATION><xsl:value-of select="@PACKAGEDURATION" /></PACKAGEDURATION>
					</xsl:if>
					<xsl:if test="@PACKAGESTATUS != ''">
						<PACKAGESTATUS><xsl:value-of select="@PACKAGESTATUS" /></PACKAGESTATUS>
					</xsl:if>
					<xsl:if test="@MEDIASTATUS != ''">
						<MEDIASTATUS><xsl:value-of select="@MEDIASTATUS" /></MEDIASTATUS>
					</xsl:if>
					<xsl:if test="@ISARCHIVED != ''">
						<ISARCHIVED><xsl:value-of select="@ISARCHIVED" /></ISARCHIVED>
					</xsl:if>
					<xsl:if test="@NOLACODE != ''">
						<NOLACODE><xsl:value-of select="@NOLACODE" /></NOLACODE>
					</xsl:if>
					<xsl:if test="@ISCC != ''">
						<ISCC><xsl:value-of select="@ISCC" /></ISCC>
					</xsl:if>
					<xsl:if test="@CCLANGUAGE != ''">
						<CCLANGUAGE><xsl:value-of select="@CCLANGUAGE" /></CCLANGUAGE>
					</xsl:if>
					<xsl:if test="@ISDVI != ''">
						<ISDVI><xsl:value-of select="@ISDVI" /></ISDVI>
					</xsl:if>
					<xsl:if test="@DVILANGUAGE != ''">
						<DVILANGUAGE><xsl:value-of select="@DVILANGUAGE" /></DVILANGUAGE>
					</xsl:if>
					<xsl:if test="@ISSAP != ''">
						<ISSAP><xsl:value-of select="@ISSAP" /></ISSAP>
					</xsl:if>
					<xsl:if test="@SAPLANGUAGE != ''">
						<SAPLANGUAGE><xsl:value-of select="@SAPLANGUAGE" /></SAPLANGUAGE>
					</xsl:if>
					<xsl:if test="@ASPECTRATIO != ''">
						<ASPECTRATIO><xsl:value-of select="@ASPECTRATIO" /></ASPECTRATIO>
					</xsl:if>
					<xsl:if test="@ISBILLABLE != ''">
						<ISBILLABLE><xsl:value-of select="@ISBILLABLE" /></ISBILLABLE>
					</xsl:if>
					<xsl:if test="@BILLTO != ''">
						<BILLTO><xsl:value-of select="@BILLTO" /></BILLTO>
					</xsl:if>
					<xsl:if test="@ISPLUSPROGRAM != ''">
						<ISPLUSPROGRAM><xsl:value-of select="@ISPLUSPROGRAM" /></ISPLUSPROGRAM>
					</xsl:if>
					<xsl:if test="@ISNPSPROGRAM != ''">
						<ISNPSPROGRAM><xsl:value-of select="@ISNPSPROGRAM" /></ISNPSPROGRAM>
					</xsl:if>
				</PACKAGEINFO>
			</xsl:for-each>
		</DataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
