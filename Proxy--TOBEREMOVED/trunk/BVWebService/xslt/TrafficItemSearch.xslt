<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="TrafficItemDataSet" targetNamespace="http://localhost/BVWebService/xsd/TrafficItemSearchDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/TrafficItemSearchDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/TrafficItemSearchDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="TrafficItemDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="TRAFFICITEMSEARCH"><xs:complexType><xs:sequence><xs:element name="ASS_ID" type="xs:int" /><xs:element name="ASS_TITLE"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_ACA_ID" type="xs:int" minOccurs="0" /><xs:element name="ASS_SYNOPSIS" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_DURATIONSCHEDULED" type="xs:int" minOccurs="0" /><xs:element name="ASS_VIDEOTEXT" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_AUDIOTEXT" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_VIDEODESCRIPTION" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="TRAFFIC_ITEM_RIGHTS_START_DATE" msdata:ReadOnly="true" type="xs:dateTime" minOccurs="0" /><xs:element name="TRAFFIC_ITEM_RIGHTS_END_DATE" msdata:ReadOnly="true" type="xs:dateTime" minOccurs="0" /><xs:element name="ASS_ISPBSAPPROVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<TrafficItemDataSet xmlns="http://localhost/BVWebService/xsd/TrafficItemSearchDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<TRAFFICITEMSEARCH>
				<xsl:attribute name="diffgr:id">TRAFFICITEMSEARCH<xsl:value-of select="position()" /></xsl:attribute>
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
					<xsl:if test="@ASS_VIDEOTEXT != ''">
						<ASS_VIDEOTEXT><xsl:value-of select="@ASS_VIDEOTEXT" /></ASS_VIDEOTEXT>
					</xsl:if>
					<xsl:if test="@ASS_AUDIOTEXT != ''">
						<ASS_AUDIOTEXT><xsl:value-of select="@ASS_AUDIOTEXT" /></ASS_AUDIOTEXT>
					</xsl:if>
					<xsl:if test="@ASS_VIDEODESCRIPTION != ''">
						<ASS_VIDEODESCRIPTION><xsl:value-of select="@ASS_VIDEODESCRIPTION" /></ASS_VIDEODESCRIPTION>
					</xsl:if>
					<xsl:if test="@TRAFFIC_ITEM_RIGHTS_START_DATE != ''">
						<TRAFFIC_ITEM_RIGHTS_START_DATE>
							<xsl:call-template name="DateConverter">
								<xsl:with-param name="InDate"><xsl:value-of select="@TRAFFIC_ITEM_RIGHTS_START_DATE" /></xsl:with-param>
							</xsl:call-template>
						</TRAFFIC_ITEM_RIGHTS_START_DATE>
					</xsl:if>
					<xsl:if test="@TRAFFIC_ITEM_RIGHTS_END_DATE != ''">
						<TRAFFIC_ITEM_RIGHTS_END_DATE>
							<xsl:call-template name="DateConverter">
								<xsl:with-param name="InDate"><xsl:value-of select="@TRAFFIC_ITEM_RIGHTS_END_DATE" /></xsl:with-param>
							</xsl:call-template>
						</TRAFFIC_ITEM_RIGHTS_END_DATE>
					</xsl:if>
					<xsl:if test="@ASS_ISPBSAPPROVED != ''">
						<ASS_ISPBSAPPROVED><xsl:value-of select="@ASS_ISPBSAPPROVED" /></ASS_ISPBSAPPROVED>
					</xsl:if>
				</TRAFFICITEMSEARCH>
			</xsl:for-each>
		</TrafficItemDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
