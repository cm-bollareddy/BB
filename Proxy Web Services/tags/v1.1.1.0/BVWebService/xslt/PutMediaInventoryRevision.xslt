<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1" xmlns:msxsl="urn:schemas-microsoft-com:xslt" version="1.0">

<xsl:output method="xml" />

<xsl:variable name="ROWSTATE_BEFORE">1</xsl:variable>
<xsl:variable name="ROWSTATE_DELETED">2</xsl:variable>
<xsl:variable name="ROWSTATE_NEW">4</xsl:variable>
<xsl:variable name="ROWSTATE_DETACHED">6</xsl:variable> <!-- This one we do not use -->
<xsl:variable name="ROWSTATE_AFTER">8</xsl:variable>
<xsl:variable name="ROWSTATE_UNCHANGED">64</xsl:variable>

<xsl:key name="OriginalMEDIAINVENTORYREVISION" match="//diffgr:before/MEDIAINVENTORYREVISION" use="@diffgr:id" />
<xsl:key name="CurrentMEDIAINVENTORYREVISION" match="//MediaInventoryRevisionDataSet/MEDIAINVENTORYREVISION" use="@diffgr:id" />
<xsl:key name="OriginalMEDIAINVENTORYCUT" match="//diffgr:before/MEDIAINVENTORYCUT" use="@diffgr:id" />
<xsl:key name="CurrentMEDIAINVENTORYCUT" match="//MediaInventoryRevisionDataSet/MEDIAINVENTORYCUT" use="@diffgr:id" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<METADATA><FIELDS><FIELD attrname="MEIR_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_ID" Roundtrip="True" /></FIELD><FIELD attrname="MEI_ASS_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEI_ASS_ID" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_MEI_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_MEI_ID" Roundtrip="True" /></FIELD><FIELD attrname="MEI_NUMBER" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEI_NUMBER" Roundtrip="True" /></FIELD><FIELD attrname="MEI_SLU_ID_STATUS" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEI_SLU_ID_STATUS_API" Roundtrip="True" /></FIELD><FIELD attrname="MEI_ISNOINGEST" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEI_ISNOINGEST" Roundtrip="True" /></FIELD><FIELD attrname="MEI_LASTSUBMITTEDDATE" fieldtype="dateTime"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEI_LASTSUBMITTEDDATE" Roundtrip="True" /></FIELD><FIELD attrname="MEI_PBSOPERATINGUNIT" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEI_PBSOPERATINGUNIT" Roundtrip="True" /></FIELD><FIELD attrname="MEI_PBSOPERATINGGROUP" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEI_PBSOPERATINGGROUP" Roundtrip="True" /></FIELD><FIELD attrname="MEI_MIT_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEI_MIT_ID" Roundtrip="True" /></FIELD><FIELD attrname="MEI_MET_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEI_MET_ID" Roundtrip="True" /></FIELD><FIELD attrname="MEI_ISCOMPLETEPACKAGE" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEI_ISCOMPLETEPACKAGE" Roundtrip="True" /></FIELD><FIELD attrname="MEI_VET_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEI_VET_ID" Roundtrip="True" /></FIELD><FIELD attrname="MEI_ISDROPFRAME" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEI_ISDROPFRAME" Roundtrip="True" /></FIELD><FIELD attrname="MEI_SLU_ID_PBSMEDIASTATUS" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEI_SLU_ID_PBSMEDIASTATUS" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_ISBILLABLE" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_ISBILLABLE" Roundtrip="True" /></FIELD><FIELD attrname="MEI_ISCHANGESALLOWED" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEI_ISCHANGESALLOWED" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_SLU_ID_PBSMEDIASTATUS" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_SLU_ID_PBSMEDIASTATUS" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_SLU_ID_STATUS" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_SLU_ID_STATUS_API" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_ISNOINGEST" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_ISNOINGEST" Roundtrip="True" /></FIELD><FIELD attrname="MEI_NOTE" fieldtype="bin.hex" SUBTYPE="Text" WIDTH="8"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEI_NOTE" Roundtrip="True" /></FIELD><FIELD attrname="MEI_ISHDINGEST" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEI_ISHDINGEST" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_REVISIONNO" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_REVISIONNO" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_MFC_ID_AUDIOTYPE" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_MFC_ID_AUDIOTYPE" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_ISCC" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_ISCC" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_ISDVI" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_ISDVI" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_ISSAP" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_ISSAP" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_SLU_ID_ASPECTRATIO" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_SLU_ID_ASPECTRATIO" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_SLU_ID_HIDEF" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_SLU_ID_HIDEF" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_MEF_ID_AUDIO1" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_MEF_ID_AUDIO1" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_MEF_ID_AUDIO2" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_MEF_ID_AUDIO2" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_MEF_ID_AUDIO3" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_MEF_ID_AUDIO3" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_MEF_ID_AUDIO4" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_MEF_ID_AUDIO4" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_MEF_ID_CAPTION1" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_MEF_ID_CAPTION1" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_MEF_ID_CAPTION2" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_MEF_ID_CAPTION2" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_MEF_ID_CAPTION3" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_MEF_ID_CAPTION3" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_CONTACTMANAGER" fieldtype="string" WIDTH="40"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_CONTACTMANAGER" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_CONTACTMANAGER_PHONE" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_CONTACTMANAGER_PHONE" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_CONTACTMANAGER_EMAIL" fieldtype="string" WIDTH="252"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_CONTACTMANAGER_EMAIL" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_CONTACTTECHNICIAN" fieldtype="string" WIDTH="40"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_CONTACTTECHNICIAN" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_CONTACTTECHNICIAN_PHONE" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_CONTACTTECHNICIAN_PHONE" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_CONTACTTECHNICIAN_EMAIL" fieldtype="string" WIDTH="252"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_CONTACTTECHNICIAN_EMAIL" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_IS_CC_PBSENCODES" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_IS_CC_PBSENCODES" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_CC_PROVIDER" fieldtype="string" WIDTH="40"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_CC_PROVIDER" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_IS_CC_PBSCOORDINATES" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_IS_CC_PBSCOORDINATES" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_PBSCV_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_PBSCV_ID" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_IS_DVI_PBSENCODES" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_IS_DVI_PBSENCODES" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_IS_DVI_PBSCOORDINATES" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_IS_DVI_PBSCOORDINATES" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_IS_SAP_PBSENCODES" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_IS_SAP_PBSENCODES" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_ISREVISIONREQUIRED" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_ISREVISIONREQUIRED" Roundtrip="True" /></FIELD><FIELD attrname="MEI_CLASS" fieldtype="string" SUBTYPE="FixedChar" WIDTH="3"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEI_CLASS" Roundtrip="True" /></FIELD><FIELD attrname="MEI_DESCRIPTION" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEI_DESCRIPTION" Roundtrip="True" /></FIELD><FIELD attrname="MEI_ISPREFEEDONLY" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEI_ISPREFEEDONLY" Roundtrip="True" /></FIELD><FIELD attrname="MEI_ISCONTAINERIZED" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEI_ISCONTAINERIZED" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_PBSBT_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_PBSBT_ID" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_PBSBC_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYREVISION.MEIR_PBSBC_ID" Roundtrip="True" /></FIELD><FIELD attrname="MEDIAINVENTORYCUT" fieldtype="nested"><FIELDS><FIELD attrname="MIC_ID" fieldtype="i4" required="true"><PARAM Name="PROVFLAGS" Value="7" Type="i4" Roundtrip="True" /><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_ID" Roundtrip="True" /></FIELD><FIELD attrname="MIC_MEIR_ID" fieldtype="i4" required="true"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_MEIR_ID" Roundtrip="True" /></FIELD><FIELD attrname="MIC_NUMBER" fieldtype="i2"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_NUMBER" Roundtrip="True" /></FIELD><FIELD attrname="MIC_MICT_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_MICT_ID" Roundtrip="True" /></FIELD><FIELD attrname="MIC_DESCRIPTION" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_DESCRIPTION" Roundtrip="True" /></FIELD><FIELD attrname="MIC_ISREUSABLE" fieldtype="i2"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_ISREUSABLE" Roundtrip="True" /></FIELD><FIELD attrname="MIC_TIMECODEIN" fieldtype="i4"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_TIMECODEIN" Roundtrip="True" /></FIELD><FIELD attrname="MIC_DURATION" fieldtype="i4"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_DURATION" Roundtrip="True" /></FIELD><FIELD attrname="MIC_TIMECODEOUT" fieldtype="i4"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_TIMECODEOUT" Roundtrip="True" /></FIELD><FIELD attrname="MIC_ISVARIABLELENGTH" fieldtype="i2"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_ISVARIABLELENGTH" Roundtrip="True" /></FIELD><FIELD attrname="MIC_DURATIONMINIMUM" fieldtype="i4"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_DURATIONMINIMUM" Roundtrip="True" /></FIELD><FIELD attrname="MIC_ISREPLACEMENTITEM" fieldtype="i2"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_ISREPLACEMENTITEM" Roundtrip="True" /></FIELD><FIELD attrname="MIC_REPLACEMENTNOTE" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_REPLACEMENTNOTE" Roundtrip="True" /></FIELD><FIELD attrname="MIC_ASS_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_ASS_ID" Roundtrip="True" /></FIELD><FIELD attrname="MIC_ASSOCIATEDTITLE" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_ASSOCIATEDTITLE" Roundtrip="True" /></FIELD><FIELD attrname="MIC_NEW_DESC" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_NEW_DESC" Roundtrip="True" /></FIELD><FIELD attrname="MIC_NEW_DATEAVAILABLEFROM" fieldtype="dateTime"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_NEW_DATEAVAILABLEFROM" Roundtrip="True" /></FIELD><FIELD attrname="MIC_NEW_DATEAVAILABLETO" fieldtype="dateTime"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_NEW_DATEAVAILABLETO" Roundtrip="True" /></FIELD><FIELD attrname="ASS_TITLE" fieldtype="string" readonly="true" WIDTH="80" /><FIELD attrname="MIC_MFC_ID_AUDIOTYPE" fieldtype="i4"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_MFC_ID_AUDIOTYPE" Roundtrip="True" /></FIELD><FIELD attrname="MIC_ISCC" fieldtype="i2"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_ISCC" Roundtrip="True" /></FIELD><FIELD attrname="MIC_ISDVI" fieldtype="i2"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_ISDVI" Roundtrip="True" /></FIELD><FIELD attrname="MIC_ISSAP" fieldtype="i2"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_ISSAP" Roundtrip="True" /></FIELD><FIELD attrname="MIC_SLU_ID_ASPECTRATIO" fieldtype="i4"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_SLU_ID_ASPECTRATIO" Roundtrip="True" /></FIELD><FIELD attrname="MIC_SLU_ID_HIDEF" fieldtype="i4"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_SLU_ID_HIDEF" Roundtrip="True" /></FIELD><FIELD attrname="MIC_MEF_ID_AUDIO1" fieldtype="i4"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_MEF_ID_AUDIO1" Roundtrip="True" /></FIELD><FIELD attrname="MIC_MEF_ID_AUDIO2" fieldtype="i4"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_MEF_ID_AUDIO2" Roundtrip="True" /></FIELD><FIELD attrname="MIC_MEF_ID_AUDIO3" fieldtype="i4"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_MEF_ID_AUDIO3" Roundtrip="True" /></FIELD><FIELD attrname="MIC_MEF_ID_AUDIO4" fieldtype="i4"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_MEF_ID_AUDIO4" Roundtrip="True" /></FIELD><FIELD attrname="MIC_MEF_ID_AUDIO5" fieldtype="i4"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_MEF_ID_AUDIO5" Roundtrip="True" /></FIELD><FIELD attrname="MIC_MEF_ID_AUDIO6" fieldtype="i4"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_MEF_ID_AUDIO6" Roundtrip="True" /></FIELD><FIELD attrname="MIC_MEF_ID_AUDIO7" fieldtype="i4"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_MEF_ID_AUDIO7" Roundtrip="True" /></FIELD><FIELD attrname="MIC_MEF_ID_AUDIO8" fieldtype="i4"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_MEF_ID_AUDIO8" Roundtrip="True" /></FIELD><FIELD attrname="MIC_MEF_ID_CAPTION1" fieldtype="i4"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_MEF_ID_CAPTION1" Roundtrip="True" /></FIELD><FIELD attrname="MIC_MEF_ID_CAPTION2" fieldtype="i4"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_MEF_ID_CAPTION2" Roundtrip="True" /></FIELD><FIELD attrname="MIC_MEF_ID_CAPTION3" fieldtype="i4"><PARAM Name="ORIGIN" Value="MEDIAINVENTORYCUT.MIC_MEF_ID_CAPTION3" Roundtrip="True" /></FIELD></FIELDS><PARAMS DATASET_DELTA="TRUE" PRIMARY_KEY="1" /></FIELD></FIELDS><PARAMS DATASET_DELTA="TRUE" /></METADATA>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template name="OutputMEDIAINVENTORYCUT">
<xsl:param name="Original" />
<xsl:param name="RowState"><xsl:value-of select="$ROWSTATE_UNCHANGED" /></xsl:param>
	<ROWMEDIAINVENTORYCUT>
		<xsl:attribute name="RowState"><xsl:value-of select="$RowState" /></xsl:attribute>
		<xsl:choose>
			<xsl:when test="$RowState = $ROWSTATE_AFTER">
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_ID) and MIC_ID) or (msxsl:node-set($Original)/MIC_ID != MIC_ID)">
					<xsl:attribute name="MIC_ID"><xsl:value-of select="MIC_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_ID and not(MIC_ID)">
					<xsl:attribute name="MIC_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_MEIR_ID) and MIC_MEIR_ID) or (msxsl:node-set($Original)/MIC_MEIR_ID != MIC_MEIR_ID)">
					<xsl:attribute name="MIC_MEIR_ID"><xsl:value-of select="MIC_MEIR_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_MEIR_ID and not(MIC_MEIR_ID)">
					<xsl:attribute name="MIC_MEIR_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_NUMBER) and MIC_NUMBER) or (msxsl:node-set($Original)/MIC_NUMBER != MIC_NUMBER)">
					<xsl:attribute name="MIC_NUMBER"><xsl:value-of select="MIC_NUMBER" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_NUMBER and not(MIC_NUMBER)">
					<xsl:attribute name="MIC_NUMBER"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_MICT_ID) and MIC_MICT_ID) or (msxsl:node-set($Original)/MIC_MICT_ID != MIC_MICT_ID)">
					<xsl:attribute name="MIC_MICT_ID"><xsl:value-of select="MIC_MICT_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_MICT_ID and not(MIC_MICT_ID)">
					<xsl:attribute name="MIC_MICT_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_DESCRIPTION) and MIC_DESCRIPTION) or (msxsl:node-set($Original)/MIC_DESCRIPTION != MIC_DESCRIPTION)">
					<xsl:attribute name="MIC_DESCRIPTION"><xsl:value-of select="MIC_DESCRIPTION" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_DESCRIPTION and not(MIC_DESCRIPTION)">
					<xsl:attribute name="MIC_DESCRIPTION"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_ISREUSABLE) and MIC_ISREUSABLE) or (msxsl:node-set($Original)/MIC_ISREUSABLE != MIC_ISREUSABLE)">
					<xsl:attribute name="MIC_ISREUSABLE"><xsl:value-of select="MIC_ISREUSABLE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_ISREUSABLE and not(MIC_ISREUSABLE)">
					<xsl:attribute name="MIC_ISREUSABLE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_TIMECODEIN) and MIC_TIMECODEIN) or (msxsl:node-set($Original)/MIC_TIMECODEIN != MIC_TIMECODEIN)">
					<xsl:attribute name="MIC_TIMECODEIN"><xsl:value-of select="MIC_TIMECODEIN" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_TIMECODEIN and not(MIC_TIMECODEIN)">
					<xsl:attribute name="MIC_TIMECODEIN"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_DURATION) and MIC_DURATION) or (msxsl:node-set($Original)/MIC_DURATION != MIC_DURATION)">
					<xsl:attribute name="MIC_DURATION"><xsl:value-of select="MIC_DURATION" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_DURATION and not(MIC_DURATION)">
					<xsl:attribute name="MIC_DURATION"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_TIMECODEOUT) and MIC_TIMECODEOUT) or (msxsl:node-set($Original)/MIC_TIMECODEOUT != MIC_TIMECODEOUT)">
					<xsl:attribute name="MIC_TIMECODEOUT"><xsl:value-of select="MIC_TIMECODEOUT" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_TIMECODEOUT and not(MIC_TIMECODEOUT)">
					<xsl:attribute name="MIC_TIMECODEOUT"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_ISVARIABLELENGTH) and MIC_ISVARIABLELENGTH) or (msxsl:node-set($Original)/MIC_ISVARIABLELENGTH != MIC_ISVARIABLELENGTH)">
					<xsl:attribute name="MIC_ISVARIABLELENGTH"><xsl:value-of select="MIC_ISVARIABLELENGTH" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_ISVARIABLELENGTH and not(MIC_ISVARIABLELENGTH)">
					<xsl:attribute name="MIC_ISVARIABLELENGTH"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_DURATIONMINIMUM) and MIC_DURATIONMINIMUM) or (msxsl:node-set($Original)/MIC_DURATIONMINIMUM != MIC_DURATIONMINIMUM)">
					<xsl:attribute name="MIC_DURATIONMINIMUM"><xsl:value-of select="MIC_DURATIONMINIMUM" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_DURATIONMINIMUM and not(MIC_DURATIONMINIMUM)">
					<xsl:attribute name="MIC_DURATIONMINIMUM"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_ISREPLACEMENTITEM) and MIC_ISREPLACEMENTITEM) or (msxsl:node-set($Original)/MIC_ISREPLACEMENTITEM != MIC_ISREPLACEMENTITEM)">
					<xsl:attribute name="MIC_ISREPLACEMENTITEM"><xsl:value-of select="MIC_ISREPLACEMENTITEM" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_ISREPLACEMENTITEM and not(MIC_ISREPLACEMENTITEM)">
					<xsl:attribute name="MIC_ISREPLACEMENTITEM"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_REPLACEMENTNOTE) and MIC_REPLACEMENTNOTE) or (msxsl:node-set($Original)/MIC_REPLACEMENTNOTE != MIC_REPLACEMENTNOTE)">
					<xsl:attribute name="MIC_REPLACEMENTNOTE"><xsl:value-of select="MIC_REPLACEMENTNOTE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_REPLACEMENTNOTE and not(MIC_REPLACEMENTNOTE)">
					<xsl:attribute name="MIC_REPLACEMENTNOTE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_ASS_ID) and MIC_ASS_ID) or (msxsl:node-set($Original)/MIC_ASS_ID != MIC_ASS_ID)">
					<xsl:attribute name="MIC_ASS_ID"><xsl:value-of select="MIC_ASS_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_ASS_ID and not(MIC_ASS_ID)">
					<xsl:attribute name="MIC_ASS_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_ASSOCIATEDTITLE) and MIC_ASSOCIATEDTITLE) or (msxsl:node-set($Original)/MIC_ASSOCIATEDTITLE != MIC_ASSOCIATEDTITLE)">
					<xsl:attribute name="MIC_ASSOCIATEDTITLE"><xsl:value-of select="MIC_ASSOCIATEDTITLE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_ASSOCIATEDTITLE and not(MIC_ASSOCIATEDTITLE)">
					<xsl:attribute name="MIC_ASSOCIATEDTITLE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_NEW_DESC) and MIC_NEW_DESC) or (msxsl:node-set($Original)/MIC_NEW_DESC != MIC_NEW_DESC)">
					<xsl:attribute name="MIC_NEW_DESC"><xsl:value-of select="MIC_NEW_DESC" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_NEW_DESC and not(MIC_NEW_DESC)">
					<xsl:attribute name="MIC_NEW_DESC"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_NEW_DATEAVAILABLEFROM) and MIC_NEW_DATEAVAILABLEFROM) or (msxsl:node-set($Original)/MIC_NEW_DATEAVAILABLEFROM != MIC_NEW_DATEAVAILABLEFROM)">
					<xsl:attribute name="MIC_NEW_DATEAVAILABLEFROM"><xsl:value-of select="MIC_NEW_DATEAVAILABLEFROM" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_NEW_DATEAVAILABLEFROM and not(MIC_NEW_DATEAVAILABLEFROM)">
					<xsl:attribute name="MIC_NEW_DATEAVAILABLEFROM"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_NEW_DATEAVAILABLETO) and MIC_NEW_DATEAVAILABLETO) or (msxsl:node-set($Original)/MIC_NEW_DATEAVAILABLETO != MIC_NEW_DATEAVAILABLETO)">
					<xsl:attribute name="MIC_NEW_DATEAVAILABLETO"><xsl:value-of select="MIC_NEW_DATEAVAILABLETO" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_NEW_DATEAVAILABLETO and not(MIC_NEW_DATEAVAILABLETO)">
					<xsl:attribute name="MIC_NEW_DATEAVAILABLETO"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_MFC_ID_AUDIOTYPE) and MIC_MFC_ID_AUDIOTYPE) or (msxsl:node-set($Original)/MIC_MFC_ID_AUDIOTYPE != MIC_MFC_ID_AUDIOTYPE)">
					<xsl:attribute name="MIC_MFC_ID_AUDIOTYPE"><xsl:value-of select="MIC_MFC_ID_AUDIOTYPE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_MFC_ID_AUDIOTYPE and not(MIC_MFC_ID_AUDIOTYPE)">
					<xsl:attribute name="MIC_MFC_ID_AUDIOTYPE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_ISCC) and MIC_ISCC) or (msxsl:node-set($Original)/MIC_ISCC != MIC_ISCC)">
					<xsl:attribute name="MIC_ISCC"><xsl:value-of select="MIC_ISCC" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_ISCC and not(MIC_ISCC)">
					<xsl:attribute name="MIC_ISCC"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_ISDVI) and MIC_ISDVI) or (msxsl:node-set($Original)/MIC_ISDVI != MIC_ISDVI)">
					<xsl:attribute name="MIC_ISDVI"><xsl:value-of select="MIC_ISDVI" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_ISDVI and not(MIC_ISDVI)">
					<xsl:attribute name="MIC_ISDVI"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_ISSAP) and MIC_ISSAP) or (msxsl:node-set($Original)/MIC_ISSAP != MIC_ISSAP)">
					<xsl:attribute name="MIC_ISSAP"><xsl:value-of select="MIC_ISSAP" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_ISSAP and not(MIC_ISSAP)">
					<xsl:attribute name="MIC_ISSAP"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_SLU_ID_ASPECTRATIO) and MIC_SLU_ID_ASPECTRATIO) or (msxsl:node-set($Original)/MIC_SLU_ID_ASPECTRATIO != MIC_SLU_ID_ASPECTRATIO)">
					<xsl:attribute name="MIC_SLU_ID_ASPECTRATIO"><xsl:value-of select="MIC_SLU_ID_ASPECTRATIO" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_SLU_ID_ASPECTRATIO and not(MIC_SLU_ID_ASPECTRATIO)">
					<xsl:attribute name="MIC_SLU_ID_ASPECTRATIO"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_SLU_ID_HIDEF) and MIC_SLU_ID_HIDEF) or (msxsl:node-set($Original)/MIC_SLU_ID_HIDEF != MIC_SLU_ID_HIDEF)">
					<xsl:attribute name="MIC_SLU_ID_HIDEF"><xsl:value-of select="MIC_SLU_ID_HIDEF" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_SLU_ID_HIDEF and not(MIC_SLU_ID_HIDEF)">
					<xsl:attribute name="MIC_SLU_ID_HIDEF"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_MEF_ID_AUDIO1) and MIC_MEF_ID_AUDIO1) or (msxsl:node-set($Original)/MIC_MEF_ID_AUDIO1 != MIC_MEF_ID_AUDIO1)">
					<xsl:attribute name="MIC_MEF_ID_AUDIO1"><xsl:value-of select="MIC_MEF_ID_AUDIO1" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_MEF_ID_AUDIO1 and not(MIC_MEF_ID_AUDIO1)">
					<xsl:attribute name="MIC_MEF_ID_AUDIO1"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_MEF_ID_AUDIO2) and MIC_MEF_ID_AUDIO2) or (msxsl:node-set($Original)/MIC_MEF_ID_AUDIO2 != MIC_MEF_ID_AUDIO2)">
					<xsl:attribute name="MIC_MEF_ID_AUDIO2"><xsl:value-of select="MIC_MEF_ID_AUDIO2" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_MEF_ID_AUDIO2 and not(MIC_MEF_ID_AUDIO2)">
					<xsl:attribute name="MIC_MEF_ID_AUDIO2"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_MEF_ID_AUDIO3) and MIC_MEF_ID_AUDIO3) or (msxsl:node-set($Original)/MIC_MEF_ID_AUDIO3 != MIC_MEF_ID_AUDIO3)">
					<xsl:attribute name="MIC_MEF_ID_AUDIO3"><xsl:value-of select="MIC_MEF_ID_AUDIO3" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_MEF_ID_AUDIO3 and not(MIC_MEF_ID_AUDIO3)">
					<xsl:attribute name="MIC_MEF_ID_AUDIO3"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_MEF_ID_AUDIO4) and MIC_MEF_ID_AUDIO4) or (msxsl:node-set($Original)/MIC_MEF_ID_AUDIO4 != MIC_MEF_ID_AUDIO4)">
					<xsl:attribute name="MIC_MEF_ID_AUDIO4"><xsl:value-of select="MIC_MEF_ID_AUDIO4" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_MEF_ID_AUDIO4 and not(MIC_MEF_ID_AUDIO4)">
					<xsl:attribute name="MIC_MEF_ID_AUDIO4"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_MEF_ID_AUDIO5) and MIC_MEF_ID_AUDIO5) or (msxsl:node-set($Original)/MIC_MEF_ID_AUDIO5 != MIC_MEF_ID_AUDIO5)">
					<xsl:attribute name="MIC_MEF_ID_AUDIO5"><xsl:value-of select="MIC_MEF_ID_AUDIO5" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_MEF_ID_AUDIO5 and not(MIC_MEF_ID_AUDIO5)">
					<xsl:attribute name="MIC_MEF_ID_AUDIO5"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_MEF_ID_AUDIO6) and MIC_MEF_ID_AUDIO6) or (msxsl:node-set($Original)/MIC_MEF_ID_AUDIO6 != MIC_MEF_ID_AUDIO6)">
					<xsl:attribute name="MIC_MEF_ID_AUDIO6"><xsl:value-of select="MIC_MEF_ID_AUDIO6" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_MEF_ID_AUDIO6 and not(MIC_MEF_ID_AUDIO6)">
					<xsl:attribute name="MIC_MEF_ID_AUDIO6"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_MEF_ID_AUDIO7) and MIC_MEF_ID_AUDIO7) or (msxsl:node-set($Original)/MIC_MEF_ID_AUDIO7 != MIC_MEF_ID_AUDIO7)">
					<xsl:attribute name="MIC_MEF_ID_AUDIO7"><xsl:value-of select="MIC_MEF_ID_AUDIO7" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_MEF_ID_AUDIO7 and not(MIC_MEF_ID_AUDIO7)">
					<xsl:attribute name="MIC_MEF_ID_AUDIO7"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_MEF_ID_AUDIO8) and MIC_MEF_ID_AUDIO8) or (msxsl:node-set($Original)/MIC_MEF_ID_AUDIO8 != MIC_MEF_ID_AUDIO8)">
					<xsl:attribute name="MIC_MEF_ID_AUDIO8"><xsl:value-of select="MIC_MEF_ID_AUDIO8" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_MEF_ID_AUDIO8 and not(MIC_MEF_ID_AUDIO8)">
					<xsl:attribute name="MIC_MEF_ID_AUDIO8"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_MEF_ID_CAPTION1) and MIC_MEF_ID_CAPTION1) or (msxsl:node-set($Original)/MIC_MEF_ID_CAPTION1 != MIC_MEF_ID_CAPTION1)">
					<xsl:attribute name="MIC_MEF_ID_CAPTION1"><xsl:value-of select="MIC_MEF_ID_CAPTION1" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_MEF_ID_CAPTION1 and not(MIC_MEF_ID_CAPTION1)">
					<xsl:attribute name="MIC_MEF_ID_CAPTION1"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_MEF_ID_CAPTION2) and MIC_MEF_ID_CAPTION2) or (msxsl:node-set($Original)/MIC_MEF_ID_CAPTION2 != MIC_MEF_ID_CAPTION2)">
					<xsl:attribute name="MIC_MEF_ID_CAPTION2"><xsl:value-of select="MIC_MEF_ID_CAPTION2" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_MEF_ID_CAPTION2 and not(MIC_MEF_ID_CAPTION2)">
					<xsl:attribute name="MIC_MEF_ID_CAPTION2"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MIC_MEF_ID_CAPTION3) and MIC_MEF_ID_CAPTION3) or (msxsl:node-set($Original)/MIC_MEF_ID_CAPTION3 != MIC_MEF_ID_CAPTION3)">
					<xsl:attribute name="MIC_MEF_ID_CAPTION3"><xsl:value-of select="MIC_MEF_ID_CAPTION3" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MIC_MEF_ID_CAPTION3 and not(MIC_MEF_ID_CAPTION3)">
					<xsl:attribute name="MIC_MEF_ID_CAPTION3"></xsl:attribute>
				</xsl:if>
			</xsl:when>
			<xsl:otherwise>
				<xsl:attribute name="MIC_ID"><xsl:value-of select="MIC_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_ID and not(MIC_ID)">
					<xsl:attribute name="MIC_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_MEIR_ID"><xsl:value-of select="MIC_MEIR_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_MEIR_ID and not(MIC_MEIR_ID)">
					<xsl:attribute name="MIC_MEIR_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_NUMBER"><xsl:value-of select="MIC_NUMBER" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_NUMBER and not(MIC_NUMBER)">
					<xsl:attribute name="MIC_NUMBER"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_MICT_ID"><xsl:value-of select="MIC_MICT_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_MICT_ID and not(MIC_MICT_ID)">
					<xsl:attribute name="MIC_MICT_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_DESCRIPTION"><xsl:value-of select="MIC_DESCRIPTION" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_DESCRIPTION and not(MIC_DESCRIPTION)">
					<xsl:attribute name="MIC_DESCRIPTION"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_ISREUSABLE"><xsl:value-of select="MIC_ISREUSABLE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_ISREUSABLE and not(MIC_ISREUSABLE)">
					<xsl:attribute name="MIC_ISREUSABLE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_TIMECODEIN"><xsl:value-of select="MIC_TIMECODEIN" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_TIMECODEIN and not(MIC_TIMECODEIN)">
					<xsl:attribute name="MIC_TIMECODEIN"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_DURATION"><xsl:value-of select="MIC_DURATION" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_DURATION and not(MIC_DURATION)">
					<xsl:attribute name="MIC_DURATION"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_TIMECODEOUT"><xsl:value-of select="MIC_TIMECODEOUT" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_TIMECODEOUT and not(MIC_TIMECODEOUT)">
					<xsl:attribute name="MIC_TIMECODEOUT"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_ISVARIABLELENGTH"><xsl:value-of select="MIC_ISVARIABLELENGTH" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_ISVARIABLELENGTH and not(MIC_ISVARIABLELENGTH)">
					<xsl:attribute name="MIC_ISVARIABLELENGTH"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_DURATIONMINIMUM"><xsl:value-of select="MIC_DURATIONMINIMUM" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_DURATIONMINIMUM and not(MIC_DURATIONMINIMUM)">
					<xsl:attribute name="MIC_DURATIONMINIMUM"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_ISREPLACEMENTITEM"><xsl:value-of select="MIC_ISREPLACEMENTITEM" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_ISREPLACEMENTITEM and not(MIC_ISREPLACEMENTITEM)">
					<xsl:attribute name="MIC_ISREPLACEMENTITEM"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_REPLACEMENTNOTE"><xsl:value-of select="MIC_REPLACEMENTNOTE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_REPLACEMENTNOTE and not(MIC_REPLACEMENTNOTE)">
					<xsl:attribute name="MIC_REPLACEMENTNOTE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_ASS_ID"><xsl:value-of select="MIC_ASS_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_ASS_ID and not(MIC_ASS_ID)">
					<xsl:attribute name="MIC_ASS_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_ASSOCIATEDTITLE"><xsl:value-of select="MIC_ASSOCIATEDTITLE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_ASSOCIATEDTITLE and not(MIC_ASSOCIATEDTITLE)">
					<xsl:attribute name="MIC_ASSOCIATEDTITLE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_NEW_DESC"><xsl:value-of select="MIC_NEW_DESC" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_NEW_DESC and not(MIC_NEW_DESC)">
					<xsl:attribute name="MIC_NEW_DESC"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_NEW_DATEAVAILABLEFROM"><xsl:value-of select="MIC_NEW_DATEAVAILABLEFROM" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_NEW_DATEAVAILABLEFROM and not(MIC_NEW_DATEAVAILABLEFROM)">
					<xsl:attribute name="MIC_NEW_DATEAVAILABLEFROM"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_NEW_DATEAVAILABLETO"><xsl:value-of select="MIC_NEW_DATEAVAILABLETO" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_NEW_DATEAVAILABLETO and not(MIC_NEW_DATEAVAILABLETO)">
					<xsl:attribute name="MIC_NEW_DATEAVAILABLETO"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_MFC_ID_AUDIOTYPE"><xsl:value-of select="MIC_MFC_ID_AUDIOTYPE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_MFC_ID_AUDIOTYPE and not(MIC_MFC_ID_AUDIOTYPE)">
					<xsl:attribute name="MIC_MFC_ID_AUDIOTYPE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_ISCC"><xsl:value-of select="MIC_ISCC" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_ISCC and not(MIC_ISCC)">
					<xsl:attribute name="MIC_ISCC"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_ISDVI"><xsl:value-of select="MIC_ISDVI" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_ISDVI and not(MIC_ISDVI)">
					<xsl:attribute name="MIC_ISDVI"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_ISSAP"><xsl:value-of select="MIC_ISSAP" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_ISSAP and not(MIC_ISSAP)">
					<xsl:attribute name="MIC_ISSAP"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_SLU_ID_ASPECTRATIO"><xsl:value-of select="MIC_SLU_ID_ASPECTRATIO" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_SLU_ID_ASPECTRATIO and not(MIC_SLU_ID_ASPECTRATIO)">
					<xsl:attribute name="MIC_SLU_ID_ASPECTRATIO"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_SLU_ID_HIDEF"><xsl:value-of select="MIC_SLU_ID_HIDEF" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_SLU_ID_HIDEF and not(MIC_SLU_ID_HIDEF)">
					<xsl:attribute name="MIC_SLU_ID_HIDEF"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_MEF_ID_AUDIO1"><xsl:value-of select="MIC_MEF_ID_AUDIO1" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_MEF_ID_AUDIO1 and not(MIC_MEF_ID_AUDIO1)">
					<xsl:attribute name="MIC_MEF_ID_AUDIO1"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_MEF_ID_AUDIO2"><xsl:value-of select="MIC_MEF_ID_AUDIO2" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_MEF_ID_AUDIO2 and not(MIC_MEF_ID_AUDIO2)">
					<xsl:attribute name="MIC_MEF_ID_AUDIO2"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_MEF_ID_AUDIO3"><xsl:value-of select="MIC_MEF_ID_AUDIO3" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_MEF_ID_AUDIO3 and not(MIC_MEF_ID_AUDIO3)">
					<xsl:attribute name="MIC_MEF_ID_AUDIO3"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_MEF_ID_AUDIO4"><xsl:value-of select="MIC_MEF_ID_AUDIO4" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_MEF_ID_AUDIO4 and not(MIC_MEF_ID_AUDIO4)">
					<xsl:attribute name="MIC_MEF_ID_AUDIO4"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_MEF_ID_AUDIO5"><xsl:value-of select="MIC_MEF_ID_AUDIO5" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_MEF_ID_AUDIO5 and not(MIC_MEF_ID_AUDIO5)">
					<xsl:attribute name="MIC_MEF_ID_AUDIO5"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_MEF_ID_AUDIO6"><xsl:value-of select="MIC_MEF_ID_AUDIO6" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_MEF_ID_AUDIO6 and not(MIC_MEF_ID_AUDIO6)">
					<xsl:attribute name="MIC_MEF_ID_AUDIO6"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_MEF_ID_AUDIO7"><xsl:value-of select="MIC_MEF_ID_AUDIO7" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_MEF_ID_AUDIO7 and not(MIC_MEF_ID_AUDIO7)">
					<xsl:attribute name="MIC_MEF_ID_AUDIO7"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_MEF_ID_AUDIO8"><xsl:value-of select="MIC_MEF_ID_AUDIO8" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_MEF_ID_AUDIO8 and not(MIC_MEF_ID_AUDIO8)">
					<xsl:attribute name="MIC_MEF_ID_AUDIO8"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_MEF_ID_CAPTION1"><xsl:value-of select="MIC_MEF_ID_CAPTION1" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_MEF_ID_CAPTION1 and not(MIC_MEF_ID_CAPTION1)">
					<xsl:attribute name="MIC_MEF_ID_CAPTION1"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_MEF_ID_CAPTION2"><xsl:value-of select="MIC_MEF_ID_CAPTION2" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_MEF_ID_CAPTION2 and not(MIC_MEF_ID_CAPTION2)">
					<xsl:attribute name="MIC_MEF_ID_CAPTION2"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MIC_MEF_ID_CAPTION3"><xsl:value-of select="MIC_MEF_ID_CAPTION3" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MIC_MEF_ID_CAPTION3 and not(MIC_MEF_ID_CAPTION3)">
					<xsl:attribute name="MIC_MEF_ID_CAPTION3"></xsl:attribute>
				</xsl:if>
			</xsl:otherwise>
		</xsl:choose>

	</ROWMEDIAINVENTORYCUT>
</xsl:template>

<xsl:template name="OutputMEDIAINVENTORYREVISION">
<xsl:param name="Original" />
<xsl:param name="RowState"><xsl:value-of select="$ROWSTATE_UNCHANGED" /></xsl:param>
	<ROW>
		<xsl:attribute name="RowState"><xsl:value-of select="$RowState" /></xsl:attribute>
		<xsl:choose>
			<xsl:when test="$RowState = $ROWSTATE_AFTER">
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_ID) and MEIR_ID) or (msxsl:node-set($Original)/MEIR_ID != MEIR_ID)">
					<xsl:attribute name="MEIR_ID"><xsl:value-of select="MEIR_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_ID and not(MEIR_ID)">
					<xsl:attribute name="MEIR_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_ASS_ID) and MEI_ASS_ID) or (msxsl:node-set($Original)/MEI_ASS_ID != MEI_ASS_ID)">
					<xsl:attribute name="MEI_ASS_ID"><xsl:value-of select="MEI_ASS_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_ASS_ID and not(MEI_ASS_ID)">
					<xsl:attribute name="MEI_ASS_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_MEI_ID) and MEIR_MEI_ID) or (msxsl:node-set($Original)/MEIR_MEI_ID != MEIR_MEI_ID)">
					<xsl:attribute name="MEIR_MEI_ID"><xsl:value-of select="MEIR_MEI_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_MEI_ID and not(MEIR_MEI_ID)">
					<xsl:attribute name="MEIR_MEI_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_NUMBER) and MEI_NUMBER) or (msxsl:node-set($Original)/MEI_NUMBER != MEI_NUMBER)">
					<xsl:attribute name="MEI_NUMBER"><xsl:value-of select="MEI_NUMBER" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_NUMBER and not(MEI_NUMBER)">
					<xsl:attribute name="MEI_NUMBER"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_SLU_ID_STATUS) and MEI_SLU_ID_STATUS) or (msxsl:node-set($Original)/MEI_SLU_ID_STATUS != MEI_SLU_ID_STATUS)">
					<xsl:attribute name="MEI_SLU_ID_STATUS"><xsl:value-of select="MEI_SLU_ID_STATUS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_SLU_ID_STATUS and not(MEI_SLU_ID_STATUS)">
					<xsl:attribute name="MEI_SLU_ID_STATUS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_ISNOINGEST) and MEI_ISNOINGEST) or (msxsl:node-set($Original)/MEI_ISNOINGEST != MEI_ISNOINGEST)">
					<xsl:attribute name="MEI_ISNOINGEST"><xsl:value-of select="MEI_ISNOINGEST" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_ISNOINGEST and not(MEI_ISNOINGEST)">
					<xsl:attribute name="MEI_ISNOINGEST"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_LASTSUBMITTEDDATE) and MEI_LASTSUBMITTEDDATE) or (msxsl:node-set($Original)/MEI_LASTSUBMITTEDDATE != MEI_LASTSUBMITTEDDATE)">
					<xsl:attribute name="MEI_LASTSUBMITTEDDATE"><xsl:value-of select="MEI_LASTSUBMITTEDDATE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_LASTSUBMITTEDDATE and not(MEI_LASTSUBMITTEDDATE)">
					<xsl:attribute name="MEI_LASTSUBMITTEDDATE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_PBSOPERATINGUNIT) and MEI_PBSOPERATINGUNIT) or (msxsl:node-set($Original)/MEI_PBSOPERATINGUNIT != MEI_PBSOPERATINGUNIT)">
					<xsl:attribute name="MEI_PBSOPERATINGUNIT"><xsl:value-of select="MEI_PBSOPERATINGUNIT" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_PBSOPERATINGUNIT and not(MEI_PBSOPERATINGUNIT)">
					<xsl:attribute name="MEI_PBSOPERATINGUNIT"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_PBSOPERATINGGROUP) and MEI_PBSOPERATINGGROUP) or (msxsl:node-set($Original)/MEI_PBSOPERATINGGROUP != MEI_PBSOPERATINGGROUP)">
					<xsl:attribute name="MEI_PBSOPERATINGGROUP"><xsl:value-of select="MEI_PBSOPERATINGGROUP" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_PBSOPERATINGGROUP and not(MEI_PBSOPERATINGGROUP)">
					<xsl:attribute name="MEI_PBSOPERATINGGROUP"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_MIT_ID) and MEI_MIT_ID) or (msxsl:node-set($Original)/MEI_MIT_ID != MEI_MIT_ID)">
					<xsl:attribute name="MEI_MIT_ID"><xsl:value-of select="MEI_MIT_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_MIT_ID and not(MEI_MIT_ID)">
					<xsl:attribute name="MEI_MIT_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_MET_ID) and MEI_MET_ID) or (msxsl:node-set($Original)/MEI_MET_ID != MEI_MET_ID)">
					<xsl:attribute name="MEI_MET_ID"><xsl:value-of select="MEI_MET_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_MET_ID and not(MEI_MET_ID)">
					<xsl:attribute name="MEI_MET_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_ISCOMPLETEPACKAGE) and MEI_ISCOMPLETEPACKAGE) or (msxsl:node-set($Original)/MEI_ISCOMPLETEPACKAGE != MEI_ISCOMPLETEPACKAGE)">
					<xsl:attribute name="MEI_ISCOMPLETEPACKAGE"><xsl:value-of select="MEI_ISCOMPLETEPACKAGE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_ISCOMPLETEPACKAGE and not(MEI_ISCOMPLETEPACKAGE)">
					<xsl:attribute name="MEI_ISCOMPLETEPACKAGE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_VET_ID) and MEI_VET_ID) or (msxsl:node-set($Original)/MEI_VET_ID != MEI_VET_ID)">
					<xsl:attribute name="MEI_VET_ID"><xsl:value-of select="MEI_VET_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_VET_ID and not(MEI_VET_ID)">
					<xsl:attribute name="MEI_VET_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_ISDROPFRAME) and MEI_ISDROPFRAME) or (msxsl:node-set($Original)/MEI_ISDROPFRAME != MEI_ISDROPFRAME)">
					<xsl:attribute name="MEI_ISDROPFRAME"><xsl:value-of select="MEI_ISDROPFRAME" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_ISDROPFRAME and not(MEI_ISDROPFRAME)">
					<xsl:attribute name="MEI_ISDROPFRAME"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_SLU_ID_PBSMEDIASTATUS) and MEI_SLU_ID_PBSMEDIASTATUS) or (msxsl:node-set($Original)/MEI_SLU_ID_PBSMEDIASTATUS != MEI_SLU_ID_PBSMEDIASTATUS)">
					<xsl:attribute name="MEI_SLU_ID_PBSMEDIASTATUS"><xsl:value-of select="MEI_SLU_ID_PBSMEDIASTATUS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_SLU_ID_PBSMEDIASTATUS and not(MEI_SLU_ID_PBSMEDIASTATUS)">
					<xsl:attribute name="MEI_SLU_ID_PBSMEDIASTATUS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_ISBILLABLE) and MEIR_ISBILLABLE) or (msxsl:node-set($Original)/MEIR_ISBILLABLE != MEIR_ISBILLABLE)">
					<xsl:attribute name="MEIR_ISBILLABLE"><xsl:value-of select="MEIR_ISBILLABLE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_ISBILLABLE and not(MEIR_ISBILLABLE)">
					<xsl:attribute name="MEIR_ISBILLABLE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_ISCHANGESALLOWED) and MEI_ISCHANGESALLOWED) or (msxsl:node-set($Original)/MEI_ISCHANGESALLOWED != MEI_ISCHANGESALLOWED)">
					<xsl:attribute name="MEI_ISCHANGESALLOWED"><xsl:value-of select="MEI_ISCHANGESALLOWED" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_ISCHANGESALLOWED and not(MEI_ISCHANGESALLOWED)">
					<xsl:attribute name="MEI_ISCHANGESALLOWED"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_SLU_ID_PBSMEDIASTATUS) and MEIR_SLU_ID_PBSMEDIASTATUS) or (msxsl:node-set($Original)/MEIR_SLU_ID_PBSMEDIASTATUS != MEIR_SLU_ID_PBSMEDIASTATUS)">
					<xsl:attribute name="MEIR_SLU_ID_PBSMEDIASTATUS"><xsl:value-of select="MEIR_SLU_ID_PBSMEDIASTATUS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_SLU_ID_PBSMEDIASTATUS and not(MEIR_SLU_ID_PBSMEDIASTATUS)">
					<xsl:attribute name="MEIR_SLU_ID_PBSMEDIASTATUS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_SLU_ID_STATUS) and MEIR_SLU_ID_STATUS) or (msxsl:node-set($Original)/MEIR_SLU_ID_STATUS != MEIR_SLU_ID_STATUS)">
					<xsl:attribute name="MEIR_SLU_ID_STATUS"><xsl:value-of select="MEIR_SLU_ID_STATUS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_SLU_ID_STATUS and not(MEIR_SLU_ID_STATUS)">
					<xsl:attribute name="MEIR_SLU_ID_STATUS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_ISNOINGEST) and MEIR_ISNOINGEST) or (msxsl:node-set($Original)/MEIR_ISNOINGEST != MEIR_ISNOINGEST)">
					<xsl:attribute name="MEIR_ISNOINGEST"><xsl:value-of select="MEIR_ISNOINGEST" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_ISNOINGEST and not(MEIR_ISNOINGEST)">
					<xsl:attribute name="MEIR_ISNOINGEST"></xsl:attribute>
				</xsl:if>
				<xsl:if test="MEI_NOTE != '' and (not(msxsl:node-set($Original)/MEI_NOTE) and MEI_NOTE) or (msxsl:node-set($Original)/MEI_NOTE != MEI_NOTE)">
					<xsl:attribute name="MEI_NOTE"><xsl:value-of select="MEI_NOTE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_NOTE and not(MEI_NOTE)">
					<xsl:attribute name="MEI_NOTE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_ISHDINGEST) and MEI_ISHDINGEST) or (msxsl:node-set($Original)/MEI_ISHDINGEST != MEI_ISHDINGEST)">
					<xsl:attribute name="MEI_ISHDINGEST"><xsl:value-of select="MEI_ISHDINGEST" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_ISHDINGEST and not(MEI_ISHDINGEST)">
					<xsl:attribute name="MEI_ISHDINGEST"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_REVISIONNO) and MEIR_REVISIONNO) or (msxsl:node-set($Original)/MEIR_REVISIONNO != MEIR_REVISIONNO)">
					<xsl:attribute name="MEIR_REVISIONNO"><xsl:value-of select="MEIR_REVISIONNO" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_REVISIONNO and not(MEIR_REVISIONNO)">
					<xsl:attribute name="MEIR_REVISIONNO"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_MFC_ID_AUDIOTYPE) and MEIR_MFC_ID_AUDIOTYPE) or (msxsl:node-set($Original)/MEIR_MFC_ID_AUDIOTYPE != MEIR_MFC_ID_AUDIOTYPE)">
					<xsl:attribute name="MEIR_MFC_ID_AUDIOTYPE"><xsl:value-of select="MEIR_MFC_ID_AUDIOTYPE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_MFC_ID_AUDIOTYPE and not(MEIR_MFC_ID_AUDIOTYPE)">
					<xsl:attribute name="MEIR_MFC_ID_AUDIOTYPE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_ISCC) and MEIR_ISCC) or (msxsl:node-set($Original)/MEIR_ISCC != MEIR_ISCC)">
					<xsl:attribute name="MEIR_ISCC"><xsl:value-of select="MEIR_ISCC" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_ISCC and not(MEIR_ISCC)">
					<xsl:attribute name="MEIR_ISCC"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_ISDVI) and MEIR_ISDVI) or (msxsl:node-set($Original)/MEIR_ISDVI != MEIR_ISDVI)">
					<xsl:attribute name="MEIR_ISDVI"><xsl:value-of select="MEIR_ISDVI" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_ISDVI and not(MEIR_ISDVI)">
					<xsl:attribute name="MEIR_ISDVI"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_ISSAP) and MEIR_ISSAP) or (msxsl:node-set($Original)/MEIR_ISSAP != MEIR_ISSAP)">
					<xsl:attribute name="MEIR_ISSAP"><xsl:value-of select="MEIR_ISSAP" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_ISSAP and not(MEIR_ISSAP)">
					<xsl:attribute name="MEIR_ISSAP"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_SLU_ID_ASPECTRATIO) and MEIR_SLU_ID_ASPECTRATIO) or (msxsl:node-set($Original)/MEIR_SLU_ID_ASPECTRATIO != MEIR_SLU_ID_ASPECTRATIO)">
					<xsl:attribute name="MEIR_SLU_ID_ASPECTRATIO"><xsl:value-of select="MEIR_SLU_ID_ASPECTRATIO" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_SLU_ID_ASPECTRATIO and not(MEIR_SLU_ID_ASPECTRATIO)">
					<xsl:attribute name="MEIR_SLU_ID_ASPECTRATIO"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_SLU_ID_HIDEF) and MEIR_SLU_ID_HIDEF) or (msxsl:node-set($Original)/MEIR_SLU_ID_HIDEF != MEIR_SLU_ID_HIDEF)">
					<xsl:attribute name="MEIR_SLU_ID_HIDEF"><xsl:value-of select="MEIR_SLU_ID_HIDEF" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_SLU_ID_HIDEF and not(MEIR_SLU_ID_HIDEF)">
					<xsl:attribute name="MEIR_SLU_ID_HIDEF"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_MEF_ID_AUDIO1) and MEIR_MEF_ID_AUDIO1) or (msxsl:node-set($Original)/MEIR_MEF_ID_AUDIO1 != MEIR_MEF_ID_AUDIO1)">
					<xsl:attribute name="MEIR_MEF_ID_AUDIO1"><xsl:value-of select="MEIR_MEF_ID_AUDIO1" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_MEF_ID_AUDIO1 and not(MEIR_MEF_ID_AUDIO1)">
					<xsl:attribute name="MEIR_MEF_ID_AUDIO1"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_MEF_ID_AUDIO2) and MEIR_MEF_ID_AUDIO2) or (msxsl:node-set($Original)/MEIR_MEF_ID_AUDIO2 != MEIR_MEF_ID_AUDIO2)">
					<xsl:attribute name="MEIR_MEF_ID_AUDIO2"><xsl:value-of select="MEIR_MEF_ID_AUDIO2" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_MEF_ID_AUDIO2 and not(MEIR_MEF_ID_AUDIO2)">
					<xsl:attribute name="MEIR_MEF_ID_AUDIO2"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_MEF_ID_AUDIO3) and MEIR_MEF_ID_AUDIO3) or (msxsl:node-set($Original)/MEIR_MEF_ID_AUDIO3 != MEIR_MEF_ID_AUDIO3)">
					<xsl:attribute name="MEIR_MEF_ID_AUDIO3"><xsl:value-of select="MEIR_MEF_ID_AUDIO3" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_MEF_ID_AUDIO3 and not(MEIR_MEF_ID_AUDIO3)">
					<xsl:attribute name="MEIR_MEF_ID_AUDIO3"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_MEF_ID_AUDIO4) and MEIR_MEF_ID_AUDIO4) or (msxsl:node-set($Original)/MEIR_MEF_ID_AUDIO4 != MEIR_MEF_ID_AUDIO4)">
					<xsl:attribute name="MEIR_MEF_ID_AUDIO4"><xsl:value-of select="MEIR_MEF_ID_AUDIO4" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_MEF_ID_AUDIO4 and not(MEIR_MEF_ID_AUDIO4)">
					<xsl:attribute name="MEIR_MEF_ID_AUDIO4"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_MEF_ID_CAPTION1) and MEIR_MEF_ID_CAPTION1) or (msxsl:node-set($Original)/MEIR_MEF_ID_CAPTION1 != MEIR_MEF_ID_CAPTION1)">
					<xsl:attribute name="MEIR_MEF_ID_CAPTION1"><xsl:value-of select="MEIR_MEF_ID_CAPTION1" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_MEF_ID_CAPTION1 and not(MEIR_MEF_ID_CAPTION1)">
					<xsl:attribute name="MEIR_MEF_ID_CAPTION1"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_MEF_ID_CAPTION2) and MEIR_MEF_ID_CAPTION2) or (msxsl:node-set($Original)/MEIR_MEF_ID_CAPTION2 != MEIR_MEF_ID_CAPTION2)">
					<xsl:attribute name="MEIR_MEF_ID_CAPTION2"><xsl:value-of select="MEIR_MEF_ID_CAPTION2" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_MEF_ID_CAPTION2 and not(MEIR_MEF_ID_CAPTION2)">
					<xsl:attribute name="MEIR_MEF_ID_CAPTION2"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_MEF_ID_CAPTION3) and MEIR_MEF_ID_CAPTION3) or (msxsl:node-set($Original)/MEIR_MEF_ID_CAPTION3 != MEIR_MEF_ID_CAPTION3)">
					<xsl:attribute name="MEIR_MEF_ID_CAPTION3"><xsl:value-of select="MEIR_MEF_ID_CAPTION3" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_MEF_ID_CAPTION3 and not(MEIR_MEF_ID_CAPTION3)">
					<xsl:attribute name="MEIR_MEF_ID_CAPTION3"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_CONTACTMANAGER) and MEIR_CONTACTMANAGER) or (msxsl:node-set($Original)/MEIR_CONTACTMANAGER != MEIR_CONTACTMANAGER)">
					<xsl:attribute name="MEIR_CONTACTMANAGER"><xsl:value-of select="MEIR_CONTACTMANAGER" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_CONTACTMANAGER and not(MEIR_CONTACTMANAGER)">
					<xsl:attribute name="MEIR_CONTACTMANAGER"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_CONTACTMANAGER_PHONE) and MEIR_CONTACTMANAGER_PHONE) or (msxsl:node-set($Original)/MEIR_CONTACTMANAGER_PHONE != MEIR_CONTACTMANAGER_PHONE)">
					<xsl:attribute name="MEIR_CONTACTMANAGER_PHONE"><xsl:value-of select="MEIR_CONTACTMANAGER_PHONE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_CONTACTMANAGER_PHONE and not(MEIR_CONTACTMANAGER_PHONE)">
					<xsl:attribute name="MEIR_CONTACTMANAGER_PHONE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_CONTACTMANAGER_EMAIL) and MEIR_CONTACTMANAGER_EMAIL) or (msxsl:node-set($Original)/MEIR_CONTACTMANAGER_EMAIL != MEIR_CONTACTMANAGER_EMAIL)">
					<xsl:attribute name="MEIR_CONTACTMANAGER_EMAIL"><xsl:value-of select="MEIR_CONTACTMANAGER_EMAIL" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_CONTACTMANAGER_EMAIL and not(MEIR_CONTACTMANAGER_EMAIL)">
					<xsl:attribute name="MEIR_CONTACTMANAGER_EMAIL"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_CONTACTTECHNICIAN) and MEIR_CONTACTTECHNICIAN) or (msxsl:node-set($Original)/MEIR_CONTACTTECHNICIAN != MEIR_CONTACTTECHNICIAN)">
					<xsl:attribute name="MEIR_CONTACTTECHNICIAN"><xsl:value-of select="MEIR_CONTACTTECHNICIAN" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_CONTACTTECHNICIAN and not(MEIR_CONTACTTECHNICIAN)">
					<xsl:attribute name="MEIR_CONTACTTECHNICIAN"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_CONTACTTECHNICIAN_PHONE) and MEIR_CONTACTTECHNICIAN_PHONE) or (msxsl:node-set($Original)/MEIR_CONTACTTECHNICIAN_PHONE != MEIR_CONTACTTECHNICIAN_PHONE)">
					<xsl:attribute name="MEIR_CONTACTTECHNICIAN_PHONE"><xsl:value-of select="MEIR_CONTACTTECHNICIAN_PHONE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_CONTACTTECHNICIAN_PHONE and not(MEIR_CONTACTTECHNICIAN_PHONE)">
					<xsl:attribute name="MEIR_CONTACTTECHNICIAN_PHONE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_CONTACTTECHNICIAN_EMAIL) and MEIR_CONTACTTECHNICIAN_EMAIL) or (msxsl:node-set($Original)/MEIR_CONTACTTECHNICIAN_EMAIL != MEIR_CONTACTTECHNICIAN_EMAIL)">
					<xsl:attribute name="MEIR_CONTACTTECHNICIAN_EMAIL"><xsl:value-of select="MEIR_CONTACTTECHNICIAN_EMAIL" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_CONTACTTECHNICIAN_EMAIL and not(MEIR_CONTACTTECHNICIAN_EMAIL)">
					<xsl:attribute name="MEIR_CONTACTTECHNICIAN_EMAIL"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_IS_CC_PBSENCODES) and MEIR_IS_CC_PBSENCODES) or (msxsl:node-set($Original)/MEIR_IS_CC_PBSENCODES != MEIR_IS_CC_PBSENCODES)">
					<xsl:attribute name="MEIR_IS_CC_PBSENCODES"><xsl:value-of select="MEIR_IS_CC_PBSENCODES" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_IS_CC_PBSENCODES and not(MEIR_IS_CC_PBSENCODES)">
					<xsl:attribute name="MEIR_IS_CC_PBSENCODES"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_CC_PROVIDER) and MEIR_CC_PROVIDER) or (msxsl:node-set($Original)/MEIR_CC_PROVIDER != MEIR_CC_PROVIDER)">
					<xsl:attribute name="MEIR_CC_PROVIDER"><xsl:value-of select="MEIR_CC_PROVIDER" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_CC_PROVIDER and not(MEIR_CC_PROVIDER)">
					<xsl:attribute name="MEIR_CC_PROVIDER"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_IS_CC_PBSCOORDINATES) and MEIR_IS_CC_PBSCOORDINATES) or (msxsl:node-set($Original)/MEIR_IS_CC_PBSCOORDINATES != MEIR_IS_CC_PBSCOORDINATES)">
					<xsl:attribute name="MEIR_IS_CC_PBSCOORDINATES"><xsl:value-of select="MEIR_IS_CC_PBSCOORDINATES" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_IS_CC_PBSCOORDINATES and not(MEIR_IS_CC_PBSCOORDINATES)">
					<xsl:attribute name="MEIR_IS_CC_PBSCOORDINATES"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_PBSCV_ID) and MEIR_PBSCV_ID) or (msxsl:node-set($Original)/MEIR_PBSCV_ID != MEIR_PBSCV_ID)">
					<xsl:attribute name="MEIR_PBSCV_ID"><xsl:value-of select="MEIR_PBSCV_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_PBSCV_ID and not(MEIR_PBSCV_ID)">
					<xsl:attribute name="MEIR_PBSCV_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_IS_DVI_PBSENCODES) and MEIR_IS_DVI_PBSENCODES) or (msxsl:node-set($Original)/MEIR_IS_DVI_PBSENCODES != MEIR_IS_DVI_PBSENCODES)">
					<xsl:attribute name="MEIR_IS_DVI_PBSENCODES"><xsl:value-of select="MEIR_IS_DVI_PBSENCODES" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_IS_DVI_PBSENCODES and not(MEIR_IS_DVI_PBSENCODES)">
					<xsl:attribute name="MEIR_IS_DVI_PBSENCODES"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_IS_DVI_PBSCOORDINATES) and MEIR_IS_DVI_PBSCOORDINATES) or (msxsl:node-set($Original)/MEIR_IS_DVI_PBSCOORDINATES != MEIR_IS_DVI_PBSCOORDINATES)">
					<xsl:attribute name="MEIR_IS_DVI_PBSCOORDINATES"><xsl:value-of select="MEIR_IS_DVI_PBSCOORDINATES" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_IS_DVI_PBSCOORDINATES and not(MEIR_IS_DVI_PBSCOORDINATES)">
					<xsl:attribute name="MEIR_IS_DVI_PBSCOORDINATES"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_IS_SAP_PBSENCODES) and MEIR_IS_SAP_PBSENCODES) or (msxsl:node-set($Original)/MEIR_IS_SAP_PBSENCODES != MEIR_IS_SAP_PBSENCODES)">
					<xsl:attribute name="MEIR_IS_SAP_PBSENCODES"><xsl:value-of select="MEIR_IS_SAP_PBSENCODES" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_IS_SAP_PBSENCODES and not(MEIR_IS_SAP_PBSENCODES)">
					<xsl:attribute name="MEIR_IS_SAP_PBSENCODES"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_ISREVISIONREQUIRED) and MEIR_ISREVISIONREQUIRED) or (msxsl:node-set($Original)/MEIR_ISREVISIONREQUIRED != MEIR_ISREVISIONREQUIRED)">
					<xsl:attribute name="MEIR_ISREVISIONREQUIRED"><xsl:value-of select="MEIR_ISREVISIONREQUIRED" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_ISREVISIONREQUIRED and not(MEIR_ISREVISIONREQUIRED)">
					<xsl:attribute name="MEIR_ISREVISIONREQUIRED"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_CLASS) and MEI_CLASS) or (msxsl:node-set($Original)/MEI_CLASS != MEI_CLASS)">
					<xsl:attribute name="MEI_CLASS"><xsl:value-of select="MEI_CLASS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_CLASS and not(MEI_CLASS)">
					<xsl:attribute name="MEI_CLASS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_DESCRIPTION) and MEI_DESCRIPTION) or (msxsl:node-set($Original)/MEI_DESCRIPTION != MEI_DESCRIPTION)">
					<xsl:attribute name="MEI_DESCRIPTION"><xsl:value-of select="MEI_DESCRIPTION" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_DESCRIPTION and not(MEI_DESCRIPTION)">
					<xsl:attribute name="MEI_DESCRIPTION"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_ISPREFEEDONLY) and MEI_ISPREFEEDONLY) or (msxsl:node-set($Original)/MEI_ISPREFEEDONLY != MEI_ISPREFEEDONLY)">
					<xsl:attribute name="MEI_ISPREFEEDONLY"><xsl:value-of select="MEI_ISPREFEEDONLY" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_ISPREFEEDONLY and not(MEI_ISPREFEEDONLY)">
					<xsl:attribute name="MEI_ISPREFEEDONLY"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_ISCONTAINERIZED) and MEI_ISCONTAINERIZED) or (msxsl:node-set($Original)/MEI_ISCONTAINERIZED != MEI_ISCONTAINERIZED)">
					<xsl:attribute name="MEI_ISCONTAINERIZED"><xsl:value-of select="MEI_ISCONTAINERIZED" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_ISCONTAINERIZED and not(MEI_ISCONTAINERIZED)">
					<xsl:attribute name="MEI_ISCONTAINERIZED"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_PBSBT_ID) and MEIR_PBSBT_ID) or (msxsl:node-set($Original)/MEIR_PBSBT_ID != MEIR_PBSBT_ID)">
					<xsl:attribute name="MEIR_PBSBT_ID"><xsl:value-of select="MEIR_PBSBT_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_PBSBT_ID and not(MEIR_PBSBT_ID)">
					<xsl:attribute name="MEIR_PBSBT_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_PBSBC_ID) and MEIR_PBSBC_ID) or (msxsl:node-set($Original)/MEIR_PBSBC_ID != MEIR_PBSBC_ID)">
					<xsl:attribute name="MEIR_PBSBC_ID"><xsl:value-of select="MEIR_PBSBC_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_PBSBC_ID and not(MEIR_PBSBC_ID)">
					<xsl:attribute name="MEIR_PBSBC_ID"></xsl:attribute>
				</xsl:if>
			</xsl:when>
			<xsl:otherwise>
				<xsl:attribute name="MEIR_ID"><xsl:value-of select="MEIR_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_ID and not(MEIR_ID)">
					<xsl:attribute name="MEIR_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_ASS_ID"><xsl:value-of select="MEI_ASS_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_ASS_ID and not(MEI_ASS_ID)">
					<xsl:attribute name="MEI_ASS_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_MEI_ID"><xsl:value-of select="MEIR_MEI_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_MEI_ID and not(MEIR_MEI_ID)">
					<xsl:attribute name="MEIR_MEI_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_NUMBER"><xsl:value-of select="MEI_NUMBER" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_NUMBER and not(MEI_NUMBER)">
					<xsl:attribute name="MEI_NUMBER"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_SLU_ID_STATUS"><xsl:value-of select="MEI_SLU_ID_STATUS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_SLU_ID_STATUS and not(MEI_SLU_ID_STATUS)">
					<xsl:attribute name="MEI_SLU_ID_STATUS"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_ISNOINGEST"><xsl:value-of select="MEI_ISNOINGEST" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_ISNOINGEST and not(MEI_ISNOINGEST)">
					<xsl:attribute name="MEI_ISNOINGEST"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_LASTSUBMITTEDDATE"><xsl:value-of select="MEI_LASTSUBMITTEDDATE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_LASTSUBMITTEDDATE and not(MEI_LASTSUBMITTEDDATE)">
					<xsl:attribute name="MEI_LASTSUBMITTEDDATE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_PBSOPERATINGUNIT"><xsl:value-of select="MEI_PBSOPERATINGUNIT" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_PBSOPERATINGUNIT and not(MEI_PBSOPERATINGUNIT)">
					<xsl:attribute name="MEI_PBSOPERATINGUNIT"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_PBSOPERATINGGROUP"><xsl:value-of select="MEI_PBSOPERATINGGROUP" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_PBSOPERATINGGROUP and not(MEI_PBSOPERATINGGROUP)">
					<xsl:attribute name="MEI_PBSOPERATINGGROUP"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_MIT_ID"><xsl:value-of select="MEI_MIT_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_MIT_ID and not(MEI_MIT_ID)">
					<xsl:attribute name="MEI_MIT_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_MET_ID"><xsl:value-of select="MEI_MET_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_MET_ID and not(MEI_MET_ID)">
					<xsl:attribute name="MEI_MET_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_ISCOMPLETEPACKAGE"><xsl:value-of select="MEI_ISCOMPLETEPACKAGE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_ISCOMPLETEPACKAGE and not(MEI_ISCOMPLETEPACKAGE)">
					<xsl:attribute name="MEI_ISCOMPLETEPACKAGE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_VET_ID"><xsl:value-of select="MEI_VET_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_VET_ID and not(MEI_VET_ID)">
					<xsl:attribute name="MEI_VET_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_ISDROPFRAME"><xsl:value-of select="MEI_ISDROPFRAME" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_ISDROPFRAME and not(MEI_ISDROPFRAME)">
					<xsl:attribute name="MEI_ISDROPFRAME"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_SLU_ID_PBSMEDIASTATUS"><xsl:value-of select="MEI_SLU_ID_PBSMEDIASTATUS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_SLU_ID_PBSMEDIASTATUS and not(MEI_SLU_ID_PBSMEDIASTATUS)">
					<xsl:attribute name="MEI_SLU_ID_PBSMEDIASTATUS"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_ISBILLABLE"><xsl:value-of select="MEIR_ISBILLABLE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_ISBILLABLE and not(MEIR_ISBILLABLE)">
					<xsl:attribute name="MEIR_ISBILLABLE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_ISCHANGESALLOWED"><xsl:value-of select="MEI_ISCHANGESALLOWED" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_ISCHANGESALLOWED and not(MEI_ISCHANGESALLOWED)">
					<xsl:attribute name="MEI_ISCHANGESALLOWED"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_SLU_ID_PBSMEDIASTATUS"><xsl:value-of select="MEIR_SLU_ID_PBSMEDIASTATUS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_SLU_ID_PBSMEDIASTATUS and not(MEIR_SLU_ID_PBSMEDIASTATUS)">
					<xsl:attribute name="MEIR_SLU_ID_PBSMEDIASTATUS"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_SLU_ID_STATUS"><xsl:value-of select="MEIR_SLU_ID_STATUS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_SLU_ID_STATUS and not(MEIR_SLU_ID_STATUS)">
					<xsl:attribute name="MEIR_SLU_ID_STATUS"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_ISNOINGEST"><xsl:value-of select="MEIR_ISNOINGEST" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_ISNOINGEST and not(MEIR_ISNOINGEST)">
					<xsl:attribute name="MEIR_ISNOINGEST"></xsl:attribute>
				</xsl:if>
				<xsl:if test="MEI_NOTE != ''">
					<xsl:attribute name="MEI_NOTE"><xsl:value-of select="MEI_NOTE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_NOTE and not(MEI_NOTE)">
					<xsl:attribute name="MEI_NOTE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_ISHDINGEST"><xsl:value-of select="MEI_ISHDINGEST" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_ISHDINGEST and not(MEI_ISHDINGEST)">
					<xsl:attribute name="MEI_ISHDINGEST"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_REVISIONNO"><xsl:value-of select="MEIR_REVISIONNO" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_REVISIONNO and not(MEIR_REVISIONNO)">
					<xsl:attribute name="MEIR_REVISIONNO"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_MFC_ID_AUDIOTYPE"><xsl:value-of select="MEIR_MFC_ID_AUDIOTYPE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_MFC_ID_AUDIOTYPE and not(MEIR_MFC_ID_AUDIOTYPE)">
					<xsl:attribute name="MEIR_MFC_ID_AUDIOTYPE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_ISCC"><xsl:value-of select="MEIR_ISCC" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_ISCC and not(MEIR_ISCC)">
					<xsl:attribute name="MEIR_ISCC"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_ISDVI"><xsl:value-of select="MEIR_ISDVI" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_ISDVI and not(MEIR_ISDVI)">
					<xsl:attribute name="MEIR_ISDVI"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_ISSAP"><xsl:value-of select="MEIR_ISSAP" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_ISSAP and not(MEIR_ISSAP)">
					<xsl:attribute name="MEIR_ISSAP"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_SLU_ID_ASPECTRATIO"><xsl:value-of select="MEIR_SLU_ID_ASPECTRATIO" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_SLU_ID_ASPECTRATIO and not(MEIR_SLU_ID_ASPECTRATIO)">
					<xsl:attribute name="MEIR_SLU_ID_ASPECTRATIO"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_SLU_ID_HIDEF"><xsl:value-of select="MEIR_SLU_ID_HIDEF" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_SLU_ID_HIDEF and not(MEIR_SLU_ID_HIDEF)">
					<xsl:attribute name="MEIR_SLU_ID_HIDEF"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_MEF_ID_AUDIO1"><xsl:value-of select="MEIR_MEF_ID_AUDIO1" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_MEF_ID_AUDIO1 and not(MEIR_MEF_ID_AUDIO1)">
					<xsl:attribute name="MEIR_MEF_ID_AUDIO1"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_MEF_ID_AUDIO2"><xsl:value-of select="MEIR_MEF_ID_AUDIO2" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_MEF_ID_AUDIO2 and not(MEIR_MEF_ID_AUDIO2)">
					<xsl:attribute name="MEIR_MEF_ID_AUDIO2"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_MEF_ID_AUDIO3"><xsl:value-of select="MEIR_MEF_ID_AUDIO3" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_MEF_ID_AUDIO3 and not(MEIR_MEF_ID_AUDIO3)">
					<xsl:attribute name="MEIR_MEF_ID_AUDIO3"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_MEF_ID_AUDIO4"><xsl:value-of select="MEIR_MEF_ID_AUDIO4" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_MEF_ID_AUDIO4 and not(MEIR_MEF_ID_AUDIO4)">
					<xsl:attribute name="MEIR_MEF_ID_AUDIO4"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_MEF_ID_CAPTION1"><xsl:value-of select="MEIR_MEF_ID_CAPTION1" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_MEF_ID_CAPTION1 and not(MEIR_MEF_ID_CAPTION1)">
					<xsl:attribute name="MEIR_MEF_ID_CAPTION1"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_MEF_ID_CAPTION2"><xsl:value-of select="MEIR_MEF_ID_CAPTION2" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_MEF_ID_CAPTION2 and not(MEIR_MEF_ID_CAPTION2)">
					<xsl:attribute name="MEIR_MEF_ID_CAPTION2"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_MEF_ID_CAPTION3"><xsl:value-of select="MEIR_MEF_ID_CAPTION3" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_MEF_ID_CAPTION3 and not(MEIR_MEF_ID_CAPTION3)">
					<xsl:attribute name="MEIR_MEF_ID_CAPTION3"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_CONTACTMANAGER"><xsl:value-of select="MEIR_CONTACTMANAGER" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_CONTACTMANAGER and not(MEIR_CONTACTMANAGER)">
					<xsl:attribute name="MEIR_CONTACTMANAGER"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_CONTACTMANAGER_PHONE"><xsl:value-of select="MEIR_CONTACTMANAGER_PHONE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_CONTACTMANAGER_PHONE and not(MEIR_CONTACTMANAGER_PHONE)">
					<xsl:attribute name="MEIR_CONTACTMANAGER_PHONE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_CONTACTMANAGER_EMAIL"><xsl:value-of select="MEIR_CONTACTMANAGER_EMAIL" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_CONTACTMANAGER_EMAIL and not(MEIR_CONTACTMANAGER_EMAIL)">
					<xsl:attribute name="MEIR_CONTACTMANAGER_EMAIL"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_CONTACTTECHNICIAN"><xsl:value-of select="MEIR_CONTACTTECHNICIAN" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_CONTACTTECHNICIAN and not(MEIR_CONTACTTECHNICIAN)">
					<xsl:attribute name="MEIR_CONTACTTECHNICIAN"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_CONTACTTECHNICIAN_PHONE"><xsl:value-of select="MEIR_CONTACTTECHNICIAN_PHONE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_CONTACTTECHNICIAN_PHONE and not(MEIR_CONTACTTECHNICIAN_PHONE)">
					<xsl:attribute name="MEIR_CONTACTTECHNICIAN_PHONE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_CONTACTTECHNICIAN_EMAIL"><xsl:value-of select="MEIR_CONTACTTECHNICIAN_EMAIL" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_CONTACTTECHNICIAN_EMAIL and not(MEIR_CONTACTTECHNICIAN_EMAIL)">
					<xsl:attribute name="MEIR_CONTACTTECHNICIAN_EMAIL"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_IS_CC_PBSENCODES"><xsl:value-of select="MEIR_IS_CC_PBSENCODES" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_IS_CC_PBSENCODES and not(MEIR_IS_CC_PBSENCODES)">
					<xsl:attribute name="MEIR_IS_CC_PBSENCODES"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_CC_PROVIDER"><xsl:value-of select="MEIR_CC_PROVIDER" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_CC_PROVIDER and not(MEIR_CC_PROVIDER)">
					<xsl:attribute name="MEIR_CC_PROVIDER"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_IS_CC_PBSCOORDINATES"><xsl:value-of select="MEIR_IS_CC_PBSCOORDINATES" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_IS_CC_PBSCOORDINATES and not(MEIR_IS_CC_PBSCOORDINATES)">
					<xsl:attribute name="MEIR_IS_CC_PBSCOORDINATES"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_PBSCV_ID"><xsl:value-of select="MEIR_PBSCV_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_PBSCV_ID and not(MEIR_PBSCV_ID)">
					<xsl:attribute name="MEIR_PBSCV_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_IS_DVI_PBSENCODES"><xsl:value-of select="MEIR_IS_DVI_PBSENCODES" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_IS_DVI_PBSENCODES and not(MEIR_IS_DVI_PBSENCODES)">
					<xsl:attribute name="MEIR_IS_DVI_PBSENCODES"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_IS_DVI_PBSCOORDINATES"><xsl:value-of select="MEIR_IS_DVI_PBSCOORDINATES" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_IS_DVI_PBSCOORDINATES and not(MEIR_IS_DVI_PBSCOORDINATES)">
					<xsl:attribute name="MEIR_IS_DVI_PBSCOORDINATES"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_IS_SAP_PBSENCODES"><xsl:value-of select="MEIR_IS_SAP_PBSENCODES" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_IS_SAP_PBSENCODES and not(MEIR_IS_SAP_PBSENCODES)">
					<xsl:attribute name="MEIR_IS_SAP_PBSENCODES"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_ISREVISIONREQUIRED"><xsl:value-of select="MEIR_ISREVISIONREQUIRED" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_ISREVISIONREQUIRED and not(MEIR_ISREVISIONREQUIRED)">
					<xsl:attribute name="MEIR_ISREVISIONREQUIRED"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_CLASS"><xsl:value-of select="MEI_CLASS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_CLASS and not(MEI_CLASS)">
					<xsl:attribute name="MEI_CLASS"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_DESCRIPTION"><xsl:value-of select="MEI_DESCRIPTION" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_DESCRIPTION and not(MEI_DESCRIPTION)">
					<xsl:attribute name="MEI_DESCRIPTION"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_ISPREFEEDONLY"><xsl:value-of select="MEI_ISPREFEEDONLY" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_ISPREFEEDONLY and not(MEI_ISPREFEEDONLY)">
					<xsl:attribute name="MEI_ISPREFEEDONLY"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_ISCONTAINERIZED"><xsl:value-of select="MEI_ISCONTAINERIZED" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_ISCONTAINERIZED and not(MEI_ISCONTAINERIZED)">
					<xsl:attribute name="MEI_ISCONTAINERIZED"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_PBSBT_ID"><xsl:value-of select="MEIR_PBSBT_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_PBSBT_ID and not(MEIR_PBSBT_ID)">
					<xsl:attribute name="MEIR_PBSBT_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_PBSBC_ID"><xsl:value-of select="MEIR_PBSBC_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_PBSBC_ID and not(MEIR_PBSBC_ID)">
					<xsl:attribute name="MEIR_PBSBC_ID"></xsl:attribute>
				</xsl:if>
			</xsl:otherwise>
		</xsl:choose>

		<MEDIAINVENTORYCUT>
			<xsl:if test="($RowState=$ROWSTATE_NEW) or ($RowState=$ROWSTATE_BEFORE) or ($RowState=$ROWSTATE_UNCHANGED)">
				<xsl:for-each select="//MediaInventoryRevisionDataSet/MEDIAINVENTORYCUT">
					<xsl:choose>
						<xsl:when test="@diffgr:hasChanges='inserted'">
							<xsl:call-template name="OutputMEDIAINVENTORYCUT">
								<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
							</xsl:call-template>
						</xsl:when>

						<xsl:when test="@diffgr:hasChanges='modified'">
							<xsl:for-each select="key('OriginalMEDIAINVENTORYCUT', @diffgr:id)">
								<xsl:call-template name="OutputMEDIAINVENTORYCUT">
									<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
								</xsl:call-template>
							</xsl:for-each>
							<xsl:call-template name="OutputMEDIAINVENTORYCUT">
								<xsl:with-param name="Original" select="key('OriginalMEDIAINVENTORYCUT', @diffgr:id)" />
								<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
							</xsl:call-template>
						</xsl:when>
					</xsl:choose>
				</xsl:for-each>
				<xsl:for-each select="//diffgr:before/MEDIAINVENTORYCUT">
					<xsl:if test="count(key('CurrentMEDIAINVENTORYCUT', @diffgr:id)) = 0">
						<xsl:call-template name="OutputMEDIAINVENTORYCUT">
							<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
						</xsl:call-template>
					</xsl:if>
				</xsl:for-each>
			</xsl:if>
		</MEDIAINVENTORYCUT>
	</ROW>
</xsl:template>

<xsl:template match="/">
	<DATAPACKET Version="2.0">
	<xsl:call-template name="Output_Schema" />
	<ROWDATA>
		<xsl:for-each select="//MediaInventoryRevisionDataSet/MEDIAINVENTORYREVISION">
			<xsl:choose>
				<xsl:when test="@diffgr:hasChanges='inserted'">
					<xsl:call-template name="OutputMEDIAINVENTORYREVISION">
						<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
					</xsl:call-template>
				</xsl:when>

				<xsl:when test="@diffgr:hasChanges='modified'">
					<xsl:for-each select="key('OriginalMEDIAINVENTORYREVISION', @diffgr:id)">
						<xsl:call-template name="OutputMEDIAINVENTORYREVISION">
							<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
						</xsl:call-template>
					</xsl:for-each>
					<xsl:call-template name="OutputMEDIAINVENTORYREVISION">
						<xsl:with-param name="Original" select="key('OriginalMEDIAINVENTORYREVISION', @diffgr:id)" />
						<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
					</xsl:call-template>
				</xsl:when>

				<xsl:otherwise>
					<xsl:call-template name="OutputMEDIAINVENTORYREVISION">
						<xsl:with-param name="RowState" select="$ROWSTATE_UNCHANGED" />
					</xsl:call-template>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:for-each>
		<xsl:for-each select="//diffgr:before/MEDIAINVENTORYREVISION">
			<xsl:if test="count(key('CurrentMEDIAINVENTORYREVISION', @diffgr:id)) = 0">
				<xsl:call-template name="OutputMEDIAINVENTORYREVISION">
					<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
				</xsl:call-template>
			</xsl:if>
		</xsl:for-each>
	</ROWDATA>
	</DATAPACKET>
</xsl:template>
</xsl:stylesheet>
