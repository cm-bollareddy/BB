<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="ProgramSearchDataSet" targetNamespace="http://localhost/BVWebService/xsd/ProgramSearchDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/ProgramSearchDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/ProgramSearchDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="ProgramSearchDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="ProgramSearch"><xs:complexType><xs:sequence><xs:element name="ASS_ID" type="xs:int" /><xs:element name="ASS_EPISODESEASON" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_TITLE"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_EPISODETITLE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_EPISODESLATE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PRODUCERID" msdata:ReadOnly="true" type="xs:int" minOccurs="0" /><xs:element name="PRESENTERID" msdata:ReadOnly="true" type="xs:int" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_PROGRAMSEARCH" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:ProgramSearch" /><xs:field xpath="mstns:ASS_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<ProgramSearchDataSet xmlns="http://localhost/BVWebService/xsd/ProgramSearchDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<ProgramSearch>
				<xsl:attribute name="diffgr:id">ProgramSearch<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<ASS_ID><xsl:value-of select="@ASS_ID" /></ASS_ID>
					<xsl:if test="@ASS_EPISODESEASON != ''">
						<ASS_EPISODESEASON><xsl:value-of select="@ASS_EPISODESEASON" /></ASS_EPISODESEASON>
					</xsl:if>
					<ASS_TITLE><xsl:value-of select="@ASS_TITLE" /></ASS_TITLE>
					<xsl:if test="@ASS_EPISODETITLE != ''">
						<ASS_EPISODETITLE><xsl:value-of select="@ASS_EPISODETITLE" /></ASS_EPISODETITLE>
					</xsl:if>
					<xsl:if test="@ASS_EPISODESLATE != ''">
						<ASS_EPISODESLATE><xsl:value-of select="@ASS_EPISODESLATE" /></ASS_EPISODESLATE>
					</xsl:if>
					<xsl:if test="@PRODUCERID != ''">
						<PRODUCERID><xsl:value-of select="@PRODUCERID" /></PRODUCERID>
					</xsl:if>
					<xsl:if test="@PRESENTERID != ''">
						<PRESENTERID><xsl:value-of select="@PRESENTERID" /></PRESENTERID>
					</xsl:if>
				</ProgramSearch>
			</xsl:for-each>
		</ProgramSearchDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
