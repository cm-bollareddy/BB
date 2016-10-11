<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1" xmlns:msxsl="urn:schemas-microsoft-com:xslt" version="1.0">

<xsl:output method="xml" />

<xsl:variable name="ROWSTATE_BEFORE">1</xsl:variable>
<xsl:variable name="ROWSTATE_DELETED">2</xsl:variable>
<xsl:variable name="ROWSTATE_NEW">4</xsl:variable>
<xsl:variable name="ROWSTATE_DETACHED">6</xsl:variable> <!-- This one we do not use -->
<xsl:variable name="ROWSTATE_AFTER">8</xsl:variable>
<xsl:variable name="ROWSTATE_UNCHANGED">64</xsl:variable>

<xsl:key name="OriginalDEAL" match="//diffgr:before/DEAL" use="@diffgr:id" />
<xsl:key name="CurrentDEAL" match="//DealWithFundingDataSet/DEAL" use="@diffgr:id" />
<xsl:key name="OriginalMASTERDEAL" match="//diffgr:before/MASTERDEAL" use="@diffgr:id" />
<xsl:key name="CurrentMASTERDEAL" match="//DealWithFundingDataSet/MASTERDEAL" use="@diffgr:id" />
<xsl:key name="OriginalMASTERDEALFUNDING" match="//diffgr:before/MASTERDEALFUNDING" use="@diffgr:id" />
<xsl:key name="CurrentMASTERDEALFUNDING" match="//DealWithFundingDataSet/MASTERDEALFUNDING" use="@diffgr:id" />
<xsl:key name="OriginalDEALFUNDING" match="//diffgr:before/DEALFUNDING" use="@diffgr:id" />
<xsl:key name="CurrentDEALFUNDING" match="//DealWithFundingDataSet/DEALFUNDING" use="@diffgr:id" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<METADATA><FIELDS><FIELD attrname="DEA_ID" fieldtype="i4" required="true"><PARAM Name="PROVFLAGS" Value="7" Type="i4" Roundtrip="True" /><PARAM Name="ORIGIN" Value="DEAL.DEA_ID" Roundtrip="True" /></FIELD><FIELD attrname="DEA_DESC" fieldtype="string" required="true" WIDTH="80"><PARAM Name="ORIGIN" Value="DEAL.DEA_DESC" Roundtrip="True" /></FIELD><FIELD attrname="EPISODE_COUNT" fieldtype="i4" readonly="true" /><FIELD attrname="DEA_PBSDS_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSDS_ID" Roundtrip="True" /></FIELD><FIELD attrname="DEA_UPDATEDATETIME" fieldtype="dateTime"><PARAM Name="ORIGIN" Value="DEAL.DEA_UPDATEDATETIME" Roundtrip="True" /></FIELD><FIELD attrname="DEA_UPDATEUSERID" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="DEAL.DEA_UPDATEUSERID" Roundtrip="True" /></FIELD><FIELD attrname="SEASON" fieldtype="string" readonly="true" WIDTH="20" /><FIELD attrname="MASTERDEALTITLE" fieldtype="string" readonly="true" WIDTH="80" /><FIELD attrname="DEA_PBSFD_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSFD_ID" Roundtrip="True" /></FIELD><FIELD attrname="DEA_ISPBSMINORITYPRODUCTION" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_ISPBSMINORITYPRODUCTION" Roundtrip="True" /></FIELD><FIELD attrname="DEA_ISPBSMINORITYPRODUCEREXEC" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_ISPBSMINORITYPRODUCEREXEC" Roundtrip="True" /></FIELD><FIELD attrname="DEA_ISPBSMINORITYDIRECTOR" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_ISPBSMINORITYDIRECTOR" Roundtrip="True" /></FIELD><FIELD attrname="DEA_ISPBSMINORITYTALENT" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_ISPBSMINORITYTALENT" Roundtrip="True" /></FIELD><FIELD attrname="DEA_ISPBSMINORITYPRODUCERLINE" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_ISPBSMINORITYPRODUCERLINE" Roundtrip="True" /></FIELD><FIELD attrname="DEA_ISPBSMINORITYWRITER" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_ISPBSMINORITYWRITER" Roundtrip="True" /></FIELD><FIELD attrname="DEA_ISPBSMINORITYSUBJECTMATTER" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_ISPBSMINORITYSUBJECTMATTER" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSPRODUCTIONCOST" fieldtype="r8"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSPRODUCTIONCOST" Roundtrip="True" /></FIELD><FIELD attrname="DEA_SLU_ID_PBSUNDERWRITINGTYPE" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_SLU_ID_PBSUNDERWRITINGTYPE" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSUNDERWRITINGNOTE" fieldtype="bin.hex" SUBTYPE="Text" WIDTH="8"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSUNDERWRITINGNOTE" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSUNDERWRITINGCONTACT" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSUNDERWRITINGCONTACT" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSUNDERWRITINGPHONE" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSUNDERWRITINGPHONE" Roundtrip="True" /></FIELD><FIELD attrname="DEA_SLU_ID_PBSSCHOOLRIGHTSTYPE" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_SLU_ID_PBSSCHOOLRIGHTSTYPE" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSSCHOOLEXPIREDATE" fieldtype="dateTime"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSSCHOOLEXPIREDATE" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSSCHOOLOBDATEMONTHS" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSSCHOOLOBDATEMONTHS" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSSCHOOLOBDATEDAYS" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSSCHOOLOBDATEDAYS" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSSCHOOLEACHBCASTMONTHS" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSSCHOOLEACHBCASTMONTHS" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSSCHOOLEACHBCASTDAYS" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSSCHOOLEACHBCASTDAYS" Roundtrip="True" /></FIELD><FIELD attrname="DEA_ISPBSSIMULCASTRIGHTS" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_ISPBSSIMULCASTRIGHTS" Roundtrip="True" /></FIELD><FIELD attrname="DEA_ISPBSNCCABLERIGHTS" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_ISPBSNCCABLERIGHTS" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSBROADCASTRIGHTSCOMMENTS" fieldtype="bin.hex" SUBTYPE="Text" WIDTH="8"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSBROADCASTRIGHTSCOMMENTS" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSCANADIANHOLDBACK" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSCANADIANHOLDBACK" Roundtrip="True" /></FIELD><FIELD attrname="DEA_ISPBSCANADIANPRERELEASE" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_ISPBSCANADIANPRERELEASE" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSPRODUCTIONCONTACTNAME" fieldtype="string" WIDTH="40"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSPRODUCTIONCONTACTNAME" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSPRODUCTIONCONTACTPHONE" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSPRODUCTIONCONTACTPHONE" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSPRODUCTIONCONTACTEMAIL" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSPRODUCTIONCONTACTEMAIL" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSTECHNICALCONTACTNAME" fieldtype="string" WIDTH="40"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSTECHNICALCONTACTNAME" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSTECHNICALCONTACTPHONE" fieldtype="string" WIDTH="40"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSTECHNICALCONTACTPHONE" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSTECHNICALCONTACTEMAIL" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSTECHNICALCONTACTEMAIL" Roundtrip="True" /></FIELD><FIELD attrname="DEA_ISPBSLIVEEVENT" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_ISPBSLIVEEVENT" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSORIGSITE" fieldtype="bin.hex" SUBTYPE="Text" WIDTH="8"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSORIGSITE" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSUP_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSUP_ID" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSLIVEORIGINATIONPATH" fieldtype="string" WIDTH="40"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSLIVEORIGINATIONPATH" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSLIVEORIGINATIONPATH2" fieldtype="string" WIDTH="40"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSLIVEORIGINATIONPATH2" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSLIVEORIGINATIONPATH3" fieldtype="string" WIDTH="40"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSLIVEORIGINATIONPATH3" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSLIVEORIGINATIONPATH4" fieldtype="string" WIDTH="40"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSLIVEORIGINATIONPATH4" Roundtrip="True" /></FIELD><FIELD attrname="DEA_ISPBSLIVERECORD" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_ISPBSLIVERECORD" Roundtrip="True" /></FIELD><FIELD attrname="DEA_MFC_ID_AUDIOTYPE" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_MFC_ID_AUDIOTYPE" Roundtrip="True" /></FIELD><FIELD attrname="DEA_MEF_ID_AUDIO1" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_MEF_ID_AUDIO1" Roundtrip="True" /></FIELD><FIELD attrname="DEA_MEF_ID_AUDIO2" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_MEF_ID_AUDIO2" Roundtrip="True" /></FIELD><FIELD attrname="DEA_MEF_ID_AUDIO3" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_MEF_ID_AUDIO3" Roundtrip="True" /></FIELD><FIELD attrname="DEA_MEF_ID_AUDIO4" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_MEF_ID_AUDIO4" Roundtrip="True" /></FIELD><FIELD attrname="DEA_MEF_ID_AUDIO5" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_MEF_ID_AUDIO5" Roundtrip="True" /></FIELD><FIELD attrname="DEA_MEF_ID_AUDIO6" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_MEF_ID_AUDIO6" Roundtrip="True" /></FIELD><FIELD attrname="DEA_MEF_ID_AUDIO7" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_MEF_ID_AUDIO7" Roundtrip="True" /></FIELD><FIELD attrname="DEA_MEF_ID_AUDIO8" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_MEF_ID_AUDIO8" Roundtrip="True" /></FIELD><FIELD attrname="DEA_IS_DVI_PBSENCODES" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_IS_DVI_PBSENCODES" Roundtrip="True" /></FIELD><FIELD attrname="DEA_IS_DVI_PBSCOORDINATES" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_IS_DVI_PBSCOORDINATES" Roundtrip="True" /></FIELD><FIELD attrname="DEA_IS_SAP_PBSENCODES" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_IS_SAP_PBSENCODES" Roundtrip="True" /></FIELD><FIELD attrname="DEA_ISSUBTITLES" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_ISSUBTITLES" Roundtrip="True" /></FIELD><FIELD attrname="DEA_LAN_ID_SUBTITLES" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_LAN_ID_SUBTITLES" Roundtrip="True" /></FIELD><FIELD attrname="DEA_MEF_ID_CAPTION1" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_MEF_ID_CAPTION1" Roundtrip="True" /></FIELD><FIELD attrname="DEA_MEF_ID_CAPTION2" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_MEF_ID_CAPTION2" Roundtrip="True" /></FIELD><FIELD attrname="DEA_MEF_ID_CAPTION3" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_MEF_ID_CAPTION3" Roundtrip="True" /></FIELD><FIELD attrname="DEA_IS_CC_PBSENCODES" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_IS_CC_PBSENCODES" Roundtrip="True" /></FIELD><FIELD attrname="DEA_IS_CC_PBSCOORDINATES" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_IS_CC_PBSCOORDINATES" Roundtrip="True" /></FIELD><FIELD attrname="DEA_CC_PROVIDER" fieldtype="string" WIDTH="40"><PARAM Name="ORIGIN" Value="DEAL.DEA_CC_PROVIDER" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSCV_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSCV_ID" Roundtrip="True" /></FIELD><FIELD attrname="DEA_SLU_ID_ASPECTRATIO" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_SLU_ID_ASPECTRATIO" Roundtrip="True" /></FIELD><FIELD attrname="DEA_ISINTERNALBREAK" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_ISINTERNALBREAK" Roundtrip="True" /></FIELD><FIELD attrname="DEA_ISCC" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_ISCC" Roundtrip="True" /></FIELD><FIELD attrname="DEA_ISSAP" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_ISSAP" Roundtrip="True" /></FIELD><FIELD attrname="DEA_ISDVI" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_ISDVI" Roundtrip="True" /></FIELD><FIELD attrname="DEA_SLU_ID_HIDEF" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_SLU_ID_HIDEF" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSCONTENTDESCRIPTION" fieldtype="bin.hex" SUBTYPE="Text" WIDTH="8"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSCONTENTDESCRIPTION" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSOPERATINGUNIT" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSOPERATINGUNIT" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSOPERATINGGROUP" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSOPERATINGGROUP" Roundtrip="True" /></FIELD><FIELD attrname="DEA_ISPBSOPENCAPTIONS" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_ISPBSOPENCAPTIONS" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSLIVEDESTINATION" fieldtype="string" WIDTH="40"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSLIVEDESTINATION" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSLIVEBACKUPPATH1" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSLIVEBACKUPPATH1" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSLIVEBACKUPPATH2" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSLIVEBACKUPPATH2" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSLIVEBACKUPPATH3" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSLIVEBACKUPPATH3" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSLIVEBACKUPPATH4" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSLIVEBACKUPPATH4" Roundtrip="True" /></FIELD><FIELD attrname="DEA_MDL_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_MDL_ID" Roundtrip="True" /></FIELD><FIELD attrname="DEA_GNR_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_GNR_ID" Roundtrip="True" /></FIELD><FIELD attrname="DEA_ACM_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_ACM_ID" Roundtrip="True" /></FIELD><FIELD attrname="DEA_ALLIANTCONTRACTID" fieldtype="string" WIDTH="34"><PARAM Name="ORIGIN" Value="DEAL.DEA_ALLIANTCONTRACTID" Roundtrip="True" /></FIELD><FIELD attrname="ISALLIANTCONTRACTINTERFACED" fieldtype="i2" readonly="true" /><FIELD attrname="DEA_PBSBC_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSBC_ID" Roundtrip="True" /></FIELD><FIELD attrname="DEA_PBSCONTENTDESCRIPTION_1" fieldtype="bin.hex" SUBTYPE="Text" WIDTH="8"><PARAM Name="ORIGIN" Value="DEAL.DEA_PBSCONTENTDESCRIPTION" Roundtrip="True" /></FIELD><FIELD attrname="DEA_ISPBSSERIESDESCRIPTION" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEAL.DEA_ISPBSSERIESDESCRIPTION" Roundtrip="True" /></FIELD><FIELD attrname="MASTERDEAL" fieldtype="nested"><FIELDS><FIELD attrname="MDL_ID" fieldtype="i4" required="true"><PARAM Name="PROVFLAGS" Value="7" Type="i4" Roundtrip="True" /><PARAM Name="ORIGIN" Value="MASTERDEAL.MDL_ID" Roundtrip="True" /></FIELD><FIELD attrname="MDL_DESC" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="MASTERDEAL.MDL_DESC" Roundtrip="True" /></FIELD><FIELD attrname="MDL_PRODUCTIONCOST" fieldtype="r8"><PARAM Name="ORIGIN" Value="MASTERDEAL.MDL_PRODUCTIONCOST" Roundtrip="True" /></FIELD></FIELDS><PARAMS DATASET_DELTA="TRUE" PRIMARY_KEY="1" /></FIELD><FIELD attrname="MASTERDEALFUNDING" fieldtype="nested"><FIELDS><FIELD attrname="MDF_ID" fieldtype="i4" required="true"><PARAM Name="PROVFLAGS" Value="7" Type="i4" Roundtrip="True" /><PARAM Name="ORIGIN" Value="MASTERDEALFUNDING.MDF_ID" Roundtrip="True" /></FIELD><FIELD attrname="MDF_MDL_ID" fieldtype="i4" required="true"><PARAM Name="ORIGIN" Value="MASTERDEALFUNDING.MDF_MDL_ID" Roundtrip="True" /></FIELD><FIELD attrname="MDF_COM_ID_FUNDER" fieldtype="i4" required="true"><PARAM Name="ORIGIN" Value="MASTERDEALFUNDING.MDF_COM_ID_FUNDER" Roundtrip="True" /></FIELD><FIELD attrname="MDF_SLU_ID_FUNDINGTYPE" fieldtype="i4"><PARAM Name="ORIGIN" Value="MASTERDEALFUNDING.MDF_SLU_ID_FUNDINGTYPE" Roundtrip="True" /></FIELD><FIELD attrname="MDF_AMOUNT" fieldtype="r8"><PARAM Name="ORIGIN" Value="MASTERDEALFUNDING.MDF_AMOUNT" Roundtrip="True" /></FIELD><FIELD attrname="MDF_ISCREDITED" fieldtype="i2"><PARAM Name="ORIGIN" Value="MASTERDEALFUNDING.MDF_ISCREDITED" Roundtrip="True" /></FIELD><FIELD attrname="MDF_BEGINDATE" fieldtype="dateTime"><PARAM Name="ORIGIN" Value="MASTERDEALFUNDING.MDF_BEGINDATE" Roundtrip="True" /></FIELD><FIELD attrname="MDF_ENDDATE" fieldtype="dateTime"><PARAM Name="ORIGIN" Value="MASTERDEALFUNDING.MDF_ENDDATE" Roundtrip="True" /></FIELD><FIELD attrname="MDF_FISCALYEAR" fieldtype="i2"><PARAM Name="ORIGIN" Value="MASTERDEALFUNDING.MDF_FISCALYEAR" Roundtrip="True" /></FIELD><FIELD attrname="MDF_ISPRODUCERFUNDING" fieldtype="i2"><PARAM Name="ORIGIN" Value="MASTERDEALFUNDING.MDF_ISPRODUCERFUNDING" Roundtrip="True" /></FIELD></FIELDS><PARAMS DATASET_DELTA="TRUE" PRIMARY_KEY="1" /></FIELD><FIELD attrname="DEALFUNDING" fieldtype="nested"><FIELDS><FIELD attrname="DEF_ID" fieldtype="i4" required="true"><PARAM Name="PROVFLAGS" Value="7" Type="i4" Roundtrip="True" /><PARAM Name="ORIGIN" Value="DEALFUNDING.DEF_ID" Roundtrip="True" /></FIELD><FIELD attrname="DEF_DEA_ID" fieldtype="i4" required="true"><PARAM Name="ORIGIN" Value="DEALFUNDING.DEF_DEA_ID" Roundtrip="True" /></FIELD><FIELD attrname="DEF_COM_ID_FUNDER" fieldtype="i4" required="true"><PARAM Name="ORIGIN" Value="DEALFUNDING.DEF_COM_ID_FUNDER" Roundtrip="True" /></FIELD><FIELD attrname="DEF_SLU_ID_FUNDINGTYPE" fieldtype="i4"><PARAM Name="ORIGIN" Value="DEALFUNDING.DEF_SLU_ID_FUNDINGTYPE" Roundtrip="True" /></FIELD><FIELD attrname="DEF_AMOUNT" fieldtype="r8"><PARAM Name="ORIGIN" Value="DEALFUNDING.DEF_AMOUNT" Roundtrip="True" /></FIELD><FIELD attrname="DEF_FISCALYEAR" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEALFUNDING.DEF_FISCALYEAR" Roundtrip="True" /></FIELD><FIELD attrname="DEF_ISCREDITED" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEALFUNDING.DEF_ISCREDITED" Roundtrip="True" /></FIELD><FIELD attrname="DEF_BEGINDATE" fieldtype="dateTime"><PARAM Name="ORIGIN" Value="DEALFUNDING.DEF_BEGINDATE" Roundtrip="True" /></FIELD><FIELD attrname="DEF_ENDDATE" fieldtype="dateTime"><PARAM Name="ORIGIN" Value="DEALFUNDING.DEF_ENDDATE" Roundtrip="True" /></FIELD><FIELD attrname="DEF_ISPRODUCERFUNDING" fieldtype="i2"><PARAM Name="ORIGIN" Value="DEALFUNDING.DEF_ISPRODUCERFUNDING" Roundtrip="True" /></FIELD></FIELDS><PARAMS DATASET_DELTA="TRUE" PRIMARY_KEY="1" /></FIELD></FIELDS><PARAMS DATASET_DELTA="TRUE" PRIMARY_KEY="1" /></METADATA>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template name="OutputMASTERDEAL">
<xsl:param name="Original" />
<xsl:param name="RowState"><xsl:value-of select="$ROWSTATE_UNCHANGED" /></xsl:param>
	<ROWMASTERDEAL>
		<xsl:attribute name="RowState"><xsl:value-of select="$RowState" /></xsl:attribute>
		<xsl:choose>
			<xsl:when test="$RowState = $ROWSTATE_AFTER">
				<xsl:if test="(not(msxsl:node-set($Original)/MDL_ID) and MDL_ID) or (msxsl:node-set($Original)/MDL_ID != MDL_ID)">
					<xsl:attribute name="MDL_ID"><xsl:value-of select="MDL_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MDL_ID and not(MDL_ID)">
					<xsl:attribute name="MDL_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MDL_DESC) and MDL_DESC) or (msxsl:node-set($Original)/MDL_DESC != MDL_DESC)">
					<xsl:attribute name="MDL_DESC"><xsl:value-of select="MDL_DESC" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MDL_DESC and not(MDL_DESC)">
					<xsl:attribute name="MDL_DESC"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MDL_PRODUCTIONCOST) and MDL_PRODUCTIONCOST) or (msxsl:node-set($Original)/MDL_PRODUCTIONCOST != MDL_PRODUCTIONCOST)">
					<xsl:attribute name="MDL_PRODUCTIONCOST"><xsl:value-of select="MDL_PRODUCTIONCOST" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MDL_PRODUCTIONCOST and not(MDL_PRODUCTIONCOST)">
					<xsl:attribute name="MDL_PRODUCTIONCOST"></xsl:attribute>
				</xsl:if>
			</xsl:when>
			<xsl:otherwise>
				<xsl:attribute name="MDL_ID"><xsl:value-of select="MDL_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MDL_ID and not(MDL_ID)">
					<xsl:attribute name="MDL_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MDL_DESC"><xsl:value-of select="MDL_DESC" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MDL_DESC and not(MDL_DESC)">
					<xsl:attribute name="MDL_DESC"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MDL_PRODUCTIONCOST"><xsl:value-of select="MDL_PRODUCTIONCOST" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MDL_PRODUCTIONCOST and not(MDL_PRODUCTIONCOST)">
					<xsl:attribute name="MDL_PRODUCTIONCOST"></xsl:attribute>
				</xsl:if>
			</xsl:otherwise>
		</xsl:choose>

	</ROWMASTERDEAL>
</xsl:template>

<xsl:template name="OutputMASTERDEALFUNDING">
<xsl:param name="Original" />
<xsl:param name="RowState"><xsl:value-of select="$ROWSTATE_UNCHANGED" /></xsl:param>
	<ROWMASTERDEALFUNDING>
		<xsl:attribute name="RowState"><xsl:value-of select="$RowState" /></xsl:attribute>
		<xsl:choose>
			<xsl:when test="$RowState = $ROWSTATE_AFTER">
				<xsl:if test="(not(msxsl:node-set($Original)/MDF_ID) and MDF_ID) or (msxsl:node-set($Original)/MDF_ID != MDF_ID)">
					<xsl:attribute name="MDF_ID"><xsl:value-of select="MDF_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MDF_ID and not(MDF_ID)">
					<xsl:attribute name="MDF_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MDF_MDL_ID) and MDF_MDL_ID) or (msxsl:node-set($Original)/MDF_MDL_ID != MDF_MDL_ID)">
					<xsl:attribute name="MDF_MDL_ID"><xsl:value-of select="MDF_MDL_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MDF_MDL_ID and not(MDF_MDL_ID)">
					<xsl:attribute name="MDF_MDL_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MDF_COM_ID_FUNDER) and MDF_COM_ID_FUNDER) or (msxsl:node-set($Original)/MDF_COM_ID_FUNDER != MDF_COM_ID_FUNDER)">
					<xsl:attribute name="MDF_COM_ID_FUNDER"><xsl:value-of select="MDF_COM_ID_FUNDER" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MDF_COM_ID_FUNDER and not(MDF_COM_ID_FUNDER)">
					<xsl:attribute name="MDF_COM_ID_FUNDER"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MDF_SLU_ID_FUNDINGTYPE) and MDF_SLU_ID_FUNDINGTYPE) or (msxsl:node-set($Original)/MDF_SLU_ID_FUNDINGTYPE != MDF_SLU_ID_FUNDINGTYPE)">
					<xsl:attribute name="MDF_SLU_ID_FUNDINGTYPE"><xsl:value-of select="MDF_SLU_ID_FUNDINGTYPE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MDF_SLU_ID_FUNDINGTYPE and not(MDF_SLU_ID_FUNDINGTYPE)">
					<xsl:attribute name="MDF_SLU_ID_FUNDINGTYPE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MDF_AMOUNT) and MDF_AMOUNT) or (msxsl:node-set($Original)/MDF_AMOUNT != MDF_AMOUNT)">
					<xsl:attribute name="MDF_AMOUNT"><xsl:value-of select="MDF_AMOUNT" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MDF_AMOUNT and not(MDF_AMOUNT)">
					<xsl:attribute name="MDF_AMOUNT"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MDF_ISCREDITED) and MDF_ISCREDITED) or (msxsl:node-set($Original)/MDF_ISCREDITED != MDF_ISCREDITED)">
					<xsl:attribute name="MDF_ISCREDITED"><xsl:value-of select="MDF_ISCREDITED" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MDF_ISCREDITED and not(MDF_ISCREDITED)">
					<xsl:attribute name="MDF_ISCREDITED"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MDF_BEGINDATE) and MDF_BEGINDATE) or (msxsl:node-set($Original)/MDF_BEGINDATE != MDF_BEGINDATE)">
					<xsl:attribute name="MDF_BEGINDATE"><xsl:value-of select="MDF_BEGINDATE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MDF_BEGINDATE and not(MDF_BEGINDATE)">
					<xsl:attribute name="MDF_BEGINDATE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MDF_ENDDATE) and MDF_ENDDATE) or (msxsl:node-set($Original)/MDF_ENDDATE != MDF_ENDDATE)">
					<xsl:attribute name="MDF_ENDDATE"><xsl:value-of select="MDF_ENDDATE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MDF_ENDDATE and not(MDF_ENDDATE)">
					<xsl:attribute name="MDF_ENDDATE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MDF_FISCALYEAR) and MDF_FISCALYEAR) or (msxsl:node-set($Original)/MDF_FISCALYEAR != MDF_FISCALYEAR)">
					<xsl:attribute name="MDF_FISCALYEAR"><xsl:value-of select="MDF_FISCALYEAR" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MDF_FISCALYEAR and not(MDF_FISCALYEAR)">
					<xsl:attribute name="MDF_FISCALYEAR"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MDF_ISPRODUCERFUNDING) and MDF_ISPRODUCERFUNDING) or (msxsl:node-set($Original)/MDF_ISPRODUCERFUNDING != MDF_ISPRODUCERFUNDING)">
					<xsl:attribute name="MDF_ISPRODUCERFUNDING"><xsl:value-of select="MDF_ISPRODUCERFUNDING" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MDF_ISPRODUCERFUNDING and not(MDF_ISPRODUCERFUNDING)">
					<xsl:attribute name="MDF_ISPRODUCERFUNDING"></xsl:attribute>
				</xsl:if>
			</xsl:when>
			<xsl:otherwise>
				<xsl:attribute name="MDF_ID"><xsl:value-of select="MDF_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MDF_ID and not(MDF_ID)">
					<xsl:attribute name="MDF_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MDF_MDL_ID"><xsl:value-of select="MDF_MDL_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MDF_MDL_ID and not(MDF_MDL_ID)">
					<xsl:attribute name="MDF_MDL_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MDF_COM_ID_FUNDER"><xsl:value-of select="MDF_COM_ID_FUNDER" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MDF_COM_ID_FUNDER and not(MDF_COM_ID_FUNDER)">
					<xsl:attribute name="MDF_COM_ID_FUNDER"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MDF_SLU_ID_FUNDINGTYPE"><xsl:value-of select="MDF_SLU_ID_FUNDINGTYPE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MDF_SLU_ID_FUNDINGTYPE and not(MDF_SLU_ID_FUNDINGTYPE)">
					<xsl:attribute name="MDF_SLU_ID_FUNDINGTYPE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MDF_AMOUNT"><xsl:value-of select="MDF_AMOUNT" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MDF_AMOUNT and not(MDF_AMOUNT)">
					<xsl:attribute name="MDF_AMOUNT"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MDF_ISCREDITED"><xsl:value-of select="MDF_ISCREDITED" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MDF_ISCREDITED and not(MDF_ISCREDITED)">
					<xsl:attribute name="MDF_ISCREDITED"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MDF_BEGINDATE"><xsl:value-of select="MDF_BEGINDATE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MDF_BEGINDATE and not(MDF_BEGINDATE)">
					<xsl:attribute name="MDF_BEGINDATE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MDF_ENDDATE"><xsl:value-of select="MDF_ENDDATE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MDF_ENDDATE and not(MDF_ENDDATE)">
					<xsl:attribute name="MDF_ENDDATE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MDF_FISCALYEAR"><xsl:value-of select="MDF_FISCALYEAR" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MDF_FISCALYEAR and not(MDF_FISCALYEAR)">
					<xsl:attribute name="MDF_FISCALYEAR"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MDF_ISPRODUCERFUNDING"><xsl:value-of select="MDF_ISPRODUCERFUNDING" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MDF_ISPRODUCERFUNDING and not(MDF_ISPRODUCERFUNDING)">
					<xsl:attribute name="MDF_ISPRODUCERFUNDING"></xsl:attribute>
				</xsl:if>
			</xsl:otherwise>
		</xsl:choose>

	</ROWMASTERDEALFUNDING>
</xsl:template>

<xsl:template name="OutputDEALFUNDING">
<xsl:param name="Original" />
<xsl:param name="RowState"><xsl:value-of select="$ROWSTATE_UNCHANGED" /></xsl:param>
	<ROWDEALFUNDING>
		<xsl:attribute name="RowState"><xsl:value-of select="$RowState" /></xsl:attribute>
		<xsl:choose>
			<xsl:when test="$RowState = $ROWSTATE_AFTER">
				<xsl:if test="(not(msxsl:node-set($Original)/DEF_ID) and DEF_ID) or (msxsl:node-set($Original)/DEF_ID != DEF_ID)">
					<xsl:attribute name="DEF_ID"><xsl:value-of select="DEF_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEF_ID and not(DEF_ID)">
					<xsl:attribute name="DEF_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEF_DEA_ID) and DEF_DEA_ID) or (msxsl:node-set($Original)/DEF_DEA_ID != DEF_DEA_ID)">
					<xsl:attribute name="DEF_DEA_ID"><xsl:value-of select="DEF_DEA_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEF_DEA_ID and not(DEF_DEA_ID)">
					<xsl:attribute name="DEF_DEA_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEF_COM_ID_FUNDER) and DEF_COM_ID_FUNDER) or (msxsl:node-set($Original)/DEF_COM_ID_FUNDER != DEF_COM_ID_FUNDER)">
					<xsl:attribute name="DEF_COM_ID_FUNDER"><xsl:value-of select="DEF_COM_ID_FUNDER" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEF_COM_ID_FUNDER and not(DEF_COM_ID_FUNDER)">
					<xsl:attribute name="DEF_COM_ID_FUNDER"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEF_SLU_ID_FUNDINGTYPE) and DEF_SLU_ID_FUNDINGTYPE) or (msxsl:node-set($Original)/DEF_SLU_ID_FUNDINGTYPE != DEF_SLU_ID_FUNDINGTYPE)">
					<xsl:attribute name="DEF_SLU_ID_FUNDINGTYPE"><xsl:value-of select="DEF_SLU_ID_FUNDINGTYPE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEF_SLU_ID_FUNDINGTYPE and not(DEF_SLU_ID_FUNDINGTYPE)">
					<xsl:attribute name="DEF_SLU_ID_FUNDINGTYPE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEF_AMOUNT) and DEF_AMOUNT) or (msxsl:node-set($Original)/DEF_AMOUNT != DEF_AMOUNT)">
					<xsl:attribute name="DEF_AMOUNT"><xsl:value-of select="DEF_AMOUNT" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEF_AMOUNT and not(DEF_AMOUNT)">
					<xsl:attribute name="DEF_AMOUNT"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEF_FISCALYEAR) and DEF_FISCALYEAR) or (msxsl:node-set($Original)/DEF_FISCALYEAR != DEF_FISCALYEAR)">
					<xsl:attribute name="DEF_FISCALYEAR"><xsl:value-of select="DEF_FISCALYEAR" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEF_FISCALYEAR and not(DEF_FISCALYEAR)">
					<xsl:attribute name="DEF_FISCALYEAR"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEF_ISCREDITED) and DEF_ISCREDITED) or (msxsl:node-set($Original)/DEF_ISCREDITED != DEF_ISCREDITED)">
					<xsl:attribute name="DEF_ISCREDITED"><xsl:value-of select="DEF_ISCREDITED" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEF_ISCREDITED and not(DEF_ISCREDITED)">
					<xsl:attribute name="DEF_ISCREDITED"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEF_BEGINDATE) and DEF_BEGINDATE) or (msxsl:node-set($Original)/DEF_BEGINDATE != DEF_BEGINDATE)">
					<xsl:attribute name="DEF_BEGINDATE"><xsl:value-of select="DEF_BEGINDATE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEF_BEGINDATE and not(DEF_BEGINDATE)">
					<xsl:attribute name="DEF_BEGINDATE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEF_ENDDATE) and DEF_ENDDATE) or (msxsl:node-set($Original)/DEF_ENDDATE != DEF_ENDDATE)">
					<xsl:attribute name="DEF_ENDDATE"><xsl:value-of select="DEF_ENDDATE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEF_ENDDATE and not(DEF_ENDDATE)">
					<xsl:attribute name="DEF_ENDDATE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEF_ISPRODUCERFUNDING) and DEF_ISPRODUCERFUNDING) or (msxsl:node-set($Original)/DEF_ISPRODUCERFUNDING != DEF_ISPRODUCERFUNDING)">
					<xsl:attribute name="DEF_ISPRODUCERFUNDING"><xsl:value-of select="DEF_ISPRODUCERFUNDING" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEF_ISPRODUCERFUNDING and not(DEF_ISPRODUCERFUNDING)">
					<xsl:attribute name="DEF_ISPRODUCERFUNDING"></xsl:attribute>
				</xsl:if>
			</xsl:when>
			<xsl:otherwise>
				<xsl:attribute name="DEF_ID"><xsl:value-of select="DEF_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEF_ID and not(DEF_ID)">
					<xsl:attribute name="DEF_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEF_DEA_ID"><xsl:value-of select="DEF_DEA_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEF_DEA_ID and not(DEF_DEA_ID)">
					<xsl:attribute name="DEF_DEA_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEF_COM_ID_FUNDER"><xsl:value-of select="DEF_COM_ID_FUNDER" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEF_COM_ID_FUNDER and not(DEF_COM_ID_FUNDER)">
					<xsl:attribute name="DEF_COM_ID_FUNDER"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEF_SLU_ID_FUNDINGTYPE"><xsl:value-of select="DEF_SLU_ID_FUNDINGTYPE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEF_SLU_ID_FUNDINGTYPE and not(DEF_SLU_ID_FUNDINGTYPE)">
					<xsl:attribute name="DEF_SLU_ID_FUNDINGTYPE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEF_AMOUNT"><xsl:value-of select="DEF_AMOUNT" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEF_AMOUNT and not(DEF_AMOUNT)">
					<xsl:attribute name="DEF_AMOUNT"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEF_FISCALYEAR"><xsl:value-of select="DEF_FISCALYEAR" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEF_FISCALYEAR and not(DEF_FISCALYEAR)">
					<xsl:attribute name="DEF_FISCALYEAR"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEF_ISCREDITED"><xsl:value-of select="DEF_ISCREDITED" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEF_ISCREDITED and not(DEF_ISCREDITED)">
					<xsl:attribute name="DEF_ISCREDITED"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEF_BEGINDATE"><xsl:value-of select="DEF_BEGINDATE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEF_BEGINDATE and not(DEF_BEGINDATE)">
					<xsl:attribute name="DEF_BEGINDATE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEF_ENDDATE"><xsl:value-of select="DEF_ENDDATE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEF_ENDDATE and not(DEF_ENDDATE)">
					<xsl:attribute name="DEF_ENDDATE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEF_ISPRODUCERFUNDING"><xsl:value-of select="DEF_ISPRODUCERFUNDING" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEF_ISPRODUCERFUNDING and not(DEF_ISPRODUCERFUNDING)">
					<xsl:attribute name="DEF_ISPRODUCERFUNDING"></xsl:attribute>
				</xsl:if>
			</xsl:otherwise>
		</xsl:choose>

	</ROWDEALFUNDING>
</xsl:template>

<xsl:template name="OutputDEAL">
<xsl:param name="Original" />
<xsl:param name="RowState"><xsl:value-of select="$ROWSTATE_UNCHANGED" /></xsl:param>
	<ROW>
		<xsl:attribute name="RowState"><xsl:value-of select="$RowState" /></xsl:attribute>
		<xsl:choose>
			<xsl:when test="$RowState = $ROWSTATE_AFTER">
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_ID) and DEA_ID) or (msxsl:node-set($Original)/DEA_ID != DEA_ID)">
					<xsl:attribute name="DEA_ID"><xsl:value-of select="DEA_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_ID and not(DEA_ID)">
					<xsl:attribute name="DEA_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_DESC) and DEA_DESC) or (msxsl:node-set($Original)/DEA_DESC != DEA_DESC)">
					<xsl:attribute name="DEA_DESC"><xsl:value-of select="DEA_DESC" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_DESC and not(DEA_DESC)">
					<xsl:attribute name="DEA_DESC"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSDS_ID) and DEA_PBSDS_ID) or (msxsl:node-set($Original)/DEA_PBSDS_ID != DEA_PBSDS_ID)">
					<xsl:attribute name="DEA_PBSDS_ID"><xsl:value-of select="DEA_PBSDS_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSDS_ID and not(DEA_PBSDS_ID)">
					<xsl:attribute name="DEA_PBSDS_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_UPDATEDATETIME) and DEA_UPDATEDATETIME) or (msxsl:node-set($Original)/DEA_UPDATEDATETIME != DEA_UPDATEDATETIME)">
					<xsl:attribute name="DEA_UPDATEDATETIME"><xsl:value-of select="DEA_UPDATEDATETIME" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_UPDATEDATETIME and not(DEA_UPDATEDATETIME)">
					<xsl:attribute name="DEA_UPDATEDATETIME"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_UPDATEUSERID) and DEA_UPDATEUSERID) or (msxsl:node-set($Original)/DEA_UPDATEUSERID != DEA_UPDATEUSERID)">
					<xsl:attribute name="DEA_UPDATEUSERID"><xsl:value-of select="DEA_UPDATEUSERID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_UPDATEUSERID and not(DEA_UPDATEUSERID)">
					<xsl:attribute name="DEA_UPDATEUSERID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSFD_ID) and DEA_PBSFD_ID) or (msxsl:node-set($Original)/DEA_PBSFD_ID != DEA_PBSFD_ID)">
					<xsl:attribute name="DEA_PBSFD_ID"><xsl:value-of select="DEA_PBSFD_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSFD_ID and not(DEA_PBSFD_ID)">
					<xsl:attribute name="DEA_PBSFD_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_ISPBSMINORITYPRODUCTION) and DEA_ISPBSMINORITYPRODUCTION) or (msxsl:node-set($Original)/DEA_ISPBSMINORITYPRODUCTION != DEA_ISPBSMINORITYPRODUCTION)">
					<xsl:attribute name="DEA_ISPBSMINORITYPRODUCTION"><xsl:value-of select="DEA_ISPBSMINORITYPRODUCTION" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSMINORITYPRODUCTION and not(DEA_ISPBSMINORITYPRODUCTION)">
					<xsl:attribute name="DEA_ISPBSMINORITYPRODUCTION"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_ISPBSMINORITYPRODUCEREXEC) and DEA_ISPBSMINORITYPRODUCEREXEC) or (msxsl:node-set($Original)/DEA_ISPBSMINORITYPRODUCEREXEC != DEA_ISPBSMINORITYPRODUCEREXEC)">
					<xsl:attribute name="DEA_ISPBSMINORITYPRODUCEREXEC"><xsl:value-of select="DEA_ISPBSMINORITYPRODUCEREXEC" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSMINORITYPRODUCEREXEC and not(DEA_ISPBSMINORITYPRODUCEREXEC)">
					<xsl:attribute name="DEA_ISPBSMINORITYPRODUCEREXEC"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_ISPBSMINORITYDIRECTOR) and DEA_ISPBSMINORITYDIRECTOR) or (msxsl:node-set($Original)/DEA_ISPBSMINORITYDIRECTOR != DEA_ISPBSMINORITYDIRECTOR)">
					<xsl:attribute name="DEA_ISPBSMINORITYDIRECTOR"><xsl:value-of select="DEA_ISPBSMINORITYDIRECTOR" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSMINORITYDIRECTOR and not(DEA_ISPBSMINORITYDIRECTOR)">
					<xsl:attribute name="DEA_ISPBSMINORITYDIRECTOR"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_ISPBSMINORITYTALENT) and DEA_ISPBSMINORITYTALENT) or (msxsl:node-set($Original)/DEA_ISPBSMINORITYTALENT != DEA_ISPBSMINORITYTALENT)">
					<xsl:attribute name="DEA_ISPBSMINORITYTALENT"><xsl:value-of select="DEA_ISPBSMINORITYTALENT" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSMINORITYTALENT and not(DEA_ISPBSMINORITYTALENT)">
					<xsl:attribute name="DEA_ISPBSMINORITYTALENT"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_ISPBSMINORITYPRODUCERLINE) and DEA_ISPBSMINORITYPRODUCERLINE) or (msxsl:node-set($Original)/DEA_ISPBSMINORITYPRODUCERLINE != DEA_ISPBSMINORITYPRODUCERLINE)">
					<xsl:attribute name="DEA_ISPBSMINORITYPRODUCERLINE"><xsl:value-of select="DEA_ISPBSMINORITYPRODUCERLINE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSMINORITYPRODUCERLINE and not(DEA_ISPBSMINORITYPRODUCERLINE)">
					<xsl:attribute name="DEA_ISPBSMINORITYPRODUCERLINE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_ISPBSMINORITYWRITER) and DEA_ISPBSMINORITYWRITER) or (msxsl:node-set($Original)/DEA_ISPBSMINORITYWRITER != DEA_ISPBSMINORITYWRITER)">
					<xsl:attribute name="DEA_ISPBSMINORITYWRITER"><xsl:value-of select="DEA_ISPBSMINORITYWRITER" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSMINORITYWRITER and not(DEA_ISPBSMINORITYWRITER)">
					<xsl:attribute name="DEA_ISPBSMINORITYWRITER"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_ISPBSMINORITYSUBJECTMATTER) and DEA_ISPBSMINORITYSUBJECTMATTER) or (msxsl:node-set($Original)/DEA_ISPBSMINORITYSUBJECTMATTER != DEA_ISPBSMINORITYSUBJECTMATTER)">
					<xsl:attribute name="DEA_ISPBSMINORITYSUBJECTMATTER"><xsl:value-of select="DEA_ISPBSMINORITYSUBJECTMATTER" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSMINORITYSUBJECTMATTER and not(DEA_ISPBSMINORITYSUBJECTMATTER)">
					<xsl:attribute name="DEA_ISPBSMINORITYSUBJECTMATTER"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSPRODUCTIONCOST) and DEA_PBSPRODUCTIONCOST) or (msxsl:node-set($Original)/DEA_PBSPRODUCTIONCOST != DEA_PBSPRODUCTIONCOST)">
					<xsl:attribute name="DEA_PBSPRODUCTIONCOST"><xsl:value-of select="DEA_PBSPRODUCTIONCOST" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSPRODUCTIONCOST and not(DEA_PBSPRODUCTIONCOST)">
					<xsl:attribute name="DEA_PBSPRODUCTIONCOST"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_SLU_ID_PBSUNDERWRITINGTYPE) and DEA_SLU_ID_PBSUNDERWRITINGTYPE) or (msxsl:node-set($Original)/DEA_SLU_ID_PBSUNDERWRITINGTYPE != DEA_SLU_ID_PBSUNDERWRITINGTYPE)">
					<xsl:attribute name="DEA_SLU_ID_PBSUNDERWRITINGTYPE"><xsl:value-of select="DEA_SLU_ID_PBSUNDERWRITINGTYPE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_SLU_ID_PBSUNDERWRITINGTYPE and not(DEA_SLU_ID_PBSUNDERWRITINGTYPE)">
					<xsl:attribute name="DEA_SLU_ID_PBSUNDERWRITINGTYPE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="DEA_PBSUNDERWRITINGNOTE != '' and (not(msxsl:node-set($Original)/DEA_PBSUNDERWRITINGNOTE) and DEA_PBSUNDERWRITINGNOTE) or (msxsl:node-set($Original)/DEA_PBSUNDERWRITINGNOTE != DEA_PBSUNDERWRITINGNOTE)">
					<xsl:attribute name="DEA_PBSUNDERWRITINGNOTE"><xsl:value-of select="DEA_PBSUNDERWRITINGNOTE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSUNDERWRITINGNOTE and not(DEA_PBSUNDERWRITINGNOTE)">
					<xsl:attribute name="DEA_PBSUNDERWRITINGNOTE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSUNDERWRITINGCONTACT) and DEA_PBSUNDERWRITINGCONTACT) or (msxsl:node-set($Original)/DEA_PBSUNDERWRITINGCONTACT != DEA_PBSUNDERWRITINGCONTACT)">
					<xsl:attribute name="DEA_PBSUNDERWRITINGCONTACT"><xsl:value-of select="DEA_PBSUNDERWRITINGCONTACT" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSUNDERWRITINGCONTACT and not(DEA_PBSUNDERWRITINGCONTACT)">
					<xsl:attribute name="DEA_PBSUNDERWRITINGCONTACT"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSUNDERWRITINGPHONE) and DEA_PBSUNDERWRITINGPHONE) or (msxsl:node-set($Original)/DEA_PBSUNDERWRITINGPHONE != DEA_PBSUNDERWRITINGPHONE)">
					<xsl:attribute name="DEA_PBSUNDERWRITINGPHONE"><xsl:value-of select="DEA_PBSUNDERWRITINGPHONE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSUNDERWRITINGPHONE and not(DEA_PBSUNDERWRITINGPHONE)">
					<xsl:attribute name="DEA_PBSUNDERWRITINGPHONE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_SLU_ID_PBSSCHOOLRIGHTSTYPE) and DEA_SLU_ID_PBSSCHOOLRIGHTSTYPE) or (msxsl:node-set($Original)/DEA_SLU_ID_PBSSCHOOLRIGHTSTYPE != DEA_SLU_ID_PBSSCHOOLRIGHTSTYPE)">
					<xsl:attribute name="DEA_SLU_ID_PBSSCHOOLRIGHTSTYPE"><xsl:value-of select="DEA_SLU_ID_PBSSCHOOLRIGHTSTYPE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_SLU_ID_PBSSCHOOLRIGHTSTYPE and not(DEA_SLU_ID_PBSSCHOOLRIGHTSTYPE)">
					<xsl:attribute name="DEA_SLU_ID_PBSSCHOOLRIGHTSTYPE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSSCHOOLEXPIREDATE) and DEA_PBSSCHOOLEXPIREDATE) or (msxsl:node-set($Original)/DEA_PBSSCHOOLEXPIREDATE != DEA_PBSSCHOOLEXPIREDATE)">
					<xsl:attribute name="DEA_PBSSCHOOLEXPIREDATE"><xsl:value-of select="DEA_PBSSCHOOLEXPIREDATE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSSCHOOLEXPIREDATE and not(DEA_PBSSCHOOLEXPIREDATE)">
					<xsl:attribute name="DEA_PBSSCHOOLEXPIREDATE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSSCHOOLOBDATEMONTHS) and DEA_PBSSCHOOLOBDATEMONTHS) or (msxsl:node-set($Original)/DEA_PBSSCHOOLOBDATEMONTHS != DEA_PBSSCHOOLOBDATEMONTHS)">
					<xsl:attribute name="DEA_PBSSCHOOLOBDATEMONTHS"><xsl:value-of select="DEA_PBSSCHOOLOBDATEMONTHS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSSCHOOLOBDATEMONTHS and not(DEA_PBSSCHOOLOBDATEMONTHS)">
					<xsl:attribute name="DEA_PBSSCHOOLOBDATEMONTHS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSSCHOOLOBDATEDAYS) and DEA_PBSSCHOOLOBDATEDAYS) or (msxsl:node-set($Original)/DEA_PBSSCHOOLOBDATEDAYS != DEA_PBSSCHOOLOBDATEDAYS)">
					<xsl:attribute name="DEA_PBSSCHOOLOBDATEDAYS"><xsl:value-of select="DEA_PBSSCHOOLOBDATEDAYS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSSCHOOLOBDATEDAYS and not(DEA_PBSSCHOOLOBDATEDAYS)">
					<xsl:attribute name="DEA_PBSSCHOOLOBDATEDAYS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSSCHOOLEACHBCASTMONTHS) and DEA_PBSSCHOOLEACHBCASTMONTHS) or (msxsl:node-set($Original)/DEA_PBSSCHOOLEACHBCASTMONTHS != DEA_PBSSCHOOLEACHBCASTMONTHS)">
					<xsl:attribute name="DEA_PBSSCHOOLEACHBCASTMONTHS"><xsl:value-of select="DEA_PBSSCHOOLEACHBCASTMONTHS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSSCHOOLEACHBCASTMONTHS and not(DEA_PBSSCHOOLEACHBCASTMONTHS)">
					<xsl:attribute name="DEA_PBSSCHOOLEACHBCASTMONTHS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSSCHOOLEACHBCASTDAYS) and DEA_PBSSCHOOLEACHBCASTDAYS) or (msxsl:node-set($Original)/DEA_PBSSCHOOLEACHBCASTDAYS != DEA_PBSSCHOOLEACHBCASTDAYS)">
					<xsl:attribute name="DEA_PBSSCHOOLEACHBCASTDAYS"><xsl:value-of select="DEA_PBSSCHOOLEACHBCASTDAYS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSSCHOOLEACHBCASTDAYS and not(DEA_PBSSCHOOLEACHBCASTDAYS)">
					<xsl:attribute name="DEA_PBSSCHOOLEACHBCASTDAYS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_ISPBSSIMULCASTRIGHTS) and DEA_ISPBSSIMULCASTRIGHTS) or (msxsl:node-set($Original)/DEA_ISPBSSIMULCASTRIGHTS != DEA_ISPBSSIMULCASTRIGHTS)">
					<xsl:attribute name="DEA_ISPBSSIMULCASTRIGHTS"><xsl:value-of select="DEA_ISPBSSIMULCASTRIGHTS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSSIMULCASTRIGHTS and not(DEA_ISPBSSIMULCASTRIGHTS)">
					<xsl:attribute name="DEA_ISPBSSIMULCASTRIGHTS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_ISPBSNCCABLERIGHTS) and DEA_ISPBSNCCABLERIGHTS) or (msxsl:node-set($Original)/DEA_ISPBSNCCABLERIGHTS != DEA_ISPBSNCCABLERIGHTS)">
					<xsl:attribute name="DEA_ISPBSNCCABLERIGHTS"><xsl:value-of select="DEA_ISPBSNCCABLERIGHTS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSNCCABLERIGHTS and not(DEA_ISPBSNCCABLERIGHTS)">
					<xsl:attribute name="DEA_ISPBSNCCABLERIGHTS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="DEA_PBSBROADCASTRIGHTSCOMMENTS != '' and (not(msxsl:node-set($Original)/DEA_PBSBROADCASTRIGHTSCOMMENTS) and DEA_PBSBROADCASTRIGHTSCOMMENTS) or (msxsl:node-set($Original)/DEA_PBSBROADCASTRIGHTSCOMMENTS != DEA_PBSBROADCASTRIGHTSCOMMENTS)">
					<xsl:attribute name="DEA_PBSBROADCASTRIGHTSCOMMENTS"><xsl:value-of select="DEA_PBSBROADCASTRIGHTSCOMMENTS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSBROADCASTRIGHTSCOMMENTS and not(DEA_PBSBROADCASTRIGHTSCOMMENTS)">
					<xsl:attribute name="DEA_PBSBROADCASTRIGHTSCOMMENTS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSCANADIANHOLDBACK) and DEA_PBSCANADIANHOLDBACK) or (msxsl:node-set($Original)/DEA_PBSCANADIANHOLDBACK != DEA_PBSCANADIANHOLDBACK)">
					<xsl:attribute name="DEA_PBSCANADIANHOLDBACK"><xsl:value-of select="DEA_PBSCANADIANHOLDBACK" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSCANADIANHOLDBACK and not(DEA_PBSCANADIANHOLDBACK)">
					<xsl:attribute name="DEA_PBSCANADIANHOLDBACK"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_ISPBSCANADIANPRERELEASE) and DEA_ISPBSCANADIANPRERELEASE) or (msxsl:node-set($Original)/DEA_ISPBSCANADIANPRERELEASE != DEA_ISPBSCANADIANPRERELEASE)">
					<xsl:attribute name="DEA_ISPBSCANADIANPRERELEASE"><xsl:value-of select="DEA_ISPBSCANADIANPRERELEASE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSCANADIANPRERELEASE and not(DEA_ISPBSCANADIANPRERELEASE)">
					<xsl:attribute name="DEA_ISPBSCANADIANPRERELEASE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSPRODUCTIONCONTACTNAME) and DEA_PBSPRODUCTIONCONTACTNAME) or (msxsl:node-set($Original)/DEA_PBSPRODUCTIONCONTACTNAME != DEA_PBSPRODUCTIONCONTACTNAME)">
					<xsl:attribute name="DEA_PBSPRODUCTIONCONTACTNAME"><xsl:value-of select="DEA_PBSPRODUCTIONCONTACTNAME" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSPRODUCTIONCONTACTNAME and not(DEA_PBSPRODUCTIONCONTACTNAME)">
					<xsl:attribute name="DEA_PBSPRODUCTIONCONTACTNAME"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSPRODUCTIONCONTACTPHONE) and DEA_PBSPRODUCTIONCONTACTPHONE) or (msxsl:node-set($Original)/DEA_PBSPRODUCTIONCONTACTPHONE != DEA_PBSPRODUCTIONCONTACTPHONE)">
					<xsl:attribute name="DEA_PBSPRODUCTIONCONTACTPHONE"><xsl:value-of select="DEA_PBSPRODUCTIONCONTACTPHONE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSPRODUCTIONCONTACTPHONE and not(DEA_PBSPRODUCTIONCONTACTPHONE)">
					<xsl:attribute name="DEA_PBSPRODUCTIONCONTACTPHONE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSPRODUCTIONCONTACTEMAIL) and DEA_PBSPRODUCTIONCONTACTEMAIL) or (msxsl:node-set($Original)/DEA_PBSPRODUCTIONCONTACTEMAIL != DEA_PBSPRODUCTIONCONTACTEMAIL)">
					<xsl:attribute name="DEA_PBSPRODUCTIONCONTACTEMAIL"><xsl:value-of select="DEA_PBSPRODUCTIONCONTACTEMAIL" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSPRODUCTIONCONTACTEMAIL and not(DEA_PBSPRODUCTIONCONTACTEMAIL)">
					<xsl:attribute name="DEA_PBSPRODUCTIONCONTACTEMAIL"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSTECHNICALCONTACTNAME) and DEA_PBSTECHNICALCONTACTNAME) or (msxsl:node-set($Original)/DEA_PBSTECHNICALCONTACTNAME != DEA_PBSTECHNICALCONTACTNAME)">
					<xsl:attribute name="DEA_PBSTECHNICALCONTACTNAME"><xsl:value-of select="DEA_PBSTECHNICALCONTACTNAME" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSTECHNICALCONTACTNAME and not(DEA_PBSTECHNICALCONTACTNAME)">
					<xsl:attribute name="DEA_PBSTECHNICALCONTACTNAME"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSTECHNICALCONTACTPHONE) and DEA_PBSTECHNICALCONTACTPHONE) or (msxsl:node-set($Original)/DEA_PBSTECHNICALCONTACTPHONE != DEA_PBSTECHNICALCONTACTPHONE)">
					<xsl:attribute name="DEA_PBSTECHNICALCONTACTPHONE"><xsl:value-of select="DEA_PBSTECHNICALCONTACTPHONE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSTECHNICALCONTACTPHONE and not(DEA_PBSTECHNICALCONTACTPHONE)">
					<xsl:attribute name="DEA_PBSTECHNICALCONTACTPHONE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSTECHNICALCONTACTEMAIL) and DEA_PBSTECHNICALCONTACTEMAIL) or (msxsl:node-set($Original)/DEA_PBSTECHNICALCONTACTEMAIL != DEA_PBSTECHNICALCONTACTEMAIL)">
					<xsl:attribute name="DEA_PBSTECHNICALCONTACTEMAIL"><xsl:value-of select="DEA_PBSTECHNICALCONTACTEMAIL" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSTECHNICALCONTACTEMAIL and not(DEA_PBSTECHNICALCONTACTEMAIL)">
					<xsl:attribute name="DEA_PBSTECHNICALCONTACTEMAIL"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_ISPBSLIVEEVENT) and DEA_ISPBSLIVEEVENT) or (msxsl:node-set($Original)/DEA_ISPBSLIVEEVENT != DEA_ISPBSLIVEEVENT)">
					<xsl:attribute name="DEA_ISPBSLIVEEVENT"><xsl:value-of select="DEA_ISPBSLIVEEVENT" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSLIVEEVENT and not(DEA_ISPBSLIVEEVENT)">
					<xsl:attribute name="DEA_ISPBSLIVEEVENT"></xsl:attribute>
				</xsl:if>
				<xsl:if test="DEA_PBSORIGSITE != '' and (not(msxsl:node-set($Original)/DEA_PBSORIGSITE) and DEA_PBSORIGSITE) or (msxsl:node-set($Original)/DEA_PBSORIGSITE != DEA_PBSORIGSITE)">
					<xsl:attribute name="DEA_PBSORIGSITE"><xsl:value-of select="DEA_PBSORIGSITE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSORIGSITE and not(DEA_PBSORIGSITE)">
					<xsl:attribute name="DEA_PBSORIGSITE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSUP_ID) and DEA_PBSUP_ID) or (msxsl:node-set($Original)/DEA_PBSUP_ID != DEA_PBSUP_ID)">
					<xsl:attribute name="DEA_PBSUP_ID"><xsl:value-of select="DEA_PBSUP_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSUP_ID and not(DEA_PBSUP_ID)">
					<xsl:attribute name="DEA_PBSUP_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSLIVEORIGINATIONPATH) and DEA_PBSLIVEORIGINATIONPATH) or (msxsl:node-set($Original)/DEA_PBSLIVEORIGINATIONPATH != DEA_PBSLIVEORIGINATIONPATH)">
					<xsl:attribute name="DEA_PBSLIVEORIGINATIONPATH"><xsl:value-of select="DEA_PBSLIVEORIGINATIONPATH" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSLIVEORIGINATIONPATH and not(DEA_PBSLIVEORIGINATIONPATH)">
					<xsl:attribute name="DEA_PBSLIVEORIGINATIONPATH"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSLIVEORIGINATIONPATH2) and DEA_PBSLIVEORIGINATIONPATH2) or (msxsl:node-set($Original)/DEA_PBSLIVEORIGINATIONPATH2 != DEA_PBSLIVEORIGINATIONPATH2)">
					<xsl:attribute name="DEA_PBSLIVEORIGINATIONPATH2"><xsl:value-of select="DEA_PBSLIVEORIGINATIONPATH2" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSLIVEORIGINATIONPATH2 and not(DEA_PBSLIVEORIGINATIONPATH2)">
					<xsl:attribute name="DEA_PBSLIVEORIGINATIONPATH2"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSLIVEORIGINATIONPATH3) and DEA_PBSLIVEORIGINATIONPATH3) or (msxsl:node-set($Original)/DEA_PBSLIVEORIGINATIONPATH3 != DEA_PBSLIVEORIGINATIONPATH3)">
					<xsl:attribute name="DEA_PBSLIVEORIGINATIONPATH3"><xsl:value-of select="DEA_PBSLIVEORIGINATIONPATH3" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSLIVEORIGINATIONPATH3 and not(DEA_PBSLIVEORIGINATIONPATH3)">
					<xsl:attribute name="DEA_PBSLIVEORIGINATIONPATH3"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSLIVEORIGINATIONPATH4) and DEA_PBSLIVEORIGINATIONPATH4) or (msxsl:node-set($Original)/DEA_PBSLIVEORIGINATIONPATH4 != DEA_PBSLIVEORIGINATIONPATH4)">
					<xsl:attribute name="DEA_PBSLIVEORIGINATIONPATH4"><xsl:value-of select="DEA_PBSLIVEORIGINATIONPATH4" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSLIVEORIGINATIONPATH4 and not(DEA_PBSLIVEORIGINATIONPATH4)">
					<xsl:attribute name="DEA_PBSLIVEORIGINATIONPATH4"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_ISPBSLIVERECORD) and DEA_ISPBSLIVERECORD) or (msxsl:node-set($Original)/DEA_ISPBSLIVERECORD != DEA_ISPBSLIVERECORD)">
					<xsl:attribute name="DEA_ISPBSLIVERECORD"><xsl:value-of select="DEA_ISPBSLIVERECORD" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSLIVERECORD and not(DEA_ISPBSLIVERECORD)">
					<xsl:attribute name="DEA_ISPBSLIVERECORD"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_MFC_ID_AUDIOTYPE) and DEA_MFC_ID_AUDIOTYPE) or (msxsl:node-set($Original)/DEA_MFC_ID_AUDIOTYPE != DEA_MFC_ID_AUDIOTYPE)">
					<xsl:attribute name="DEA_MFC_ID_AUDIOTYPE"><xsl:value-of select="DEA_MFC_ID_AUDIOTYPE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_MFC_ID_AUDIOTYPE and not(DEA_MFC_ID_AUDIOTYPE)">
					<xsl:attribute name="DEA_MFC_ID_AUDIOTYPE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_MEF_ID_AUDIO1) and DEA_MEF_ID_AUDIO1) or (msxsl:node-set($Original)/DEA_MEF_ID_AUDIO1 != DEA_MEF_ID_AUDIO1)">
					<xsl:attribute name="DEA_MEF_ID_AUDIO1"><xsl:value-of select="DEA_MEF_ID_AUDIO1" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_MEF_ID_AUDIO1 and not(DEA_MEF_ID_AUDIO1)">
					<xsl:attribute name="DEA_MEF_ID_AUDIO1"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_MEF_ID_AUDIO2) and DEA_MEF_ID_AUDIO2) or (msxsl:node-set($Original)/DEA_MEF_ID_AUDIO2 != DEA_MEF_ID_AUDIO2)">
					<xsl:attribute name="DEA_MEF_ID_AUDIO2"><xsl:value-of select="DEA_MEF_ID_AUDIO2" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_MEF_ID_AUDIO2 and not(DEA_MEF_ID_AUDIO2)">
					<xsl:attribute name="DEA_MEF_ID_AUDIO2"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_MEF_ID_AUDIO3) and DEA_MEF_ID_AUDIO3) or (msxsl:node-set($Original)/DEA_MEF_ID_AUDIO3 != DEA_MEF_ID_AUDIO3)">
					<xsl:attribute name="DEA_MEF_ID_AUDIO3"><xsl:value-of select="DEA_MEF_ID_AUDIO3" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_MEF_ID_AUDIO3 and not(DEA_MEF_ID_AUDIO3)">
					<xsl:attribute name="DEA_MEF_ID_AUDIO3"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_MEF_ID_AUDIO4) and DEA_MEF_ID_AUDIO4) or (msxsl:node-set($Original)/DEA_MEF_ID_AUDIO4 != DEA_MEF_ID_AUDIO4)">
					<xsl:attribute name="DEA_MEF_ID_AUDIO4"><xsl:value-of select="DEA_MEF_ID_AUDIO4" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_MEF_ID_AUDIO4 and not(DEA_MEF_ID_AUDIO4)">
					<xsl:attribute name="DEA_MEF_ID_AUDIO4"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_MEF_ID_AUDIO5) and DEA_MEF_ID_AUDIO5) or (msxsl:node-set($Original)/DEA_MEF_ID_AUDIO5 != DEA_MEF_ID_AUDIO5)">
					<xsl:attribute name="DEA_MEF_ID_AUDIO5"><xsl:value-of select="DEA_MEF_ID_AUDIO5" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_MEF_ID_AUDIO5 and not(DEA_MEF_ID_AUDIO5)">
					<xsl:attribute name="DEA_MEF_ID_AUDIO5"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_MEF_ID_AUDIO6) and DEA_MEF_ID_AUDIO6) or (msxsl:node-set($Original)/DEA_MEF_ID_AUDIO6 != DEA_MEF_ID_AUDIO6)">
					<xsl:attribute name="DEA_MEF_ID_AUDIO6"><xsl:value-of select="DEA_MEF_ID_AUDIO6" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_MEF_ID_AUDIO6 and not(DEA_MEF_ID_AUDIO6)">
					<xsl:attribute name="DEA_MEF_ID_AUDIO6"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_MEF_ID_AUDIO7) and DEA_MEF_ID_AUDIO7) or (msxsl:node-set($Original)/DEA_MEF_ID_AUDIO7 != DEA_MEF_ID_AUDIO7)">
					<xsl:attribute name="DEA_MEF_ID_AUDIO7"><xsl:value-of select="DEA_MEF_ID_AUDIO7" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_MEF_ID_AUDIO7 and not(DEA_MEF_ID_AUDIO7)">
					<xsl:attribute name="DEA_MEF_ID_AUDIO7"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_MEF_ID_AUDIO8) and DEA_MEF_ID_AUDIO8) or (msxsl:node-set($Original)/DEA_MEF_ID_AUDIO8 != DEA_MEF_ID_AUDIO8)">
					<xsl:attribute name="DEA_MEF_ID_AUDIO8"><xsl:value-of select="DEA_MEF_ID_AUDIO8" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_MEF_ID_AUDIO8 and not(DEA_MEF_ID_AUDIO8)">
					<xsl:attribute name="DEA_MEF_ID_AUDIO8"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_IS_DVI_PBSENCODES) and DEA_IS_DVI_PBSENCODES) or (msxsl:node-set($Original)/DEA_IS_DVI_PBSENCODES != DEA_IS_DVI_PBSENCODES)">
					<xsl:attribute name="DEA_IS_DVI_PBSENCODES"><xsl:value-of select="DEA_IS_DVI_PBSENCODES" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_IS_DVI_PBSENCODES and not(DEA_IS_DVI_PBSENCODES)">
					<xsl:attribute name="DEA_IS_DVI_PBSENCODES"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_IS_DVI_PBSCOORDINATES) and DEA_IS_DVI_PBSCOORDINATES) or (msxsl:node-set($Original)/DEA_IS_DVI_PBSCOORDINATES != DEA_IS_DVI_PBSCOORDINATES)">
					<xsl:attribute name="DEA_IS_DVI_PBSCOORDINATES"><xsl:value-of select="DEA_IS_DVI_PBSCOORDINATES" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_IS_DVI_PBSCOORDINATES and not(DEA_IS_DVI_PBSCOORDINATES)">
					<xsl:attribute name="DEA_IS_DVI_PBSCOORDINATES"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_IS_SAP_PBSENCODES) and DEA_IS_SAP_PBSENCODES) or (msxsl:node-set($Original)/DEA_IS_SAP_PBSENCODES != DEA_IS_SAP_PBSENCODES)">
					<xsl:attribute name="DEA_IS_SAP_PBSENCODES"><xsl:value-of select="DEA_IS_SAP_PBSENCODES" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_IS_SAP_PBSENCODES and not(DEA_IS_SAP_PBSENCODES)">
					<xsl:attribute name="DEA_IS_SAP_PBSENCODES"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_ISSUBTITLES) and DEA_ISSUBTITLES) or (msxsl:node-set($Original)/DEA_ISSUBTITLES != DEA_ISSUBTITLES)">
					<xsl:attribute name="DEA_ISSUBTITLES"><xsl:value-of select="DEA_ISSUBTITLES" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISSUBTITLES and not(DEA_ISSUBTITLES)">
					<xsl:attribute name="DEA_ISSUBTITLES"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_LAN_ID_SUBTITLES) and DEA_LAN_ID_SUBTITLES) or (msxsl:node-set($Original)/DEA_LAN_ID_SUBTITLES != DEA_LAN_ID_SUBTITLES)">
					<xsl:attribute name="DEA_LAN_ID_SUBTITLES"><xsl:value-of select="DEA_LAN_ID_SUBTITLES" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_LAN_ID_SUBTITLES and not(DEA_LAN_ID_SUBTITLES)">
					<xsl:attribute name="DEA_LAN_ID_SUBTITLES"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_MEF_ID_CAPTION1) and DEA_MEF_ID_CAPTION1) or (msxsl:node-set($Original)/DEA_MEF_ID_CAPTION1 != DEA_MEF_ID_CAPTION1)">
					<xsl:attribute name="DEA_MEF_ID_CAPTION1"><xsl:value-of select="DEA_MEF_ID_CAPTION1" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_MEF_ID_CAPTION1 and not(DEA_MEF_ID_CAPTION1)">
					<xsl:attribute name="DEA_MEF_ID_CAPTION1"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_MEF_ID_CAPTION2) and DEA_MEF_ID_CAPTION2) or (msxsl:node-set($Original)/DEA_MEF_ID_CAPTION2 != DEA_MEF_ID_CAPTION2)">
					<xsl:attribute name="DEA_MEF_ID_CAPTION2"><xsl:value-of select="DEA_MEF_ID_CAPTION2" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_MEF_ID_CAPTION2 and not(DEA_MEF_ID_CAPTION2)">
					<xsl:attribute name="DEA_MEF_ID_CAPTION2"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_MEF_ID_CAPTION3) and DEA_MEF_ID_CAPTION3) or (msxsl:node-set($Original)/DEA_MEF_ID_CAPTION3 != DEA_MEF_ID_CAPTION3)">
					<xsl:attribute name="DEA_MEF_ID_CAPTION3"><xsl:value-of select="DEA_MEF_ID_CAPTION3" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_MEF_ID_CAPTION3 and not(DEA_MEF_ID_CAPTION3)">
					<xsl:attribute name="DEA_MEF_ID_CAPTION3"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_IS_CC_PBSENCODES) and DEA_IS_CC_PBSENCODES) or (msxsl:node-set($Original)/DEA_IS_CC_PBSENCODES != DEA_IS_CC_PBSENCODES)">
					<xsl:attribute name="DEA_IS_CC_PBSENCODES"><xsl:value-of select="DEA_IS_CC_PBSENCODES" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_IS_CC_PBSENCODES and not(DEA_IS_CC_PBSENCODES)">
					<xsl:attribute name="DEA_IS_CC_PBSENCODES"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_IS_CC_PBSCOORDINATES) and DEA_IS_CC_PBSCOORDINATES) or (msxsl:node-set($Original)/DEA_IS_CC_PBSCOORDINATES != DEA_IS_CC_PBSCOORDINATES)">
					<xsl:attribute name="DEA_IS_CC_PBSCOORDINATES"><xsl:value-of select="DEA_IS_CC_PBSCOORDINATES" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_IS_CC_PBSCOORDINATES and not(DEA_IS_CC_PBSCOORDINATES)">
					<xsl:attribute name="DEA_IS_CC_PBSCOORDINATES"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_CC_PROVIDER) and DEA_CC_PROVIDER) or (msxsl:node-set($Original)/DEA_CC_PROVIDER != DEA_CC_PROVIDER)">
					<xsl:attribute name="DEA_CC_PROVIDER"><xsl:value-of select="DEA_CC_PROVIDER" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_CC_PROVIDER and not(DEA_CC_PROVIDER)">
					<xsl:attribute name="DEA_CC_PROVIDER"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSCV_ID) and DEA_PBSCV_ID) or (msxsl:node-set($Original)/DEA_PBSCV_ID != DEA_PBSCV_ID)">
					<xsl:attribute name="DEA_PBSCV_ID"><xsl:value-of select="DEA_PBSCV_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSCV_ID and not(DEA_PBSCV_ID)">
					<xsl:attribute name="DEA_PBSCV_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_SLU_ID_ASPECTRATIO) and DEA_SLU_ID_ASPECTRATIO) or (msxsl:node-set($Original)/DEA_SLU_ID_ASPECTRATIO != DEA_SLU_ID_ASPECTRATIO)">
					<xsl:attribute name="DEA_SLU_ID_ASPECTRATIO"><xsl:value-of select="DEA_SLU_ID_ASPECTRATIO" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_SLU_ID_ASPECTRATIO and not(DEA_SLU_ID_ASPECTRATIO)">
					<xsl:attribute name="DEA_SLU_ID_ASPECTRATIO"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_ISINTERNALBREAK) and DEA_ISINTERNALBREAK) or (msxsl:node-set($Original)/DEA_ISINTERNALBREAK != DEA_ISINTERNALBREAK)">
					<xsl:attribute name="DEA_ISINTERNALBREAK"><xsl:value-of select="DEA_ISINTERNALBREAK" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISINTERNALBREAK and not(DEA_ISINTERNALBREAK)">
					<xsl:attribute name="DEA_ISINTERNALBREAK"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_ISCC) and DEA_ISCC) or (msxsl:node-set($Original)/DEA_ISCC != DEA_ISCC)">
					<xsl:attribute name="DEA_ISCC"><xsl:value-of select="DEA_ISCC" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISCC and not(DEA_ISCC)">
					<xsl:attribute name="DEA_ISCC"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_ISSAP) and DEA_ISSAP) or (msxsl:node-set($Original)/DEA_ISSAP != DEA_ISSAP)">
					<xsl:attribute name="DEA_ISSAP"><xsl:value-of select="DEA_ISSAP" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISSAP and not(DEA_ISSAP)">
					<xsl:attribute name="DEA_ISSAP"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_ISDVI) and DEA_ISDVI) or (msxsl:node-set($Original)/DEA_ISDVI != DEA_ISDVI)">
					<xsl:attribute name="DEA_ISDVI"><xsl:value-of select="DEA_ISDVI" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISDVI and not(DEA_ISDVI)">
					<xsl:attribute name="DEA_ISDVI"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_SLU_ID_HIDEF) and DEA_SLU_ID_HIDEF) or (msxsl:node-set($Original)/DEA_SLU_ID_HIDEF != DEA_SLU_ID_HIDEF)">
					<xsl:attribute name="DEA_SLU_ID_HIDEF"><xsl:value-of select="DEA_SLU_ID_HIDEF" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_SLU_ID_HIDEF and not(DEA_SLU_ID_HIDEF)">
					<xsl:attribute name="DEA_SLU_ID_HIDEF"></xsl:attribute>
				</xsl:if>
				<xsl:if test="DEA_PBSCONTENTDESCRIPTION != '' and (not(msxsl:node-set($Original)/DEA_PBSCONTENTDESCRIPTION) and DEA_PBSCONTENTDESCRIPTION) or (msxsl:node-set($Original)/DEA_PBSCONTENTDESCRIPTION != DEA_PBSCONTENTDESCRIPTION)">
					<xsl:attribute name="DEA_PBSCONTENTDESCRIPTION"><xsl:value-of select="DEA_PBSCONTENTDESCRIPTION" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSCONTENTDESCRIPTION and not(DEA_PBSCONTENTDESCRIPTION)">
					<xsl:attribute name="DEA_PBSCONTENTDESCRIPTION"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSOPERATINGUNIT) and DEA_PBSOPERATINGUNIT) or (msxsl:node-set($Original)/DEA_PBSOPERATINGUNIT != DEA_PBSOPERATINGUNIT)">
					<xsl:attribute name="DEA_PBSOPERATINGUNIT"><xsl:value-of select="DEA_PBSOPERATINGUNIT" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSOPERATINGUNIT and not(DEA_PBSOPERATINGUNIT)">
					<xsl:attribute name="DEA_PBSOPERATINGUNIT"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSOPERATINGGROUP) and DEA_PBSOPERATINGGROUP) or (msxsl:node-set($Original)/DEA_PBSOPERATINGGROUP != DEA_PBSOPERATINGGROUP)">
					<xsl:attribute name="DEA_PBSOPERATINGGROUP"><xsl:value-of select="DEA_PBSOPERATINGGROUP" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSOPERATINGGROUP and not(DEA_PBSOPERATINGGROUP)">
					<xsl:attribute name="DEA_PBSOPERATINGGROUP"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_ISPBSOPENCAPTIONS) and DEA_ISPBSOPENCAPTIONS) or (msxsl:node-set($Original)/DEA_ISPBSOPENCAPTIONS != DEA_ISPBSOPENCAPTIONS)">
					<xsl:attribute name="DEA_ISPBSOPENCAPTIONS"><xsl:value-of select="DEA_ISPBSOPENCAPTIONS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSOPENCAPTIONS and not(DEA_ISPBSOPENCAPTIONS)">
					<xsl:attribute name="DEA_ISPBSOPENCAPTIONS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSLIVEDESTINATION) and DEA_PBSLIVEDESTINATION) or (msxsl:node-set($Original)/DEA_PBSLIVEDESTINATION != DEA_PBSLIVEDESTINATION)">
					<xsl:attribute name="DEA_PBSLIVEDESTINATION"><xsl:value-of select="DEA_PBSLIVEDESTINATION" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSLIVEDESTINATION and not(DEA_PBSLIVEDESTINATION)">
					<xsl:attribute name="DEA_PBSLIVEDESTINATION"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSLIVEBACKUPPATH1) and DEA_PBSLIVEBACKUPPATH1) or (msxsl:node-set($Original)/DEA_PBSLIVEBACKUPPATH1 != DEA_PBSLIVEBACKUPPATH1)">
					<xsl:attribute name="DEA_PBSLIVEBACKUPPATH1"><xsl:value-of select="DEA_PBSLIVEBACKUPPATH1" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSLIVEBACKUPPATH1 and not(DEA_PBSLIVEBACKUPPATH1)">
					<xsl:attribute name="DEA_PBSLIVEBACKUPPATH1"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSLIVEBACKUPPATH2) and DEA_PBSLIVEBACKUPPATH2) or (msxsl:node-set($Original)/DEA_PBSLIVEBACKUPPATH2 != DEA_PBSLIVEBACKUPPATH2)">
					<xsl:attribute name="DEA_PBSLIVEBACKUPPATH2"><xsl:value-of select="DEA_PBSLIVEBACKUPPATH2" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSLIVEBACKUPPATH2 and not(DEA_PBSLIVEBACKUPPATH2)">
					<xsl:attribute name="DEA_PBSLIVEBACKUPPATH2"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSLIVEBACKUPPATH3) and DEA_PBSLIVEBACKUPPATH3) or (msxsl:node-set($Original)/DEA_PBSLIVEBACKUPPATH3 != DEA_PBSLIVEBACKUPPATH3)">
					<xsl:attribute name="DEA_PBSLIVEBACKUPPATH3"><xsl:value-of select="DEA_PBSLIVEBACKUPPATH3" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSLIVEBACKUPPATH3 and not(DEA_PBSLIVEBACKUPPATH3)">
					<xsl:attribute name="DEA_PBSLIVEBACKUPPATH3"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSLIVEBACKUPPATH4) and DEA_PBSLIVEBACKUPPATH4) or (msxsl:node-set($Original)/DEA_PBSLIVEBACKUPPATH4 != DEA_PBSLIVEBACKUPPATH4)">
					<xsl:attribute name="DEA_PBSLIVEBACKUPPATH4"><xsl:value-of select="DEA_PBSLIVEBACKUPPATH4" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSLIVEBACKUPPATH4 and not(DEA_PBSLIVEBACKUPPATH4)">
					<xsl:attribute name="DEA_PBSLIVEBACKUPPATH4"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_MDL_ID) and DEA_MDL_ID) or (msxsl:node-set($Original)/DEA_MDL_ID != DEA_MDL_ID)">
					<xsl:attribute name="DEA_MDL_ID"><xsl:value-of select="DEA_MDL_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_MDL_ID and not(DEA_MDL_ID)">
					<xsl:attribute name="DEA_MDL_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_GNR_ID) and DEA_GNR_ID) or (msxsl:node-set($Original)/DEA_GNR_ID != DEA_GNR_ID)">
					<xsl:attribute name="DEA_GNR_ID"><xsl:value-of select="DEA_GNR_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_GNR_ID and not(DEA_GNR_ID)">
					<xsl:attribute name="DEA_GNR_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_ACM_ID) and DEA_ACM_ID) or (msxsl:node-set($Original)/DEA_ACM_ID != DEA_ACM_ID)">
					<xsl:attribute name="DEA_ACM_ID"><xsl:value-of select="DEA_ACM_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_ACM_ID and not(DEA_ACM_ID)">
					<xsl:attribute name="DEA_ACM_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_ALLIANTCONTRACTID) and DEA_ALLIANTCONTRACTID) or (msxsl:node-set($Original)/DEA_ALLIANTCONTRACTID != DEA_ALLIANTCONTRACTID)">
					<xsl:attribute name="DEA_ALLIANTCONTRACTID"><xsl:value-of select="DEA_ALLIANTCONTRACTID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_ALLIANTCONTRACTID and not(DEA_ALLIANTCONTRACTID)">
					<xsl:attribute name="DEA_ALLIANTCONTRACTID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_PBSBC_ID) and DEA_PBSBC_ID) or (msxsl:node-set($Original)/DEA_PBSBC_ID != DEA_PBSBC_ID)">
					<xsl:attribute name="DEA_PBSBC_ID"><xsl:value-of select="DEA_PBSBC_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSBC_ID and not(DEA_PBSBC_ID)">
					<xsl:attribute name="DEA_PBSBC_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="DEA_PBSCONTENTDESCRIPTION_1 != '' and (not(msxsl:node-set($Original)/DEA_PBSCONTENTDESCRIPTION_1) and DEA_PBSCONTENTDESCRIPTION_1) or (msxsl:node-set($Original)/DEA_PBSCONTENTDESCRIPTION_1 != DEA_PBSCONTENTDESCRIPTION_1)">
					<xsl:attribute name="DEA_PBSCONTENTDESCRIPTION_1"><xsl:value-of select="DEA_PBSCONTENTDESCRIPTION_1" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSCONTENTDESCRIPTION_1 and not(DEA_PBSCONTENTDESCRIPTION_1)">
					<xsl:attribute name="DEA_PBSCONTENTDESCRIPTION_1"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/DEA_ISPBSSERIESDESCRIPTION) and DEA_ISPBSSERIESDESCRIPTION) or (msxsl:node-set($Original)/DEA_ISPBSSERIESDESCRIPTION != DEA_ISPBSSERIESDESCRIPTION)">
					<xsl:attribute name="DEA_ISPBSSERIESDESCRIPTION"><xsl:value-of select="DEA_ISPBSSERIESDESCRIPTION" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSSERIESDESCRIPTION and not(DEA_ISPBSSERIESDESCRIPTION)">
					<xsl:attribute name="DEA_ISPBSSERIESDESCRIPTION"></xsl:attribute>
				</xsl:if>
			</xsl:when>
			<xsl:otherwise>
				<xsl:attribute name="DEA_ID"><xsl:value-of select="DEA_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_ID and not(DEA_ID)">
					<xsl:attribute name="DEA_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_DESC"><xsl:value-of select="DEA_DESC" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_DESC and not(DEA_DESC)">
					<xsl:attribute name="DEA_DESC"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSDS_ID"><xsl:value-of select="DEA_PBSDS_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSDS_ID and not(DEA_PBSDS_ID)">
					<xsl:attribute name="DEA_PBSDS_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_UPDATEDATETIME"><xsl:value-of select="DEA_UPDATEDATETIME" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_UPDATEDATETIME and not(DEA_UPDATEDATETIME)">
					<xsl:attribute name="DEA_UPDATEDATETIME"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_UPDATEUSERID"><xsl:value-of select="DEA_UPDATEUSERID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_UPDATEUSERID and not(DEA_UPDATEUSERID)">
					<xsl:attribute name="DEA_UPDATEUSERID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSFD_ID"><xsl:value-of select="DEA_PBSFD_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSFD_ID and not(DEA_PBSFD_ID)">
					<xsl:attribute name="DEA_PBSFD_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_ISPBSMINORITYPRODUCTION"><xsl:value-of select="DEA_ISPBSMINORITYPRODUCTION" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSMINORITYPRODUCTION and not(DEA_ISPBSMINORITYPRODUCTION)">
					<xsl:attribute name="DEA_ISPBSMINORITYPRODUCTION"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_ISPBSMINORITYPRODUCEREXEC"><xsl:value-of select="DEA_ISPBSMINORITYPRODUCEREXEC" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSMINORITYPRODUCEREXEC and not(DEA_ISPBSMINORITYPRODUCEREXEC)">
					<xsl:attribute name="DEA_ISPBSMINORITYPRODUCEREXEC"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_ISPBSMINORITYDIRECTOR"><xsl:value-of select="DEA_ISPBSMINORITYDIRECTOR" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSMINORITYDIRECTOR and not(DEA_ISPBSMINORITYDIRECTOR)">
					<xsl:attribute name="DEA_ISPBSMINORITYDIRECTOR"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_ISPBSMINORITYTALENT"><xsl:value-of select="DEA_ISPBSMINORITYTALENT" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSMINORITYTALENT and not(DEA_ISPBSMINORITYTALENT)">
					<xsl:attribute name="DEA_ISPBSMINORITYTALENT"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_ISPBSMINORITYPRODUCERLINE"><xsl:value-of select="DEA_ISPBSMINORITYPRODUCERLINE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSMINORITYPRODUCERLINE and not(DEA_ISPBSMINORITYPRODUCERLINE)">
					<xsl:attribute name="DEA_ISPBSMINORITYPRODUCERLINE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_ISPBSMINORITYWRITER"><xsl:value-of select="DEA_ISPBSMINORITYWRITER" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSMINORITYWRITER and not(DEA_ISPBSMINORITYWRITER)">
					<xsl:attribute name="DEA_ISPBSMINORITYWRITER"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_ISPBSMINORITYSUBJECTMATTER"><xsl:value-of select="DEA_ISPBSMINORITYSUBJECTMATTER" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSMINORITYSUBJECTMATTER and not(DEA_ISPBSMINORITYSUBJECTMATTER)">
					<xsl:attribute name="DEA_ISPBSMINORITYSUBJECTMATTER"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSPRODUCTIONCOST"><xsl:value-of select="DEA_PBSPRODUCTIONCOST" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSPRODUCTIONCOST and not(DEA_PBSPRODUCTIONCOST)">
					<xsl:attribute name="DEA_PBSPRODUCTIONCOST"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_SLU_ID_PBSUNDERWRITINGTYPE"><xsl:value-of select="DEA_SLU_ID_PBSUNDERWRITINGTYPE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_SLU_ID_PBSUNDERWRITINGTYPE and not(DEA_SLU_ID_PBSUNDERWRITINGTYPE)">
					<xsl:attribute name="DEA_SLU_ID_PBSUNDERWRITINGTYPE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="DEA_PBSUNDERWRITINGNOTE != ''">
					<xsl:attribute name="DEA_PBSUNDERWRITINGNOTE"><xsl:value-of select="DEA_PBSUNDERWRITINGNOTE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSUNDERWRITINGNOTE and not(DEA_PBSUNDERWRITINGNOTE)">
					<xsl:attribute name="DEA_PBSUNDERWRITINGNOTE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSUNDERWRITINGCONTACT"><xsl:value-of select="DEA_PBSUNDERWRITINGCONTACT" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSUNDERWRITINGCONTACT and not(DEA_PBSUNDERWRITINGCONTACT)">
					<xsl:attribute name="DEA_PBSUNDERWRITINGCONTACT"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSUNDERWRITINGPHONE"><xsl:value-of select="DEA_PBSUNDERWRITINGPHONE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSUNDERWRITINGPHONE and not(DEA_PBSUNDERWRITINGPHONE)">
					<xsl:attribute name="DEA_PBSUNDERWRITINGPHONE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_SLU_ID_PBSSCHOOLRIGHTSTYPE"><xsl:value-of select="DEA_SLU_ID_PBSSCHOOLRIGHTSTYPE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_SLU_ID_PBSSCHOOLRIGHTSTYPE and not(DEA_SLU_ID_PBSSCHOOLRIGHTSTYPE)">
					<xsl:attribute name="DEA_SLU_ID_PBSSCHOOLRIGHTSTYPE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSSCHOOLEXPIREDATE"><xsl:value-of select="DEA_PBSSCHOOLEXPIREDATE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSSCHOOLEXPIREDATE and not(DEA_PBSSCHOOLEXPIREDATE)">
					<xsl:attribute name="DEA_PBSSCHOOLEXPIREDATE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSSCHOOLOBDATEMONTHS"><xsl:value-of select="DEA_PBSSCHOOLOBDATEMONTHS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSSCHOOLOBDATEMONTHS and not(DEA_PBSSCHOOLOBDATEMONTHS)">
					<xsl:attribute name="DEA_PBSSCHOOLOBDATEMONTHS"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSSCHOOLOBDATEDAYS"><xsl:value-of select="DEA_PBSSCHOOLOBDATEDAYS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSSCHOOLOBDATEDAYS and not(DEA_PBSSCHOOLOBDATEDAYS)">
					<xsl:attribute name="DEA_PBSSCHOOLOBDATEDAYS"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSSCHOOLEACHBCASTMONTHS"><xsl:value-of select="DEA_PBSSCHOOLEACHBCASTMONTHS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSSCHOOLEACHBCASTMONTHS and not(DEA_PBSSCHOOLEACHBCASTMONTHS)">
					<xsl:attribute name="DEA_PBSSCHOOLEACHBCASTMONTHS"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSSCHOOLEACHBCASTDAYS"><xsl:value-of select="DEA_PBSSCHOOLEACHBCASTDAYS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSSCHOOLEACHBCASTDAYS and not(DEA_PBSSCHOOLEACHBCASTDAYS)">
					<xsl:attribute name="DEA_PBSSCHOOLEACHBCASTDAYS"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_ISPBSSIMULCASTRIGHTS"><xsl:value-of select="DEA_ISPBSSIMULCASTRIGHTS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSSIMULCASTRIGHTS and not(DEA_ISPBSSIMULCASTRIGHTS)">
					<xsl:attribute name="DEA_ISPBSSIMULCASTRIGHTS"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_ISPBSNCCABLERIGHTS"><xsl:value-of select="DEA_ISPBSNCCABLERIGHTS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSNCCABLERIGHTS and not(DEA_ISPBSNCCABLERIGHTS)">
					<xsl:attribute name="DEA_ISPBSNCCABLERIGHTS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="DEA_PBSBROADCASTRIGHTSCOMMENTS != ''">
					<xsl:attribute name="DEA_PBSBROADCASTRIGHTSCOMMENTS"><xsl:value-of select="DEA_PBSBROADCASTRIGHTSCOMMENTS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSBROADCASTRIGHTSCOMMENTS and not(DEA_PBSBROADCASTRIGHTSCOMMENTS)">
					<xsl:attribute name="DEA_PBSBROADCASTRIGHTSCOMMENTS"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSCANADIANHOLDBACK"><xsl:value-of select="DEA_PBSCANADIANHOLDBACK" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSCANADIANHOLDBACK and not(DEA_PBSCANADIANHOLDBACK)">
					<xsl:attribute name="DEA_PBSCANADIANHOLDBACK"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_ISPBSCANADIANPRERELEASE"><xsl:value-of select="DEA_ISPBSCANADIANPRERELEASE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSCANADIANPRERELEASE and not(DEA_ISPBSCANADIANPRERELEASE)">
					<xsl:attribute name="DEA_ISPBSCANADIANPRERELEASE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSPRODUCTIONCONTACTNAME"><xsl:value-of select="DEA_PBSPRODUCTIONCONTACTNAME" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSPRODUCTIONCONTACTNAME and not(DEA_PBSPRODUCTIONCONTACTNAME)">
					<xsl:attribute name="DEA_PBSPRODUCTIONCONTACTNAME"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSPRODUCTIONCONTACTPHONE"><xsl:value-of select="DEA_PBSPRODUCTIONCONTACTPHONE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSPRODUCTIONCONTACTPHONE and not(DEA_PBSPRODUCTIONCONTACTPHONE)">
					<xsl:attribute name="DEA_PBSPRODUCTIONCONTACTPHONE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSPRODUCTIONCONTACTEMAIL"><xsl:value-of select="DEA_PBSPRODUCTIONCONTACTEMAIL" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSPRODUCTIONCONTACTEMAIL and not(DEA_PBSPRODUCTIONCONTACTEMAIL)">
					<xsl:attribute name="DEA_PBSPRODUCTIONCONTACTEMAIL"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSTECHNICALCONTACTNAME"><xsl:value-of select="DEA_PBSTECHNICALCONTACTNAME" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSTECHNICALCONTACTNAME and not(DEA_PBSTECHNICALCONTACTNAME)">
					<xsl:attribute name="DEA_PBSTECHNICALCONTACTNAME"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSTECHNICALCONTACTPHONE"><xsl:value-of select="DEA_PBSTECHNICALCONTACTPHONE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSTECHNICALCONTACTPHONE and not(DEA_PBSTECHNICALCONTACTPHONE)">
					<xsl:attribute name="DEA_PBSTECHNICALCONTACTPHONE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSTECHNICALCONTACTEMAIL"><xsl:value-of select="DEA_PBSTECHNICALCONTACTEMAIL" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSTECHNICALCONTACTEMAIL and not(DEA_PBSTECHNICALCONTACTEMAIL)">
					<xsl:attribute name="DEA_PBSTECHNICALCONTACTEMAIL"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_ISPBSLIVEEVENT"><xsl:value-of select="DEA_ISPBSLIVEEVENT" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSLIVEEVENT and not(DEA_ISPBSLIVEEVENT)">
					<xsl:attribute name="DEA_ISPBSLIVEEVENT"></xsl:attribute>
				</xsl:if>
				<xsl:if test="DEA_PBSORIGSITE != ''">
					<xsl:attribute name="DEA_PBSORIGSITE"><xsl:value-of select="DEA_PBSORIGSITE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSORIGSITE and not(DEA_PBSORIGSITE)">
					<xsl:attribute name="DEA_PBSORIGSITE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSUP_ID"><xsl:value-of select="DEA_PBSUP_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSUP_ID and not(DEA_PBSUP_ID)">
					<xsl:attribute name="DEA_PBSUP_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSLIVEORIGINATIONPATH"><xsl:value-of select="DEA_PBSLIVEORIGINATIONPATH" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSLIVEORIGINATIONPATH and not(DEA_PBSLIVEORIGINATIONPATH)">
					<xsl:attribute name="DEA_PBSLIVEORIGINATIONPATH"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSLIVEORIGINATIONPATH2"><xsl:value-of select="DEA_PBSLIVEORIGINATIONPATH2" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSLIVEORIGINATIONPATH2 and not(DEA_PBSLIVEORIGINATIONPATH2)">
					<xsl:attribute name="DEA_PBSLIVEORIGINATIONPATH2"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSLIVEORIGINATIONPATH3"><xsl:value-of select="DEA_PBSLIVEORIGINATIONPATH3" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSLIVEORIGINATIONPATH3 and not(DEA_PBSLIVEORIGINATIONPATH3)">
					<xsl:attribute name="DEA_PBSLIVEORIGINATIONPATH3"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSLIVEORIGINATIONPATH4"><xsl:value-of select="DEA_PBSLIVEORIGINATIONPATH4" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSLIVEORIGINATIONPATH4 and not(DEA_PBSLIVEORIGINATIONPATH4)">
					<xsl:attribute name="DEA_PBSLIVEORIGINATIONPATH4"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_ISPBSLIVERECORD"><xsl:value-of select="DEA_ISPBSLIVERECORD" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSLIVERECORD and not(DEA_ISPBSLIVERECORD)">
					<xsl:attribute name="DEA_ISPBSLIVERECORD"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_MFC_ID_AUDIOTYPE"><xsl:value-of select="DEA_MFC_ID_AUDIOTYPE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_MFC_ID_AUDIOTYPE and not(DEA_MFC_ID_AUDIOTYPE)">
					<xsl:attribute name="DEA_MFC_ID_AUDIOTYPE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_MEF_ID_AUDIO1"><xsl:value-of select="DEA_MEF_ID_AUDIO1" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_MEF_ID_AUDIO1 and not(DEA_MEF_ID_AUDIO1)">
					<xsl:attribute name="DEA_MEF_ID_AUDIO1"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_MEF_ID_AUDIO2"><xsl:value-of select="DEA_MEF_ID_AUDIO2" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_MEF_ID_AUDIO2 and not(DEA_MEF_ID_AUDIO2)">
					<xsl:attribute name="DEA_MEF_ID_AUDIO2"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_MEF_ID_AUDIO3"><xsl:value-of select="DEA_MEF_ID_AUDIO3" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_MEF_ID_AUDIO3 and not(DEA_MEF_ID_AUDIO3)">
					<xsl:attribute name="DEA_MEF_ID_AUDIO3"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_MEF_ID_AUDIO4"><xsl:value-of select="DEA_MEF_ID_AUDIO4" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_MEF_ID_AUDIO4 and not(DEA_MEF_ID_AUDIO4)">
					<xsl:attribute name="DEA_MEF_ID_AUDIO4"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_MEF_ID_AUDIO5"><xsl:value-of select="DEA_MEF_ID_AUDIO5" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_MEF_ID_AUDIO5 and not(DEA_MEF_ID_AUDIO5)">
					<xsl:attribute name="DEA_MEF_ID_AUDIO5"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_MEF_ID_AUDIO6"><xsl:value-of select="DEA_MEF_ID_AUDIO6" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_MEF_ID_AUDIO6 and not(DEA_MEF_ID_AUDIO6)">
					<xsl:attribute name="DEA_MEF_ID_AUDIO6"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_MEF_ID_AUDIO7"><xsl:value-of select="DEA_MEF_ID_AUDIO7" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_MEF_ID_AUDIO7 and not(DEA_MEF_ID_AUDIO7)">
					<xsl:attribute name="DEA_MEF_ID_AUDIO7"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_MEF_ID_AUDIO8"><xsl:value-of select="DEA_MEF_ID_AUDIO8" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_MEF_ID_AUDIO8 and not(DEA_MEF_ID_AUDIO8)">
					<xsl:attribute name="DEA_MEF_ID_AUDIO8"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_IS_DVI_PBSENCODES"><xsl:value-of select="DEA_IS_DVI_PBSENCODES" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_IS_DVI_PBSENCODES and not(DEA_IS_DVI_PBSENCODES)">
					<xsl:attribute name="DEA_IS_DVI_PBSENCODES"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_IS_DVI_PBSCOORDINATES"><xsl:value-of select="DEA_IS_DVI_PBSCOORDINATES" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_IS_DVI_PBSCOORDINATES and not(DEA_IS_DVI_PBSCOORDINATES)">
					<xsl:attribute name="DEA_IS_DVI_PBSCOORDINATES"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_IS_SAP_PBSENCODES"><xsl:value-of select="DEA_IS_SAP_PBSENCODES" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_IS_SAP_PBSENCODES and not(DEA_IS_SAP_PBSENCODES)">
					<xsl:attribute name="DEA_IS_SAP_PBSENCODES"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_ISSUBTITLES"><xsl:value-of select="DEA_ISSUBTITLES" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISSUBTITLES and not(DEA_ISSUBTITLES)">
					<xsl:attribute name="DEA_ISSUBTITLES"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_LAN_ID_SUBTITLES"><xsl:value-of select="DEA_LAN_ID_SUBTITLES" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_LAN_ID_SUBTITLES and not(DEA_LAN_ID_SUBTITLES)">
					<xsl:attribute name="DEA_LAN_ID_SUBTITLES"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_MEF_ID_CAPTION1"><xsl:value-of select="DEA_MEF_ID_CAPTION1" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_MEF_ID_CAPTION1 and not(DEA_MEF_ID_CAPTION1)">
					<xsl:attribute name="DEA_MEF_ID_CAPTION1"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_MEF_ID_CAPTION2"><xsl:value-of select="DEA_MEF_ID_CAPTION2" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_MEF_ID_CAPTION2 and not(DEA_MEF_ID_CAPTION2)">
					<xsl:attribute name="DEA_MEF_ID_CAPTION2"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_MEF_ID_CAPTION3"><xsl:value-of select="DEA_MEF_ID_CAPTION3" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_MEF_ID_CAPTION3 and not(DEA_MEF_ID_CAPTION3)">
					<xsl:attribute name="DEA_MEF_ID_CAPTION3"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_IS_CC_PBSENCODES"><xsl:value-of select="DEA_IS_CC_PBSENCODES" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_IS_CC_PBSENCODES and not(DEA_IS_CC_PBSENCODES)">
					<xsl:attribute name="DEA_IS_CC_PBSENCODES"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_IS_CC_PBSCOORDINATES"><xsl:value-of select="DEA_IS_CC_PBSCOORDINATES" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_IS_CC_PBSCOORDINATES and not(DEA_IS_CC_PBSCOORDINATES)">
					<xsl:attribute name="DEA_IS_CC_PBSCOORDINATES"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_CC_PROVIDER"><xsl:value-of select="DEA_CC_PROVIDER" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_CC_PROVIDER and not(DEA_CC_PROVIDER)">
					<xsl:attribute name="DEA_CC_PROVIDER"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSCV_ID"><xsl:value-of select="DEA_PBSCV_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSCV_ID and not(DEA_PBSCV_ID)">
					<xsl:attribute name="DEA_PBSCV_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_SLU_ID_ASPECTRATIO"><xsl:value-of select="DEA_SLU_ID_ASPECTRATIO" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_SLU_ID_ASPECTRATIO and not(DEA_SLU_ID_ASPECTRATIO)">
					<xsl:attribute name="DEA_SLU_ID_ASPECTRATIO"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_ISINTERNALBREAK"><xsl:value-of select="DEA_ISINTERNALBREAK" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISINTERNALBREAK and not(DEA_ISINTERNALBREAK)">
					<xsl:attribute name="DEA_ISINTERNALBREAK"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_ISCC"><xsl:value-of select="DEA_ISCC" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISCC and not(DEA_ISCC)">
					<xsl:attribute name="DEA_ISCC"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_ISSAP"><xsl:value-of select="DEA_ISSAP" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISSAP and not(DEA_ISSAP)">
					<xsl:attribute name="DEA_ISSAP"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_ISDVI"><xsl:value-of select="DEA_ISDVI" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISDVI and not(DEA_ISDVI)">
					<xsl:attribute name="DEA_ISDVI"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_SLU_ID_HIDEF"><xsl:value-of select="DEA_SLU_ID_HIDEF" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_SLU_ID_HIDEF and not(DEA_SLU_ID_HIDEF)">
					<xsl:attribute name="DEA_SLU_ID_HIDEF"></xsl:attribute>
				</xsl:if>
				<xsl:if test="DEA_PBSCONTENTDESCRIPTION != ''">
					<xsl:attribute name="DEA_PBSCONTENTDESCRIPTION"><xsl:value-of select="DEA_PBSCONTENTDESCRIPTION" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSCONTENTDESCRIPTION and not(DEA_PBSCONTENTDESCRIPTION)">
					<xsl:attribute name="DEA_PBSCONTENTDESCRIPTION"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSOPERATINGUNIT"><xsl:value-of select="DEA_PBSOPERATINGUNIT" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSOPERATINGUNIT and not(DEA_PBSOPERATINGUNIT)">
					<xsl:attribute name="DEA_PBSOPERATINGUNIT"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSOPERATINGGROUP"><xsl:value-of select="DEA_PBSOPERATINGGROUP" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSOPERATINGGROUP and not(DEA_PBSOPERATINGGROUP)">
					<xsl:attribute name="DEA_PBSOPERATINGGROUP"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_ISPBSOPENCAPTIONS"><xsl:value-of select="DEA_ISPBSOPENCAPTIONS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSOPENCAPTIONS and not(DEA_ISPBSOPENCAPTIONS)">
					<xsl:attribute name="DEA_ISPBSOPENCAPTIONS"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSLIVEDESTINATION"><xsl:value-of select="DEA_PBSLIVEDESTINATION" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSLIVEDESTINATION and not(DEA_PBSLIVEDESTINATION)">
					<xsl:attribute name="DEA_PBSLIVEDESTINATION"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSLIVEBACKUPPATH1"><xsl:value-of select="DEA_PBSLIVEBACKUPPATH1" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSLIVEBACKUPPATH1 and not(DEA_PBSLIVEBACKUPPATH1)">
					<xsl:attribute name="DEA_PBSLIVEBACKUPPATH1"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSLIVEBACKUPPATH2"><xsl:value-of select="DEA_PBSLIVEBACKUPPATH2" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSLIVEBACKUPPATH2 and not(DEA_PBSLIVEBACKUPPATH2)">
					<xsl:attribute name="DEA_PBSLIVEBACKUPPATH2"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSLIVEBACKUPPATH3"><xsl:value-of select="DEA_PBSLIVEBACKUPPATH3" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSLIVEBACKUPPATH3 and not(DEA_PBSLIVEBACKUPPATH3)">
					<xsl:attribute name="DEA_PBSLIVEBACKUPPATH3"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSLIVEBACKUPPATH4"><xsl:value-of select="DEA_PBSLIVEBACKUPPATH4" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSLIVEBACKUPPATH4 and not(DEA_PBSLIVEBACKUPPATH4)">
					<xsl:attribute name="DEA_PBSLIVEBACKUPPATH4"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_MDL_ID"><xsl:value-of select="DEA_MDL_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_MDL_ID and not(DEA_MDL_ID)">
					<xsl:attribute name="DEA_MDL_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_GNR_ID"><xsl:value-of select="DEA_GNR_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_GNR_ID and not(DEA_GNR_ID)">
					<xsl:attribute name="DEA_GNR_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_ACM_ID"><xsl:value-of select="DEA_ACM_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_ACM_ID and not(DEA_ACM_ID)">
					<xsl:attribute name="DEA_ACM_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_ALLIANTCONTRACTID"><xsl:value-of select="DEA_ALLIANTCONTRACTID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_ALLIANTCONTRACTID and not(DEA_ALLIANTCONTRACTID)">
					<xsl:attribute name="DEA_ALLIANTCONTRACTID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_PBSBC_ID"><xsl:value-of select="DEA_PBSBC_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSBC_ID and not(DEA_PBSBC_ID)">
					<xsl:attribute name="DEA_PBSBC_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="DEA_PBSCONTENTDESCRIPTION_1 != ''">
					<xsl:attribute name="DEA_PBSCONTENTDESCRIPTION_1"><xsl:value-of select="DEA_PBSCONTENTDESCRIPTION_1" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/DEA_PBSCONTENTDESCRIPTION_1 and not(DEA_PBSCONTENTDESCRIPTION_1)">
					<xsl:attribute name="DEA_PBSCONTENTDESCRIPTION_1"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="DEA_ISPBSSERIESDESCRIPTION"><xsl:value-of select="DEA_ISPBSSERIESDESCRIPTION" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/DEA_ISPBSSERIESDESCRIPTION and not(DEA_ISPBSSERIESDESCRIPTION)">
					<xsl:attribute name="DEA_ISPBSSERIESDESCRIPTION"></xsl:attribute>
				</xsl:if>
			</xsl:otherwise>
		</xsl:choose>

		<MASTERDEAL>
			<xsl:if test="($RowState=$ROWSTATE_NEW) or ($RowState=$ROWSTATE_BEFORE) or ($RowState=$ROWSTATE_UNCHANGED)">
				<xsl:for-each select="//DealWithFundingDataSet/MASTERDEAL">
					<xsl:choose>
						<xsl:when test="@diffgr:hasChanges='inserted'">
							<xsl:call-template name="OutputMASTERDEAL">
								<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
							</xsl:call-template>
						</xsl:when>

						<xsl:when test="@diffgr:hasChanges='modified'">
							<xsl:for-each select="key('OriginalMASTERDEAL', @diffgr:id)">
								<xsl:call-template name="OutputMASTERDEAL">
									<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
								</xsl:call-template>
							</xsl:for-each>
							<xsl:call-template name="OutputMASTERDEAL">
								<xsl:with-param name="Original" select="key('OriginalMASTERDEAL', @diffgr:id)" />
								<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
							</xsl:call-template>
						</xsl:when>
					</xsl:choose>
				</xsl:for-each>
				<xsl:for-each select="//diffgr:before/MASTERDEAL">
					<xsl:if test="count(key('CurrentMASTERDEAL', @diffgr:id)) = 0">
						<xsl:call-template name="OutputMASTERDEAL">
							<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
						</xsl:call-template>
					</xsl:if>
				</xsl:for-each>
			</xsl:if>
		</MASTERDEAL>
		<MASTERDEALFUNDING>
			<xsl:if test="($RowState=$ROWSTATE_NEW) or ($RowState=$ROWSTATE_BEFORE) or ($RowState=$ROWSTATE_UNCHANGED)">
				<xsl:for-each select="//DealWithFundingDataSet/MASTERDEALFUNDING">
					<xsl:choose>
						<xsl:when test="@diffgr:hasChanges='inserted'">
							<xsl:call-template name="OutputMASTERDEALFUNDING">
								<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
							</xsl:call-template>
						</xsl:when>

						<xsl:when test="@diffgr:hasChanges='modified'">
							<xsl:for-each select="key('OriginalMASTERDEALFUNDING', @diffgr:id)">
								<xsl:call-template name="OutputMASTERDEALFUNDING">
									<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
								</xsl:call-template>
							</xsl:for-each>
							<xsl:call-template name="OutputMASTERDEALFUNDING">
								<xsl:with-param name="Original" select="key('OriginalMASTERDEALFUNDING', @diffgr:id)" />
								<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
							</xsl:call-template>
						</xsl:when>
					</xsl:choose>
				</xsl:for-each>
				<xsl:for-each select="//diffgr:before/MASTERDEALFUNDING">
					<xsl:if test="count(key('CurrentMASTERDEALFUNDING', @diffgr:id)) = 0">
						<xsl:call-template name="OutputMASTERDEALFUNDING">
							<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
						</xsl:call-template>
					</xsl:if>
				</xsl:for-each>
			</xsl:if>
		</MASTERDEALFUNDING>
		<DEALFUNDING>
			<xsl:if test="($RowState=$ROWSTATE_NEW) or ($RowState=$ROWSTATE_BEFORE) or ($RowState=$ROWSTATE_UNCHANGED)">
				<xsl:for-each select="//DealWithFundingDataSet/DEALFUNDING">
					<xsl:choose>
						<xsl:when test="@diffgr:hasChanges='inserted'">
							<xsl:call-template name="OutputDEALFUNDING">
								<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
							</xsl:call-template>
						</xsl:when>

						<xsl:when test="@diffgr:hasChanges='modified'">
							<xsl:for-each select="key('OriginalDEALFUNDING', @diffgr:id)">
								<xsl:call-template name="OutputDEALFUNDING">
									<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
								</xsl:call-template>
							</xsl:for-each>
							<xsl:call-template name="OutputDEALFUNDING">
								<xsl:with-param name="Original" select="key('OriginalDEALFUNDING', @diffgr:id)" />
								<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
							</xsl:call-template>
						</xsl:when>
					</xsl:choose>
				</xsl:for-each>
				<xsl:for-each select="//diffgr:before/DEALFUNDING">
					<xsl:if test="count(key('CurrentDEALFUNDING', @diffgr:id)) = 0">
						<xsl:call-template name="OutputDEALFUNDING">
							<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
						</xsl:call-template>
					</xsl:if>
				</xsl:for-each>
			</xsl:if>
		</DEALFUNDING>
	</ROW>
</xsl:template>

<xsl:template match="/">
	<DATAPACKET Version="2.0">
	<xsl:call-template name="Output_Schema" />
	<ROWDATA>
		<xsl:for-each select="//DealWithFundingDataSet/DEAL">
			<xsl:choose>
				<xsl:when test="@diffgr:hasChanges='inserted'">
					<xsl:call-template name="OutputDEAL">
						<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
					</xsl:call-template>
				</xsl:when>

				<xsl:when test="@diffgr:hasChanges='modified'">
					<xsl:for-each select="key('OriginalDEAL', @diffgr:id)">
						<xsl:call-template name="OutputDEAL">
							<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
						</xsl:call-template>
					</xsl:for-each>
					<xsl:call-template name="OutputDEAL">
						<xsl:with-param name="Original" select="key('OriginalDEAL', @diffgr:id)" />
						<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
					</xsl:call-template>
				</xsl:when>

				<xsl:otherwise>
					<xsl:call-template name="OutputDEAL">
						<xsl:with-param name="RowState" select="$ROWSTATE_UNCHANGED" />
					</xsl:call-template>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:for-each>
		<xsl:for-each select="//diffgr:before/DEAL">
			<xsl:if test="count(key('CurrentDEAL', @diffgr:id)) = 0">
				<xsl:call-template name="OutputDEAL">
					<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
				</xsl:call-template>
			</xsl:if>
		</xsl:for-each>
	</ROWDATA>
	</DATAPACKET>
</xsl:template>
</xsl:stylesheet>
