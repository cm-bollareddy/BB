<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1" xmlns:msxsl="urn:schemas-microsoft-com:xslt" version="1.0">

<xsl:output method="xml" />

<xsl:variable name="ROWSTATE_BEFORE">1</xsl:variable>
<xsl:variable name="ROWSTATE_DELETED">2</xsl:variable>
<xsl:variable name="ROWSTATE_NEW">4</xsl:variable>
<xsl:variable name="ROWSTATE_DETACHED">6</xsl:variable> <!-- This one we do not use -->
<xsl:variable name="ROWSTATE_AFTER">8</xsl:variable>
<xsl:variable name="ROWSTATE_UNCHANGED">64</xsl:variable>

<xsl:key name="OriginalASSET" match="//diffgr:before/ASSET" use="@diffgr:id" />
<xsl:key name="CurrentASSET" match="//ProgramDetailsDataSet/ASSET" use="@diffgr:id" />
<xsl:key name="OriginalCASTTABLE" match="//diffgr:before/CASTTABLE" use="@diffgr:id" />
<xsl:key name="CurrentCASTTABLE" match="//ProgramDetailsDataSet/CASTTABLE" use="@diffgr:id" />
<xsl:key name="OriginalASSET_PBSPROGRAMKEYWORD" match="//diffgr:before/ASSET_PBSPROGRAMKEYWORD" use="@diffgr:id" />
<xsl:key name="CurrentASSET_PBSPROGRAMKEYWORD" match="//ProgramDetailsDataSet/ASSET_PBSPROGRAMKEYWORD" use="@diffgr:id" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<METADATA><FIELDS><FIELD attrname="ASS_ID" fieldtype="i4" required="true"><PARAM Name="PROVFLAGS" Value="7" Type="i4" Roundtrip="True" /><PARAM Name="ORIGIN" Value="ASSET.ASS_ID" Roundtrip="True" /></FIELD><FIELD attrname="ASS_EPISODENUMBER" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="ASSET.ASS_EPISODENUMBER" Roundtrip="True" /></FIELD><FIELD attrname="ASS_TITLE" fieldtype="string" required="true" WIDTH="80"><PARAM Name="ORIGIN" Value="ASSET.ASS_TITLE" Roundtrip="True" /></FIELD><FIELD attrname="ASS_EPISODETITLE" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="ASSET.ASS_EPISODETITLE" Roundtrip="True" /></FIELD><FIELD attrname="ASS_PBS_ISFINALTITLE" fieldtype="i2"><PARAM Name="ORIGIN" Value="ASSET.ASS_PBS_ISFINALTITLE" Roundtrip="True" /></FIELD><FIELD attrname="ASS_PBSTITLEPREVIOUS" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="ASSET.ASS_PBSTITLEPREVIOUS" Roundtrip="True" /></FIELD><FIELD attrname="ASS_EPISODESLATE" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="ASSET.ASS_EPISODESLATE" Roundtrip="True" /></FIELD><FIELD attrname="ASS_SYNOPSIS" fieldtype="bin.hex" SUBTYPE="Text" WIDTH="8"><PARAM Name="ORIGIN" Value="ASSET.ASS_SYNOPSIS" Roundtrip="True" /></FIELD><FIELD attrname="ASS_PBSPICTURELOCKDATE" fieldtype="dateTime"><PARAM Name="ORIGIN" Value="ASSET.ASS_PBSPICTURELOCKDATE" Roundtrip="True" /></FIELD><FIELD attrname="ASS_EPGTEXT" fieldtype="bin.hex" SUBTYPE="Text" WIDTH="8"><PARAM Name="ORIGIN" Value="ASSET.ASS_EPGTEXT" Roundtrip="True" /></FIELD><FIELD attrname="ASS_TITLELISTING" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="ASSET.ASS_TITLELISTING" Roundtrip="True" /></FIELD><FIELD attrname="DEAL_ID" fieldtype="i4" readonly="true" /><FIELD attrname="ASS_ACA_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="ASSET.ASS_ACA_ID" Roundtrip="True" /></FIELD><FIELD attrname="ASS_PMC_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="ASSET.ASS_PMC_ID" Roundtrip="True" /></FIELD><FIELD attrname="ASS_PVA_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="ASSET.ASS_PVA_ID" Roundtrip="True" /></FIELD><FIELD attrname="PREMIEREDATETIME" fieldtype="dateTime" readonly="true" /><FIELD attrname="CASTTABLE" fieldtype="nested"><FIELDS><FIELD attrname="TAL_ID" fieldtype="i4" required="true"><PARAM Name="ORIGIN" Value="TALENT.TAL_ID" Roundtrip="True" /></FIELD><FIELD attrname="TAL_NAME" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="TALENT.TAL_NAME" Roundtrip="True" /></FIELD><FIELD attrname="TRO_ID" fieldtype="i4" required="true"><PARAM Name="ORIGIN" Value="TALENTROLES.TRO_ID" Roundtrip="True" /></FIELD><FIELD attrname="ASS_TAL_DESC" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="ASSET_TALENT.ASS_TAL_DESC" Roundtrip="True" /></FIELD><FIELD attrname="ASS_ID" fieldtype="i4" required="true"><PARAM Name="ORIGIN" Value="ASSET_TALENT.ASS_ID" Roundtrip="True" /></FIELD></FIELDS><PARAMS DATASET_DELTA="TRUE" /></FIELD><FIELD attrname="ASSET_PBSPROGRAMKEYWORD" fieldtype="nested"><FIELDS><FIELD attrname="PBSPK_ID" fieldtype="i4" required="true"><PARAM Name="PROVFLAGS" Value="7" Type="i4" Roundtrip="True" /><PARAM Name="ORIGIN" Value="ASSET_PBSPROGRAMKEYWORD.PBSPK_ID" Roundtrip="True" /></FIELD><FIELD attrname="ASS_ID" fieldtype="i4" required="true"><PARAM Name="PROVFLAGS" Value="7" Type="i4" Roundtrip="True" /><PARAM Name="ORIGIN" Value="ASSET_PBSPROGRAMKEYWORD.ASS_ID" Roundtrip="True" /></FIELD></FIELDS><PARAMS DATASET_DELTA="TRUE" PRIMARY_KEY="1 2" /></FIELD></FIELDS><PARAMS DATASET_DELTA="TRUE" PRIMARY_KEY="1"><PARAM Name="MD_FIELDLINKS" Value="17 1 5" Type="IntArray" /><PARAM Name="MD_FIELDLINKS" Value="18 1 2" Type="IntArray" /></PARAMS></METADATA>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template name="OutputCASTTABLE">
<xsl:param name="Original" />
<xsl:param name="RowState"><xsl:value-of select="$ROWSTATE_UNCHANGED" /></xsl:param>
	<ROWCASTTABLE>
		<xsl:attribute name="RowState"><xsl:value-of select="$RowState" /></xsl:attribute>
		<xsl:choose>
			<xsl:when test="$RowState = $ROWSTATE_AFTER">
				<xsl:if test="(not(msxsl:node-set($Original)/TAL_ID) and TAL_ID) or (msxsl:node-set($Original)/TAL_ID != TAL_ID)">
					<xsl:attribute name="TAL_ID"><xsl:value-of select="TAL_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/TAL_ID and not(TAL_ID)">
					<xsl:attribute name="TAL_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/TAL_NAME) and TAL_NAME) or (msxsl:node-set($Original)/TAL_NAME != TAL_NAME)">
					<xsl:attribute name="TAL_NAME"><xsl:value-of select="TAL_NAME" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/TAL_NAME and not(TAL_NAME)">
					<xsl:attribute name="TAL_NAME"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/TRO_ID) and TRO_ID) or (msxsl:node-set($Original)/TRO_ID != TRO_ID)">
					<xsl:attribute name="TRO_ID"><xsl:value-of select="TRO_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/TRO_ID and not(TRO_ID)">
					<xsl:attribute name="TRO_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_TAL_DESC) and ASS_TAL_DESC) or (msxsl:node-set($Original)/ASS_TAL_DESC != ASS_TAL_DESC)">
					<xsl:attribute name="ASS_TAL_DESC"><xsl:value-of select="ASS_TAL_DESC" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_TAL_DESC and not(ASS_TAL_DESC)">
					<xsl:attribute name="ASS_TAL_DESC"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_ID) and ASS_ID) or (msxsl:node-set($Original)/ASS_ID != ASS_ID)">
					<xsl:attribute name="ASS_ID"><xsl:value-of select="ASS_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_ID and not(ASS_ID)">
					<xsl:attribute name="ASS_ID"></xsl:attribute>
				</xsl:if>
			</xsl:when>
			<xsl:otherwise>
				<xsl:attribute name="TAL_ID"><xsl:value-of select="TAL_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/TAL_ID and not(TAL_ID)">
					<xsl:attribute name="TAL_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="TAL_NAME"><xsl:value-of select="TAL_NAME" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/TAL_NAME and not(TAL_NAME)">
					<xsl:attribute name="TAL_NAME"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="TRO_ID"><xsl:value-of select="TRO_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/TRO_ID and not(TRO_ID)">
					<xsl:attribute name="TRO_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ASS_TAL_DESC"><xsl:value-of select="ASS_TAL_DESC" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_TAL_DESC and not(ASS_TAL_DESC)">
					<xsl:attribute name="ASS_TAL_DESC"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ASS_ID"><xsl:value-of select="ASS_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_ID and not(ASS_ID)">
					<xsl:attribute name="ASS_ID"></xsl:attribute>
				</xsl:if>
			</xsl:otherwise>
		</xsl:choose>

	</ROWCASTTABLE>
</xsl:template>

<xsl:template name="OutputASSET_PBSPROGRAMKEYWORD">
<xsl:param name="Original" />
<xsl:param name="RowState"><xsl:value-of select="$ROWSTATE_UNCHANGED" /></xsl:param>
	<ROWASSET_PBSPROGRAMKEYWORD>
		<xsl:attribute name="RowState"><xsl:value-of select="$RowState" /></xsl:attribute>
		<xsl:choose>
			<xsl:when test="$RowState = $ROWSTATE_AFTER">
				<xsl:if test="(not(msxsl:node-set($Original)/PBSPK_ID) and PBSPK_ID) or (msxsl:node-set($Original)/PBSPK_ID != PBSPK_ID)">
					<xsl:attribute name="PBSPK_ID"><xsl:value-of select="PBSPK_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PBSPK_ID and not(PBSPK_ID)">
					<xsl:attribute name="PBSPK_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_ID) and ASS_ID) or (msxsl:node-set($Original)/ASS_ID != ASS_ID)">
					<xsl:attribute name="ASS_ID"><xsl:value-of select="ASS_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_ID and not(ASS_ID)">
					<xsl:attribute name="ASS_ID"></xsl:attribute>
				</xsl:if>
			</xsl:when>
			<xsl:otherwise>
				<xsl:attribute name="PBSPK_ID"><xsl:value-of select="PBSPK_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PBSPK_ID and not(PBSPK_ID)">
					<xsl:attribute name="PBSPK_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ASS_ID"><xsl:value-of select="ASS_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_ID and not(ASS_ID)">
					<xsl:attribute name="ASS_ID"></xsl:attribute>
				</xsl:if>
			</xsl:otherwise>
		</xsl:choose>

	</ROWASSET_PBSPROGRAMKEYWORD>
</xsl:template>

<xsl:template name="OutputASSET">
<xsl:param name="Original" />
<xsl:param name="RowState"><xsl:value-of select="$ROWSTATE_UNCHANGED" /></xsl:param>
	<ROW>
		<xsl:attribute name="RowState"><xsl:value-of select="$RowState" /></xsl:attribute>
		<xsl:choose>
			<xsl:when test="$RowState = $ROWSTATE_AFTER">
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_ID) and ASS_ID) or (msxsl:node-set($Original)/ASS_ID != ASS_ID)">
					<xsl:attribute name="ASS_ID"><xsl:value-of select="ASS_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_ID and not(ASS_ID)">
					<xsl:attribute name="ASS_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_EPISODENUMBER) and ASS_EPISODENUMBER) or (msxsl:node-set($Original)/ASS_EPISODENUMBER != ASS_EPISODENUMBER)">
					<xsl:attribute name="ASS_EPISODENUMBER"><xsl:value-of select="ASS_EPISODENUMBER" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_EPISODENUMBER and not(ASS_EPISODENUMBER)">
					<xsl:attribute name="ASS_EPISODENUMBER"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_TITLE) and ASS_TITLE) or (msxsl:node-set($Original)/ASS_TITLE != ASS_TITLE)">
					<xsl:attribute name="ASS_TITLE"><xsl:value-of select="ASS_TITLE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_TITLE and not(ASS_TITLE)">
					<xsl:attribute name="ASS_TITLE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_EPISODETITLE) and ASS_EPISODETITLE) or (msxsl:node-set($Original)/ASS_EPISODETITLE != ASS_EPISODETITLE)">
					<xsl:attribute name="ASS_EPISODETITLE"><xsl:value-of select="ASS_EPISODETITLE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_EPISODETITLE and not(ASS_EPISODETITLE)">
					<xsl:attribute name="ASS_EPISODETITLE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_PBS_ISFINALTITLE) and ASS_PBS_ISFINALTITLE) or (msxsl:node-set($Original)/ASS_PBS_ISFINALTITLE != ASS_PBS_ISFINALTITLE)">
					<xsl:attribute name="ASS_PBS_ISFINALTITLE"><xsl:value-of select="ASS_PBS_ISFINALTITLE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_PBS_ISFINALTITLE and not(ASS_PBS_ISFINALTITLE)">
					<xsl:attribute name="ASS_PBS_ISFINALTITLE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_PBSTITLEPREVIOUS) and ASS_PBSTITLEPREVIOUS) or (msxsl:node-set($Original)/ASS_PBSTITLEPREVIOUS != ASS_PBSTITLEPREVIOUS)">
					<xsl:attribute name="ASS_PBSTITLEPREVIOUS"><xsl:value-of select="ASS_PBSTITLEPREVIOUS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_PBSTITLEPREVIOUS and not(ASS_PBSTITLEPREVIOUS)">
					<xsl:attribute name="ASS_PBSTITLEPREVIOUS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_EPISODESLATE) and ASS_EPISODESLATE) or (msxsl:node-set($Original)/ASS_EPISODESLATE != ASS_EPISODESLATE)">
					<xsl:attribute name="ASS_EPISODESLATE"><xsl:value-of select="ASS_EPISODESLATE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_EPISODESLATE and not(ASS_EPISODESLATE)">
					<xsl:attribute name="ASS_EPISODESLATE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="ASS_SYNOPSIS != '' and (not(msxsl:node-set($Original)/ASS_SYNOPSIS) and ASS_SYNOPSIS) or (msxsl:node-set($Original)/ASS_SYNOPSIS != ASS_SYNOPSIS)">
					<xsl:attribute name="ASS_SYNOPSIS"><xsl:value-of select="ASS_SYNOPSIS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_SYNOPSIS and not(ASS_SYNOPSIS)">
					<xsl:attribute name="ASS_SYNOPSIS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_PBSPICTURELOCKDATE) and ASS_PBSPICTURELOCKDATE) or (msxsl:node-set($Original)/ASS_PBSPICTURELOCKDATE != ASS_PBSPICTURELOCKDATE)">
					<xsl:attribute name="ASS_PBSPICTURELOCKDATE"><xsl:value-of select="ASS_PBSPICTURELOCKDATE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_PBSPICTURELOCKDATE and not(ASS_PBSPICTURELOCKDATE)">
					<xsl:attribute name="ASS_PBSPICTURELOCKDATE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="ASS_EPGTEXT != '' and (not(msxsl:node-set($Original)/ASS_EPGTEXT) and ASS_EPGTEXT) or (msxsl:node-set($Original)/ASS_EPGTEXT != ASS_EPGTEXT)">
					<xsl:attribute name="ASS_EPGTEXT"><xsl:value-of select="ASS_EPGTEXT" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_EPGTEXT and not(ASS_EPGTEXT)">
					<xsl:attribute name="ASS_EPGTEXT"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_TITLELISTING) and ASS_TITLELISTING) or (msxsl:node-set($Original)/ASS_TITLELISTING != ASS_TITLELISTING)">
					<xsl:attribute name="ASS_TITLELISTING"><xsl:value-of select="ASS_TITLELISTING" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_TITLELISTING and not(ASS_TITLELISTING)">
					<xsl:attribute name="ASS_TITLELISTING"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_ACA_ID) and ASS_ACA_ID) or (msxsl:node-set($Original)/ASS_ACA_ID != ASS_ACA_ID)">
					<xsl:attribute name="ASS_ACA_ID"><xsl:value-of select="ASS_ACA_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_ACA_ID and not(ASS_ACA_ID)">
					<xsl:attribute name="ASS_ACA_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_PMC_ID) and ASS_PMC_ID) or (msxsl:node-set($Original)/ASS_PMC_ID != ASS_PMC_ID)">
					<xsl:attribute name="ASS_PMC_ID"><xsl:value-of select="ASS_PMC_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_PMC_ID and not(ASS_PMC_ID)">
					<xsl:attribute name="ASS_PMC_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_PVA_ID) and ASS_PVA_ID) or (msxsl:node-set($Original)/ASS_PVA_ID != ASS_PVA_ID)">
					<xsl:attribute name="ASS_PVA_ID"><xsl:value-of select="ASS_PVA_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_PVA_ID and not(ASS_PVA_ID)">
					<xsl:attribute name="ASS_PVA_ID"></xsl:attribute>
				</xsl:if>
			</xsl:when>
			<xsl:otherwise>
				<xsl:attribute name="ASS_ID"><xsl:value-of select="ASS_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_ID and not(ASS_ID)">
					<xsl:attribute name="ASS_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ASS_EPISODENUMBER"><xsl:value-of select="ASS_EPISODENUMBER" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_EPISODENUMBER and not(ASS_EPISODENUMBER)">
					<xsl:attribute name="ASS_EPISODENUMBER"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ASS_TITLE"><xsl:value-of select="ASS_TITLE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_TITLE and not(ASS_TITLE)">
					<xsl:attribute name="ASS_TITLE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ASS_EPISODETITLE"><xsl:value-of select="ASS_EPISODETITLE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_EPISODETITLE and not(ASS_EPISODETITLE)">
					<xsl:attribute name="ASS_EPISODETITLE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ASS_PBS_ISFINALTITLE"><xsl:value-of select="ASS_PBS_ISFINALTITLE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_PBS_ISFINALTITLE and not(ASS_PBS_ISFINALTITLE)">
					<xsl:attribute name="ASS_PBS_ISFINALTITLE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ASS_PBSTITLEPREVIOUS"><xsl:value-of select="ASS_PBSTITLEPREVIOUS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_PBSTITLEPREVIOUS and not(ASS_PBSTITLEPREVIOUS)">
					<xsl:attribute name="ASS_PBSTITLEPREVIOUS"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ASS_EPISODESLATE"><xsl:value-of select="ASS_EPISODESLATE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_EPISODESLATE and not(ASS_EPISODESLATE)">
					<xsl:attribute name="ASS_EPISODESLATE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="ASS_SYNOPSIS != ''">
					<xsl:attribute name="ASS_SYNOPSIS"><xsl:value-of select="ASS_SYNOPSIS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_SYNOPSIS and not(ASS_SYNOPSIS)">
					<xsl:attribute name="ASS_SYNOPSIS"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ASS_PBSPICTURELOCKDATE"><xsl:value-of select="ASS_PBSPICTURELOCKDATE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_PBSPICTURELOCKDATE and not(ASS_PBSPICTURELOCKDATE)">
					<xsl:attribute name="ASS_PBSPICTURELOCKDATE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="ASS_EPGTEXT != ''">
					<xsl:attribute name="ASS_EPGTEXT"><xsl:value-of select="ASS_EPGTEXT" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_EPGTEXT and not(ASS_EPGTEXT)">
					<xsl:attribute name="ASS_EPGTEXT"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ASS_TITLELISTING"><xsl:value-of select="ASS_TITLELISTING" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_TITLELISTING and not(ASS_TITLELISTING)">
					<xsl:attribute name="ASS_TITLELISTING"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ASS_ACA_ID"><xsl:value-of select="ASS_ACA_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_ACA_ID and not(ASS_ACA_ID)">
					<xsl:attribute name="ASS_ACA_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ASS_PMC_ID"><xsl:value-of select="ASS_PMC_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_PMC_ID and not(ASS_PMC_ID)">
					<xsl:attribute name="ASS_PMC_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ASS_PVA_ID"><xsl:value-of select="ASS_PVA_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_PVA_ID and not(ASS_PVA_ID)">
					<xsl:attribute name="ASS_PVA_ID"></xsl:attribute>
				</xsl:if>
			</xsl:otherwise>
		</xsl:choose>

		<CASTTABLE>
			<xsl:if test="($RowState=$ROWSTATE_NEW) or ($RowState=$ROWSTATE_BEFORE) or ($RowState=$ROWSTATE_UNCHANGED)">
				<xsl:for-each select="//ProgramDetailsDataSet/CASTTABLE">
					<xsl:choose>
						<xsl:when test="@diffgr:hasChanges='inserted'">
							<xsl:call-template name="OutputCASTTABLE">
								<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
							</xsl:call-template>
						</xsl:when>

						<xsl:when test="@diffgr:hasChanges='modified'">
							<xsl:for-each select="key('OriginalCASTTABLE', @diffgr:id)">
								<xsl:call-template name="OutputCASTTABLE">
									<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
								</xsl:call-template>
							</xsl:for-each>
							<xsl:call-template name="OutputCASTTABLE">
								<xsl:with-param name="Original" select="key('OriginalCASTTABLE', @diffgr:id)" />
								<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
							</xsl:call-template>
						</xsl:when>
					</xsl:choose>
				</xsl:for-each>
				<xsl:for-each select="//diffgr:before/CASTTABLE">
					<xsl:if test="count(key('CurrentCASTTABLE', @diffgr:id)) = 0">
						<xsl:call-template name="OutputCASTTABLE">
							<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
						</xsl:call-template>
					</xsl:if>
				</xsl:for-each>
			</xsl:if>
		</CASTTABLE>
		<ASSET_PBSPROGRAMKEYWORD>
			<xsl:if test="($RowState=$ROWSTATE_NEW) or ($RowState=$ROWSTATE_BEFORE) or ($RowState=$ROWSTATE_UNCHANGED)">
				<xsl:for-each select="//ProgramDetailsDataSet/ASSET_PBSPROGRAMKEYWORD">
					<xsl:choose>
						<xsl:when test="@diffgr:hasChanges='inserted'">
							<xsl:call-template name="OutputASSET_PBSPROGRAMKEYWORD">
								<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
							</xsl:call-template>
						</xsl:when>

						<xsl:when test="@diffgr:hasChanges='modified'">
							<xsl:for-each select="key('OriginalASSET_PBSPROGRAMKEYWORD', @diffgr:id)">
								<xsl:call-template name="OutputASSET_PBSPROGRAMKEYWORD">
									<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
								</xsl:call-template>
							</xsl:for-each>
							<xsl:call-template name="OutputASSET_PBSPROGRAMKEYWORD">
								<xsl:with-param name="Original" select="key('OriginalASSET_PBSPROGRAMKEYWORD', @diffgr:id)" />
								<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
							</xsl:call-template>
						</xsl:when>
					</xsl:choose>
				</xsl:for-each>
				<xsl:for-each select="//diffgr:before/ASSET_PBSPROGRAMKEYWORD">
					<xsl:if test="count(key('CurrentASSET_PBSPROGRAMKEYWORD', @diffgr:id)) = 0">
						<xsl:call-template name="OutputASSET_PBSPROGRAMKEYWORD">
							<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
						</xsl:call-template>
					</xsl:if>
				</xsl:for-each>
			</xsl:if>
		</ASSET_PBSPROGRAMKEYWORD>
	</ROW>
</xsl:template>

<xsl:template match="/">
	<DATAPACKET Version="2.0">
	<xsl:call-template name="Output_Schema" />
	<ROWDATA>
		<xsl:for-each select="//ProgramDetailsDataSet/ASSET">
			<xsl:choose>
				<xsl:when test="@diffgr:hasChanges='inserted'">
					<xsl:call-template name="OutputASSET">
						<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
					</xsl:call-template>
				</xsl:when>

				<xsl:when test="@diffgr:hasChanges='modified'">
					<xsl:for-each select="key('OriginalASSET', @diffgr:id)">
						<xsl:call-template name="OutputASSET">
							<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
						</xsl:call-template>
					</xsl:for-each>
					<xsl:call-template name="OutputASSET">
						<xsl:with-param name="Original" select="key('OriginalASSET', @diffgr:id)" />
						<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
					</xsl:call-template>
				</xsl:when>

				<xsl:otherwise>
					<xsl:call-template name="OutputASSET">
						<xsl:with-param name="RowState" select="$ROWSTATE_UNCHANGED" />
					</xsl:call-template>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:for-each>
		<xsl:for-each select="//diffgr:before/ASSET">
			<xsl:if test="count(key('CurrentASSET', @diffgr:id)) = 0">
				<xsl:call-template name="OutputASSET">
					<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
				</xsl:call-template>
			</xsl:if>
		</xsl:for-each>
	</ROWDATA>
	</DATAPACKET>
</xsl:template>
</xsl:stylesheet>
