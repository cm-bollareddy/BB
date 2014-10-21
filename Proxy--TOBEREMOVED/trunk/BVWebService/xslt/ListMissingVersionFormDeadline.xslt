<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="MissingVersionFormDeadlineDataSet" targetNamespace="http://localhost/BVWebService/xsd/ListMissingVersionFormDeadlineDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/ListMissingVersionFormDeadlineDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/ListMissingVersionFormDeadlineDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="MissingVersionFormDeadlineDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="VERSION_DEADLINE_TEMP"><xs:complexType><xs:sequence><xs:element name="DEA_ID" type="xs:int" minOccurs="0" /><xs:element name="DEA_DESC" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_ID" type="xs:int" minOccurs="0" /><xs:element name="ASS_TITLE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_EPISODETITLE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_EPISODESLATE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="VER_ID" type="xs:int" /><xs:element name="VER_REVISIONNO" type="xs:short" minOccurs="0" /><xs:element name="VER_VET_ID" type="xs:int" minOccurs="0" /><xs:element name="PREMIEREDATETIME" type="xs:dateTime" minOccurs="0" /><xs:element name="TABTYPE"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="3" /></xs:restriction></xs:simpleType></xs:element></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_VERSION_DEADLINE_TEMP" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:VERSION_DEADLINE_TEMP" /><xs:field xpath="mstns:VER_ID" /><xs:field xpath="mstns:TABTYPE" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<MissingVersionFormDeadlineDataSet xmlns="http://localhost/BVWebService/xsd/ListMissingVersionFormDeadlineDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<VERSION_DEADLINE_TEMP>
				<xsl:attribute name="diffgr:id">VERSION_DEADLINE_TEMP<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<xsl:if test="@DEA_ID != ''">
						<DEA_ID><xsl:value-of select="@DEA_ID" /></DEA_ID>
					</xsl:if>
					<xsl:if test="@DEA_DESC != ''">
						<DEA_DESC><xsl:value-of select="@DEA_DESC" /></DEA_DESC>
					</xsl:if>
					<xsl:if test="@ASS_ID != ''">
						<ASS_ID><xsl:value-of select="@ASS_ID" /></ASS_ID>
					</xsl:if>
					<xsl:if test="@ASS_TITLE != ''">
						<ASS_TITLE><xsl:value-of select="@ASS_TITLE" /></ASS_TITLE>
					</xsl:if>
					<xsl:if test="@ASS_EPISODETITLE != ''">
						<ASS_EPISODETITLE><xsl:value-of select="@ASS_EPISODETITLE" /></ASS_EPISODETITLE>
					</xsl:if>
					<xsl:if test="@ASS_EPISODESLATE != ''">
						<ASS_EPISODESLATE><xsl:value-of select="@ASS_EPISODESLATE" /></ASS_EPISODESLATE>
					</xsl:if>
					<VER_ID><xsl:value-of select="@VER_ID" /></VER_ID>
					<xsl:if test="@VER_REVISIONNO != ''">
						<VER_REVISIONNO><xsl:value-of select="@VER_REVISIONNO" /></VER_REVISIONNO>
					</xsl:if>
					<xsl:if test="@VER_VET_ID != ''">
						<VER_VET_ID><xsl:value-of select="@VER_VET_ID" /></VER_VET_ID>
					</xsl:if>
					<xsl:if test="@PREMIEREDATETIME != ''">
						<PREMIEREDATETIME>
							<xsl:call-template name="DateConverter">
								<xsl:with-param name="InDate"><xsl:value-of select="@PREMIEREDATETIME" /></xsl:with-param>
							</xsl:call-template>
						</PREMIEREDATETIME>
					</xsl:if>
					<TABTYPE><xsl:value-of select="@TABTYPE" /></TABTYPE>
				</VERSION_DEADLINE_TEMP>
			</xsl:for-each>
		</MissingVersionFormDeadlineDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
