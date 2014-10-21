<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1" xmlns:msxsl="urn:schemas-microsoft-com:xslt" version="1.0">

<xsl:output method="xml" />

<xsl:variable name="ROWSTATE_BEFORE">1</xsl:variable>
<xsl:variable name="ROWSTATE_DELETED">2</xsl:variable>
<xsl:variable name="ROWSTATE_NEW">4</xsl:variable>
<xsl:variable name="ROWSTATE_DETACHED">6</xsl:variable> <!-- This one we do not use -->
<xsl:variable name="ROWSTATE_AFTER">8</xsl:variable>
<xsl:variable name="ROWSTATE_UNCHANGED">64</xsl:variable>

<xsl:key name="OriginalUCC" match="//diffgr:before/UCC" use="@diffgr:id" />
<xsl:key name="CurrentUCC" match="//UCCDataSet/UCC" use="@diffgr:id" />
<xsl:key name="OriginalVW_PBSUCCDETAIL" match="//diffgr:before/VW_PBSUCCDETAIL" use="@diffgr:id" />
<xsl:key name="CurrentVW_PBSUCCDETAIL" match="//UCCDataSet/VW_PBSUCCDETAIL" use="@diffgr:id" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<METADATA><FIELDS><FIELD attrname="PUCC_ID" fieldtype="i4" required="true"><PARAM Name="PROVFLAGS" Value="7" Type="i4" Roundtrip="True" /><PARAM Name="ORIGIN" Value="PBSUCC.PUCC_ID" Roundtrip="True" /></FIELD><FIELD attrname="PUCC_CONTACT" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="PBSUCC.PUCC_CONTACT" Roundtrip="True" /></FIELD><FIELD attrname="PUCC_PHONE" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="PBSUCC.PUCC_PHONE" Roundtrip="True" /></FIELD><FIELD attrname="PUCC_EMAIL" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="PBSUCC.PUCC_EMAIL" Roundtrip="True" /></FIELD><FIELD attrname="PUCC_FAX" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="PBSUCC.PUCC_FAX" Roundtrip="True" /></FIELD><FIELD attrname="PUCC_DEA_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="PBSUCC.PUCC_DEA_ID" Roundtrip="True" /></FIELD><FIELD attrname="PUCC_FORMSTATUS" fieldtype="i2"><PARAM Name="ORIGIN" Value="PBSUCC.PUCC_FORMSTATUS" Roundtrip="True" /></FIELD><FIELD attrname="PUCC_OPERATINGUNIT" fieldtype="i4"><PARAM Name="ORIGIN" Value="PBSUCC.PUCC_OPERATINGUNIT" Roundtrip="True" /></FIELD><FIELD attrname="PUCC_OPERATINGGROUP" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="PBSUCC.PUCC_OPERATINGGROUP" Roundtrip="True" /></FIELD><FIELD attrname="PREMIEREDATE" fieldtype="dateTime" readonly="true" /><FIELD attrname="VW_PBSUCCDETAIL" fieldtype="nested"><FIELDS><FIELD attrname="PUCCD_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_PBSUCCDETAIL.PUCCD_ID" Roundtrip="True" /></FIELD><FIELD attrname="PUCCD_UCC_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_PBSUCCDETAIL.PUCCD_UCC_ID" Roundtrip="True" /></FIELD><FIELD attrname="PUCCD_BED" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_PBSUCCDETAIL.PUCCD_BED" Roundtrip="True" /></FIELD><FIELD attrname="PUCCD_POSITION" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_PBSUCCDETAIL.PUCCD_POSITION" Roundtrip="True" /></FIELD><FIELD attrname="ASS_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_PBSUCCDETAIL.ASS_ID" Roundtrip="True" /></FIELD><FIELD attrname="ASS_TITLE" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="VW_PBSUCCDETAIL.ASS_TITLE" Roundtrip="True" /></FIELD><FIELD attrname="ASS_DURATIONSCHEDULED" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_PBSUCCDETAIL.ASS_DURATIONSCHEDULED" Roundtrip="True" /></FIELD><FIELD attrname="ASS_VIDEOTEXT" fieldtype="bin.hex" SUBTYPE="Text" WIDTH="8"><PARAM Name="ORIGIN" Value="VW_PBSUCCDETAIL.ASS_VIDEOTEXT" Roundtrip="True" /></FIELD><FIELD attrname="ASS_AUDIOTEXT" fieldtype="bin.hex" SUBTYPE="Text" WIDTH="8"><PARAM Name="ORIGIN" Value="VW_PBSUCCDETAIL.ASS_AUDIOTEXT" Roundtrip="True" /></FIELD><FIELD attrname="ASS_COM_ID_ADVERTISER" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_PBSUCCDETAIL.ASS_COM_ID_ADVERTISER" Roundtrip="True" /></FIELD><FIELD attrname="ASS_ISPBSAPPROVED" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_PBSUCCDETAIL.ASS_ISPBSAPPROVED" Roundtrip="True" /></FIELD><FIELD attrname="ARW_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_PBSUCCDETAIL.ARW_ID" Roundtrip="True" /></FIELD><FIELD attrname="ARW_DATEAVAILABLEFROM" fieldtype="dateTime"><PARAM Name="ORIGIN" Value="VW_PBSUCCDETAIL.ARW_DATEAVAILABLEFROM" Roundtrip="True" /></FIELD><FIELD attrname="ARW_DATEAVAILABLETO" fieldtype="dateTime"><PARAM Name="ORIGIN" Value="VW_PBSUCCDETAIL.ARW_DATEAVAILABLETO" Roundtrip="True" /></FIELD></FIELDS><PARAMS DATASET_DELTA="TRUE" /></FIELD></FIELDS><PARAMS DATASET_DELTA="TRUE" PRIMARY_KEY="1" /></METADATA>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template name="OutputVW_PBSUCCDETAIL">
<xsl:param name="Original" />
<xsl:param name="RowState"><xsl:value-of select="$ROWSTATE_UNCHANGED" /></xsl:param>
	<ROWVW_PBSUCCDETAIL>
		<xsl:attribute name="RowState"><xsl:value-of select="$RowState" /></xsl:attribute>
		<xsl:choose>
			<xsl:when test="$RowState = $ROWSTATE_AFTER">
				<xsl:if test="(not(msxsl:node-set($Original)/PUCCD_ID) and PUCCD_ID) or (msxsl:node-set($Original)/PUCCD_ID != PUCCD_ID)">
					<xsl:attribute name="PUCCD_ID"><xsl:value-of select="PUCCD_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PUCCD_ID and not(PUCCD_ID)">
					<xsl:attribute name="PUCCD_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PUCCD_UCC_ID) and PUCCD_UCC_ID) or (msxsl:node-set($Original)/PUCCD_UCC_ID != PUCCD_UCC_ID)">
					<xsl:attribute name="PUCCD_UCC_ID"><xsl:value-of select="PUCCD_UCC_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PUCCD_UCC_ID and not(PUCCD_UCC_ID)">
					<xsl:attribute name="PUCCD_UCC_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PUCCD_BED) and PUCCD_BED) or (msxsl:node-set($Original)/PUCCD_BED != PUCCD_BED)">
					<xsl:attribute name="PUCCD_BED"><xsl:value-of select="PUCCD_BED" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PUCCD_BED and not(PUCCD_BED)">
					<xsl:attribute name="PUCCD_BED"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PUCCD_POSITION) and PUCCD_POSITION) or (msxsl:node-set($Original)/PUCCD_POSITION != PUCCD_POSITION)">
					<xsl:attribute name="PUCCD_POSITION"><xsl:value-of select="PUCCD_POSITION" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PUCCD_POSITION and not(PUCCD_POSITION)">
					<xsl:attribute name="PUCCD_POSITION"></xsl:attribute>
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
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_DURATIONSCHEDULED) and ASS_DURATIONSCHEDULED) or (msxsl:node-set($Original)/ASS_DURATIONSCHEDULED != ASS_DURATIONSCHEDULED)">
					<xsl:attribute name="ASS_DURATIONSCHEDULED"><xsl:value-of select="ASS_DURATIONSCHEDULED" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_DURATIONSCHEDULED and not(ASS_DURATIONSCHEDULED)">
					<xsl:attribute name="ASS_DURATIONSCHEDULED"></xsl:attribute>
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
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_COM_ID_ADVERTISER) and ASS_COM_ID_ADVERTISER) or (msxsl:node-set($Original)/ASS_COM_ID_ADVERTISER != ASS_COM_ID_ADVERTISER)">
					<xsl:attribute name="ASS_COM_ID_ADVERTISER"><xsl:value-of select="ASS_COM_ID_ADVERTISER" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_COM_ID_ADVERTISER and not(ASS_COM_ID_ADVERTISER)">
					<xsl:attribute name="ASS_COM_ID_ADVERTISER"></xsl:attribute>
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
				<xsl:attribute name="PUCCD_ID"><xsl:value-of select="PUCCD_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PUCCD_ID and not(PUCCD_ID)">
					<xsl:attribute name="PUCCD_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PUCCD_UCC_ID"><xsl:value-of select="PUCCD_UCC_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PUCCD_UCC_ID and not(PUCCD_UCC_ID)">
					<xsl:attribute name="PUCCD_UCC_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PUCCD_BED"><xsl:value-of select="PUCCD_BED" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PUCCD_BED and not(PUCCD_BED)">
					<xsl:attribute name="PUCCD_BED"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PUCCD_POSITION"><xsl:value-of select="PUCCD_POSITION" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PUCCD_POSITION and not(PUCCD_POSITION)">
					<xsl:attribute name="PUCCD_POSITION"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ASS_ID"><xsl:value-of select="ASS_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_ID and not(ASS_ID)">
					<xsl:attribute name="ASS_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ASS_TITLE"><xsl:value-of select="ASS_TITLE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_TITLE and not(ASS_TITLE)">
					<xsl:attribute name="ASS_TITLE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ASS_DURATIONSCHEDULED"><xsl:value-of select="ASS_DURATIONSCHEDULED" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_DURATIONSCHEDULED and not(ASS_DURATIONSCHEDULED)">
					<xsl:attribute name="ASS_DURATIONSCHEDULED"></xsl:attribute>
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
				<xsl:attribute name="ASS_COM_ID_ADVERTISER"><xsl:value-of select="ASS_COM_ID_ADVERTISER" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_COM_ID_ADVERTISER and not(ASS_COM_ID_ADVERTISER)">
					<xsl:attribute name="ASS_COM_ID_ADVERTISER"></xsl:attribute>
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

	</ROWVW_PBSUCCDETAIL>
</xsl:template>

<xsl:template name="OutputUCC">
<xsl:param name="Original" />
<xsl:param name="RowState"><xsl:value-of select="$ROWSTATE_UNCHANGED" /></xsl:param>
	<ROW>
		<xsl:attribute name="RowState"><xsl:value-of select="$RowState" /></xsl:attribute>
		<xsl:choose>
			<xsl:when test="$RowState = $ROWSTATE_AFTER">
				<xsl:if test="(not(msxsl:node-set($Original)/PUCC_ID) and PUCC_ID) or (msxsl:node-set($Original)/PUCC_ID != PUCC_ID)">
					<xsl:attribute name="PUCC_ID"><xsl:value-of select="PUCC_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PUCC_ID and not(PUCC_ID)">
					<xsl:attribute name="PUCC_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PUCC_CONTACT) and PUCC_CONTACT) or (msxsl:node-set($Original)/PUCC_CONTACT != PUCC_CONTACT)">
					<xsl:attribute name="PUCC_CONTACT"><xsl:value-of select="PUCC_CONTACT" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PUCC_CONTACT and not(PUCC_CONTACT)">
					<xsl:attribute name="PUCC_CONTACT"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PUCC_PHONE) and PUCC_PHONE) or (msxsl:node-set($Original)/PUCC_PHONE != PUCC_PHONE)">
					<xsl:attribute name="PUCC_PHONE"><xsl:value-of select="PUCC_PHONE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PUCC_PHONE and not(PUCC_PHONE)">
					<xsl:attribute name="PUCC_PHONE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PUCC_EMAIL) and PUCC_EMAIL) or (msxsl:node-set($Original)/PUCC_EMAIL != PUCC_EMAIL)">
					<xsl:attribute name="PUCC_EMAIL"><xsl:value-of select="PUCC_EMAIL" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PUCC_EMAIL and not(PUCC_EMAIL)">
					<xsl:attribute name="PUCC_EMAIL"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PUCC_FAX) and PUCC_FAX) or (msxsl:node-set($Original)/PUCC_FAX != PUCC_FAX)">
					<xsl:attribute name="PUCC_FAX"><xsl:value-of select="PUCC_FAX" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PUCC_FAX and not(PUCC_FAX)">
					<xsl:attribute name="PUCC_FAX"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PUCC_DEA_ID) and PUCC_DEA_ID) or (msxsl:node-set($Original)/PUCC_DEA_ID != PUCC_DEA_ID)">
					<xsl:attribute name="PUCC_DEA_ID"><xsl:value-of select="PUCC_DEA_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PUCC_DEA_ID and not(PUCC_DEA_ID)">
					<xsl:attribute name="PUCC_DEA_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PUCC_FORMSTATUS) and PUCC_FORMSTATUS) or (msxsl:node-set($Original)/PUCC_FORMSTATUS != PUCC_FORMSTATUS)">
					<xsl:attribute name="PUCC_FORMSTATUS"><xsl:value-of select="PUCC_FORMSTATUS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PUCC_FORMSTATUS and not(PUCC_FORMSTATUS)">
					<xsl:attribute name="PUCC_FORMSTATUS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PUCC_OPERATINGUNIT) and PUCC_OPERATINGUNIT) or (msxsl:node-set($Original)/PUCC_OPERATINGUNIT != PUCC_OPERATINGUNIT)">
					<xsl:attribute name="PUCC_OPERATINGUNIT"><xsl:value-of select="PUCC_OPERATINGUNIT" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PUCC_OPERATINGUNIT and not(PUCC_OPERATINGUNIT)">
					<xsl:attribute name="PUCC_OPERATINGUNIT"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PUCC_OPERATINGGROUP) and PUCC_OPERATINGGROUP) or (msxsl:node-set($Original)/PUCC_OPERATINGGROUP != PUCC_OPERATINGGROUP)">
					<xsl:attribute name="PUCC_OPERATINGGROUP"><xsl:value-of select="PUCC_OPERATINGGROUP" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PUCC_OPERATINGGROUP and not(PUCC_OPERATINGGROUP)">
					<xsl:attribute name="PUCC_OPERATINGGROUP"></xsl:attribute>
				</xsl:if>
			</xsl:when>
			<xsl:otherwise>
				<xsl:attribute name="PUCC_ID"><xsl:value-of select="PUCC_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PUCC_ID and not(PUCC_ID)">
					<xsl:attribute name="PUCC_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PUCC_CONTACT"><xsl:value-of select="PUCC_CONTACT" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PUCC_CONTACT and not(PUCC_CONTACT)">
					<xsl:attribute name="PUCC_CONTACT"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PUCC_PHONE"><xsl:value-of select="PUCC_PHONE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PUCC_PHONE and not(PUCC_PHONE)">
					<xsl:attribute name="PUCC_PHONE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PUCC_EMAIL"><xsl:value-of select="PUCC_EMAIL" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PUCC_EMAIL and not(PUCC_EMAIL)">
					<xsl:attribute name="PUCC_EMAIL"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PUCC_FAX"><xsl:value-of select="PUCC_FAX" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PUCC_FAX and not(PUCC_FAX)">
					<xsl:attribute name="PUCC_FAX"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PUCC_DEA_ID"><xsl:value-of select="PUCC_DEA_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PUCC_DEA_ID and not(PUCC_DEA_ID)">
					<xsl:attribute name="PUCC_DEA_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PUCC_FORMSTATUS"><xsl:value-of select="PUCC_FORMSTATUS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PUCC_FORMSTATUS and not(PUCC_FORMSTATUS)">
					<xsl:attribute name="PUCC_FORMSTATUS"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PUCC_OPERATINGUNIT"><xsl:value-of select="PUCC_OPERATINGUNIT" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PUCC_OPERATINGUNIT and not(PUCC_OPERATINGUNIT)">
					<xsl:attribute name="PUCC_OPERATINGUNIT"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PUCC_OPERATINGGROUP"><xsl:value-of select="PUCC_OPERATINGGROUP" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PUCC_OPERATINGGROUP and not(PUCC_OPERATINGGROUP)">
					<xsl:attribute name="PUCC_OPERATINGGROUP"></xsl:attribute>
				</xsl:if>
			</xsl:otherwise>
		</xsl:choose>

		<VW_PBSUCCDETAIL>
			<xsl:if test="($RowState=$ROWSTATE_NEW) or ($RowState=$ROWSTATE_BEFORE) or ($RowState=$ROWSTATE_UNCHANGED)">
				<xsl:for-each select="//UCCDataSet/VW_PBSUCCDETAIL">
					<xsl:choose>
						<xsl:when test="@diffgr:hasChanges='inserted'">
							<xsl:call-template name="OutputVW_PBSUCCDETAIL">
								<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
							</xsl:call-template>
						</xsl:when>

						<xsl:when test="@diffgr:hasChanges='modified'">
							<xsl:for-each select="key('OriginalVW_PBSUCCDETAIL', @diffgr:id)">
								<xsl:call-template name="OutputVW_PBSUCCDETAIL">
									<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
								</xsl:call-template>
							</xsl:for-each>
							<xsl:call-template name="OutputVW_PBSUCCDETAIL">
								<xsl:with-param name="Original" select="key('OriginalVW_PBSUCCDETAIL', @diffgr:id)" />
								<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
							</xsl:call-template>
						</xsl:when>
					</xsl:choose>
				</xsl:for-each>
				<xsl:for-each select="//diffgr:before/VW_PBSUCCDETAIL">
					<xsl:if test="count(key('CurrentVW_PBSUCCDETAIL', @diffgr:id)) = 0">
						<xsl:call-template name="OutputVW_PBSUCCDETAIL">
							<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
						</xsl:call-template>
					</xsl:if>
				</xsl:for-each>
			</xsl:if>
		</VW_PBSUCCDETAIL>
	</ROW>
</xsl:template>

<xsl:template match="/">
	<DATAPACKET Version="2.0">
	<xsl:call-template name="Output_Schema" />
	<ROWDATA>
		<xsl:for-each select="//UCCDataSet/UCC">
			<xsl:choose>
				<xsl:when test="@diffgr:hasChanges='inserted'">
					<xsl:call-template name="OutputUCC">
						<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
					</xsl:call-template>
				</xsl:when>

				<xsl:when test="@diffgr:hasChanges='modified'">
					<xsl:for-each select="key('OriginalUCC', @diffgr:id)">
						<xsl:call-template name="OutputUCC">
							<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
						</xsl:call-template>
					</xsl:for-each>
					<xsl:call-template name="OutputUCC">
						<xsl:with-param name="Original" select="key('OriginalUCC', @diffgr:id)" />
						<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
					</xsl:call-template>
				</xsl:when>

				<xsl:otherwise>
					<xsl:call-template name="OutputUCC">
						<xsl:with-param name="RowState" select="$ROWSTATE_UNCHANGED" />
					</xsl:call-template>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:for-each>
		<xsl:for-each select="//diffgr:before/UCC">
			<xsl:if test="count(key('CurrentUCC', @diffgr:id)) = 0">
				<xsl:call-template name="OutputUCC">
					<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
				</xsl:call-template>
			</xsl:if>
		</xsl:for-each>
	</ROWDATA>
	</DATAPACKET>
</xsl:template>
</xsl:stylesheet>
