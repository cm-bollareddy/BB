<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="AdCopyDataSet" targetNamespace="http://localhost/BVWebService/xsd/AdCopyDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/AdCopyDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/AdCopyDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="AdCopyDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="ADCOPY"><xs:complexType><xs:sequence><xs:element name="ASS_ID" type="xs:int" /><xs:element name="ASS_TITLE"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_DURATIONSCHEDULED" type="xs:int" minOccurs="0" /><xs:element name="ASS_VIDEOTEXT" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_AUDIOTEXT" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_COM_ID_ADVERTISER" type="xs:int" minOccurs="0" /><xs:element name="ASS_ISPBSAPPROVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element><xs:element name="ASSETRIGHTWINDOW"><xs:complexType><xs:sequence><xs:element name="ARW_ID" type="xs:int" /><xs:element name="ARW_ASS_ID" type="xs:int" minOccurs="0" /><xs:element name="ARW_DATEAVAILABLEFROM" type="xs:dateTime" minOccurs="0" /><xs:element name="ARW_DATEAVAILABLETO" type="xs:dateTime" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_ADCOPY" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:ADCOPY" /><xs:field xpath="mstns:ASS_ID" /></xs:unique><xs:unique name="PK_ASSETRIGHTWINDOW" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:ASSETRIGHTWINDOW" /><xs:field xpath="mstns:ARW_ID" /></xs:unique><xs:keyref name="FK_ADCOPYASSETRIGHTWINDOW" refer="PK_ADCOPY"><xs:selector xpath=".//mstns:ASSETRIGHTWINDOW" /><xs:field xpath="mstns:ARW_ASS_ID" /></xs:keyref></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<AdCopyDataSet xmlns="http://localhost/BVWebService/xsd/AdCopyDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<ADCOPY>
				<xsl:attribute name="diffgr:id">ADCOPY<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<ASS_ID><xsl:value-of select="@ASS_ID" /></ASS_ID>
					<ASS_TITLE><xsl:value-of select="@ASS_TITLE" /></ASS_TITLE>
					<xsl:if test="@ASS_DURATIONSCHEDULED != ''">
						<ASS_DURATIONSCHEDULED><xsl:value-of select="@ASS_DURATIONSCHEDULED" /></ASS_DURATIONSCHEDULED>
					</xsl:if>
					<xsl:if test="@ASS_VIDEOTEXT != ''">
						<ASS_VIDEOTEXT><xsl:value-of select="@ASS_VIDEOTEXT" /></ASS_VIDEOTEXT>
					</xsl:if>
					<xsl:if test="@ASS_AUDIOTEXT != ''">
						<ASS_AUDIOTEXT><xsl:value-of select="@ASS_AUDIOTEXT" /></ASS_AUDIOTEXT>
					</xsl:if>
					<xsl:if test="@ASS_COM_ID_ADVERTISER != ''">
						<ASS_COM_ID_ADVERTISER><xsl:value-of select="@ASS_COM_ID_ADVERTISER" /></ASS_COM_ID_ADVERTISER>
					</xsl:if>
					<xsl:if test="@ASS_ISPBSAPPROVED != ''">
						<ASS_ISPBSAPPROVED><xsl:value-of select="@ASS_ISPBSAPPROVED" /></ASS_ISPBSAPPROVED>
					</xsl:if>
				</ADCOPY>
				<xsl:for-each select="ASSETRIGHTWINDOW/ROWASSETRIGHTWINDOW">
					<ASSETRIGHTWINDOW>
					<xsl:attribute name="diffgr:id">ASSETRIGHTWINDOW<xsl:value-of select="position()" /></xsl:attribute>
					<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
						<ARW_ID><xsl:value-of select="@ARW_ID" /></ARW_ID>
						<xsl:if test="@ARW_ASS_ID != ''">
							<ARW_ASS_ID><xsl:value-of select="@ARW_ASS_ID" /></ARW_ASS_ID>
						</xsl:if>
						<xsl:if test="@ARW_DATEAVAILABLEFROM != ''">
							<ARW_DATEAVAILABLEFROM>
								<xsl:call-template name="DateConverter">
									<xsl:with-param name="InDate"><xsl:value-of select="@ARW_DATEAVAILABLEFROM" /></xsl:with-param>
								</xsl:call-template>
							</ARW_DATEAVAILABLEFROM>
						</xsl:if>
						<xsl:if test="@ARW_DATEAVAILABLETO != ''">
							<ARW_DATEAVAILABLETO>
								<xsl:call-template name="DateConverter">
									<xsl:with-param name="InDate"><xsl:value-of select="@ARW_DATEAVAILABLETO" /></xsl:with-param>
								</xsl:call-template>
							</ARW_DATEAVAILABLETO>
						</xsl:if>
					</ASSETRIGHTWINDOW>
				</xsl:for-each>
			</xsl:for-each>
		</AdCopyDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
