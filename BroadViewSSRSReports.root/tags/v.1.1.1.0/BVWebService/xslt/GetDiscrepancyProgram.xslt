<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="DiscrepancyProgramDataSet" targetNamespace="http://localhost/BVWebService/xsd/DiscrepancyProgramDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/DiscrepancyProgramDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/DiscrepancyProgramDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="DiscrepancyProgramDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="PACKAGEDETAIL"><xs:complexType><xs:sequence><xs:element name="DISCREPANCY_START" type="xs:dateTime" minOccurs="0" /><xs:element name="CHA_CODE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PACKAGE_ID" type="xs:int" minOccurs="0" /><xs:element name="PACKAGE_NUMBER" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PACKAGE_TITLE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PROGRAM_TITLE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="SERIES_TITLE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PROGRAM_EPISODETITLE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="SCHEDULED_DATETIME" type="xs:dateTime" minOccurs="0" /><xs:element name="SCHEDULED_DURATION" type="xs:int" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<DiscrepancyProgramDataSet xmlns="http://localhost/BVWebService/xsd/DiscrepancyProgramDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<PACKAGEDETAIL>
				<xsl:attribute name="diffgr:id">PACKAGEDETAIL<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<xsl:if test="@DISCREPANCY_START != ''">
						<DISCREPANCY_START>
							<xsl:call-template name="DateConverter">
								<xsl:with-param name="InDate"><xsl:value-of select="@DISCREPANCY_START" /></xsl:with-param>
							</xsl:call-template>
						</DISCREPANCY_START>
					</xsl:if>
					<xsl:if test="@CHA_CODE != ''">
						<CHA_CODE><xsl:value-of select="@CHA_CODE" /></CHA_CODE>
					</xsl:if>
					<xsl:if test="@PACKAGE_ID != ''">
						<PACKAGE_ID><xsl:value-of select="@PACKAGE_ID" /></PACKAGE_ID>
					</xsl:if>
					<xsl:if test="@PACKAGE_NUMBER != ''">
						<PACKAGE_NUMBER><xsl:value-of select="@PACKAGE_NUMBER" /></PACKAGE_NUMBER>
					</xsl:if>
					<xsl:if test="@PACKAGE_TITLE != ''">
						<PACKAGE_TITLE><xsl:value-of select="@PACKAGE_TITLE" /></PACKAGE_TITLE>
					</xsl:if>
					<xsl:if test="@PROGRAM_TITLE != ''">
						<PROGRAM_TITLE><xsl:value-of select="@PROGRAM_TITLE" /></PROGRAM_TITLE>
					</xsl:if>
					<xsl:if test="@SERIES_TITLE != ''">
						<SERIES_TITLE><xsl:value-of select="@SERIES_TITLE" /></SERIES_TITLE>
					</xsl:if>
					<xsl:if test="@PROGRAM_EPISODETITLE != ''">
						<PROGRAM_EPISODETITLE><xsl:value-of select="@PROGRAM_EPISODETITLE" /></PROGRAM_EPISODETITLE>
					</xsl:if>
					<xsl:if test="@SCHEDULED_DATETIME != ''">
						<SCHEDULED_DATETIME>
							<xsl:call-template name="DateConverter">
								<xsl:with-param name="InDate"><xsl:value-of select="@SCHEDULED_DATETIME" /></xsl:with-param>
							</xsl:call-template>
						</SCHEDULED_DATETIME>
					</xsl:if>
					<xsl:if test="@SCHEDULED_DURATION != ''">
						<SCHEDULED_DURATION><xsl:value-of select="@SCHEDULED_DURATION" /></SCHEDULED_DURATION>
					</xsl:if>
				</PACKAGEDETAIL>
			</xsl:for-each>
		</DiscrepancyProgramDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
