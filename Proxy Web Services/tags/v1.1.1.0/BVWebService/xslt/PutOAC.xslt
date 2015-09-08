<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1" xmlns:msxsl="urn:schemas-microsoft-com:xslt" version="1.0">

<xsl:output method="xml" />

<xsl:variable name="ROWSTATE_BEFORE">1</xsl:variable>
<xsl:variable name="ROWSTATE_DELETED">2</xsl:variable>
<xsl:variable name="ROWSTATE_NEW">4</xsl:variable>
<xsl:variable name="ROWSTATE_DETACHED">6</xsl:variable> <!-- This one we do not use -->
<xsl:variable name="ROWSTATE_AFTER">8</xsl:variable>
<xsl:variable name="ROWSTATE_UNCHANGED">64</xsl:variable>

<xsl:key name="OriginalOAC" match="//diffgr:before/OAC" use="@diffgr:id" />
<xsl:key name="CurrentOAC" match="//OACDataSet/OAC" use="@diffgr:id" />
<xsl:key name="OriginalVW_PBSOACENTITY" match="//diffgr:before/VW_PBSOACENTITY" use="@diffgr:id" />
<xsl:key name="CurrentVW_PBSOACENTITY" match="//OACDataSet/VW_PBSOACENTITY" use="@diffgr:id" />
<xsl:key name="OriginalPBSOACITEM" match="//diffgr:before/PBSOACITEM" use="@diffgr:id" />
<xsl:key name="CurrentPBSOACITEM" match="//OACDataSet/PBSOACITEM" use="@diffgr:id" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<METADATA><FIELDS><FIELD attrname="POAC_ID" fieldtype="i4" required="true"><PARAM Name="PROVFLAGS" Value="7" Type="i4" Roundtrip="True" /><PARAM Name="ORIGIN" Value="PBSOAC.POAC_ID" Roundtrip="True" /></FIELD><FIELD attrname="POAC_CONTACT" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="PBSOAC.POAC_CONTACT" Roundtrip="True" /></FIELD><FIELD attrname="POAC_PHONE" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="PBSOAC.POAC_PHONE" Roundtrip="True" /></FIELD><FIELD attrname="POAC_EMAIL" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="PBSOAC.POAC_EMAIL" Roundtrip="True" /></FIELD><FIELD attrname="POAC_DEA_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="PBSOAC.POAC_DEA_ID" Roundtrip="True" /></FIELD><FIELD attrname="POAC_FORMSTATUS" fieldtype="i2"><PARAM Name="ORIGIN" Value="PBSOAC.POAC_FORMSTATUS" Roundtrip="True" /></FIELD><FIELD attrname="POAC_OPERATINGUNIT" fieldtype="i4"><PARAM Name="ORIGIN" Value="PBSOAC.POAC_OPERATINGUNIT" Roundtrip="True" /></FIELD><FIELD attrname="POAC_OPERATINGGROUP" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="PBSOAC.POAC_OPERATINGGROUP" Roundtrip="True" /></FIELD><FIELD attrname="PREMIEREDATE" fieldtype="dateTime" readonly="true" /><FIELD attrname="VW_PBSOACENTITY" fieldtype="nested"><FIELDS><FIELD attrname="POEN_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.POEN_ID" Roundtrip="True" /></FIELD><FIELD attrname="POEN_OAC_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.POEN_OAC_ID" Roundtrip="True" /></FIELD><FIELD attrname="POEN_OFFEROR" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.POEN_OFFEROR" Roundtrip="True" /></FIELD><FIELD attrname="POEN_FENAME" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.POEN_FENAME" Roundtrip="True" /></FIELD><FIELD attrname="POEN_FEADDRESS" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.POEN_FEADDRESS" Roundtrip="True" /></FIELD><FIELD attrname="POEN_FECITY" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.POEN_FECITY" Roundtrip="True" /></FIELD><FIELD attrname="POEN_FESTATE" fieldtype="string" SUBTYPE="FixedChar" WIDTH="3"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.POEN_FESTATE" Roundtrip="True" /></FIELD><FIELD attrname="POEN_FEZIP" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.POEN_FEZIP" Roundtrip="True" /></FIELD><FIELD attrname="POEN_OFFERMADEBY" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.POEN_OFFERMADEBY" Roundtrip="True" /></FIELD><FIELD attrname="POEN_PAYMENTCOMPANY" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.POEN_PAYMENTCOMPANY" Roundtrip="True" /></FIELD><FIELD attrname="POEN_PAYMENTCONTACT" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.POEN_PAYMENTCONTACT" Roundtrip="True" /></FIELD><FIELD attrname="POEN_PAYMENTADDRESS" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.POEN_PAYMENTADDRESS" Roundtrip="True" /></FIELD><FIELD attrname="POEN_PAYMENTCITY" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.POEN_PAYMENTCITY" Roundtrip="True" /></FIELD><FIELD attrname="POEN_PAYMENTSTATE" fieldtype="string" SUBTYPE="FixedChar" WIDTH="3"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.POEN_PAYMENTSTATE" Roundtrip="True" /></FIELD><FIELD attrname="POEN_PAYMENTZIP" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.POEN_PAYMENTZIP" Roundtrip="True" /></FIELD><FIELD attrname="POEN_PAYMENTPHONE" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.POEN_PAYMENTPHONE" Roundtrip="True" /></FIELD><FIELD attrname="POEN_PAYMENTFAX" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.POEN_PAYMENTFAX" Roundtrip="True" /></FIELD><FIELD attrname="POEN_PAYMENTEMAIL" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.POEN_PAYMENTEMAIL" Roundtrip="True" /></FIELD><FIELD attrname="POEN_PREPBSLOGO" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.POEN_PREPBSLOGO" Roundtrip="True" /></FIELD><FIELD attrname="POEN_PODT_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.POEN_PODT_ID" Roundtrip="True" /></FIELD><FIELD attrname="POEN_PREOFFERDESCDETAILS" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.POEN_PREOFFERDESCDETAILS" Roundtrip="True" /></FIELD><FIELD attrname="POEN_POPDT_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.POEN_POPDT_ID" Roundtrip="True" /></FIELD><FIELD attrname="POEN_POSTOFFERDESCDETAILS" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.POEN_POSTOFFERDESCDETAILS" Roundtrip="True" /></FIELD><FIELD attrname="ASS_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.ASS_ID" Roundtrip="True" /></FIELD><FIELD attrname="ASS_TITLE" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.ASS_TITLE" Roundtrip="True" /></FIELD><FIELD attrname="ASS_SYNOPSIS" fieldtype="bin.hex" SUBTYPE="Text" WIDTH="8"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.ASS_SYNOPSIS" Roundtrip="True" /></FIELD><FIELD attrname="ASS_VIDEOTEXT" fieldtype="bin.hex" SUBTYPE="Text" WIDTH="8"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.ASS_VIDEOTEXT" Roundtrip="True" /></FIELD><FIELD attrname="ASS_AUDIOTEXT" fieldtype="bin.hex" SUBTYPE="Text" WIDTH="8"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.ASS_AUDIOTEXT" Roundtrip="True" /></FIELD><FIELD attrname="ASS_VIDEODESCRIPTION" fieldtype="bin.hex" SUBTYPE="Text" WIDTH="8"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.ASS_VIDEODESCRIPTION" Roundtrip="True" /></FIELD><FIELD attrname="ASS_DURATIONSCHEDULED" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.ASS_DURATIONSCHEDULED" Roundtrip="True" /></FIELD><FIELD attrname="ASS_ISPBSAPPROVED" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.ASS_ISPBSAPPROVED" Roundtrip="True" /></FIELD><FIELD attrname="ARW_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.ARW_ID" Roundtrip="True" /></FIELD><FIELD attrname="ARW_DATEAVAILABLEFROM" fieldtype="dateTime"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.ARW_DATEAVAILABLEFROM" Roundtrip="True" /></FIELD><FIELD attrname="ARW_DATEAVAILABLETO" fieldtype="dateTime"><PARAM Name="ORIGIN" Value="VW_PBSOACENTITY.ARW_DATEAVAILABLETO" Roundtrip="True" /></FIELD><FIELD attrname="PBSOACITEM" fieldtype="nested"><FIELDS><FIELD attrname="POAI_ID" fieldtype="i4" required="true"><PARAM Name="PROVFLAGS" Value="7" Type="i4" Roundtrip="True" /><PARAM Name="ORIGIN" Value="PBSOACITEM.POAI_ID" Roundtrip="True" /></FIELD><FIELD attrname="POAI_OEN_ID" fieldtype="i4" required="true"><PARAM Name="ORIGIN" Value="PBSOACITEM.POAI_OEN_ID" Roundtrip="True" /></FIELD><FIELD attrname="POAI_ITEM" fieldtype="string" SUBTYPE="FixedChar" WIDTH="3"><PARAM Name="ORIGIN" Value="PBSOACITEM.POAI_ITEM" Roundtrip="True" /></FIELD><FIELD attrname="POAI_DESC" fieldtype="string" WIDTH="252"><PARAM Name="ORIGIN" Value="PBSOACITEM.POAI_DESC" Roundtrip="True" /></FIELD><FIELD attrname="POAI_MANUFACTURER" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="PBSOACITEM.POAI_MANUFACTURER" Roundtrip="True" /></FIELD><FIELD attrname="POAI_OFFERINGPRICE" fieldtype="r8"><PARAM Name="ORIGIN" Value="PBSOACITEM.POAI_OFFERINGPRICE" Roundtrip="True" /></FIELD><FIELD attrname="POAI_SHIPPINGPRICE" fieldtype="r8"><PARAM Name="ORIGIN" Value="PBSOACITEM.POAI_SHIPPINGPRICE" Roundtrip="True" /></FIELD><FIELD attrname="POAI_TOTALPRICE" fieldtype="r8"><PARAM Name="ORIGIN" Value="PBSOACITEM.POAI_TOTALPRICE" Roundtrip="True" /></FIELD><FIELD attrname="POAI_PRODUCTIONCOST" fieldtype="r8"><PARAM Name="ORIGIN" Value="PBSOACITEM.POAI_PRODUCTIONCOST" Roundtrip="True" /></FIELD><FIELD attrname="POAI_SHIPPINGCOST" fieldtype="r8"><PARAM Name="ORIGIN" Value="PBSOACITEM.POAI_SHIPPINGCOST" Roundtrip="True" /></FIELD><FIELD attrname="POAI_ADMINCOST" fieldtype="r8"><PARAM Name="ORIGIN" Value="PBSOACITEM.POAI_ADMINCOST" Roundtrip="True" /></FIELD><FIELD attrname="POAI_OTHERCOST" fieldtype="r8"><PARAM Name="ORIGIN" Value="PBSOACITEM.POAI_OTHERCOST" Roundtrip="True" /></FIELD></FIELDS><PARAMS DATASET_DELTA="TRUE" PRIMARY_KEY="1" /></FIELD></FIELDS><PARAMS DATASET_DELTA="TRUE" /></FIELD></FIELDS><PARAMS DATASET_DELTA="TRUE" PRIMARY_KEY="1" /></METADATA>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template name="OutputVW_PBSOACENTITY">
<xsl:param name="Original" />
<xsl:param name="RowState"><xsl:value-of select="$ROWSTATE_UNCHANGED" /></xsl:param>
	<ROWVW_PBSOACENTITY>
		<xsl:attribute name="RowState"><xsl:value-of select="$RowState" /></xsl:attribute>
		<xsl:choose>
			<xsl:when test="$RowState = $ROWSTATE_AFTER">
				<xsl:if test="(not(msxsl:node-set($Original)/POEN_ID) and POEN_ID) or (msxsl:node-set($Original)/POEN_ID != POEN_ID)">
					<xsl:attribute name="POEN_ID"><xsl:value-of select="POEN_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POEN_ID and not(POEN_ID)">
					<xsl:attribute name="POEN_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POEN_OAC_ID) and POEN_OAC_ID) or (msxsl:node-set($Original)/POEN_OAC_ID != POEN_OAC_ID)">
					<xsl:attribute name="POEN_OAC_ID"><xsl:value-of select="POEN_OAC_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POEN_OAC_ID and not(POEN_OAC_ID)">
					<xsl:attribute name="POEN_OAC_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POEN_OFFEROR) and POEN_OFFEROR) or (msxsl:node-set($Original)/POEN_OFFEROR != POEN_OFFEROR)">
					<xsl:attribute name="POEN_OFFEROR"><xsl:value-of select="POEN_OFFEROR" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POEN_OFFEROR and not(POEN_OFFEROR)">
					<xsl:attribute name="POEN_OFFEROR"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POEN_FENAME) and POEN_FENAME) or (msxsl:node-set($Original)/POEN_FENAME != POEN_FENAME)">
					<xsl:attribute name="POEN_FENAME"><xsl:value-of select="POEN_FENAME" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POEN_FENAME and not(POEN_FENAME)">
					<xsl:attribute name="POEN_FENAME"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POEN_FEADDRESS) and POEN_FEADDRESS) or (msxsl:node-set($Original)/POEN_FEADDRESS != POEN_FEADDRESS)">
					<xsl:attribute name="POEN_FEADDRESS"><xsl:value-of select="POEN_FEADDRESS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POEN_FEADDRESS and not(POEN_FEADDRESS)">
					<xsl:attribute name="POEN_FEADDRESS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POEN_FECITY) and POEN_FECITY) or (msxsl:node-set($Original)/POEN_FECITY != POEN_FECITY)">
					<xsl:attribute name="POEN_FECITY"><xsl:value-of select="POEN_FECITY" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POEN_FECITY and not(POEN_FECITY)">
					<xsl:attribute name="POEN_FECITY"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POEN_FESTATE) and POEN_FESTATE) or (msxsl:node-set($Original)/POEN_FESTATE != POEN_FESTATE)">
					<xsl:attribute name="POEN_FESTATE"><xsl:value-of select="POEN_FESTATE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POEN_FESTATE and not(POEN_FESTATE)">
					<xsl:attribute name="POEN_FESTATE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POEN_FEZIP) and POEN_FEZIP) or (msxsl:node-set($Original)/POEN_FEZIP != POEN_FEZIP)">
					<xsl:attribute name="POEN_FEZIP"><xsl:value-of select="POEN_FEZIP" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POEN_FEZIP and not(POEN_FEZIP)">
					<xsl:attribute name="POEN_FEZIP"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POEN_OFFERMADEBY) and POEN_OFFERMADEBY) or (msxsl:node-set($Original)/POEN_OFFERMADEBY != POEN_OFFERMADEBY)">
					<xsl:attribute name="POEN_OFFERMADEBY"><xsl:value-of select="POEN_OFFERMADEBY" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POEN_OFFERMADEBY and not(POEN_OFFERMADEBY)">
					<xsl:attribute name="POEN_OFFERMADEBY"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POEN_PAYMENTCOMPANY) and POEN_PAYMENTCOMPANY) or (msxsl:node-set($Original)/POEN_PAYMENTCOMPANY != POEN_PAYMENTCOMPANY)">
					<xsl:attribute name="POEN_PAYMENTCOMPANY"><xsl:value-of select="POEN_PAYMENTCOMPANY" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POEN_PAYMENTCOMPANY and not(POEN_PAYMENTCOMPANY)">
					<xsl:attribute name="POEN_PAYMENTCOMPANY"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POEN_PAYMENTCONTACT) and POEN_PAYMENTCONTACT) or (msxsl:node-set($Original)/POEN_PAYMENTCONTACT != POEN_PAYMENTCONTACT)">
					<xsl:attribute name="POEN_PAYMENTCONTACT"><xsl:value-of select="POEN_PAYMENTCONTACT" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POEN_PAYMENTCONTACT and not(POEN_PAYMENTCONTACT)">
					<xsl:attribute name="POEN_PAYMENTCONTACT"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POEN_PAYMENTADDRESS) and POEN_PAYMENTADDRESS) or (msxsl:node-set($Original)/POEN_PAYMENTADDRESS != POEN_PAYMENTADDRESS)">
					<xsl:attribute name="POEN_PAYMENTADDRESS"><xsl:value-of select="POEN_PAYMENTADDRESS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POEN_PAYMENTADDRESS and not(POEN_PAYMENTADDRESS)">
					<xsl:attribute name="POEN_PAYMENTADDRESS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POEN_PAYMENTCITY) and POEN_PAYMENTCITY) or (msxsl:node-set($Original)/POEN_PAYMENTCITY != POEN_PAYMENTCITY)">
					<xsl:attribute name="POEN_PAYMENTCITY"><xsl:value-of select="POEN_PAYMENTCITY" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POEN_PAYMENTCITY and not(POEN_PAYMENTCITY)">
					<xsl:attribute name="POEN_PAYMENTCITY"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POEN_PAYMENTSTATE) and POEN_PAYMENTSTATE) or (msxsl:node-set($Original)/POEN_PAYMENTSTATE != POEN_PAYMENTSTATE)">
					<xsl:attribute name="POEN_PAYMENTSTATE"><xsl:value-of select="POEN_PAYMENTSTATE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POEN_PAYMENTSTATE and not(POEN_PAYMENTSTATE)">
					<xsl:attribute name="POEN_PAYMENTSTATE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POEN_PAYMENTZIP) and POEN_PAYMENTZIP) or (msxsl:node-set($Original)/POEN_PAYMENTZIP != POEN_PAYMENTZIP)">
					<xsl:attribute name="POEN_PAYMENTZIP"><xsl:value-of select="POEN_PAYMENTZIP" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POEN_PAYMENTZIP and not(POEN_PAYMENTZIP)">
					<xsl:attribute name="POEN_PAYMENTZIP"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POEN_PAYMENTPHONE) and POEN_PAYMENTPHONE) or (msxsl:node-set($Original)/POEN_PAYMENTPHONE != POEN_PAYMENTPHONE)">
					<xsl:attribute name="POEN_PAYMENTPHONE"><xsl:value-of select="POEN_PAYMENTPHONE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POEN_PAYMENTPHONE and not(POEN_PAYMENTPHONE)">
					<xsl:attribute name="POEN_PAYMENTPHONE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POEN_PAYMENTFAX) and POEN_PAYMENTFAX) or (msxsl:node-set($Original)/POEN_PAYMENTFAX != POEN_PAYMENTFAX)">
					<xsl:attribute name="POEN_PAYMENTFAX"><xsl:value-of select="POEN_PAYMENTFAX" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POEN_PAYMENTFAX and not(POEN_PAYMENTFAX)">
					<xsl:attribute name="POEN_PAYMENTFAX"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POEN_PAYMENTEMAIL) and POEN_PAYMENTEMAIL) or (msxsl:node-set($Original)/POEN_PAYMENTEMAIL != POEN_PAYMENTEMAIL)">
					<xsl:attribute name="POEN_PAYMENTEMAIL"><xsl:value-of select="POEN_PAYMENTEMAIL" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POEN_PAYMENTEMAIL and not(POEN_PAYMENTEMAIL)">
					<xsl:attribute name="POEN_PAYMENTEMAIL"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POEN_PREPBSLOGO) and POEN_PREPBSLOGO) or (msxsl:node-set($Original)/POEN_PREPBSLOGO != POEN_PREPBSLOGO)">
					<xsl:attribute name="POEN_PREPBSLOGO"><xsl:value-of select="POEN_PREPBSLOGO" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POEN_PREPBSLOGO and not(POEN_PREPBSLOGO)">
					<xsl:attribute name="POEN_PREPBSLOGO"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POEN_PODT_ID) and POEN_PODT_ID) or (msxsl:node-set($Original)/POEN_PODT_ID != POEN_PODT_ID)">
					<xsl:attribute name="POEN_PODT_ID"><xsl:value-of select="POEN_PODT_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POEN_PODT_ID and not(POEN_PODT_ID)">
					<xsl:attribute name="POEN_PODT_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POEN_PREOFFERDESCDETAILS) and POEN_PREOFFERDESCDETAILS) or (msxsl:node-set($Original)/POEN_PREOFFERDESCDETAILS != POEN_PREOFFERDESCDETAILS)">
					<xsl:attribute name="POEN_PREOFFERDESCDETAILS"><xsl:value-of select="POEN_PREOFFERDESCDETAILS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POEN_PREOFFERDESCDETAILS and not(POEN_PREOFFERDESCDETAILS)">
					<xsl:attribute name="POEN_PREOFFERDESCDETAILS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POEN_POPDT_ID) and POEN_POPDT_ID) or (msxsl:node-set($Original)/POEN_POPDT_ID != POEN_POPDT_ID)">
					<xsl:attribute name="POEN_POPDT_ID"><xsl:value-of select="POEN_POPDT_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POEN_POPDT_ID and not(POEN_POPDT_ID)">
					<xsl:attribute name="POEN_POPDT_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POEN_POSTOFFERDESCDETAILS) and POEN_POSTOFFERDESCDETAILS) or (msxsl:node-set($Original)/POEN_POSTOFFERDESCDETAILS != POEN_POSTOFFERDESCDETAILS)">
					<xsl:attribute name="POEN_POSTOFFERDESCDETAILS"><xsl:value-of select="POEN_POSTOFFERDESCDETAILS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POEN_POSTOFFERDESCDETAILS and not(POEN_POSTOFFERDESCDETAILS)">
					<xsl:attribute name="POEN_POSTOFFERDESCDETAILS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_ID) and ASS_ID) or (msxsl:node-set($Original)/ASS_ID != ASS_ID)">
					<xsl:attribute name="ASS_ID"><xsl:value-of select="ASS_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_ID and not(ASS_ID)">
					<xsl:attribute name="ASS_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_TITLE) and ASS_TITLE) or (msxsl:node-set($Original)/ASS_TITLE != ASS_TITLE)">
					<xsl:attribute name="ASS_TITLE"><xsl:value-of select="ASS_TITLE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_TITLE and not(ASS_TITLE)">
					<xsl:attribute name="ASS_TITLE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="ASS_SYNOPSIS != '' and (not(msxsl:node-set($Original)/ASS_SYNOPSIS) and ASS_SYNOPSIS) or (msxsl:node-set($Original)/ASS_SYNOPSIS != ASS_SYNOPSIS)">
					<xsl:attribute name="ASS_SYNOPSIS"><xsl:value-of select="ASS_SYNOPSIS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_SYNOPSIS and not(ASS_SYNOPSIS)">
					<xsl:attribute name="ASS_SYNOPSIS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="ASS_VIDEOTEXT != '' and (not(msxsl:node-set($Original)/ASS_VIDEOTEXT) and ASS_VIDEOTEXT) or (msxsl:node-set($Original)/ASS_VIDEOTEXT != ASS_VIDEOTEXT)">
					<xsl:attribute name="ASS_VIDEOTEXT"><xsl:value-of select="ASS_VIDEOTEXT" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_VIDEOTEXT and not(ASS_VIDEOTEXT)">
					<xsl:attribute name="ASS_VIDEOTEXT"></xsl:attribute>
				</xsl:if>
				<xsl:if test="ASS_AUDIOTEXT != '' and (not(msxsl:node-set($Original)/ASS_AUDIOTEXT) and ASS_AUDIOTEXT) or (msxsl:node-set($Original)/ASS_AUDIOTEXT != ASS_AUDIOTEXT)">
					<xsl:attribute name="ASS_AUDIOTEXT"><xsl:value-of select="ASS_AUDIOTEXT" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_AUDIOTEXT and not(ASS_AUDIOTEXT)">
					<xsl:attribute name="ASS_AUDIOTEXT"></xsl:attribute>
				</xsl:if>
				<xsl:if test="ASS_VIDEODESCRIPTION != '' and (not(msxsl:node-set($Original)/ASS_VIDEODESCRIPTION) and ASS_VIDEODESCRIPTION) or (msxsl:node-set($Original)/ASS_VIDEODESCRIPTION != ASS_VIDEODESCRIPTION)">
					<xsl:attribute name="ASS_VIDEODESCRIPTION"><xsl:value-of select="ASS_VIDEODESCRIPTION" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_VIDEODESCRIPTION and not(ASS_VIDEODESCRIPTION)">
					<xsl:attribute name="ASS_VIDEODESCRIPTION"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_DURATIONSCHEDULED) and ASS_DURATIONSCHEDULED) or (msxsl:node-set($Original)/ASS_DURATIONSCHEDULED != ASS_DURATIONSCHEDULED)">
					<xsl:attribute name="ASS_DURATIONSCHEDULED"><xsl:value-of select="ASS_DURATIONSCHEDULED" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_DURATIONSCHEDULED and not(ASS_DURATIONSCHEDULED)">
					<xsl:attribute name="ASS_DURATIONSCHEDULED"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_ISPBSAPPROVED) and ASS_ISPBSAPPROVED) or (msxsl:node-set($Original)/ASS_ISPBSAPPROVED != ASS_ISPBSAPPROVED)">
					<xsl:attribute name="ASS_ISPBSAPPROVED"><xsl:value-of select="ASS_ISPBSAPPROVED" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_ISPBSAPPROVED and not(ASS_ISPBSAPPROVED)">
					<xsl:attribute name="ASS_ISPBSAPPROVED"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/ARW_ID) and ARW_ID) or (msxsl:node-set($Original)/ARW_ID != ARW_ID)">
					<xsl:attribute name="ARW_ID"><xsl:value-of select="ARW_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ARW_ID and not(ARW_ID)">
					<xsl:attribute name="ARW_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/ARW_DATEAVAILABLEFROM) and ARW_DATEAVAILABLEFROM) or (msxsl:node-set($Original)/ARW_DATEAVAILABLEFROM != ARW_DATEAVAILABLEFROM)">
					<xsl:attribute name="ARW_DATEAVAILABLEFROM"><xsl:value-of select="ARW_DATEAVAILABLEFROM" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ARW_DATEAVAILABLEFROM and not(ARW_DATEAVAILABLEFROM)">
					<xsl:attribute name="ARW_DATEAVAILABLEFROM"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/ARW_DATEAVAILABLETO) and ARW_DATEAVAILABLETO) or (msxsl:node-set($Original)/ARW_DATEAVAILABLETO != ARW_DATEAVAILABLETO)">
					<xsl:attribute name="ARW_DATEAVAILABLETO"><xsl:value-of select="ARW_DATEAVAILABLETO" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ARW_DATEAVAILABLETO and not(ARW_DATEAVAILABLETO)">
					<xsl:attribute name="ARW_DATEAVAILABLETO"></xsl:attribute>
				</xsl:if>
			</xsl:when>
			<xsl:otherwise>
				<xsl:attribute name="POEN_ID"><xsl:value-of select="POEN_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POEN_ID and not(POEN_ID)">
					<xsl:attribute name="POEN_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POEN_OAC_ID"><xsl:value-of select="POEN_OAC_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POEN_OAC_ID and not(POEN_OAC_ID)">
					<xsl:attribute name="POEN_OAC_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POEN_OFFEROR"><xsl:value-of select="POEN_OFFEROR" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POEN_OFFEROR and not(POEN_OFFEROR)">
					<xsl:attribute name="POEN_OFFEROR"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POEN_FENAME"><xsl:value-of select="POEN_FENAME" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POEN_FENAME and not(POEN_FENAME)">
					<xsl:attribute name="POEN_FENAME"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POEN_FEADDRESS"><xsl:value-of select="POEN_FEADDRESS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POEN_FEADDRESS and not(POEN_FEADDRESS)">
					<xsl:attribute name="POEN_FEADDRESS"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POEN_FECITY"><xsl:value-of select="POEN_FECITY" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POEN_FECITY and not(POEN_FECITY)">
					<xsl:attribute name="POEN_FECITY"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POEN_FESTATE"><xsl:value-of select="POEN_FESTATE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POEN_FESTATE and not(POEN_FESTATE)">
					<xsl:attribute name="POEN_FESTATE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POEN_FEZIP"><xsl:value-of select="POEN_FEZIP" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POEN_FEZIP and not(POEN_FEZIP)">
					<xsl:attribute name="POEN_FEZIP"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POEN_OFFERMADEBY"><xsl:value-of select="POEN_OFFERMADEBY" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POEN_OFFERMADEBY and not(POEN_OFFERMADEBY)">
					<xsl:attribute name="POEN_OFFERMADEBY"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POEN_PAYMENTCOMPANY"><xsl:value-of select="POEN_PAYMENTCOMPANY" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POEN_PAYMENTCOMPANY and not(POEN_PAYMENTCOMPANY)">
					<xsl:attribute name="POEN_PAYMENTCOMPANY"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POEN_PAYMENTCONTACT"><xsl:value-of select="POEN_PAYMENTCONTACT" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POEN_PAYMENTCONTACT and not(POEN_PAYMENTCONTACT)">
					<xsl:attribute name="POEN_PAYMENTCONTACT"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POEN_PAYMENTADDRESS"><xsl:value-of select="POEN_PAYMENTADDRESS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POEN_PAYMENTADDRESS and not(POEN_PAYMENTADDRESS)">
					<xsl:attribute name="POEN_PAYMENTADDRESS"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POEN_PAYMENTCITY"><xsl:value-of select="POEN_PAYMENTCITY" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POEN_PAYMENTCITY and not(POEN_PAYMENTCITY)">
					<xsl:attribute name="POEN_PAYMENTCITY"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POEN_PAYMENTSTATE"><xsl:value-of select="POEN_PAYMENTSTATE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POEN_PAYMENTSTATE and not(POEN_PAYMENTSTATE)">
					<xsl:attribute name="POEN_PAYMENTSTATE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POEN_PAYMENTZIP"><xsl:value-of select="POEN_PAYMENTZIP" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POEN_PAYMENTZIP and not(POEN_PAYMENTZIP)">
					<xsl:attribute name="POEN_PAYMENTZIP"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POEN_PAYMENTPHONE"><xsl:value-of select="POEN_PAYMENTPHONE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POEN_PAYMENTPHONE and not(POEN_PAYMENTPHONE)">
					<xsl:attribute name="POEN_PAYMENTPHONE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POEN_PAYMENTFAX"><xsl:value-of select="POEN_PAYMENTFAX" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POEN_PAYMENTFAX and not(POEN_PAYMENTFAX)">
					<xsl:attribute name="POEN_PAYMENTFAX"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POEN_PAYMENTEMAIL"><xsl:value-of select="POEN_PAYMENTEMAIL" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POEN_PAYMENTEMAIL and not(POEN_PAYMENTEMAIL)">
					<xsl:attribute name="POEN_PAYMENTEMAIL"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POEN_PREPBSLOGO"><xsl:value-of select="POEN_PREPBSLOGO" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POEN_PREPBSLOGO and not(POEN_PREPBSLOGO)">
					<xsl:attribute name="POEN_PREPBSLOGO"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POEN_PODT_ID"><xsl:value-of select="POEN_PODT_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POEN_PODT_ID and not(POEN_PODT_ID)">
					<xsl:attribute name="POEN_PODT_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POEN_PREOFFERDESCDETAILS"><xsl:value-of select="POEN_PREOFFERDESCDETAILS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POEN_PREOFFERDESCDETAILS and not(POEN_PREOFFERDESCDETAILS)">
					<xsl:attribute name="POEN_PREOFFERDESCDETAILS"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POEN_POPDT_ID"><xsl:value-of select="POEN_POPDT_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POEN_POPDT_ID and not(POEN_POPDT_ID)">
					<xsl:attribute name="POEN_POPDT_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POEN_POSTOFFERDESCDETAILS"><xsl:value-of select="POEN_POSTOFFERDESCDETAILS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POEN_POSTOFFERDESCDETAILS and not(POEN_POSTOFFERDESCDETAILS)">
					<xsl:attribute name="POEN_POSTOFFERDESCDETAILS"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ASS_ID"><xsl:value-of select="ASS_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_ID and not(ASS_ID)">
					<xsl:attribute name="ASS_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ASS_TITLE"><xsl:value-of select="ASS_TITLE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_TITLE and not(ASS_TITLE)">
					<xsl:attribute name="ASS_TITLE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="ASS_SYNOPSIS != ''">
					<xsl:attribute name="ASS_SYNOPSIS"><xsl:value-of select="ASS_SYNOPSIS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_SYNOPSIS and not(ASS_SYNOPSIS)">
					<xsl:attribute name="ASS_SYNOPSIS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="ASS_VIDEOTEXT != ''">
					<xsl:attribute name="ASS_VIDEOTEXT"><xsl:value-of select="ASS_VIDEOTEXT" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_VIDEOTEXT and not(ASS_VIDEOTEXT)">
					<xsl:attribute name="ASS_VIDEOTEXT"></xsl:attribute>
				</xsl:if>
				<xsl:if test="ASS_AUDIOTEXT != ''">
					<xsl:attribute name="ASS_AUDIOTEXT"><xsl:value-of select="ASS_AUDIOTEXT" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_AUDIOTEXT and not(ASS_AUDIOTEXT)">
					<xsl:attribute name="ASS_AUDIOTEXT"></xsl:attribute>
				</xsl:if>
				<xsl:if test="ASS_VIDEODESCRIPTION != ''">
					<xsl:attribute name="ASS_VIDEODESCRIPTION"><xsl:value-of select="ASS_VIDEODESCRIPTION" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_VIDEODESCRIPTION and not(ASS_VIDEODESCRIPTION)">
					<xsl:attribute name="ASS_VIDEODESCRIPTION"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ASS_DURATIONSCHEDULED"><xsl:value-of select="ASS_DURATIONSCHEDULED" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_DURATIONSCHEDULED and not(ASS_DURATIONSCHEDULED)">
					<xsl:attribute name="ASS_DURATIONSCHEDULED"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ASS_ISPBSAPPROVED"><xsl:value-of select="ASS_ISPBSAPPROVED" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_ISPBSAPPROVED and not(ASS_ISPBSAPPROVED)">
					<xsl:attribute name="ASS_ISPBSAPPROVED"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ARW_ID"><xsl:value-of select="ARW_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ARW_ID and not(ARW_ID)">
					<xsl:attribute name="ARW_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ARW_DATEAVAILABLEFROM"><xsl:value-of select="ARW_DATEAVAILABLEFROM" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ARW_DATEAVAILABLEFROM and not(ARW_DATEAVAILABLEFROM)">
					<xsl:attribute name="ARW_DATEAVAILABLEFROM"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ARW_DATEAVAILABLETO"><xsl:value-of select="ARW_DATEAVAILABLETO" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ARW_DATEAVAILABLETO and not(ARW_DATEAVAILABLETO)">
					<xsl:attribute name="ARW_DATEAVAILABLETO"></xsl:attribute>
				</xsl:if>
			</xsl:otherwise>
		</xsl:choose>

		<PBSOACITEM>
			<xsl:if test="($RowState=$ROWSTATE_NEW) or ($RowState=$ROWSTATE_BEFORE) or ($RowState=$ROWSTATE_UNCHANGED)">
				<xsl:for-each select="//OACDataSet/PBSOACITEM">
					<xsl:choose>
						<xsl:when test="@diffgr:hasChanges='inserted'">
							<xsl:call-template name="OutputPBSOACITEM">
								<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
							</xsl:call-template>
						</xsl:when>

						<xsl:when test="@diffgr:hasChanges='modified'">
							<xsl:for-each select="key('OriginalPBSOACITEM', @diffgr:id)">
								<xsl:call-template name="OutputPBSOACITEM">
									<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
								</xsl:call-template>
							</xsl:for-each>
							<xsl:call-template name="OutputPBSOACITEM">
								<xsl:with-param name="Original" select="key('OriginalPBSOACITEM', @diffgr:id)" />
								<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
							</xsl:call-template>
						</xsl:when>
					</xsl:choose>
				</xsl:for-each>
				<xsl:for-each select="//diffgr:before/PBSOACITEM">
					<xsl:if test="count(key('CurrentPBSOACITEM', @diffgr:id)) = 0">
						<xsl:call-template name="OutputPBSOACITEM">
							<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
						</xsl:call-template>
					</xsl:if>
				</xsl:for-each>
			</xsl:if>
		</PBSOACITEM>
	</ROWVW_PBSOACENTITY>
</xsl:template>

<xsl:template name="OutputPBSOACITEM">
<xsl:param name="Original" />
<xsl:param name="RowState"><xsl:value-of select="$ROWSTATE_UNCHANGED" /></xsl:param>
	<ROWPBSOACITEM>
		<xsl:attribute name="RowState"><xsl:value-of select="$RowState" /></xsl:attribute>
		<xsl:choose>
			<xsl:when test="$RowState = $ROWSTATE_AFTER">
				<xsl:if test="(not(msxsl:node-set($Original)/POAI_ID) and POAI_ID) or (msxsl:node-set($Original)/POAI_ID != POAI_ID)">
					<xsl:attribute name="POAI_ID"><xsl:value-of select="POAI_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POAI_ID and not(POAI_ID)">
					<xsl:attribute name="POAI_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POAI_OEN_ID) and POAI_OEN_ID) or (msxsl:node-set($Original)/POAI_OEN_ID != POAI_OEN_ID)">
					<xsl:attribute name="POAI_OEN_ID"><xsl:value-of select="POAI_OEN_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POAI_OEN_ID and not(POAI_OEN_ID)">
					<xsl:attribute name="POAI_OEN_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POAI_ITEM) and POAI_ITEM) or (msxsl:node-set($Original)/POAI_ITEM != POAI_ITEM)">
					<xsl:attribute name="POAI_ITEM"><xsl:value-of select="POAI_ITEM" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POAI_ITEM and not(POAI_ITEM)">
					<xsl:attribute name="POAI_ITEM"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POAI_DESC) and POAI_DESC) or (msxsl:node-set($Original)/POAI_DESC != POAI_DESC)">
					<xsl:attribute name="POAI_DESC"><xsl:value-of select="POAI_DESC" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POAI_DESC and not(POAI_DESC)">
					<xsl:attribute name="POAI_DESC"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POAI_MANUFACTURER) and POAI_MANUFACTURER) or (msxsl:node-set($Original)/POAI_MANUFACTURER != POAI_MANUFACTURER)">
					<xsl:attribute name="POAI_MANUFACTURER"><xsl:value-of select="POAI_MANUFACTURER" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POAI_MANUFACTURER and not(POAI_MANUFACTURER)">
					<xsl:attribute name="POAI_MANUFACTURER"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POAI_OFFERINGPRICE) and POAI_OFFERINGPRICE) or (msxsl:node-set($Original)/POAI_OFFERINGPRICE != POAI_OFFERINGPRICE)">
					<xsl:attribute name="POAI_OFFERINGPRICE"><xsl:value-of select="POAI_OFFERINGPRICE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POAI_OFFERINGPRICE and not(POAI_OFFERINGPRICE)">
					<xsl:attribute name="POAI_OFFERINGPRICE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POAI_SHIPPINGPRICE) and POAI_SHIPPINGPRICE) or (msxsl:node-set($Original)/POAI_SHIPPINGPRICE != POAI_SHIPPINGPRICE)">
					<xsl:attribute name="POAI_SHIPPINGPRICE"><xsl:value-of select="POAI_SHIPPINGPRICE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POAI_SHIPPINGPRICE and not(POAI_SHIPPINGPRICE)">
					<xsl:attribute name="POAI_SHIPPINGPRICE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POAI_TOTALPRICE) and POAI_TOTALPRICE) or (msxsl:node-set($Original)/POAI_TOTALPRICE != POAI_TOTALPRICE)">
					<xsl:attribute name="POAI_TOTALPRICE"><xsl:value-of select="POAI_TOTALPRICE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POAI_TOTALPRICE and not(POAI_TOTALPRICE)">
					<xsl:attribute name="POAI_TOTALPRICE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POAI_PRODUCTIONCOST) and POAI_PRODUCTIONCOST) or (msxsl:node-set($Original)/POAI_PRODUCTIONCOST != POAI_PRODUCTIONCOST)">
					<xsl:attribute name="POAI_PRODUCTIONCOST"><xsl:value-of select="POAI_PRODUCTIONCOST" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POAI_PRODUCTIONCOST and not(POAI_PRODUCTIONCOST)">
					<xsl:attribute name="POAI_PRODUCTIONCOST"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POAI_SHIPPINGCOST) and POAI_SHIPPINGCOST) or (msxsl:node-set($Original)/POAI_SHIPPINGCOST != POAI_SHIPPINGCOST)">
					<xsl:attribute name="POAI_SHIPPINGCOST"><xsl:value-of select="POAI_SHIPPINGCOST" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POAI_SHIPPINGCOST and not(POAI_SHIPPINGCOST)">
					<xsl:attribute name="POAI_SHIPPINGCOST"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POAI_ADMINCOST) and POAI_ADMINCOST) or (msxsl:node-set($Original)/POAI_ADMINCOST != POAI_ADMINCOST)">
					<xsl:attribute name="POAI_ADMINCOST"><xsl:value-of select="POAI_ADMINCOST" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POAI_ADMINCOST and not(POAI_ADMINCOST)">
					<xsl:attribute name="POAI_ADMINCOST"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POAI_OTHERCOST) and POAI_OTHERCOST) or (msxsl:node-set($Original)/POAI_OTHERCOST != POAI_OTHERCOST)">
					<xsl:attribute name="POAI_OTHERCOST"><xsl:value-of select="POAI_OTHERCOST" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POAI_OTHERCOST and not(POAI_OTHERCOST)">
					<xsl:attribute name="POAI_OTHERCOST"></xsl:attribute>
				</xsl:if>
			</xsl:when>
			<xsl:otherwise>
				<xsl:attribute name="POAI_ID"><xsl:value-of select="POAI_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POAI_ID and not(POAI_ID)">
					<xsl:attribute name="POAI_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POAI_OEN_ID"><xsl:value-of select="POAI_OEN_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POAI_OEN_ID and not(POAI_OEN_ID)">
					<xsl:attribute name="POAI_OEN_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POAI_ITEM"><xsl:value-of select="POAI_ITEM" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POAI_ITEM and not(POAI_ITEM)">
					<xsl:attribute name="POAI_ITEM"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POAI_DESC"><xsl:value-of select="POAI_DESC" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POAI_DESC and not(POAI_DESC)">
					<xsl:attribute name="POAI_DESC"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POAI_MANUFACTURER"><xsl:value-of select="POAI_MANUFACTURER" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POAI_MANUFACTURER and not(POAI_MANUFACTURER)">
					<xsl:attribute name="POAI_MANUFACTURER"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POAI_OFFERINGPRICE"><xsl:value-of select="POAI_OFFERINGPRICE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POAI_OFFERINGPRICE and not(POAI_OFFERINGPRICE)">
					<xsl:attribute name="POAI_OFFERINGPRICE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POAI_SHIPPINGPRICE"><xsl:value-of select="POAI_SHIPPINGPRICE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POAI_SHIPPINGPRICE and not(POAI_SHIPPINGPRICE)">
					<xsl:attribute name="POAI_SHIPPINGPRICE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POAI_TOTALPRICE"><xsl:value-of select="POAI_TOTALPRICE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POAI_TOTALPRICE and not(POAI_TOTALPRICE)">
					<xsl:attribute name="POAI_TOTALPRICE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POAI_PRODUCTIONCOST"><xsl:value-of select="POAI_PRODUCTIONCOST" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POAI_PRODUCTIONCOST and not(POAI_PRODUCTIONCOST)">
					<xsl:attribute name="POAI_PRODUCTIONCOST"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POAI_SHIPPINGCOST"><xsl:value-of select="POAI_SHIPPINGCOST" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POAI_SHIPPINGCOST and not(POAI_SHIPPINGCOST)">
					<xsl:attribute name="POAI_SHIPPINGCOST"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POAI_ADMINCOST"><xsl:value-of select="POAI_ADMINCOST" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POAI_ADMINCOST and not(POAI_ADMINCOST)">
					<xsl:attribute name="POAI_ADMINCOST"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POAI_OTHERCOST"><xsl:value-of select="POAI_OTHERCOST" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POAI_OTHERCOST and not(POAI_OTHERCOST)">
					<xsl:attribute name="POAI_OTHERCOST"></xsl:attribute>
				</xsl:if>
			</xsl:otherwise>
		</xsl:choose>

	</ROWPBSOACITEM>
</xsl:template>

<xsl:template name="OutputOAC">
<xsl:param name="Original" />
<xsl:param name="RowState"><xsl:value-of select="$ROWSTATE_UNCHANGED" /></xsl:param>
	<ROW>
		<xsl:attribute name="RowState"><xsl:value-of select="$RowState" /></xsl:attribute>
		<xsl:choose>
			<xsl:when test="$RowState = $ROWSTATE_AFTER">
				<xsl:if test="(not(msxsl:node-set($Original)/POAC_ID) and POAC_ID) or (msxsl:node-set($Original)/POAC_ID != POAC_ID)">
					<xsl:attribute name="POAC_ID"><xsl:value-of select="POAC_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POAC_ID and not(POAC_ID)">
					<xsl:attribute name="POAC_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POAC_CONTACT) and POAC_CONTACT) or (msxsl:node-set($Original)/POAC_CONTACT != POAC_CONTACT)">
					<xsl:attribute name="POAC_CONTACT"><xsl:value-of select="POAC_CONTACT" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POAC_CONTACT and not(POAC_CONTACT)">
					<xsl:attribute name="POAC_CONTACT"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POAC_PHONE) and POAC_PHONE) or (msxsl:node-set($Original)/POAC_PHONE != POAC_PHONE)">
					<xsl:attribute name="POAC_PHONE"><xsl:value-of select="POAC_PHONE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POAC_PHONE and not(POAC_PHONE)">
					<xsl:attribute name="POAC_PHONE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POAC_EMAIL) and POAC_EMAIL) or (msxsl:node-set($Original)/POAC_EMAIL != POAC_EMAIL)">
					<xsl:attribute name="POAC_EMAIL"><xsl:value-of select="POAC_EMAIL" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POAC_EMAIL and not(POAC_EMAIL)">
					<xsl:attribute name="POAC_EMAIL"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POAC_DEA_ID) and POAC_DEA_ID) or (msxsl:node-set($Original)/POAC_DEA_ID != POAC_DEA_ID)">
					<xsl:attribute name="POAC_DEA_ID"><xsl:value-of select="POAC_DEA_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POAC_DEA_ID and not(POAC_DEA_ID)">
					<xsl:attribute name="POAC_DEA_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POAC_FORMSTATUS) and POAC_FORMSTATUS) or (msxsl:node-set($Original)/POAC_FORMSTATUS != POAC_FORMSTATUS)">
					<xsl:attribute name="POAC_FORMSTATUS"><xsl:value-of select="POAC_FORMSTATUS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POAC_FORMSTATUS and not(POAC_FORMSTATUS)">
					<xsl:attribute name="POAC_FORMSTATUS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POAC_OPERATINGUNIT) and POAC_OPERATINGUNIT) or (msxsl:node-set($Original)/POAC_OPERATINGUNIT != POAC_OPERATINGUNIT)">
					<xsl:attribute name="POAC_OPERATINGUNIT"><xsl:value-of select="POAC_OPERATINGUNIT" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POAC_OPERATINGUNIT and not(POAC_OPERATINGUNIT)">
					<xsl:attribute name="POAC_OPERATINGUNIT"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/POAC_OPERATINGGROUP) and POAC_OPERATINGGROUP) or (msxsl:node-set($Original)/POAC_OPERATINGGROUP != POAC_OPERATINGGROUP)">
					<xsl:attribute name="POAC_OPERATINGGROUP"><xsl:value-of select="POAC_OPERATINGGROUP" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/POAC_OPERATINGGROUP and not(POAC_OPERATINGGROUP)">
					<xsl:attribute name="POAC_OPERATINGGROUP"></xsl:attribute>
				</xsl:if>
			</xsl:when>
			<xsl:otherwise>
				<xsl:attribute name="POAC_ID"><xsl:value-of select="POAC_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POAC_ID and not(POAC_ID)">
					<xsl:attribute name="POAC_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POAC_CONTACT"><xsl:value-of select="POAC_CONTACT" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POAC_CONTACT and not(POAC_CONTACT)">
					<xsl:attribute name="POAC_CONTACT"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POAC_PHONE"><xsl:value-of select="POAC_PHONE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POAC_PHONE and not(POAC_PHONE)">
					<xsl:attribute name="POAC_PHONE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POAC_EMAIL"><xsl:value-of select="POAC_EMAIL" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POAC_EMAIL and not(POAC_EMAIL)">
					<xsl:attribute name="POAC_EMAIL"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POAC_DEA_ID"><xsl:value-of select="POAC_DEA_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POAC_DEA_ID and not(POAC_DEA_ID)">
					<xsl:attribute name="POAC_DEA_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POAC_FORMSTATUS"><xsl:value-of select="POAC_FORMSTATUS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POAC_FORMSTATUS and not(POAC_FORMSTATUS)">
					<xsl:attribute name="POAC_FORMSTATUS"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POAC_OPERATINGUNIT"><xsl:value-of select="POAC_OPERATINGUNIT" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POAC_OPERATINGUNIT and not(POAC_OPERATINGUNIT)">
					<xsl:attribute name="POAC_OPERATINGUNIT"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="POAC_OPERATINGGROUP"><xsl:value-of select="POAC_OPERATINGGROUP" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/POAC_OPERATINGGROUP and not(POAC_OPERATINGGROUP)">
					<xsl:attribute name="POAC_OPERATINGGROUP"></xsl:attribute>
				</xsl:if>
			</xsl:otherwise>
		</xsl:choose>

		<VW_PBSOACENTITY>
			<xsl:if test="($RowState=$ROWSTATE_NEW) or ($RowState=$ROWSTATE_BEFORE) or ($RowState=$ROWSTATE_UNCHANGED)">
				<xsl:for-each select="//OACDataSet/VW_PBSOACENTITY">
					<xsl:choose>
						<xsl:when test="@diffgr:hasChanges='inserted'">
							<xsl:call-template name="OutputVW_PBSOACENTITY">
								<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
							</xsl:call-template>
						</xsl:when>

						<xsl:when test="@diffgr:hasChanges='modified'">
							<xsl:for-each select="key('OriginalVW_PBSOACENTITY', @diffgr:id)">
								<xsl:call-template name="OutputVW_PBSOACENTITY">
									<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
								</xsl:call-template>
							</xsl:for-each>
							<xsl:call-template name="OutputVW_PBSOACENTITY">
								<xsl:with-param name="Original" select="key('OriginalVW_PBSOACENTITY', @diffgr:id)" />
								<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
							</xsl:call-template>
						</xsl:when>

						<xsl:otherwise>
							<xsl:call-template name="OutputVW_PBSOACENTITY">
								<xsl:with-param name="RowState" select="$ROWSTATE_UNCHANGED" />
							</xsl:call-template>
						</xsl:otherwise>
					</xsl:choose>
				</xsl:for-each>
				<xsl:for-each select="//diffgr:before/VW_PBSOACENTITY">
					<xsl:if test="count(key('CurrentVW_PBSOACENTITY', @diffgr:id)) = 0">
						<xsl:call-template name="OutputVW_PBSOACENTITY">
							<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
						</xsl:call-template>
					</xsl:if>
				</xsl:for-each>
			</xsl:if>
		</VW_PBSOACENTITY>
	</ROW>
</xsl:template>

<xsl:template match="/">
	<DATAPACKET Version="2.0">
	<xsl:call-template name="Output_Schema" />
	<ROWDATA>
		<xsl:for-each select="//OACDataSet/OAC">
			<xsl:choose>
				<xsl:when test="@diffgr:hasChanges='inserted'">
					<xsl:call-template name="OutputOAC">
						<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
					</xsl:call-template>
				</xsl:when>

				<xsl:when test="@diffgr:hasChanges='modified'">
					<xsl:for-each select="key('OriginalOAC', @diffgr:id)">
						<xsl:call-template name="OutputOAC">
							<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
						</xsl:call-template>
					</xsl:for-each>
					<xsl:call-template name="OutputOAC">
						<xsl:with-param name="Original" select="key('OriginalOAC', @diffgr:id)" />
						<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
					</xsl:call-template>
				</xsl:when>

				<xsl:otherwise>
					<xsl:call-template name="OutputOAC">
						<xsl:with-param name="RowState" select="$ROWSTATE_UNCHANGED" />
					</xsl:call-template>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:for-each>
		<xsl:for-each select="//diffgr:before/OAC">
			<xsl:if test="count(key('CurrentOAC', @diffgr:id)) = 0">
				<xsl:call-template name="OutputOAC">
					<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
				</xsl:call-template>
			</xsl:if>
		</xsl:for-each>
	</ROWDATA>
	</DATAPACKET>
</xsl:template>
</xsl:stylesheet>
