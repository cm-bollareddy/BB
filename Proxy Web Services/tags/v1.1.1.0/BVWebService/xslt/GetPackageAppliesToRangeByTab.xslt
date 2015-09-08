<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="PackageAppliesToRangeByTabDataSet" targetNamespace="http://localhost/BVWebService/xsd/PackageAppliesToRangeByTabDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/PackageAppliesToRangeByTabDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/PackageAppliesToRangeByTabDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="PackageAppliesToRangeByTabDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="PROGRAMS"><xs:complexType><xs:sequence><xs:element name="ASS_ID" type="xs:int" /><xs:element name="ASS_TITLE"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_EPISODENUMBER" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_EPISODETITLE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element></xs:sequence></xs:complexType></xs:element><xs:element name="VW_VERSIONAPPLIESTORANGE"><xs:complexType><xs:sequence><xs:element name="VER_ID" type="xs:int" /><xs:element name="VER_ASS_ID" type="xs:int" minOccurs="0" /><xs:element name="TABID" type="xs:int" /><xs:element name="TABTYPE"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="3" /></xs:restriction></xs:simpleType></xs:element><xs:element name="IS_APPROVED" type="xs:short" minOccurs="0" /><xs:element name="PACKAGE_MEDIA_STATUS" type="xs:int" minOccurs="0" /><xs:element name="PACKAGE_TYPE" type="xs:int" minOccurs="0" /><xs:element name="PACKAGE_REVISION_NUMBER" type="xs:short" minOccurs="0" /><xs:element name="IS_UPDATEABLE" type="xs:short" minOccurs="0" /><xs:element name="PACKAGE_HOUSENUMBER" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEALID" msdata:ReadOnly="true" type="xs:int" minOccurs="0" /><xs:element name="VIDEO_FORMAT" msdata:ReadOnly="true" type="xs:int" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_PROGRAMS" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:PROGRAMS" /><xs:field xpath="mstns:ASS_ID" /></xs:unique><xs:unique name="PK_VW_VERSIONAPPLIESTORANGE" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:VW_VERSIONAPPLIESTORANGE" /><xs:field xpath="mstns:VER_ID" /><xs:field xpath="mstns:TABID" /><xs:field xpath="mstns:TABTYPE" /></xs:unique><xs:keyref name="FK_PROGRAMS_VW_VERSIONAPPLIESTORANGE" refer="PK_PROGRAMS"><xs:selector xpath=".//mstns:VW_VERSIONAPPLIESTORANGE" /><xs:field xpath="mstns:VER_ASS_ID" /></xs:keyref></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<PackageAppliesToRangeByTabDataSet xmlns="http://localhost/BVWebService/xsd/PackageAppliesToRangeByTabDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<xsl:variable name="PARENTID"><xsl:value-of select="position()"/></xsl:variable>
				<PROGRAMS>
				<xsl:attribute name="diffgr:id">PROGRAMS<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<ASS_ID><xsl:value-of select="@ASS_ID" /></ASS_ID>
					<ASS_TITLE><xsl:value-of select="@ASS_TITLE" /></ASS_TITLE>
					<xsl:if test="@ASS_EPISODENUMBER != ''">
						<ASS_EPISODENUMBER><xsl:value-of select="@ASS_EPISODENUMBER" /></ASS_EPISODENUMBER>
					</xsl:if>
					<xsl:if test="@ASS_EPISODETITLE != ''">
						<ASS_EPISODETITLE><xsl:value-of select="@ASS_EPISODETITLE" /></ASS_EPISODETITLE>
					</xsl:if>
				</PROGRAMS>
				<xsl:for-each select="VW_VERSIONAPPLIESTORANGE/ROWVW_VERSIONAPPLIESTORANGE">
					<VW_VERSIONAPPLIESTORANGE>
					<xsl:attribute name="diffgr:id">VW_VERSIONAPPLIESTORANGE<xsl:value-of select="position()" /></xsl:attribute>
					<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="($PARENTID*10000) + position()" /></xsl:attribute>
						<VER_ID><xsl:value-of select="@VER_ID" /></VER_ID>
						<xsl:if test="@VER_ASS_ID != ''">
							<VER_ASS_ID><xsl:value-of select="@VER_ASS_ID" /></VER_ASS_ID>
						</xsl:if>
						<TABID><xsl:value-of select="@TABID" /></TABID>
						<TABTYPE><xsl:value-of select="@TABTYPE" /></TABTYPE>
						<xsl:if test="@IS_APPROVED != ''">
							<IS_APPROVED><xsl:value-of select="@IS_APPROVED" /></IS_APPROVED>
						</xsl:if>
						<xsl:if test="@PACKAGE_MEDIA_STATUS != ''">
							<PACKAGE_MEDIA_STATUS><xsl:value-of select="@PACKAGE_MEDIA_STATUS" /></PACKAGE_MEDIA_STATUS>
						</xsl:if>
						<xsl:if test="@PACKAGE_TYPE != ''">
							<PACKAGE_TYPE><xsl:value-of select="@PACKAGE_TYPE" /></PACKAGE_TYPE>
						</xsl:if>
						<xsl:if test="@PACKAGE_REVISION_NUMBER != ''">
							<PACKAGE_REVISION_NUMBER><xsl:value-of select="@PACKAGE_REVISION_NUMBER" /></PACKAGE_REVISION_NUMBER>
						</xsl:if>
						<xsl:if test="@IS_UPDATEABLE != ''">
							<IS_UPDATEABLE><xsl:value-of select="@IS_UPDATEABLE" /></IS_UPDATEABLE>
						</xsl:if>
						<xsl:if test="@PACKAGE_HOUSENUMBER != ''">
							<PACKAGE_HOUSENUMBER><xsl:value-of select="@PACKAGE_HOUSENUMBER" /></PACKAGE_HOUSENUMBER>
						</xsl:if>
						<xsl:if test="@DEALID != ''">
							<DEALID><xsl:value-of select="@DEALID" /></DEALID>
						</xsl:if>
						<xsl:if test="@VIDEO_FORMAT != ''">
							<VIDEO_FORMAT><xsl:value-of select="@VIDEO_FORMAT" /></VIDEO_FORMAT>
						</xsl:if>
					</VW_VERSIONAPPLIESTORANGE>
				</xsl:for-each>
			</xsl:for-each>
		</PackageAppliesToRangeByTabDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
