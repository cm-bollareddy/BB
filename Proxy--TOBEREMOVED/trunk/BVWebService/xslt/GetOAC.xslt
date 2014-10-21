<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="OACDataSet" targetNamespace="http://localhost/BVWebService/xsd/OACDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/OACDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/OACDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="OACDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="OAC"><xs:complexType><xs:sequence><xs:element name="POAC_ID" type="xs:int" /><xs:element name="POAC_CONTACT" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POAC_PHONE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POAC_EMAIL" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POAC_DEA_ID" type="xs:int" minOccurs="0" /><xs:element name="POAC_FORMSTATUS" type="xs:short" minOccurs="0" /><xs:element name="POAC_OPERATINGUNIT" type="xs:int" minOccurs="0" /><xs:element name="POAC_OPERATINGGROUP" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PREMIEREDATE" msdata:ReadOnly="true" type="xs:dateTime" minOccurs="0" /></xs:sequence></xs:complexType></xs:element><xs:element name="VW_PBSOACENTITY"><xs:complexType><xs:sequence><xs:element name="POEN_ID" type="xs:int" /><xs:element name="POEN_OAC_ID" type="xs:int" minOccurs="0" /><xs:element name="POEN_OFFEROR" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POEN_FENAME" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POEN_FEADDRESS" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POEN_FECITY" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POEN_FESTATE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="3" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POEN_FEZIP" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POEN_OFFERMADEBY" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POEN_PAYMENTCOMPANY" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POEN_PAYMENTCONTACT" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POEN_PAYMENTADDRESS" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POEN_PAYMENTCITY" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POEN_PAYMENTSTATE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="3" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POEN_PAYMENTZIP" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POEN_PAYMENTPHONE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POEN_PAYMENTFAX" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POEN_PAYMENTEMAIL" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POEN_PREPBSLOGO" type="xs:short" minOccurs="0" /><xs:element name="POEN_PODT_ID" type="xs:int" minOccurs="0" /><xs:element name="POEN_PREOFFERDESCDETAILS" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POEN_POPDT_ID" type="xs:int" minOccurs="0" /><xs:element name="POEN_POSTOFFERDESCDETAILS" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_ID" type="xs:int" minOccurs="0" /><xs:element name="ASS_TITLE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_SYNOPSIS" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_VIDEOTEXT" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_AUDIOTEXT" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_VIDEODESCRIPTION" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_DURATIONSCHEDULED" type="xs:int" minOccurs="0" /><xs:element name="ASS_ISPBSAPPROVED" type="xs:short" minOccurs="0" /><xs:element name="ARW_ID" type="xs:int" minOccurs="0" /><xs:element name="ARW_DATEAVAILABLEFROM" type="xs:dateTime" minOccurs="0" /><xs:element name="ARW_DATEAVAILABLETO" type="xs:dateTime" minOccurs="0" /></xs:sequence></xs:complexType></xs:element><xs:element name="PBSOACITEM"><xs:complexType><xs:sequence><xs:element name="POAI_ID" type="xs:int" /><xs:element name="POAI_OEN_ID" type="xs:int" /><xs:element name="POAI_ITEM" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="3" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POAI_DESC" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="252" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POAI_MANUFACTURER" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POAI_OFFERINGPRICE" type="xs:double" minOccurs="0" /><xs:element name="POAI_SHIPPINGPRICE" type="xs:double" minOccurs="0" /><xs:element name="POAI_TOTALPRICE" type="xs:double" minOccurs="0" /><xs:element name="POAI_PRODUCTIONCOST" type="xs:double" minOccurs="0" /><xs:element name="POAI_SHIPPINGCOST" type="xs:double" minOccurs="0" /><xs:element name="POAI_ADMINCOST" type="xs:double" minOccurs="0" /><xs:element name="POAI_OTHERCOST" type="xs:double" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_OAC" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:OAC" /><xs:field xpath="mstns:POAC_ID" /></xs:unique><xs:unique name="PK_VW_PBSOACENTITY" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:VW_PBSOACENTITY" /><xs:field xpath="mstns:POEN_ID" /></xs:unique><xs:unique name="PK_PBSOACITEM" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:PBSOACITEM" /><xs:field xpath="mstns:POAI_ID" /></xs:unique><xs:keyref name="FK_VW_PBSOACENTITY_PBSOACITEM" refer="PK_VW_PBSOACENTITY"><xs:selector xpath=".//mstns:PBSOACITEM" /><xs:field xpath="mstns:POAI_OEN_ID" /></xs:keyref><xs:keyref name="FK_OAC_VW_PBSOACENTITY" refer="PK_OAC"><xs:selector xpath=".//mstns:VW_PBSOACENTITY" /><xs:field xpath="mstns:POEN_OAC_ID" /></xs:keyref></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<OACDataSet xmlns="http://localhost/BVWebService/xsd/OACDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<OAC>
				<xsl:attribute name="diffgr:id">OAC<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<POAC_ID><xsl:value-of select="@POAC_ID" /></POAC_ID>
					<xsl:if test="@POAC_CONTACT != ''">
						<POAC_CONTACT><xsl:value-of select="@POAC_CONTACT" /></POAC_CONTACT>
					</xsl:if>
					<xsl:if test="@POAC_PHONE != ''">
						<POAC_PHONE><xsl:value-of select="@POAC_PHONE" /></POAC_PHONE>
					</xsl:if>
					<xsl:if test="@POAC_EMAIL != ''">
						<POAC_EMAIL><xsl:value-of select="@POAC_EMAIL" /></POAC_EMAIL>
					</xsl:if>
					<xsl:if test="@POAC_DEA_ID != ''">
						<POAC_DEA_ID><xsl:value-of select="@POAC_DEA_ID" /></POAC_DEA_ID>
					</xsl:if>
					<xsl:if test="@POAC_FORMSTATUS != ''">
						<POAC_FORMSTATUS><xsl:value-of select="@POAC_FORMSTATUS" /></POAC_FORMSTATUS>
					</xsl:if>
					<xsl:if test="@POAC_OPERATINGUNIT != ''">
						<POAC_OPERATINGUNIT><xsl:value-of select="@POAC_OPERATINGUNIT" /></POAC_OPERATINGUNIT>
					</xsl:if>
						<POAC_OPERATINGGROUP><xsl:value-of select="@POAC_OPERATINGGROUP" /></POAC_OPERATINGGROUP>
					<xsl:if test="@PREMIEREDATE != ''">
						<PREMIEREDATE>
							<xsl:call-template name="DateConverter">
								<xsl:with-param name="InDate"><xsl:value-of select="@PREMIEREDATE" /></xsl:with-param>
							</xsl:call-template>
						</PREMIEREDATE>
					</xsl:if>
				</OAC>
				<xsl:for-each select="VW_PBSOACENTITY/ROWVW_PBSOACENTITY">
					<VW_PBSOACENTITY>
					<xsl:attribute name="diffgr:id">VW_PBSOACENTITY<xsl:value-of select="position()" /></xsl:attribute>
					<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
						<POEN_ID><xsl:value-of select="@POEN_ID" /></POEN_ID>
						<xsl:if test="@POEN_OAC_ID != ''">
							<POEN_OAC_ID><xsl:value-of select="@POEN_OAC_ID" /></POEN_OAC_ID>
						</xsl:if>
						<xsl:if test="@POEN_OFFEROR != ''">
							<POEN_OFFEROR><xsl:value-of select="@POEN_OFFEROR" /></POEN_OFFEROR>
						</xsl:if>
						<xsl:if test="@POEN_FENAME != ''">
							<POEN_FENAME><xsl:value-of select="@POEN_FENAME" /></POEN_FENAME>
						</xsl:if>
						<xsl:if test="@POEN_FEADDRESS != ''">
							<POEN_FEADDRESS><xsl:value-of select="@POEN_FEADDRESS" /></POEN_FEADDRESS>
						</xsl:if>
						<xsl:if test="@POEN_FECITY != ''">
							<POEN_FECITY><xsl:value-of select="@POEN_FECITY" /></POEN_FECITY>
						</xsl:if>
						<xsl:if test="@POEN_FESTATE != ''">
							<POEN_FESTATE><xsl:value-of select="@POEN_FESTATE" /></POEN_FESTATE>
						</xsl:if>
						<xsl:if test="@POEN_FEZIP != ''">
							<POEN_FEZIP><xsl:value-of select="@POEN_FEZIP" /></POEN_FEZIP>
						</xsl:if>
						<xsl:if test="@POEN_OFFERMADEBY != ''">
							<POEN_OFFERMADEBY><xsl:value-of select="@POEN_OFFERMADEBY" /></POEN_OFFERMADEBY>
						</xsl:if>
						<xsl:if test="@POEN_PAYMENTCOMPANY != ''">
							<POEN_PAYMENTCOMPANY><xsl:value-of select="@POEN_PAYMENTCOMPANY" /></POEN_PAYMENTCOMPANY>
						</xsl:if>
						<xsl:if test="@POEN_PAYMENTCONTACT != ''">
							<POEN_PAYMENTCONTACT><xsl:value-of select="@POEN_PAYMENTCONTACT" /></POEN_PAYMENTCONTACT>
						</xsl:if>
						<xsl:if test="@POEN_PAYMENTADDRESS != ''">
							<POEN_PAYMENTADDRESS><xsl:value-of select="@POEN_PAYMENTADDRESS" /></POEN_PAYMENTADDRESS>
						</xsl:if>
						<xsl:if test="@POEN_PAYMENTCITY != ''">
							<POEN_PAYMENTCITY><xsl:value-of select="@POEN_PAYMENTCITY" /></POEN_PAYMENTCITY>
						</xsl:if>
						<xsl:if test="@POEN_PAYMENTSTATE != ''">
							<POEN_PAYMENTSTATE><xsl:value-of select="@POEN_PAYMENTSTATE" /></POEN_PAYMENTSTATE>
						</xsl:if>
						<xsl:if test="@POEN_PAYMENTZIP != ''">
							<POEN_PAYMENTZIP><xsl:value-of select="@POEN_PAYMENTZIP" /></POEN_PAYMENTZIP>
						</xsl:if>
						<xsl:if test="@POEN_PAYMENTPHONE != ''">
							<POEN_PAYMENTPHONE><xsl:value-of select="@POEN_PAYMENTPHONE" /></POEN_PAYMENTPHONE>
						</xsl:if>
						<xsl:if test="@POEN_PAYMENTFAX != ''">
							<POEN_PAYMENTFAX><xsl:value-of select="@POEN_PAYMENTFAX" /></POEN_PAYMENTFAX>
						</xsl:if>
						<xsl:if test="@POEN_PAYMENTEMAIL != ''">
							<POEN_PAYMENTEMAIL><xsl:value-of select="@POEN_PAYMENTEMAIL" /></POEN_PAYMENTEMAIL>
						</xsl:if>
						<xsl:if test="@POEN_PREPBSLOGO != ''">
							<POEN_PREPBSLOGO><xsl:value-of select="@POEN_PREPBSLOGO" /></POEN_PREPBSLOGO>
						</xsl:if>
						<xsl:if test="@POEN_PODT_ID != ''">
							<POEN_PODT_ID><xsl:value-of select="@POEN_PODT_ID" /></POEN_PODT_ID>
						</xsl:if>
						<xsl:if test="@POEN_PREOFFERDESCDETAILS != ''">
							<POEN_PREOFFERDESCDETAILS><xsl:value-of select="@POEN_PREOFFERDESCDETAILS" /></POEN_PREOFFERDESCDETAILS>
						</xsl:if>
						<xsl:if test="@POEN_POPDT_ID != ''">
							<POEN_POPDT_ID><xsl:value-of select="@POEN_POPDT_ID" /></POEN_POPDT_ID>
						</xsl:if>
						<xsl:if test="@POEN_POSTOFFERDESCDETAILS != ''">
							<POEN_POSTOFFERDESCDETAILS><xsl:value-of select="@POEN_POSTOFFERDESCDETAILS" /></POEN_POSTOFFERDESCDETAILS>
						</xsl:if>
						<xsl:if test="@ASS_ID != ''">
							<ASS_ID><xsl:value-of select="@ASS_ID" /></ASS_ID>
						</xsl:if>
						<xsl:if test="@ASS_TITLE != ''">
							<ASS_TITLE><xsl:value-of select="@ASS_TITLE" /></ASS_TITLE>
						</xsl:if>
						<xsl:if test="@ASS_SYNOPSIS != ''">
							<ASS_SYNOPSIS><xsl:value-of select="@ASS_SYNOPSIS" /></ASS_SYNOPSIS>
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
						<xsl:if test="@ASS_DURATIONSCHEDULED != ''">
							<ASS_DURATIONSCHEDULED><xsl:value-of select="@ASS_DURATIONSCHEDULED" /></ASS_DURATIONSCHEDULED>
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
					</VW_PBSOACENTITY>
					<xsl:for-each select="PBSOACITEM/ROWPBSOACITEM">
						<PBSOACITEM>
						<xsl:attribute name="diffgr:id">PBSOACITEM<xsl:value-of select="position()" /></xsl:attribute>
						<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
							<POAI_ID><xsl:value-of select="@POAI_ID" /></POAI_ID>
							<POAI_OEN_ID><xsl:value-of select="@POAI_OEN_ID" /></POAI_OEN_ID>
							<xsl:if test="@POAI_ITEM != ''">
								<POAI_ITEM><xsl:value-of select="@POAI_ITEM" /></POAI_ITEM>
							</xsl:if>
							<xsl:if test="@POAI_DESC != ''">
								<POAI_DESC><xsl:value-of select="@POAI_DESC" /></POAI_DESC>
							</xsl:if>
							<xsl:if test="@POAI_MANUFACTURER != ''">
								<POAI_MANUFACTURER><xsl:value-of select="@POAI_MANUFACTURER" /></POAI_MANUFACTURER>
							</xsl:if>
							<xsl:if test="@POAI_OFFERINGPRICE != ''">
								<POAI_OFFERINGPRICE><xsl:value-of select="@POAI_OFFERINGPRICE" /></POAI_OFFERINGPRICE>
							</xsl:if>
							<xsl:if test="@POAI_SHIPPINGPRICE != ''">
								<POAI_SHIPPINGPRICE><xsl:value-of select="@POAI_SHIPPINGPRICE" /></POAI_SHIPPINGPRICE>
							</xsl:if>
							<xsl:if test="@POAI_TOTALPRICE != ''">
								<POAI_TOTALPRICE><xsl:value-of select="@POAI_TOTALPRICE" /></POAI_TOTALPRICE>
							</xsl:if>
							<xsl:if test="@POAI_PRODUCTIONCOST != ''">
								<POAI_PRODUCTIONCOST><xsl:value-of select="@POAI_PRODUCTIONCOST" /></POAI_PRODUCTIONCOST>
							</xsl:if>
							<xsl:if test="@POAI_SHIPPINGCOST != ''">
								<POAI_SHIPPINGCOST><xsl:value-of select="@POAI_SHIPPINGCOST" /></POAI_SHIPPINGCOST>
							</xsl:if>
							<xsl:if test="@POAI_ADMINCOST != ''">
								<POAI_ADMINCOST><xsl:value-of select="@POAI_ADMINCOST" /></POAI_ADMINCOST>
							</xsl:if>
							<xsl:if test="@POAI_OTHERCOST != ''">
								<POAI_OTHERCOST><xsl:value-of select="@POAI_OTHERCOST" /></POAI_OTHERCOST>
							</xsl:if>
						</PBSOACITEM>
					</xsl:for-each>
				</xsl:for-each>
			</xsl:for-each>
		</OACDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
