<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="AssetAppliesToRangeByTabDataSet" targetNamespace="http://localhost/BVWebService/xsd/AssetAppliesToRangeByTabDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/AssetAppliesToRangeByTabDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/AssetAppliesToRangeByTabDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="AssetAppliesToRangeByTabDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="ASSETAPPLIESTORANGE"><xs:complexType><xs:sequence><xs:element name="ASS_ID" type="xs:int" /><xs:element name="ASS_TITLE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_EPISODENUMBER" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_EPISODETITLE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="TABID" type="xs:int" /><xs:element name="TABTYPE"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="3" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEALID" msdata:ReadOnly="true" type="xs:int" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_ASSETAPPLIESTORANGE" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:ASSETAPPLIESTORANGE" /><xs:field xpath="mstns:ASS_ID" /><xs:field xpath="mstns:TABID" /><xs:field xpath="mstns:TABTYPE" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<AssetAppliesToRangeByTabDataSet xmlns="http://localhost/BVWebService/xsd/AssetAppliesToRangeByTabDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<ASSETAPPLIESTORANGE>
				<xsl:attribute name="diffgr:id">ASSETAPPLIESTORANGE<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<ASS_ID><xsl:value-of select="@ASS_ID" /></ASS_ID>
					<xsl:if test="@ASS_TITLE != ''">
						<ASS_TITLE><xsl:value-of select="@ASS_TITLE" /></ASS_TITLE>
					</xsl:if>
					<xsl:if test="@ASS_EPISODENUMBER != ''">
						<ASS_EPISODENUMBER><xsl:value-of select="@ASS_EPISODENUMBER" /></ASS_EPISODENUMBER>
					</xsl:if>
					<xsl:if test="@ASS_EPISODETITLE != ''">
						<ASS_EPISODETITLE><xsl:value-of select="@ASS_EPISODETITLE" /></ASS_EPISODETITLE>
					</xsl:if>
					<TABID><xsl:value-of select="@TABID" /></TABID>
					<TABTYPE><xsl:value-of select="@TABTYPE" /></TABTYPE>
					<xsl:if test="@DEALID != ''">
						<DEALID><xsl:value-of select="@DEALID" /></DEALID>
					</xsl:if>
				</ASSETAPPLIESTORANGE>
			</xsl:for-each>
		</AssetAppliesToRangeByTabDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
