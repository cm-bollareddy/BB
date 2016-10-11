<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1" xmlns:msxsl="urn:schemas-microsoft-com:xslt" version="1.0">

<xsl:output method="xml" />

<xsl:variable name="ROWSTATE_BEFORE">1</xsl:variable>
<xsl:variable name="ROWSTATE_DELETED">2</xsl:variable>
<xsl:variable name="ROWSTATE_NEW">4</xsl:variable>
<xsl:variable name="ROWSTATE_DETACHED">6</xsl:variable> <!-- This one we do not use -->
<xsl:variable name="ROWSTATE_AFTER">8</xsl:variable>
<xsl:variable name="ROWSTATE_UNCHANGED">64</xsl:variable>

<xsl:key name="OriginalIWT" match="//diffgr:before/IWT" use="@diffgr:id" />
<xsl:key name="CurrentIWT" match="//IWTDataSet/IWT" use="@diffgr:id" />
<xsl:key name="OriginalPBSIWTDETAIL" match="//diffgr:before/PBSIWTDETAIL" use="@diffgr:id" />
<xsl:key name="CurrentPBSIWTDETAIL" match="//IWTDataSet/PBSIWTDETAIL" use="@diffgr:id" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<METADATA><FIELDS><FIELD attrname="PIWT_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_PBSIWT.PIWT_ID" Roundtrip="True" /></FIELD><FIELD attrname="PIWT_CONTACT" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="VW_PBSIWT.PIWT_CONTACT" Roundtrip="True" /></FIELD><FIELD attrname="PIWT_PHONE" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="VW_PBSIWT.PIWT_PHONE" Roundtrip="True" /></FIELD><FIELD attrname="PIWT_EMAIL" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="VW_PBSIWT.PIWT_EMAIL" Roundtrip="True" /></FIELD><FIELD attrname="PIWT_ETVDATA" fieldtype="bin.hex" SUBTYPE="Text" WIDTH="8"><PARAM Name="ORIGIN" Value="VW_PBSIWT.PIWT_ETVDATA" Roundtrip="True" /></FIELD><FIELD attrname="PIWT_PBSOPERATINGUNIT" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_PBSIWT.PIWT_PBSOPERATINGUNIT" Roundtrip="True" /></FIELD><FIELD attrname="PIWT_PBSOPERATINGGROUP" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="VW_PBSIWT.PIWT_PBSOPERATINGGROUP" Roundtrip="True" /></FIELD><FIELD attrname="PIWT_DEA_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_PBSIWT.PIWT_DEA_ID" Roundtrip="True" /></FIELD><FIELD attrname="PIWT_FORMSTATUS" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_PBSIWT.PIWT_FORMSTATUS" Roundtrip="True" /></FIELD><FIELD attrname="PREMIEREDATE" fieldtype="dateTime" readonly="true" /><FIELD attrname="ASS_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_PBSIWT.ASS_ID" Roundtrip="True" /></FIELD><FIELD attrname="ASS_TITLE" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="VW_PBSIWT.ASS_TITLE" Roundtrip="True" /></FIELD><FIELD attrname="ASS_DURATIONSCHEDULED" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_PBSIWT.ASS_DURATIONSCHEDULED" Roundtrip="True" /></FIELD><FIELD attrname="ASS_VIDEOTEXT" fieldtype="bin.hex" SUBTYPE="Text" WIDTH="8"><PARAM Name="ORIGIN" Value="VW_PBSIWT.ASS_VIDEOTEXT" Roundtrip="True" /></FIELD><FIELD attrname="ASS_AUDIOTEXT" fieldtype="bin.hex" SUBTYPE="Text" WIDTH="8"><PARAM Name="ORIGIN" Value="VW_PBSIWT.ASS_AUDIOTEXT" Roundtrip="True" /></FIELD><FIELD attrname="ASS_ISPBSAPPROVED" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_PBSIWT.ASS_ISPBSAPPROVED" Roundtrip="True" /></FIELD><FIELD attrname="PBSIWTDETAIL" fieldtype="nested"><FIELDS><FIELD attrname="PIWTD_ID" fieldtype="i4" required="true"><PARAM Name="PROVFLAGS" Value="7" Type="i4" Roundtrip="True" /><PARAM Name="ORIGIN" Value="PBSIWTDETAIL.PIWTD_ID" Roundtrip="True" /></FIELD><FIELD attrname="PIWTD_PIWT_ID" fieldtype="i4" required="true"><PARAM Name="ORIGIN" Value="PBSIWTDETAIL.PIWTD_PIWT_ID" Roundtrip="True" /></FIELD><FIELD attrname="PIWTD_INFO" fieldtype="string" WIDTH="252"><PARAM Name="ORIGIN" Value="PBSIWTDETAIL.PIWTD_INFO" Roundtrip="True" /></FIELD><FIELD attrname="PIWTD_URL" fieldtype="string" WIDTH="252"><PARAM Name="ORIGIN" Value="PBSIWTDETAIL.PIWTD_URL" Roundtrip="True" /></FIELD></FIELDS><PARAMS DATASET_DELTA="TRUE" PRIMARY_KEY="1" /></FIELD></FIELDS><PARAMS DATASET_DELTA="TRUE" /></METADATA>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template name="OutputPBSIWTDETAIL">
<xsl:param name="Original" />
<xsl:param name="RowState"><xsl:value-of select="$ROWSTATE_UNCHANGED" /></xsl:param>
	<ROWPBSIWTDETAIL>
		<xsl:attribute name="RowState"><xsl:value-of select="$RowState" /></xsl:attribute>
		<xsl:choose>
			<xsl:when test="$RowState = $ROWSTATE_AFTER">
				<xsl:if test="(not(msxsl:node-set($Original)/PIWTD_ID) and PIWTD_ID) or (msxsl:node-set($Original)/PIWTD_ID != PIWTD_ID)">
					<xsl:attribute name="PIWTD_ID"><xsl:value-of select="PIWTD_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PIWTD_ID and not(PIWTD_ID)">
					<xsl:attribute name="PIWTD_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PIWTD_PIWT_ID) and PIWTD_PIWT_ID) or (msxsl:node-set($Original)/PIWTD_PIWT_ID != PIWTD_PIWT_ID)">
					<xsl:attribute name="PIWTD_PIWT_ID"><xsl:value-of select="PIWTD_PIWT_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PIWTD_PIWT_ID and not(PIWTD_PIWT_ID)">
					<xsl:attribute name="PIWTD_PIWT_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PIWTD_INFO) and PIWTD_INFO) or (msxsl:node-set($Original)/PIWTD_INFO != PIWTD_INFO)">
					<xsl:attribute name="PIWTD_INFO"><xsl:value-of select="PIWTD_INFO" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PIWTD_INFO and not(PIWTD_INFO)">
					<xsl:attribute name="PIWTD_INFO"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PIWTD_URL) and PIWTD_URL) or (msxsl:node-set($Original)/PIWTD_URL != PIWTD_URL)">
					<xsl:attribute name="PIWTD_URL"><xsl:value-of select="PIWTD_URL" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PIWTD_URL and not(PIWTD_URL)">
					<xsl:attribute name="PIWTD_URL"></xsl:attribute>
				</xsl:if>
			</xsl:when>
			<xsl:otherwise>
				<xsl:attribute name="PIWTD_ID"><xsl:value-of select="PIWTD_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PIWTD_ID and not(PIWTD_ID)">
					<xsl:attribute name="PIWTD_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PIWTD_PIWT_ID"><xsl:value-of select="PIWTD_PIWT_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PIWTD_PIWT_ID and not(PIWTD_PIWT_ID)">
					<xsl:attribute name="PIWTD_PIWT_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PIWTD_INFO"><xsl:value-of select="PIWTD_INFO" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PIWTD_INFO and not(PIWTD_INFO)">
					<xsl:attribute name="PIWTD_INFO"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PIWTD_URL"><xsl:value-of select="PIWTD_URL" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PIWTD_URL and not(PIWTD_URL)">
					<xsl:attribute name="PIWTD_URL"></xsl:attribute>
				</xsl:if>
			</xsl:otherwise>
		</xsl:choose>

	</ROWPBSIWTDETAIL>
</xsl:template>

<xsl:template name="OutputIWT">
<xsl:param name="Original" />
<xsl:param name="RowState"><xsl:value-of select="$ROWSTATE_UNCHANGED" /></xsl:param>
	<ROW>
		<xsl:attribute name="RowState"><xsl:value-of select="$RowState" /></xsl:attribute>
		<xsl:choose>
			<xsl:when test="$RowState = $ROWSTATE_AFTER">
				<xsl:if test="(not(msxsl:node-set($Original)/PIWT_ID) and PIWT_ID) or (msxsl:node-set($Original)/PIWT_ID != PIWT_ID)">
					<xsl:attribute name="PIWT_ID"><xsl:value-of select="PIWT_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PIWT_ID and not(PIWT_ID)">
					<xsl:attribute name="PIWT_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PIWT_CONTACT) and PIWT_CONTACT) or (msxsl:node-set($Original)/PIWT_CONTACT != PIWT_CONTACT)">
					<xsl:attribute name="PIWT_CONTACT"><xsl:value-of select="PIWT_CONTACT" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PIWT_CONTACT and not(PIWT_CONTACT)">
					<xsl:attribute name="PIWT_CONTACT"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PIWT_PHONE) and PIWT_PHONE) or (msxsl:node-set($Original)/PIWT_PHONE != PIWT_PHONE)">
					<xsl:attribute name="PIWT_PHONE"><xsl:value-of select="PIWT_PHONE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PIWT_PHONE and not(PIWT_PHONE)">
					<xsl:attribute name="PIWT_PHONE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PIWT_EMAIL) and PIWT_EMAIL) or (msxsl:node-set($Original)/PIWT_EMAIL != PIWT_EMAIL)">
					<xsl:attribute name="PIWT_EMAIL"><xsl:value-of select="PIWT_EMAIL" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PIWT_EMAIL and not(PIWT_EMAIL)">
					<xsl:attribute name="PIWT_EMAIL"></xsl:attribute>
				</xsl:if>
				<xsl:if test="PIWT_ETVDATA != '' and (not(msxsl:node-set($Original)/PIWT_ETVDATA) and PIWT_ETVDATA) or (msxsl:node-set($Original)/PIWT_ETVDATA != PIWT_ETVDATA)">
					<xsl:attribute name="PIWT_ETVDATA"><xsl:value-of select="PIWT_ETVDATA" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PIWT_ETVDATA and not(PIWT_ETVDATA)">
					<xsl:attribute name="PIWT_ETVDATA"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PIWT_PBSOPERATINGUNIT) and PIWT_PBSOPERATINGUNIT) or (msxsl:node-set($Original)/PIWT_PBSOPERATINGUNIT != PIWT_PBSOPERATINGUNIT)">
					<xsl:attribute name="PIWT_PBSOPERATINGUNIT"><xsl:value-of select="PIWT_PBSOPERATINGUNIT" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PIWT_PBSOPERATINGUNIT and not(PIWT_PBSOPERATINGUNIT)">
					<xsl:attribute name="PIWT_PBSOPERATINGUNIT"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PIWT_PBSOPERATINGGROUP) and PIWT_PBSOPERATINGGROUP) or (msxsl:node-set($Original)/PIWT_PBSOPERATINGGROUP != PIWT_PBSOPERATINGGROUP)">
					<xsl:attribute name="PIWT_PBSOPERATINGGROUP"><xsl:value-of select="PIWT_PBSOPERATINGGROUP" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PIWT_PBSOPERATINGGROUP and not(PIWT_PBSOPERATINGGROUP)">
					<xsl:attribute name="PIWT_PBSOPERATINGGROUP"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PIWT_DEA_ID) and PIWT_DEA_ID) or (msxsl:node-set($Original)/PIWT_DEA_ID != PIWT_DEA_ID)">
					<xsl:attribute name="PIWT_DEA_ID"><xsl:value-of select="PIWT_DEA_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PIWT_DEA_ID and not(PIWT_DEA_ID)">
					<xsl:attribute name="PIWT_DEA_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PIWT_FORMSTATUS) and PIWT_FORMSTATUS) or (msxsl:node-set($Original)/PIWT_FORMSTATUS != PIWT_FORMSTATUS)">
					<xsl:attribute name="PIWT_FORMSTATUS"><xsl:value-of select="PIWT_FORMSTATUS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PIWT_FORMSTATUS and not(PIWT_FORMSTATUS)">
					<xsl:attribute name="PIWT_FORMSTATUS"></xsl:attribute>
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
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_ISPBSAPPROVED) and ASS_ISPBSAPPROVED) or (msxsl:node-set($Original)/ASS_ISPBSAPPROVED != ASS_ISPBSAPPROVED)">
					<xsl:attribute name="ASS_ISPBSAPPROVED"><xsl:value-of select="ASS_ISPBSAPPROVED" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_ISPBSAPPROVED and not(ASS_ISPBSAPPROVED)">
					<xsl:attribute name="ASS_ISPBSAPPROVED"></xsl:attribute>
				</xsl:if>
			</xsl:when>
			<xsl:otherwise>
				<xsl:attribute name="PIWT_ID"><xsl:value-of select="PIWT_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PIWT_ID and not(PIWT_ID)">
					<xsl:attribute name="PIWT_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PIWT_CONTACT"><xsl:value-of select="PIWT_CONTACT" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PIWT_CONTACT and not(PIWT_CONTACT)">
					<xsl:attribute name="PIWT_CONTACT"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PIWT_PHONE"><xsl:value-of select="PIWT_PHONE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PIWT_PHONE and not(PIWT_PHONE)">
					<xsl:attribute name="PIWT_PHONE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PIWT_EMAIL"><xsl:value-of select="PIWT_EMAIL" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PIWT_EMAIL and not(PIWT_EMAIL)">
					<xsl:attribute name="PIWT_EMAIL"></xsl:attribute>
				</xsl:if>
				<xsl:if test="PIWT_ETVDATA != ''">
					<xsl:attribute name="PIWT_ETVDATA"><xsl:value-of select="PIWT_ETVDATA" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PIWT_ETVDATA and not(PIWT_ETVDATA)">
					<xsl:attribute name="PIWT_ETVDATA"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PIWT_PBSOPERATINGUNIT"><xsl:value-of select="PIWT_PBSOPERATINGUNIT" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PIWT_PBSOPERATINGUNIT and not(PIWT_PBSOPERATINGUNIT)">
					<xsl:attribute name="PIWT_PBSOPERATINGUNIT"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PIWT_PBSOPERATINGGROUP"><xsl:value-of select="PIWT_PBSOPERATINGGROUP" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PIWT_PBSOPERATINGGROUP and not(PIWT_PBSOPERATINGGROUP)">
					<xsl:attribute name="PIWT_PBSOPERATINGGROUP"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PIWT_DEA_ID"><xsl:value-of select="PIWT_DEA_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PIWT_DEA_ID and not(PIWT_DEA_ID)">
					<xsl:attribute name="PIWT_DEA_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PIWT_FORMSTATUS"><xsl:value-of select="PIWT_FORMSTATUS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PIWT_FORMSTATUS and not(PIWT_FORMSTATUS)">
					<xsl:attribute name="PIWT_FORMSTATUS"></xsl:attribute>
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
				<xsl:attribute name="ASS_ISPBSAPPROVED"><xsl:value-of select="ASS_ISPBSAPPROVED" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_ISPBSAPPROVED and not(ASS_ISPBSAPPROVED)">
					<xsl:attribute name="ASS_ISPBSAPPROVED"></xsl:attribute>
				</xsl:if>
			</xsl:otherwise>
		</xsl:choose>

		<PBSIWTDETAIL>
			<xsl:if test="($RowState=$ROWSTATE_NEW) or ($RowState=$ROWSTATE_BEFORE) or ($RowState=$ROWSTATE_UNCHANGED)">
				<xsl:for-each select="//IWTDataSet/PBSIWTDETAIL">
					<xsl:choose>
						<xsl:when test="@diffgr:hasChanges='inserted'">
							<xsl:call-template name="OutputPBSIWTDETAIL">
								<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
							</xsl:call-template>
						</xsl:when>

						<xsl:when test="@diffgr:hasChanges='modified'">
							<xsl:for-each select="key('OriginalPBSIWTDETAIL', @diffgr:id)">
								<xsl:call-template name="OutputPBSIWTDETAIL">
									<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
								</xsl:call-template>
							</xsl:for-each>
							<xsl:call-template name="OutputPBSIWTDETAIL">
								<xsl:with-param name="Original" select="key('OriginalPBSIWTDETAIL', @diffgr:id)" />
								<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
							</xsl:call-template>
						</xsl:when>
					</xsl:choose>
				</xsl:for-each>
				<xsl:for-each select="//diffgr:before/PBSIWTDETAIL">
					<xsl:if test="count(key('CurrentPBSIWTDETAIL', @diffgr:id)) = 0">
						<xsl:call-template name="OutputPBSIWTDETAIL">
							<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
						</xsl:call-template>
					</xsl:if>
				</xsl:for-each>
			</xsl:if>
		</PBSIWTDETAIL>
	</ROW>
</xsl:template>

<xsl:template match="/">
	<DATAPACKET Version="2.0">
	<xsl:call-template name="Output_Schema" />
	<ROWDATA>
		<xsl:for-each select="//IWTDataSet/IWT">
			<xsl:choose>
				<xsl:when test="@diffgr:hasChanges='inserted'">
					<xsl:call-template name="OutputIWT">
						<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
					</xsl:call-template>
				</xsl:when>

				<xsl:when test="@diffgr:hasChanges='modified'">
					<xsl:for-each select="key('OriginalIWT', @diffgr:id)">
						<xsl:call-template name="OutputIWT">
							<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
						</xsl:call-template>
					</xsl:for-each>
					<xsl:call-template name="OutputIWT">
						<xsl:with-param name="Original" select="key('OriginalIWT', @diffgr:id)" />
						<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
					</xsl:call-template>
				</xsl:when>

				<xsl:otherwise>
					<xsl:call-template name="OutputIWT">
						<xsl:with-param name="RowState" select="$ROWSTATE_UNCHANGED" />
					</xsl:call-template>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:for-each>
		<xsl:for-each select="//diffgr:before/IWT">
			<xsl:if test="count(key('CurrentIWT', @diffgr:id)) = 0">
				<xsl:call-template name="OutputIWT">
					<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
				</xsl:call-template>
			</xsl:if>
		</xsl:for-each>
	</ROWDATA>
	</DATAPACKET>
</xsl:template>
</xsl:stylesheet>
