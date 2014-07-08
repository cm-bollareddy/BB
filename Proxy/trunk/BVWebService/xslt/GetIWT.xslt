<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="IWTDataSet" targetNamespace="http://localhost/BVWebService/xsd/IWTDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/IWTDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/IWTDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="IWTDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="IWT"><xs:complexType><xs:sequence><xs:element name="PIWT_ID" type="xs:int" /><xs:element name="PIWT_CONTACT" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PIWT_PHONE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PIWT_EMAIL" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PIWT_ETVDATA" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PIWT_PBSOPERATINGUNIT" type="xs:int" minOccurs="0" /><xs:element name="PIWT_PBSOPERATINGGROUP" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PIWT_DEA_ID" type="xs:int" minOccurs="0" /><xs:element name="PIWT_FORMSTATUS" type="xs:short" minOccurs="0" /><xs:element name="PREMIEREDATE" msdata:ReadOnly="true" type="xs:dateTime" minOccurs="0" /><xs:element name="ASS_ID" type="xs:int" minOccurs="0" /><xs:element name="ASS_TITLE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_DURATIONSCHEDULED" type="xs:int" minOccurs="0" /><xs:element name="ASS_VIDEOTEXT" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_AUDIOTEXT" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_ISPBSAPPROVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element><xs:element name="PBSIWTDETAIL"><xs:complexType><xs:sequence><xs:element name="PIWTD_ID" type="xs:int" /><xs:element name="PIWTD_PIWT_ID" type="xs:int" /><xs:element name="PIWTD_INFO" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="252" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PIWTD_URL" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="252" /></xs:restriction></xs:simpleType></xs:element></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_IWT" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:IWT" /><xs:field xpath="mstns:PIWT_ID" /></xs:unique><xs:unique name="PK_PBSIWTDETAIL" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:PBSIWTDETAIL" /><xs:field xpath="mstns:PIWTD_ID" /></xs:unique><xs:keyref name="FK_IWT_PBSIWTDETAIL" refer="PK_IWT"><xs:selector xpath=".//mstns:PBSIWTDETAIL" /><xs:field xpath="mstns:PIWTD_PIWT_ID" /></xs:keyref></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<IWTDataSet xmlns="http://localhost/BVWebService/xsd/IWTDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<IWT>
				<xsl:attribute name="diffgr:id">IWT<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<PIWT_ID><xsl:value-of select="@PIWT_ID" /></PIWT_ID>
					<xsl:if test="@PIWT_CONTACT != ''">
						<PIWT_CONTACT><xsl:value-of select="@PIWT_CONTACT" /></PIWT_CONTACT>
					</xsl:if>
					<xsl:if test="@PIWT_PHONE != ''">
						<PIWT_PHONE><xsl:value-of select="@PIWT_PHONE" /></PIWT_PHONE>
					</xsl:if>
					<xsl:if test="@PIWT_EMAIL != ''">
						<PIWT_EMAIL><xsl:value-of select="@PIWT_EMAIL" /></PIWT_EMAIL>
					</xsl:if>
					<xsl:if test="@PIWT_ETVDATA != ''">
						<PIWT_ETVDATA><xsl:value-of select="@PIWT_ETVDATA" /></PIWT_ETVDATA>
					</xsl:if>
					<xsl:if test="@PIWT_PBSOPERATINGUNIT != ''">
						<PIWT_PBSOPERATINGUNIT><xsl:value-of select="@PIWT_PBSOPERATINGUNIT" /></PIWT_PBSOPERATINGUNIT>
					</xsl:if>
						<PIWT_PBSOPERATINGGROUP><xsl:value-of select="@PIWT_PBSOPERATINGGROUP" /></PIWT_PBSOPERATINGGROUP>
					<xsl:if test="@PIWT_DEA_ID != ''">
						<PIWT_DEA_ID><xsl:value-of select="@PIWT_DEA_ID" /></PIWT_DEA_ID>
					</xsl:if>
					<xsl:if test="@PIWT_FORMSTATUS != ''">
						<PIWT_FORMSTATUS><xsl:value-of select="@PIWT_FORMSTATUS" /></PIWT_FORMSTATUS>
					</xsl:if>
					<xsl:if test="@PREMIEREDATE != ''">
						<PREMIEREDATE>
							<xsl:call-template name="DateConverter">
								<xsl:with-param name="InDate"><xsl:value-of select="@PREMIEREDATE" /></xsl:with-param>
							</xsl:call-template>
						</PREMIEREDATE>
					</xsl:if>
					<xsl:if test="@ASS_ID != ''">
						<ASS_ID><xsl:value-of select="@ASS_ID" /></ASS_ID>
					</xsl:if>
					<xsl:if test="@ASS_TITLE != ''">
						<ASS_TITLE><xsl:value-of select="@ASS_TITLE" /></ASS_TITLE>
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
					<xsl:if test="@ASS_ISPBSAPPROVED != ''">
						<ASS_ISPBSAPPROVED><xsl:value-of select="@ASS_ISPBSAPPROVED" /></ASS_ISPBSAPPROVED>
					</xsl:if>
				</IWT>
				<xsl:for-each select="PBSIWTDETAIL/ROWPBSIWTDETAIL">
					<PBSIWTDETAIL>
					<xsl:attribute name="diffgr:id">PBSIWTDETAIL<xsl:value-of select="position()" /></xsl:attribute>
					<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
						<PIWTD_ID><xsl:value-of select="@PIWTD_ID" /></PIWTD_ID>
						<PIWTD_PIWT_ID><xsl:value-of select="@PIWTD_PIWT_ID" /></PIWTD_PIWT_ID>
						<xsl:if test="@PIWTD_INFO != ''">
							<PIWTD_INFO><xsl:value-of select="@PIWTD_INFO" /></PIWTD_INFO>
						</xsl:if>
						<xsl:if test="@PIWTD_URL != ''">
							<PIWTD_URL><xsl:value-of select="@PIWTD_URL" /></PIWTD_URL>
						</xsl:if>
					</PBSIWTDETAIL>
				</xsl:for-each>
			</xsl:for-each>
		</IWTDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
