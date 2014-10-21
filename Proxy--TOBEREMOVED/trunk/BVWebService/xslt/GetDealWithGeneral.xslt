<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="DealWithGeneralDataSet" targetNamespace="http://localhost/BVWebService/xsd/DealWithGeneralDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/DealWithGeneralDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/DealWithGeneralDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="DealWithGeneralDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="DEAL"><xs:complexType><xs:sequence><xs:element name="DEA_ID" type="xs:int" /><xs:element name="DEA_DESC"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="EPISODE_COUNT" msdata:ReadOnly="true" type="xs:int" minOccurs="0" /><xs:element name="DEA_PBSDS_ID" type="xs:int" minOccurs="0" /><xs:element name="DEA_UPDATEDATETIME" type="xs:dateTime" minOccurs="0" /><xs:element name="DEA_UPDATEUSERID" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="SEASON" msdata:ReadOnly="true" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MASTERDEALTITLE" msdata:ReadOnly="true" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_PBSFD_ID" type="xs:int" minOccurs="0" /><xs:element name="DEA_ISPBSMINORITYPRODUCTION" type="xs:short" minOccurs="0" /><xs:element name="DEA_ISPBSMINORITYPRODUCEREXEC" type="xs:short" minOccurs="0" /><xs:element name="DEA_ISPBSMINORITYDIRECTOR" type="xs:short" minOccurs="0" /><xs:element name="DEA_ISPBSMINORITYTALENT" type="xs:short" minOccurs="0" /><xs:element name="DEA_ISPBSMINORITYPRODUCERLINE" type="xs:short" minOccurs="0" /><xs:element name="DEA_ISPBSMINORITYWRITER" type="xs:short" minOccurs="0" /><xs:element name="DEA_ISPBSMINORITYSUBJECTMATTER" type="xs:short" minOccurs="0" /><xs:element name="DEA_PBSPRODUCTIONCOST" type="xs:double" minOccurs="0" /><xs:element name="DEA_SLU_ID_PBSUNDERWRITINGTYPE" type="xs:int" minOccurs="0" /><xs:element name="DEA_PBSUNDERWRITINGNOTE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_PBSUNDERWRITINGCONTACT" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_PBSUNDERWRITINGPHONE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_SLU_ID_PBSSCHOOLRIGHTSTYPE" type="xs:int" minOccurs="0" /><xs:element name="DEA_PBSSCHOOLEXPIREDATE" type="xs:dateTime" minOccurs="0" /><xs:element name="DEA_PBSSCHOOLOBDATEMONTHS" type="xs:short" minOccurs="0" /><xs:element name="DEA_PBSSCHOOLOBDATEDAYS" type="xs:short" minOccurs="0" /><xs:element name="DEA_PBSSCHOOLEACHBCASTMONTHS" type="xs:short" minOccurs="0" /><xs:element name="DEA_PBSSCHOOLEACHBCASTDAYS" type="xs:short" minOccurs="0" /><xs:element name="DEA_ISPBSSIMULCASTRIGHTS" type="xs:short" minOccurs="0" /><xs:element name="DEA_ISPBSNCCABLERIGHTS" type="xs:short" minOccurs="0" /><xs:element name="DEA_PBSBROADCASTRIGHTSCOMMENTS" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_PBSCANADIANHOLDBACK" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_ISPBSCANADIANPRERELEASE" type="xs:short" minOccurs="0" /><xs:element name="DEA_PBSPRODUCTIONCONTACTNAME" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_PBSPRODUCTIONCONTACTPHONE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_PBSPRODUCTIONCONTACTEMAIL" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_PBSTECHNICALCONTACTNAME" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_PBSTECHNICALCONTACTPHONE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_PBSTECHNICALCONTACTEMAIL" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_ISPBSLIVEEVENT" type="xs:short" minOccurs="0" /><xs:element name="DEA_PBSORIGSITE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_PBSUP_ID" type="xs:int" minOccurs="0" /><xs:element name="DEA_PBSLIVEORIGINATIONPATH" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_PBSLIVEORIGINATIONPATH2" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_PBSLIVEORIGINATIONPATH3" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_PBSLIVEORIGINATIONPATH4" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_ISPBSLIVERECORD" type="xs:short" minOccurs="0" /><xs:element name="DEA_MFC_ID_AUDIOTYPE" type="xs:int" minOccurs="0" /><xs:element name="DEA_MEF_ID_AUDIO1" type="xs:int" minOccurs="0" /><xs:element name="DEA_MEF_ID_AUDIO2" type="xs:int" minOccurs="0" /><xs:element name="DEA_MEF_ID_AUDIO3" type="xs:int" minOccurs="0" /><xs:element name="DEA_MEF_ID_AUDIO4" type="xs:int" minOccurs="0" /><xs:element name="DEA_MEF_ID_AUDIO5" type="xs:int" minOccurs="0" /><xs:element name="DEA_MEF_ID_AUDIO6" type="xs:int" minOccurs="0" /><xs:element name="DEA_MEF_ID_AUDIO7" type="xs:int" minOccurs="0" /><xs:element name="DEA_MEF_ID_AUDIO8" type="xs:int" minOccurs="0" /><xs:element name="DEA_IS_DVI_PBSENCODES" type="xs:short" minOccurs="0" /><xs:element name="DEA_IS_DVI_PBSCOORDINATES" type="xs:short" minOccurs="0" /><xs:element name="DEA_IS_SAP_PBSENCODES" type="xs:short" minOccurs="0" /><xs:element name="DEA_ISSUBTITLES" type="xs:short" minOccurs="0" /><xs:element name="DEA_LAN_ID_SUBTITLES" type="xs:int" minOccurs="0" /><xs:element name="DEA_MEF_ID_CAPTION1" type="xs:int" minOccurs="0" /><xs:element name="DEA_MEF_ID_CAPTION2" type="xs:int" minOccurs="0" /><xs:element name="DEA_MEF_ID_CAPTION3" type="xs:int" minOccurs="0" /><xs:element name="DEA_IS_CC_PBSENCODES" type="xs:short" minOccurs="0" /><xs:element name="DEA_IS_CC_PBSCOORDINATES" type="xs:short" minOccurs="0" /><xs:element name="DEA_CC_PROVIDER" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_PBSCV_ID" type="xs:int" minOccurs="0" /><xs:element name="DEA_SLU_ID_ASPECTRATIO" type="xs:int" minOccurs="0" /><xs:element name="DEA_ISINTERNALBREAK" type="xs:short" minOccurs="0" /><xs:element name="DEA_ISCC" type="xs:short" minOccurs="0" /><xs:element name="DEA_ISSAP" type="xs:short" minOccurs="0" /><xs:element name="DEA_ISDVI" type="xs:short" minOccurs="0" /><xs:element name="DEA_SLU_ID_HIDEF" type="xs:int" minOccurs="0" /><xs:element name="DEA_PBSCONTENTDESCRIPTION" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_PBSOPERATINGUNIT" type="xs:int" minOccurs="0" /><xs:element name="DEA_PBSOPERATINGGROUP" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_ISPBSOPENCAPTIONS" type="xs:short" minOccurs="0" /><xs:element name="DEA_PBSLIVEDESTINATION" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_PBSLIVEBACKUPPATH1" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_PBSLIVEBACKUPPATH2" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_PBSLIVEBACKUPPATH3" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_PBSLIVEBACKUPPATH4" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_MDL_ID" type="xs:int" minOccurs="0" /><xs:element name="DEA_GNR_ID" type="xs:int" minOccurs="0" /><xs:element name="DEA_ACM_ID" type="xs:int" minOccurs="0" /><xs:element name="DEA_ALLIANTCONTRACTID" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="34" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ISALLIANTCONTRACTINTERFACED" msdata:ReadOnly="true" type="xs:short" minOccurs="0" /><xs:element name="DEA_PBSBC_ID" type="xs:int" minOccurs="0" /><xs:element name="DEA_PBSCONTENTDESCRIPTION_1" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEA_ISPBSSERIESDESCRIPTION" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element><xs:element name="PBSDEALCONTACT"><xs:complexType><xs:sequence><xs:element name="PBSDC_ID" type="xs:int" /><xs:element name="PBSDC_SLU_ID_CONTACTTYPE" type="xs:int" /><xs:element name="PBSDC_CONTACTNAME" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PBSDC_CONTACTPHONE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PBSDC_CONTACTEMAIL" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PBSDC_COM_ID" type="xs:int" /><xs:element name="PBSDC_DEA_ID" type="xs:int" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_DEAL" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:DEAL" /><xs:field xpath="mstns:DEA_ID" /></xs:unique><xs:unique name="PK_PBSDEALCONTACT" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:PBSDEALCONTACT" /><xs:field xpath="mstns:PBSDC_ID" /></xs:unique><xs:keyref name="FK_DEAL_PBSDEALCONTACT" refer="PK_DEAL"><xs:selector xpath=".//mstns:PBSDEALCONTACT" /><xs:field xpath="mstns:PBSDC_DEA_ID" /></xs:keyref></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<DealWithGeneralDataSet xmlns="http://localhost/BVWebService/xsd/DealWithGeneralDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<DEAL>
				<xsl:attribute name="diffgr:id">DEAL<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<DEA_ID><xsl:value-of select="@DEA_ID" /></DEA_ID>
					<DEA_DESC><xsl:value-of select="@DEA_DESC" /></DEA_DESC>
					<xsl:if test="@EPISODE_COUNT != ''">
						<EPISODE_COUNT><xsl:value-of select="@EPISODE_COUNT" /></EPISODE_COUNT>
					</xsl:if>
					<xsl:if test="@DEA_PBSDS_ID != ''">
						<DEA_PBSDS_ID><xsl:value-of select="@DEA_PBSDS_ID" /></DEA_PBSDS_ID>
					</xsl:if>
					<xsl:if test="@DEA_UPDATEDATETIME != ''">
						<DEA_UPDATEDATETIME>
							<xsl:call-template name="DateConverter">
								<xsl:with-param name="InDate"><xsl:value-of select="@DEA_UPDATEDATETIME" /></xsl:with-param>
							</xsl:call-template>
						</DEA_UPDATEDATETIME>
					</xsl:if>
					<xsl:if test="@DEA_UPDATEUSERID != ''">
						<DEA_UPDATEUSERID><xsl:value-of select="@DEA_UPDATEUSERID" /></DEA_UPDATEUSERID>
					</xsl:if>
					<xsl:if test="@SEASON != ''">
						<SEASON><xsl:value-of select="@SEASON" /></SEASON>
					</xsl:if>
					<xsl:if test="@MASTERDEALTITLE != ''">
						<MASTERDEALTITLE><xsl:value-of select="@MASTERDEALTITLE" /></MASTERDEALTITLE>
					</xsl:if>
					<xsl:if test="@DEA_PBSFD_ID != ''">
						<DEA_PBSFD_ID><xsl:value-of select="@DEA_PBSFD_ID" /></DEA_PBSFD_ID>
					</xsl:if>
					<xsl:if test="@DEA_ISPBSMINORITYPRODUCTION != ''">
						<DEA_ISPBSMINORITYPRODUCTION><xsl:value-of select="@DEA_ISPBSMINORITYPRODUCTION" /></DEA_ISPBSMINORITYPRODUCTION>
					</xsl:if>
					<xsl:if test="@DEA_ISPBSMINORITYPRODUCEREXEC != ''">
						<DEA_ISPBSMINORITYPRODUCEREXEC><xsl:value-of select="@DEA_ISPBSMINORITYPRODUCEREXEC" /></DEA_ISPBSMINORITYPRODUCEREXEC>
					</xsl:if>
					<xsl:if test="@DEA_ISPBSMINORITYDIRECTOR != ''">
						<DEA_ISPBSMINORITYDIRECTOR><xsl:value-of select="@DEA_ISPBSMINORITYDIRECTOR" /></DEA_ISPBSMINORITYDIRECTOR>
					</xsl:if>
					<xsl:if test="@DEA_ISPBSMINORITYTALENT != ''">
						<DEA_ISPBSMINORITYTALENT><xsl:value-of select="@DEA_ISPBSMINORITYTALENT" /></DEA_ISPBSMINORITYTALENT>
					</xsl:if>
					<xsl:if test="@DEA_ISPBSMINORITYPRODUCERLINE != ''">
						<DEA_ISPBSMINORITYPRODUCERLINE><xsl:value-of select="@DEA_ISPBSMINORITYPRODUCERLINE" /></DEA_ISPBSMINORITYPRODUCERLINE>
					</xsl:if>
					<xsl:if test="@DEA_ISPBSMINORITYWRITER != ''">
						<DEA_ISPBSMINORITYWRITER><xsl:value-of select="@DEA_ISPBSMINORITYWRITER" /></DEA_ISPBSMINORITYWRITER>
					</xsl:if>
					<xsl:if test="@DEA_ISPBSMINORITYSUBJECTMATTER != ''">
						<DEA_ISPBSMINORITYSUBJECTMATTER><xsl:value-of select="@DEA_ISPBSMINORITYSUBJECTMATTER" /></DEA_ISPBSMINORITYSUBJECTMATTER>
					</xsl:if>
					<xsl:if test="@DEA_PBSPRODUCTIONCOST != ''">
						<DEA_PBSPRODUCTIONCOST><xsl:value-of select="@DEA_PBSPRODUCTIONCOST" /></DEA_PBSPRODUCTIONCOST>
					</xsl:if>
					<xsl:if test="@DEA_SLU_ID_PBSUNDERWRITINGTYPE != ''">
						<DEA_SLU_ID_PBSUNDERWRITINGTYPE><xsl:value-of select="@DEA_SLU_ID_PBSUNDERWRITINGTYPE" /></DEA_SLU_ID_PBSUNDERWRITINGTYPE>
					</xsl:if>
					<xsl:if test="@DEA_PBSUNDERWRITINGNOTE != ''">
						<DEA_PBSUNDERWRITINGNOTE><xsl:value-of select="@DEA_PBSUNDERWRITINGNOTE" /></DEA_PBSUNDERWRITINGNOTE>
					</xsl:if>
					<xsl:if test="@DEA_PBSUNDERWRITINGCONTACT != ''">
						<DEA_PBSUNDERWRITINGCONTACT><xsl:value-of select="@DEA_PBSUNDERWRITINGCONTACT" /></DEA_PBSUNDERWRITINGCONTACT>
					</xsl:if>
					<xsl:if test="@DEA_PBSUNDERWRITINGPHONE != ''">
						<DEA_PBSUNDERWRITINGPHONE><xsl:value-of select="@DEA_PBSUNDERWRITINGPHONE" /></DEA_PBSUNDERWRITINGPHONE>
					</xsl:if>
					<xsl:if test="@DEA_SLU_ID_PBSSCHOOLRIGHTSTYPE != ''">
						<DEA_SLU_ID_PBSSCHOOLRIGHTSTYPE><xsl:value-of select="@DEA_SLU_ID_PBSSCHOOLRIGHTSTYPE" /></DEA_SLU_ID_PBSSCHOOLRIGHTSTYPE>
					</xsl:if>
					<xsl:if test="@DEA_PBSSCHOOLEXPIREDATE != ''">
						<DEA_PBSSCHOOLEXPIREDATE>
							<xsl:call-template name="DateConverter">
								<xsl:with-param name="InDate"><xsl:value-of select="@DEA_PBSSCHOOLEXPIREDATE" /></xsl:with-param>
							</xsl:call-template>
						</DEA_PBSSCHOOLEXPIREDATE>
					</xsl:if>
					<xsl:if test="@DEA_PBSSCHOOLOBDATEMONTHS != ''">
						<DEA_PBSSCHOOLOBDATEMONTHS><xsl:value-of select="@DEA_PBSSCHOOLOBDATEMONTHS" /></DEA_PBSSCHOOLOBDATEMONTHS>
					</xsl:if>
					<xsl:if test="@DEA_PBSSCHOOLOBDATEDAYS != ''">
						<DEA_PBSSCHOOLOBDATEDAYS><xsl:value-of select="@DEA_PBSSCHOOLOBDATEDAYS" /></DEA_PBSSCHOOLOBDATEDAYS>
					</xsl:if>
					<xsl:if test="@DEA_PBSSCHOOLEACHBCASTMONTHS != ''">
						<DEA_PBSSCHOOLEACHBCASTMONTHS><xsl:value-of select="@DEA_PBSSCHOOLEACHBCASTMONTHS" /></DEA_PBSSCHOOLEACHBCASTMONTHS>
					</xsl:if>
					<xsl:if test="@DEA_PBSSCHOOLEACHBCASTDAYS != ''">
						<DEA_PBSSCHOOLEACHBCASTDAYS><xsl:value-of select="@DEA_PBSSCHOOLEACHBCASTDAYS" /></DEA_PBSSCHOOLEACHBCASTDAYS>
					</xsl:if>
					<xsl:if test="@DEA_ISPBSSIMULCASTRIGHTS != ''">
						<DEA_ISPBSSIMULCASTRIGHTS><xsl:value-of select="@DEA_ISPBSSIMULCASTRIGHTS" /></DEA_ISPBSSIMULCASTRIGHTS>
					</xsl:if>
					<xsl:if test="@DEA_ISPBSNCCABLERIGHTS != ''">
						<DEA_ISPBSNCCABLERIGHTS><xsl:value-of select="@DEA_ISPBSNCCABLERIGHTS" /></DEA_ISPBSNCCABLERIGHTS>
					</xsl:if>
					<xsl:if test="@DEA_PBSBROADCASTRIGHTSCOMMENTS != ''">
						<DEA_PBSBROADCASTRIGHTSCOMMENTS><xsl:value-of select="@DEA_PBSBROADCASTRIGHTSCOMMENTS" /></DEA_PBSBROADCASTRIGHTSCOMMENTS>
					</xsl:if>
					<xsl:if test="@DEA_PBSCANADIANHOLDBACK != ''">
						<DEA_PBSCANADIANHOLDBACK><xsl:value-of select="@DEA_PBSCANADIANHOLDBACK" /></DEA_PBSCANADIANHOLDBACK>
					</xsl:if>
					<xsl:if test="@DEA_ISPBSCANADIANPRERELEASE != ''">
						<DEA_ISPBSCANADIANPRERELEASE><xsl:value-of select="@DEA_ISPBSCANADIANPRERELEASE" /></DEA_ISPBSCANADIANPRERELEASE>
					</xsl:if>
					<xsl:if test="@DEA_PBSPRODUCTIONCONTACTNAME != ''">
						<DEA_PBSPRODUCTIONCONTACTNAME><xsl:value-of select="@DEA_PBSPRODUCTIONCONTACTNAME" /></DEA_PBSPRODUCTIONCONTACTNAME>
					</xsl:if>
					<xsl:if test="@DEA_PBSPRODUCTIONCONTACTPHONE != ''">
						<DEA_PBSPRODUCTIONCONTACTPHONE><xsl:value-of select="@DEA_PBSPRODUCTIONCONTACTPHONE" /></DEA_PBSPRODUCTIONCONTACTPHONE>
					</xsl:if>
					<xsl:if test="@DEA_PBSPRODUCTIONCONTACTEMAIL != ''">
						<DEA_PBSPRODUCTIONCONTACTEMAIL><xsl:value-of select="@DEA_PBSPRODUCTIONCONTACTEMAIL" /></DEA_PBSPRODUCTIONCONTACTEMAIL>
					</xsl:if>
					<xsl:if test="@DEA_PBSTECHNICALCONTACTNAME != ''">
						<DEA_PBSTECHNICALCONTACTNAME><xsl:value-of select="@DEA_PBSTECHNICALCONTACTNAME" /></DEA_PBSTECHNICALCONTACTNAME>
					</xsl:if>
					<xsl:if test="@DEA_PBSTECHNICALCONTACTPHONE != ''">
						<DEA_PBSTECHNICALCONTACTPHONE><xsl:value-of select="@DEA_PBSTECHNICALCONTACTPHONE" /></DEA_PBSTECHNICALCONTACTPHONE>
					</xsl:if>
					<xsl:if test="@DEA_PBSTECHNICALCONTACTEMAIL != ''">
						<DEA_PBSTECHNICALCONTACTEMAIL><xsl:value-of select="@DEA_PBSTECHNICALCONTACTEMAIL" /></DEA_PBSTECHNICALCONTACTEMAIL>
					</xsl:if>
					<xsl:if test="@DEA_ISPBSLIVEEVENT != ''">
						<DEA_ISPBSLIVEEVENT><xsl:value-of select="@DEA_ISPBSLIVEEVENT" /></DEA_ISPBSLIVEEVENT>
					</xsl:if>
					<xsl:if test="@DEA_PBSORIGSITE != ''">
						<DEA_PBSORIGSITE><xsl:value-of select="@DEA_PBSORIGSITE" /></DEA_PBSORIGSITE>
					</xsl:if>
					<xsl:if test="@DEA_PBSUP_ID != ''">
						<DEA_PBSUP_ID><xsl:value-of select="@DEA_PBSUP_ID" /></DEA_PBSUP_ID>
					</xsl:if>
					<xsl:if test="@DEA_PBSLIVEORIGINATIONPATH != ''">
						<DEA_PBSLIVEORIGINATIONPATH><xsl:value-of select="@DEA_PBSLIVEORIGINATIONPATH" /></DEA_PBSLIVEORIGINATIONPATH>
					</xsl:if>
					<xsl:if test="@DEA_PBSLIVEORIGINATIONPATH2 != ''">
						<DEA_PBSLIVEORIGINATIONPATH2><xsl:value-of select="@DEA_PBSLIVEORIGINATIONPATH2" /></DEA_PBSLIVEORIGINATIONPATH2>
					</xsl:if>
					<xsl:if test="@DEA_PBSLIVEORIGINATIONPATH3 != ''">
						<DEA_PBSLIVEORIGINATIONPATH3><xsl:value-of select="@DEA_PBSLIVEORIGINATIONPATH3" /></DEA_PBSLIVEORIGINATIONPATH3>
					</xsl:if>
					<xsl:if test="@DEA_PBSLIVEORIGINATIONPATH4 != ''">
						<DEA_PBSLIVEORIGINATIONPATH4><xsl:value-of select="@DEA_PBSLIVEORIGINATIONPATH4" /></DEA_PBSLIVEORIGINATIONPATH4>
					</xsl:if>
					<xsl:if test="@DEA_ISPBSLIVERECORD != ''">
						<DEA_ISPBSLIVERECORD><xsl:value-of select="@DEA_ISPBSLIVERECORD" /></DEA_ISPBSLIVERECORD>
					</xsl:if>
					<xsl:if test="@DEA_MFC_ID_AUDIOTYPE != ''">
						<DEA_MFC_ID_AUDIOTYPE><xsl:value-of select="@DEA_MFC_ID_AUDIOTYPE" /></DEA_MFC_ID_AUDIOTYPE>
					</xsl:if>
					<xsl:if test="@DEA_MEF_ID_AUDIO1 != ''">
						<DEA_MEF_ID_AUDIO1><xsl:value-of select="@DEA_MEF_ID_AUDIO1" /></DEA_MEF_ID_AUDIO1>
					</xsl:if>
					<xsl:if test="@DEA_MEF_ID_AUDIO2 != ''">
						<DEA_MEF_ID_AUDIO2><xsl:value-of select="@DEA_MEF_ID_AUDIO2" /></DEA_MEF_ID_AUDIO2>
					</xsl:if>
					<xsl:if test="@DEA_MEF_ID_AUDIO3 != ''">
						<DEA_MEF_ID_AUDIO3><xsl:value-of select="@DEA_MEF_ID_AUDIO3" /></DEA_MEF_ID_AUDIO3>
					</xsl:if>
					<xsl:if test="@DEA_MEF_ID_AUDIO4 != ''">
						<DEA_MEF_ID_AUDIO4><xsl:value-of select="@DEA_MEF_ID_AUDIO4" /></DEA_MEF_ID_AUDIO4>
					</xsl:if>
					<xsl:if test="@DEA_MEF_ID_AUDIO5 != ''">
						<DEA_MEF_ID_AUDIO5><xsl:value-of select="@DEA_MEF_ID_AUDIO5" /></DEA_MEF_ID_AUDIO5>
					</xsl:if>
					<xsl:if test="@DEA_MEF_ID_AUDIO6 != ''">
						<DEA_MEF_ID_AUDIO6><xsl:value-of select="@DEA_MEF_ID_AUDIO6" /></DEA_MEF_ID_AUDIO6>
					</xsl:if>
					<xsl:if test="@DEA_MEF_ID_AUDIO7 != ''">
						<DEA_MEF_ID_AUDIO7><xsl:value-of select="@DEA_MEF_ID_AUDIO7" /></DEA_MEF_ID_AUDIO7>
					</xsl:if>
					<xsl:if test="@DEA_MEF_ID_AUDIO8 != ''">
						<DEA_MEF_ID_AUDIO8><xsl:value-of select="@DEA_MEF_ID_AUDIO8" /></DEA_MEF_ID_AUDIO8>
					</xsl:if>
					<xsl:if test="@DEA_IS_DVI_PBSENCODES != ''">
						<DEA_IS_DVI_PBSENCODES><xsl:value-of select="@DEA_IS_DVI_PBSENCODES" /></DEA_IS_DVI_PBSENCODES>
					</xsl:if>
					<xsl:if test="@DEA_IS_DVI_PBSCOORDINATES != ''">
						<DEA_IS_DVI_PBSCOORDINATES><xsl:value-of select="@DEA_IS_DVI_PBSCOORDINATES" /></DEA_IS_DVI_PBSCOORDINATES>
					</xsl:if>
					<xsl:if test="@DEA_IS_SAP_PBSENCODES != ''">
						<DEA_IS_SAP_PBSENCODES><xsl:value-of select="@DEA_IS_SAP_PBSENCODES" /></DEA_IS_SAP_PBSENCODES>
					</xsl:if>
					<xsl:if test="@DEA_ISSUBTITLES != ''">
						<DEA_ISSUBTITLES><xsl:value-of select="@DEA_ISSUBTITLES" /></DEA_ISSUBTITLES>
					</xsl:if>
					<xsl:if test="@DEA_LAN_ID_SUBTITLES != ''">
						<DEA_LAN_ID_SUBTITLES><xsl:value-of select="@DEA_LAN_ID_SUBTITLES" /></DEA_LAN_ID_SUBTITLES>
					</xsl:if>
					<xsl:if test="@DEA_MEF_ID_CAPTION1 != ''">
						<DEA_MEF_ID_CAPTION1><xsl:value-of select="@DEA_MEF_ID_CAPTION1" /></DEA_MEF_ID_CAPTION1>
					</xsl:if>
					<xsl:if test="@DEA_MEF_ID_CAPTION2 != ''">
						<DEA_MEF_ID_CAPTION2><xsl:value-of select="@DEA_MEF_ID_CAPTION2" /></DEA_MEF_ID_CAPTION2>
					</xsl:if>
					<xsl:if test="@DEA_MEF_ID_CAPTION3 != ''">
						<DEA_MEF_ID_CAPTION3><xsl:value-of select="@DEA_MEF_ID_CAPTION3" /></DEA_MEF_ID_CAPTION3>
					</xsl:if>
					<xsl:if test="@DEA_IS_CC_PBSENCODES != ''">
						<DEA_IS_CC_PBSENCODES><xsl:value-of select="@DEA_IS_CC_PBSENCODES" /></DEA_IS_CC_PBSENCODES>
					</xsl:if>
					<xsl:if test="@DEA_IS_CC_PBSCOORDINATES != ''">
						<DEA_IS_CC_PBSCOORDINATES><xsl:value-of select="@DEA_IS_CC_PBSCOORDINATES" /></DEA_IS_CC_PBSCOORDINATES>
					</xsl:if>
					<xsl:if test="@DEA_CC_PROVIDER != ''">
						<DEA_CC_PROVIDER><xsl:value-of select="@DEA_CC_PROVIDER" /></DEA_CC_PROVIDER>
					</xsl:if>
					<xsl:if test="@DEA_PBSCV_ID != ''">
						<DEA_PBSCV_ID><xsl:value-of select="@DEA_PBSCV_ID" /></DEA_PBSCV_ID>
					</xsl:if>
					<xsl:if test="@DEA_SLU_ID_ASPECTRATIO != ''">
						<DEA_SLU_ID_ASPECTRATIO><xsl:value-of select="@DEA_SLU_ID_ASPECTRATIO" /></DEA_SLU_ID_ASPECTRATIO>
					</xsl:if>
					<xsl:if test="@DEA_ISINTERNALBREAK != ''">
						<DEA_ISINTERNALBREAK><xsl:value-of select="@DEA_ISINTERNALBREAK" /></DEA_ISINTERNALBREAK>
					</xsl:if>
					<xsl:if test="@DEA_ISCC != ''">
						<DEA_ISCC><xsl:value-of select="@DEA_ISCC" /></DEA_ISCC>
					</xsl:if>
					<xsl:if test="@DEA_ISSAP != ''">
						<DEA_ISSAP><xsl:value-of select="@DEA_ISSAP" /></DEA_ISSAP>
					</xsl:if>
					<xsl:if test="@DEA_ISDVI != ''">
						<DEA_ISDVI><xsl:value-of select="@DEA_ISDVI" /></DEA_ISDVI>
					</xsl:if>
					<xsl:if test="@DEA_SLU_ID_HIDEF != ''">
						<DEA_SLU_ID_HIDEF><xsl:value-of select="@DEA_SLU_ID_HIDEF" /></DEA_SLU_ID_HIDEF>
					</xsl:if>
					<xsl:if test="@DEA_PBSCONTENTDESCRIPTION != ''">
						<DEA_PBSCONTENTDESCRIPTION><xsl:value-of select="@DEA_PBSCONTENTDESCRIPTION" /></DEA_PBSCONTENTDESCRIPTION>
					</xsl:if>
					<xsl:if test="@DEA_PBSOPERATINGUNIT != ''">
						<DEA_PBSOPERATINGUNIT><xsl:value-of select="@DEA_PBSOPERATINGUNIT" /></DEA_PBSOPERATINGUNIT>
					</xsl:if>
						<DEA_PBSOPERATINGGROUP><xsl:value-of select="@DEA_PBSOPERATINGGROUP" /></DEA_PBSOPERATINGGROUP>
					<xsl:if test="@DEA_ISPBSOPENCAPTIONS != ''">
						<DEA_ISPBSOPENCAPTIONS><xsl:value-of select="@DEA_ISPBSOPENCAPTIONS" /></DEA_ISPBSOPENCAPTIONS>
					</xsl:if>
					<xsl:if test="@DEA_PBSLIVEDESTINATION != ''">
						<DEA_PBSLIVEDESTINATION><xsl:value-of select="@DEA_PBSLIVEDESTINATION" /></DEA_PBSLIVEDESTINATION>
					</xsl:if>
					<xsl:if test="@DEA_PBSLIVEBACKUPPATH1 != ''">
						<DEA_PBSLIVEBACKUPPATH1><xsl:value-of select="@DEA_PBSLIVEBACKUPPATH1" /></DEA_PBSLIVEBACKUPPATH1>
					</xsl:if>
					<xsl:if test="@DEA_PBSLIVEBACKUPPATH2 != ''">
						<DEA_PBSLIVEBACKUPPATH2><xsl:value-of select="@DEA_PBSLIVEBACKUPPATH2" /></DEA_PBSLIVEBACKUPPATH2>
					</xsl:if>
					<xsl:if test="@DEA_PBSLIVEBACKUPPATH3 != ''">
						<DEA_PBSLIVEBACKUPPATH3><xsl:value-of select="@DEA_PBSLIVEBACKUPPATH3" /></DEA_PBSLIVEBACKUPPATH3>
					</xsl:if>
					<xsl:if test="@DEA_PBSLIVEBACKUPPATH4 != ''">
						<DEA_PBSLIVEBACKUPPATH4><xsl:value-of select="@DEA_PBSLIVEBACKUPPATH4" /></DEA_PBSLIVEBACKUPPATH4>
					</xsl:if>
					<xsl:if test="@DEA_MDL_ID != ''">
						<DEA_MDL_ID><xsl:value-of select="@DEA_MDL_ID" /></DEA_MDL_ID>
					</xsl:if>
					<xsl:if test="@DEA_GNR_ID != ''">
						<DEA_GNR_ID><xsl:value-of select="@DEA_GNR_ID" /></DEA_GNR_ID>
					</xsl:if>
					<xsl:if test="@DEA_ACM_ID != ''">
						<DEA_ACM_ID><xsl:value-of select="@DEA_ACM_ID" /></DEA_ACM_ID>
					</xsl:if>
					<xsl:if test="@DEA_ALLIANTCONTRACTID != ''">
						<DEA_ALLIANTCONTRACTID><xsl:value-of select="@DEA_ALLIANTCONTRACTID" /></DEA_ALLIANTCONTRACTID>
					</xsl:if>
					<xsl:if test="@ISALLIANTCONTRACTINTERFACED != ''">
						<ISALLIANTCONTRACTINTERFACED><xsl:value-of select="@ISALLIANTCONTRACTINTERFACED" /></ISALLIANTCONTRACTINTERFACED>
					</xsl:if>
					<xsl:if test="@DEA_PBSBC_ID != ''">
						<DEA_PBSBC_ID><xsl:value-of select="@DEA_PBSBC_ID" /></DEA_PBSBC_ID>
					</xsl:if>
					<xsl:if test="@DEA_PBSCONTENTDESCRIPTION_1 != ''">
						<DEA_PBSCONTENTDESCRIPTION_1><xsl:value-of select="@DEA_PBSCONTENTDESCRIPTION_1" /></DEA_PBSCONTENTDESCRIPTION_1>
					</xsl:if>
					<xsl:if test="@DEA_ISPBSSERIESDESCRIPTION != ''">
						<DEA_ISPBSSERIESDESCRIPTION><xsl:value-of select="@DEA_ISPBSSERIESDESCRIPTION" /></DEA_ISPBSSERIESDESCRIPTION>
					</xsl:if>
				</DEAL>
				<xsl:for-each select="PBSDEALCONTACT/ROWPBSDEALCONTACT">
					<PBSDEALCONTACT>
					<xsl:attribute name="diffgr:id">PBSDEALCONTACT<xsl:value-of select="position()" /></xsl:attribute>
					<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
						<PBSDC_ID><xsl:value-of select="@PBSDC_ID" /></PBSDC_ID>
						<PBSDC_SLU_ID_CONTACTTYPE><xsl:value-of select="@PBSDC_SLU_ID_CONTACTTYPE" /></PBSDC_SLU_ID_CONTACTTYPE>
						<xsl:if test="@PBSDC_CONTACTNAME != ''">
							<PBSDC_CONTACTNAME><xsl:value-of select="@PBSDC_CONTACTNAME" /></PBSDC_CONTACTNAME>
						</xsl:if>
						<xsl:if test="@PBSDC_CONTACTPHONE != ''">
							<PBSDC_CONTACTPHONE><xsl:value-of select="@PBSDC_CONTACTPHONE" /></PBSDC_CONTACTPHONE>
						</xsl:if>
						<xsl:if test="@PBSDC_CONTACTEMAIL != ''">
							<PBSDC_CONTACTEMAIL><xsl:value-of select="@PBSDC_CONTACTEMAIL" /></PBSDC_CONTACTEMAIL>
						</xsl:if>
						<PBSDC_COM_ID><xsl:value-of select="@PBSDC_COM_ID" /></PBSDC_COM_ID>
						<PBSDC_DEA_ID><xsl:value-of select="@PBSDC_DEA_ID" /></PBSDC_DEA_ID>
					</PBSDEALCONTACT>
				</xsl:for-each>
			</xsl:for-each>
		</DealWithGeneralDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
