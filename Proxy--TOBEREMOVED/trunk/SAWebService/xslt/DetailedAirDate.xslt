<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="DetailedAirDateDataSet" targetNamespace="http://localhost/SAWebService/DetailedAirDateDataSet.xsd" xmlns:mstns="http://localhost/SAWebService/DetailedAirDateDataSet.xsd" xmlns="http://localhost/SAWebService/DetailedAirDateDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="DetailedAirDateDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="MASTER"><xs:complexType><xs:sequence><xs:element name="FIRSTAIRDATE" type="xs:dateTime" minOccurs="0" /><xs:element name="NEXTAIRDATE" type="xs:dateTime" minOccurs="0" /><xs:element name="MEDIAARRIVALDATE" type="xs:dateTime" minOccurs="0" /><xs:element name="FEEDDISTRIBUTORID" type="xs:int" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<DetailedAirDateDataSet xmlns="http://localhost/SAWebService/DetailedAirDateDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<MASTER>
				<xsl:attribute name="diffgr:id">MASTER<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<xsl:if test="@FIRSTAIRDATE != ''">
						<FIRSTAIRDATE>
							<xsl:call-template name="DateConverter">
								<xsl:with-param name="InDate"><xsl:value-of select="@FIRSTAIRDATE" /></xsl:with-param>
							</xsl:call-template>
						</FIRSTAIRDATE>
					</xsl:if>
					<xsl:if test="@NEXTAIRDATE != ''">
						<NEXTAIRDATE>
							<xsl:call-template name="DateConverter">
								<xsl:with-param name="InDate"><xsl:value-of select="@NEXTAIRDATE" /></xsl:with-param>
							</xsl:call-template>
						</NEXTAIRDATE>
					</xsl:if>
					<xsl:if test="@MEDIAARRIVALDATE != ''">
						<MEDIAARRIVALDATE>
							<xsl:call-template name="DateConverter">
								<xsl:with-param name="InDate"><xsl:value-of select="@MEDIAARRIVALDATE" /></xsl:with-param>
							</xsl:call-template>
						</MEDIAARRIVALDATE>
					</xsl:if>
					<xsl:if test="@FEEDDISTRIBUTORID != ''">
						<FEEDDISTRIBUTORID><xsl:value-of select="@FEEDDISTRIBUTORID" /></FEEDDISTRIBUTORID>
					</xsl:if>
				</MASTER>
			</xsl:for-each>
		</DetailedAirDateDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
