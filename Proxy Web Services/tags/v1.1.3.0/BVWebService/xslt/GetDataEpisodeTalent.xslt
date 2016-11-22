<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="EpisodeTalentDataSet" targetNamespace="http://localhost/BVWebService/xsd/EpisodeTalentDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/EpisodeTalentDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/EpisodeTalentDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="EpisodeTalentDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="EPISODETALENT"><xs:complexType><xs:sequence><xs:element name="ASS_ID" type="xs:int" /><xs:element name="TAL_ID" type="xs:int" /><xs:element name="TRO_ID" type="xs:int" /><xs:element name="ASS_TAL_DESC" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_EPISODETALENT" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:EPISODETALENT" /><xs:field xpath="mstns:ASS_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<EpisodeTalentDataSet xmlns="http://localhost/BVWebService/xsd/EpisodeTalentDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<EPISODETALENT>
				<xsl:attribute name="diffgr:id">EPISODETALENT<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<ASS_ID><xsl:value-of select="@ASS_ID" /></ASS_ID>
					<TAL_ID><xsl:value-of select="@TAL_ID" /></TAL_ID>
					<TRO_ID><xsl:value-of select="@TRO_ID" /></TRO_ID>
					<xsl:if test="@ASS_TAL_DESC != ''">
						<ASS_TAL_DESC><xsl:value-of select="@ASS_TAL_DESC" /></ASS_TAL_DESC>
					</xsl:if>
				</EPISODETALENT>
			</xsl:for-each>
		</EpisodeTalentDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
