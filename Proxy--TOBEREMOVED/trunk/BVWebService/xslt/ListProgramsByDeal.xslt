<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="ProgramsByDealDataSet" targetNamespace="http://localhost/BVWebService/xsd/ListProgramsByDealDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/ListProgramsByDealDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/ListProgramsByDealDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="ProgramsByDealDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="ASSET"><xs:complexType><xs:sequence><xs:element name="ASS_ID" type="xs:int" /><xs:element name="ASS_EPISODENUMBER" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_TITLE"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_EPISODETITLE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_EPISODESLATE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_PMC_ID" type="xs:int" minOccurs="0" /><xs:element name="ASS_PVA_ID" type="xs:int" minOccurs="0" /><xs:element name="ASS_ISARCHIVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element><xs:element name="VERSION"><xs:complexType><xs:sequence><xs:element name="VER_ID" type="xs:int" /><xs:element name="VER_ASS_ID" type="xs:int" /><xs:element name="VER_VET_ID" type="xs:int" /><xs:element name="VER_SLATE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="VER_PFS_ID" type="xs:int" minOccurs="0" /><xs:element name="VER_PIWT_ID" type="xs:int" minOccurs="0" /><xs:element name="VER_POAC_ID" type="xs:int" minOccurs="0" /><xs:element name="VER_PUCC_ID" type="xs:int" minOccurs="0" /><xs:element name="VER_PACKAGEHOUSE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="VER_PACKAGENUMBER" type="xs:int" minOccurs="0" /><xs:element name="VER_REVISIONNO" type="xs:short" minOccurs="0" /><xs:element name="DCO_OBDATE" msdata:ReadOnly="true" type="xs:dateTime" minOccurs="0" /><xs:element name="VER_ISARCHIVED" type="xs:short" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_ASSET" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:ASSET" /><xs:field xpath="mstns:ASS_ID" /></xs:unique><xs:unique name="PK_VERSION" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:VERSION" /><xs:field xpath="mstns:VER_ID" /></xs:unique><xs:keyref name="FK_ASSET_VERSION" refer="PK_ASSET"><xs:selector xpath=".//mstns:VERSION" /><xs:field xpath="mstns:VER_ASS_ID" /></xs:keyref></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<ProgramsByDealDataSet xmlns="http://localhost/BVWebService/xsd/ListProgramsByDealDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<xsl:variable name="PARENTID"><xsl:value-of select="position()"/></xsl:variable>
				<ASSET>
				<xsl:attribute name="diffgr:id">ASSET<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<ASS_ID><xsl:value-of select="@ASS_ID" /></ASS_ID>
					<xsl:if test="@ASS_EPISODENUMBER != ''">
						<ASS_EPISODENUMBER><xsl:value-of select="@ASS_EPISODENUMBER" /></ASS_EPISODENUMBER>
					</xsl:if>
					<ASS_TITLE><xsl:value-of select="@ASS_TITLE" /></ASS_TITLE>
					<xsl:if test="@ASS_EPISODETITLE != ''">
						<ASS_EPISODETITLE><xsl:value-of select="@ASS_EPISODETITLE" /></ASS_EPISODETITLE>
					</xsl:if>
					<xsl:if test="@ASS_EPISODESLATE != ''">
						<ASS_EPISODESLATE><xsl:value-of select="@ASS_EPISODESLATE" /></ASS_EPISODESLATE>
					</xsl:if>
					<xsl:if test="@ASS_PMC_ID != ''">
						<ASS_PMC_ID><xsl:value-of select="@ASS_PMC_ID" /></ASS_PMC_ID>
					</xsl:if>
					<xsl:if test="@ASS_PVA_ID != ''">
						<ASS_PVA_ID><xsl:value-of select="@ASS_PVA_ID" /></ASS_PVA_ID>
					</xsl:if>
					<xsl:if test="@ASS_ISARCHIVED != ''">
						<ASS_ISARCHIVED><xsl:value-of select="@ASS_ISARCHIVED" /></ASS_ISARCHIVED>
					</xsl:if>
				</ASSET>
				<xsl:for-each select="VERSION/ROWVERSION">
					<VERSION>
					<xsl:attribute name="diffgr:id">VERSION<xsl:value-of select="position()" /></xsl:attribute>
					<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="($PARENTID*10000) + position()" /></xsl:attribute>
						<VER_ID><xsl:value-of select="@VER_ID" /></VER_ID>
						<VER_ASS_ID><xsl:value-of select="@VER_ASS_ID" /></VER_ASS_ID>
						<VER_VET_ID><xsl:value-of select="@VER_VET_ID" /></VER_VET_ID>
						<xsl:if test="@VER_SLATE != ''">
							<VER_SLATE><xsl:value-of select="@VER_SLATE" /></VER_SLATE>
						</xsl:if>
						<xsl:if test="@VER_PFS_ID != ''">
							<VER_PFS_ID><xsl:value-of select="@VER_PFS_ID" /></VER_PFS_ID>
						</xsl:if>
						<xsl:if test="@VER_PIWT_ID != ''">
							<VER_PIWT_ID><xsl:value-of select="@VER_PIWT_ID" /></VER_PIWT_ID>
						</xsl:if>
						<xsl:if test="@VER_POAC_ID != ''">
							<VER_POAC_ID><xsl:value-of select="@VER_POAC_ID" /></VER_POAC_ID>
						</xsl:if>
						<xsl:if test="@VER_PUCC_ID != ''">
							<VER_PUCC_ID><xsl:value-of select="@VER_PUCC_ID" /></VER_PUCC_ID>
						</xsl:if>
						<xsl:if test="@VER_PACKAGEHOUSE != ''">
							<VER_PACKAGEHOUSE><xsl:value-of select="@VER_PACKAGEHOUSE" /></VER_PACKAGEHOUSE>
						</xsl:if>
						<xsl:if test="@VER_PACKAGENUMBER != ''">
							<VER_PACKAGENUMBER><xsl:value-of select="@VER_PACKAGENUMBER" /></VER_PACKAGENUMBER>
						</xsl:if>
						<xsl:if test="@VER_REVISIONNO != ''">
							<VER_REVISIONNO><xsl:value-of select="@VER_REVISIONNO" /></VER_REVISIONNO>
						</xsl:if>
						<xsl:if test="@DCO_OBDATE != ''">
							<DCO_OBDATE>
								<xsl:call-template name="DateConverter">
									<xsl:with-param name="InDate"><xsl:value-of select="@DCO_OBDATE" /></xsl:with-param>
								</xsl:call-template>
							</DCO_OBDATE>
						</xsl:if>
						<VER_ISARCHIVED><xsl:value-of select="@VER_ISARCHIVED" /></VER_ISARCHIVED>
					</VERSION>
				</xsl:for-each>
			</xsl:for-each>
		</ProgramsByDealDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
