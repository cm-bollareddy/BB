<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="ValidateEpisodeSlateDataSet" targetNamespace="http://localhost/BVWebService/xsd/ValidateEpisodeSlateDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/ValidateEpisodeSlateDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/ValidateEpisodeSlateDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="ValidateEpisodeSlateDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="MASTER"><xs:complexType><xs:sequence><xs:element name="EPISODESLATE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PROGRAMTITLE"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="EPISODETITLE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ISARCHIVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<ValidateEpisodeSlateDataSet xmlns="http://localhost/BVWebService/xsd/ValidateEpisodeSlateDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<MASTER>
				<xsl:attribute name="diffgr:id">MASTER<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<xsl:if test="@EPISODESLATE != ''">
						<EPISODESLATE><xsl:value-of select="@EPISODESLATE" /></EPISODESLATE>
					</xsl:if>
					<PROGRAMTITLE><xsl:value-of select="@PROGRAMTITLE" /></PROGRAMTITLE>
					<xsl:if test="@EPISODETITLE != ''">
						<EPISODETITLE><xsl:value-of select="@EPISODETITLE" /></EPISODETITLE>
					</xsl:if>
					<xsl:if test="@ISARCHIVED != ''">
						<ISARCHIVED><xsl:value-of select="@ISARCHIVED" /></ISARCHIVED>
					</xsl:if>
				</MASTER>
			</xsl:for-each>
		</ValidateEpisodeSlateDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
