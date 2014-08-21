<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="AdCopyDataSet" targetNamespace="http://localhost/BVWebService/xsd/AdCopySearchDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/AdCopySearchDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/AdCopySearchDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="AdCopyDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="ADCOPYSEARCH"><xs:complexType><xs:sequence><xs:element name="ASS_ID" type="xs:int" /><xs:element name="ASS_TITLE"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_ACA_ID" type="xs:int" minOccurs="0" /><xs:element name="ASS_SYNOPSIS" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_DURATIONSCHEDULED" type="xs:int" minOccurs="0" /><xs:element name="ASS_COM_ID_ADVERTISER" type="xs:int" minOccurs="0" /><xs:element name="ASS_VIDEOTEXT" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_AUDIOTEXT" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="AD_COPY_RIGHTS_START_DATE" msdata:ReadOnly="true" type="xs:dateTime" minOccurs="0" /><xs:element name="AD_COPY_RIGHTS_END_DATE" msdata:ReadOnly="true" type="xs:dateTime" minOccurs="0" /><xs:element name="ASS_ISPBSAPPROVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<AdCopyDataSet xmlns="http://localhost/BVWebService/xsd/AdCopySearchDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<ADCOPYSEARCH>
				<xsl:attribute name="diffgr:id">ADCOPYSEARCH<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<ASS_ID><xsl:value-of select="@ASS_ID" /></ASS_ID>
					<ASS_TITLE><xsl:value-of select="@ASS_TITLE" /></ASS_TITLE>
					<xsl:if test="@ASS_ACA_ID != ''">
						<ASS_ACA_ID><xsl:value-of select="@ASS_ACA_ID" /></ASS_ACA_ID>
					</xsl:if>
					<xsl:if test="@ASS_SYNOPSIS != ''">
						<ASS_SYNOPSIS><xsl:value-of select="@ASS_SYNOPSIS" /></ASS_SYNOPSIS>
					</xsl:if>
					<xsl:if test="@ASS_DURATIONSCHEDULED != ''">
						<ASS_DURATIONSCHEDULED><xsl:value-of select="@ASS_DURATIONSCHEDULED" /></ASS_DURATIONSCHEDULED>
					</xsl:if>
					<xsl:if test="@ASS_COM_ID_ADVERTISER != ''">
						<ASS_COM_ID_ADVERTISER><xsl:value-of select="@ASS_COM_ID_ADVERTISER" /></ASS_COM_ID_ADVERTISER>
					</xsl:if>
					<xsl:if test="@ASS_VIDEOTEXT != ''">
						<ASS_VIDEOTEXT><xsl:value-of select="@ASS_VIDEOTEXT" /></ASS_VIDEOTEXT>
					</xsl:if>
					<xsl:if test="@ASS_AUDIOTEXT != ''">
						<ASS_AUDIOTEXT><xsl:value-of select="@ASS_AUDIOTEXT" /></ASS_AUDIOTEXT>
					</xsl:if>
					<xsl:if test="@AD_COPY_RIGHTS_START_DATE != ''">
						<AD_COPY_RIGHTS_START_DATE>
							<xsl:call-template name="DateConverter">
								<xsl:with-param name="InDate"><xsl:value-of select="@AD_COPY_RIGHTS_START_DATE" /></xsl:with-param>
							</xsl:call-template>
						</AD_COPY_RIGHTS_START_DATE>
					</xsl:if>
					<xsl:if test="@AD_COPY_RIGHTS_END_DATE != ''">
						<AD_COPY_RIGHTS_END_DATE>
							<xsl:call-template name="DateConverter">
								<xsl:with-param name="InDate"><xsl:value-of select="@AD_COPY_RIGHTS_END_DATE" /></xsl:with-param>
							</xsl:call-template>
						</AD_COPY_RIGHTS_END_DATE>
					</xsl:if>
					<xsl:if test="@ASS_ISPBSAPPROVED != ''">
						<ASS_ISPBSAPPROVED><xsl:value-of select="@ASS_ISPBSAPPROVED" /></ASS_ISPBSAPPROVED>
					</xsl:if>
				</ADCOPYSEARCH>
			</xsl:for-each>
		</AdCopyDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
