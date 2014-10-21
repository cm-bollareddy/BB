<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="UCCDataSet" targetNamespace="http://localhost/BVWebService/xsd/UCCDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/UCCDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/UCCDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="UCCDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="UCC"><xs:complexType><xs:sequence><xs:element name="PUCC_ID" type="xs:int" /><xs:element name="PUCC_CONTACT" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PUCC_PHONE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PUCC_EMAIL" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PUCC_FAX" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PUCC_DEA_ID" type="xs:int" minOccurs="0" /><xs:element name="PUCC_FORMSTATUS" type="xs:short" minOccurs="0" /><xs:element name="PUCC_OPERATINGUNIT" type="xs:int" minOccurs="0" /><xs:element name="PUCC_OPERATINGGROUP" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PREMIEREDATE" msdata:ReadOnly="true" type="xs:dateTime" minOccurs="0" /></xs:sequence></xs:complexType></xs:element><xs:element name="VW_PBSUCCDETAIL"><xs:complexType><xs:sequence><xs:element name="PUCCD_ID" type="xs:int" /><xs:element name="PUCCD_UCC_ID" type="xs:int" minOccurs="0" /><xs:element name="PUCCD_BED" type="xs:int" minOccurs="0" /><xs:element name="PUCCD_POSITION" type="xs:int" minOccurs="0" /><xs:element name="ASS_ID" type="xs:int" minOccurs="0" /><xs:element name="ASS_TITLE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_DURATIONSCHEDULED" type="xs:int" minOccurs="0" /><xs:element name="ASS_VIDEOTEXT" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_AUDIOTEXT" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_COM_ID_ADVERTISER" type="xs:int" minOccurs="0" /><xs:element name="ASS_ISPBSAPPROVED" type="xs:short" minOccurs="0" /><xs:element name="ARW_ID" type="xs:int" minOccurs="0" /><xs:element name="ARW_DATEAVAILABLEFROM" type="xs:dateTime" minOccurs="0" /><xs:element name="ARW_DATEAVAILABLETO" type="xs:dateTime" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_UCC" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:UCC" /><xs:field xpath="mstns:PUCC_ID" /></xs:unique><xs:unique name="PK_VW_PBSUCCDETAIL" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:VW_PBSUCCDETAIL" /><xs:field xpath="mstns:PUCCD_ID" /></xs:unique><xs:keyref name="FK_UCC_VW_PBSUCCDETAIL" refer="PK_UCC"><xs:selector xpath=".//mstns:VW_PBSUCCDETAIL" /><xs:field xpath="mstns:PUCCD_UCC_ID" /></xs:keyref></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<UCCDataSet xmlns="http://localhost/BVWebService/xsd/UCCDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<UCC>
				<xsl:attribute name="diffgr:id">UCC<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<PUCC_ID><xsl:value-of select="@PUCC_ID" /></PUCC_ID>
					<xsl:if test="@PUCC_CONTACT != ''">
						<PUCC_CONTACT><xsl:value-of select="@PUCC_CONTACT" /></PUCC_CONTACT>
					</xsl:if>
					<xsl:if test="@PUCC_PHONE != ''">
						<PUCC_PHONE><xsl:value-of select="@PUCC_PHONE" /></PUCC_PHONE>
					</xsl:if>
					<xsl:if test="@PUCC_EMAIL != ''">
						<PUCC_EMAIL><xsl:value-of select="@PUCC_EMAIL" /></PUCC_EMAIL>
					</xsl:if>
					<xsl:if test="@PUCC_FAX != ''">
						<PUCC_FAX><xsl:value-of select="@PUCC_FAX" /></PUCC_FAX>
					</xsl:if>
					<xsl:if test="@PUCC_DEA_ID != ''">
						<PUCC_DEA_ID><xsl:value-of select="@PUCC_DEA_ID" /></PUCC_DEA_ID>
					</xsl:if>
					<xsl:if test="@PUCC_FORMSTATUS != ''">
						<PUCC_FORMSTATUS><xsl:value-of select="@PUCC_FORMSTATUS" /></PUCC_FORMSTATUS>
					</xsl:if>
					<xsl:if test="@PUCC_OPERATINGUNIT != ''">
						<PUCC_OPERATINGUNIT><xsl:value-of select="@PUCC_OPERATINGUNIT" /></PUCC_OPERATINGUNIT>
					</xsl:if>
						<PUCC_OPERATINGGROUP><xsl:value-of select="@PUCC_OPERATINGGROUP" /></PUCC_OPERATINGGROUP>
					<xsl:if test="@PREMIEREDATE != ''">
						<PREMIEREDATE>
							<xsl:call-template name="DateConverter">
								<xsl:with-param name="InDate"><xsl:value-of select="@PREMIEREDATE" /></xsl:with-param>
							</xsl:call-template>
						</PREMIEREDATE>
					</xsl:if>
				</UCC>
				<xsl:for-each select="VW_PBSUCCDETAIL/ROWVW_PBSUCCDETAIL">
					<VW_PBSUCCDETAIL>
					<xsl:attribute name="diffgr:id">VW_PBSUCCDETAIL<xsl:value-of select="position()" /></xsl:attribute>
					<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
						<PUCCD_ID><xsl:value-of select="@PUCCD_ID" /></PUCCD_ID>
						<xsl:if test="@PUCCD_UCC_ID != ''">
							<PUCCD_UCC_ID><xsl:value-of select="@PUCCD_UCC_ID" /></PUCCD_UCC_ID>
						</xsl:if>
						<xsl:if test="@PUCCD_BED != ''">
							<PUCCD_BED><xsl:value-of select="@PUCCD_BED" /></PUCCD_BED>
						</xsl:if>
						<xsl:if test="@PUCCD_POSITION != ''">
							<PUCCD_POSITION><xsl:value-of select="@PUCCD_POSITION" /></PUCCD_POSITION>
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
						<xsl:if test="@ASS_COM_ID_ADVERTISER != ''">
							<ASS_COM_ID_ADVERTISER><xsl:value-of select="@ASS_COM_ID_ADVERTISER" /></ASS_COM_ID_ADVERTISER>
						</xsl:if>
						<xsl:if test="@ASS_ISPBSAPPROVED != ''">
							<ASS_ISPBSAPPROVED><xsl:value-of select="@ASS_ISPBSAPPROVED" /></ASS_ISPBSAPPROVED>
						</xsl:if>
						<xsl:if test="@ARW_ID != ''">
							<ARW_ID><xsl:value-of select="@ARW_ID" /></ARW_ID>
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
					</VW_PBSUCCDETAIL>
				</xsl:for-each>
			</xsl:for-each>
		</UCCDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
