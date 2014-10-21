<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="DataSet" targetNamespace="http://localhost/SAWebService/MediaInfoSearchDataSet.xsd" xmlns:mstns="http://localhost/SAWebService/MediaInfoSearchDataSet.xsd" xmlns="http://localhost/SAWebService/MediaInfoSearchDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="DataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="MEDIAINFO"><xs:complexType><xs:sequence><xs:element name="MEIR_ID" type="xs:int" /><xs:element name="REVISIONHOUSENUMBER" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="RECORDHOUSENUMBER" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DESCRIPTION"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="EPISODENO" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="EPISODETITLE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PACKAGETYPE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MEDIAFORMAT" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MEDIAFORMATTYPE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MEDIAINVENTORYTYPE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DURATION" msdata:ReadOnly="true" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PERMANENTLOCATION" msdata:ReadOnly="true" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="1" /></xs:restriction></xs:simpleType></xs:element><xs:element name="CURRENTLOCATION" msdata:ReadOnly="true" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="1" /></xs:restriction></xs:simpleType></xs:element><xs:element name="NOLACODE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ISCC" msdata:ReadOnly="true" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="1" /></xs:restriction></xs:simpleType></xs:element><xs:element name="CCLANGUAGE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="CCCOORDINATOR" msdata:ReadOnly="true" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="5" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ISDVI" msdata:ReadOnly="true" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="1" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DVILANGUAGE" msdata:ReadOnly="true" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="1" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DVICOORDINATOR" msdata:ReadOnly="true" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="5" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ISSAP" msdata:ReadOnly="true" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="1" /></xs:restriction></xs:simpleType></xs:element><xs:element name="SAPLANGUAGE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="SAPCOORDINATOR" msdata:ReadOnly="true" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="5" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASPECTRATIO" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="AUDIOTRACK1" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="AUDIOTRACK2" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="AUDIOTRACK3" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="AUDIOTRACK4" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ISBILLABLE" msdata:ReadOnly="true" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="1" /></xs:restriction></xs:simpleType></xs:element><xs:element name="BILLTO" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="REVISIONSTATUS1" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="REVISIONSTATUS2" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="REVISIONSTATUS3" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="REVISIONSTATUS4" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="AUDIOTYPE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<DataSet xmlns="http://localhost/SAWebService/MediaInfoSearchDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<MEDIAINFO>
				<xsl:attribute name="diffgr:id">MEDIAINFO<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<MEIR_ID><xsl:value-of select="@MEIR_ID" /></MEIR_ID>
					<xsl:if test="@REVISIONHOUSENUMBER != ''">
						<REVISIONHOUSENUMBER><xsl:value-of select="@REVISIONHOUSENUMBER" /></REVISIONHOUSENUMBER>
					</xsl:if>
					<xsl:if test="@RECORDHOUSENUMBER != ''">
						<RECORDHOUSENUMBER><xsl:value-of select="@RECORDHOUSENUMBER" /></RECORDHOUSENUMBER>
					</xsl:if>
					<DESCRIPTION><xsl:value-of select="@DESCRIPTION" /></DESCRIPTION>
					<xsl:if test="@EPISODENO != ''">
						<EPISODENO><xsl:value-of select="@EPISODENO" /></EPISODENO>
					</xsl:if>
					<xsl:if test="@EPISODETITLE != ''">
						<EPISODETITLE><xsl:value-of select="@EPISODETITLE" /></EPISODETITLE>
					</xsl:if>
					<xsl:if test="@PACKAGETYPE != ''">
						<PACKAGETYPE><xsl:value-of select="@PACKAGETYPE" /></PACKAGETYPE>
					</xsl:if>
					<xsl:if test="@MEDIAFORMAT != ''">
						<MEDIAFORMAT><xsl:value-of select="@MEDIAFORMAT" /></MEDIAFORMAT>
					</xsl:if>
					<xsl:if test="@MEDIAFORMATTYPE != ''">
						<MEDIAFORMATTYPE><xsl:value-of select="@MEDIAFORMATTYPE" /></MEDIAFORMATTYPE>
					</xsl:if>
					<xsl:if test="@MEDIAINVENTORYTYPE != ''">
						<MEDIAINVENTORYTYPE><xsl:value-of select="@MEDIAINVENTORYTYPE" /></MEDIAINVENTORYTYPE>
					</xsl:if>
					<xsl:if test="@DURATION != ''">
						<DURATION><xsl:value-of select="@DURATION" /></DURATION>
					</xsl:if>
					<xsl:if test="@PERMANENTLOCATION != ''">
						<PERMANENTLOCATION><xsl:value-of select="@PERMANENTLOCATION" /></PERMANENTLOCATION>
					</xsl:if>
					<xsl:if test="@CURRENTLOCATION != ''">
						<CURRENTLOCATION><xsl:value-of select="@CURRENTLOCATION" /></CURRENTLOCATION>
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
					<xsl:if test="@CCCOORDINATOR != ''">
						<CCCOORDINATOR><xsl:value-of select="@CCCOORDINATOR" /></CCCOORDINATOR>
					</xsl:if>
					<xsl:if test="@ISDVI != ''">
						<ISDVI><xsl:value-of select="@ISDVI" /></ISDVI>
					</xsl:if>
					<xsl:if test="@DVILANGUAGE != ''">
						<DVILANGUAGE><xsl:value-of select="@DVILANGUAGE" /></DVILANGUAGE>
					</xsl:if>
					<xsl:if test="@DVICOORDINATOR != ''">
						<DVICOORDINATOR><xsl:value-of select="@DVICOORDINATOR" /></DVICOORDINATOR>
					</xsl:if>
					<xsl:if test="@ISSAP != ''">
						<ISSAP><xsl:value-of select="@ISSAP" /></ISSAP>
					</xsl:if>
					<xsl:if test="@SAPLANGUAGE != ''">
						<SAPLANGUAGE><xsl:value-of select="@SAPLANGUAGE" /></SAPLANGUAGE>
					</xsl:if>
					<xsl:if test="@SAPCOORDINATOR != ''">
						<SAPCOORDINATOR><xsl:value-of select="@SAPCOORDINATOR" /></SAPCOORDINATOR>
					</xsl:if>
					<xsl:if test="@ASPECTRATIO != ''">
						<ASPECTRATIO><xsl:value-of select="@ASPECTRATIO" /></ASPECTRATIO>
					</xsl:if>
					<xsl:if test="@AUDIOTRACK1 != ''">
						<AUDIOTRACK1><xsl:value-of select="@AUDIOTRACK1" /></AUDIOTRACK1>
					</xsl:if>
					<xsl:if test="@AUDIOTRACK2 != ''">
						<AUDIOTRACK2><xsl:value-of select="@AUDIOTRACK2" /></AUDIOTRACK2>
					</xsl:if>
					<xsl:if test="@AUDIOTRACK3 != ''">
						<AUDIOTRACK3><xsl:value-of select="@AUDIOTRACK3" /></AUDIOTRACK3>
					</xsl:if>
					<xsl:if test="@AUDIOTRACK4 != ''">
						<AUDIOTRACK4><xsl:value-of select="@AUDIOTRACK4" /></AUDIOTRACK4>
					</xsl:if>
					<xsl:if test="@ISBILLABLE != ''">
						<ISBILLABLE><xsl:value-of select="@ISBILLABLE" /></ISBILLABLE>
					</xsl:if>
					<xsl:if test="@BILLTO != ''">
						<BILLTO><xsl:value-of select="@BILLTO" /></BILLTO>
					</xsl:if>
					<xsl:if test="@REVISIONSTATUS1 != ''">
						<REVISIONSTATUS1><xsl:value-of select="@REVISIONSTATUS1" /></REVISIONSTATUS1>
					</xsl:if>
					<xsl:if test="@REVISIONSTATUS2 != ''">
						<REVISIONSTATUS2><xsl:value-of select="@REVISIONSTATUS2" /></REVISIONSTATUS2>
					</xsl:if>
					<xsl:if test="@REVISIONSTATUS3 != ''">
						<REVISIONSTATUS3><xsl:value-of select="@REVISIONSTATUS3" /></REVISIONSTATUS3>
					</xsl:if>
					<xsl:if test="@REVISIONSTATUS4 != ''">
						<REVISIONSTATUS4><xsl:value-of select="@REVISIONSTATUS4" /></REVISIONSTATUS4>
					</xsl:if>
					<xsl:if test="@AUDIOTYPE != ''">
						<AUDIOTYPE><xsl:value-of select="@AUDIOTYPE" /></AUDIOTYPE>
					</xsl:if>
				</MEDIAINFO>
			</xsl:for-each>
		</DataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
