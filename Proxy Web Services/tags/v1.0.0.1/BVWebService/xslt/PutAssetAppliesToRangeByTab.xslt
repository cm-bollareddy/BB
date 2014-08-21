<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1" xmlns:msxsl="urn:schemas-microsoft-com:xslt" version="1.0">

<xsl:output method="xml" />

<xsl:variable name="ROWSTATE_BEFORE">1</xsl:variable>
<xsl:variable name="ROWSTATE_DELETED">2</xsl:variable>
<xsl:variable name="ROWSTATE_NEW">4</xsl:variable>
<xsl:variable name="ROWSTATE_DETACHED">6</xsl:variable> <!-- This one we do not use -->
<xsl:variable name="ROWSTATE_AFTER">8</xsl:variable>
<xsl:variable name="ROWSTATE_UNCHANGED">64</xsl:variable>

<xsl:key name="OriginalASSETAPPLIESTORANGE" match="//diffgr:before/ASSETAPPLIESTORANGE" use="@diffgr:id" />
<xsl:key name="CurrentASSETAPPLIESTORANGE" match="//AssetAppliesToRangeByTabDataSet/ASSETAPPLIESTORANGE" use="@diffgr:id" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<METADATA><FIELDS><FIELD attrname="ASS_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_ASSETAPPLIESTORANGE.ASS_ID" Roundtrip="True" /></FIELD><FIELD attrname="ASS_TITLE" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="VW_ASSETAPPLIESTORANGE.ASS_TITLE" Roundtrip="True" /></FIELD><FIELD attrname="ASS_EPISODENUMBER" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="VW_ASSETAPPLIESTORANGE.ASS_EPISODENUMBER" Roundtrip="True" /></FIELD><FIELD attrname="ASS_EPISODETITLE" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="VW_ASSETAPPLIESTORANGE.ASS_EPISODETITLE" Roundtrip="True" /></FIELD><FIELD attrname="TABID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_ASSETAPPLIESTORANGE.TABID" Roundtrip="True" /></FIELD><FIELD attrname="TABTYPE" fieldtype="string" SUBTYPE="FixedChar" WIDTH="3"><PARAM Name="ORIGIN" Value="VW_ASSETAPPLIESTORANGE.TABTYPE" Roundtrip="True" /></FIELD><FIELD attrname="DEALID" fieldtype="i4" readonly="true" /></FIELDS><PARAMS DATASET_DELTA="TRUE" /></METADATA>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template name="OutputASSETAPPLIESTORANGE">
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
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_TITLE) and ASS_TITLE) or (msxsl:node-set($Original)/ASS_TITLE != ASS_TITLE)">
					<xsl:attribute name="ASS_TITLE"><xsl:value-of select="ASS_TITLE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_TITLE and not(ASS_TITLE)">
					<xsl:attribute name="ASS_TITLE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_EPISODENUMBER) and ASS_EPISODENUMBER) or (msxsl:node-set($Original)/ASS_EPISODENUMBER != ASS_EPISODENUMBER)">
					<xsl:attribute name="ASS_EPISODENUMBER"><xsl:value-of select="ASS_EPISODENUMBER" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_EPISODENUMBER and not(ASS_EPISODENUMBER)">
					<xsl:attribute name="ASS_EPISODENUMBER"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/ASS_EPISODETITLE) and ASS_EPISODETITLE) or (msxsl:node-set($Original)/ASS_EPISODETITLE != ASS_EPISODETITLE)">
					<xsl:attribute name="ASS_EPISODETITLE"><xsl:value-of select="ASS_EPISODETITLE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ASS_EPISODETITLE and not(ASS_EPISODETITLE)">
					<xsl:attribute name="ASS_EPISODETITLE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/TABID) and TABID) or (msxsl:node-set($Original)/TABID != TABID)">
					<xsl:attribute name="TABID"><xsl:value-of select="TABID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/TABID and not(TABID)">
					<xsl:attribute name="TABID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/TABTYPE) and TABTYPE) or (msxsl:node-set($Original)/TABTYPE != TABTYPE)">
					<xsl:attribute name="TABTYPE"><xsl:value-of select="TABTYPE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/TABTYPE and not(TABTYPE)">
					<xsl:attribute name="TABTYPE"></xsl:attribute>
				</xsl:if>
			</xsl:when>
			<xsl:otherwise>
				<xsl:attribute name="ASS_ID"><xsl:value-of select="ASS_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_ID and not(ASS_ID)">
					<xsl:attribute name="ASS_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ASS_TITLE"><xsl:value-of select="ASS_TITLE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_TITLE and not(ASS_TITLE)">
					<xsl:attribute name="ASS_TITLE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ASS_EPISODENUMBER"><xsl:value-of select="ASS_EPISODENUMBER" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_EPISODENUMBER and not(ASS_EPISODENUMBER)">
					<xsl:attribute name="ASS_EPISODENUMBER"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ASS_EPISODETITLE"><xsl:value-of select="ASS_EPISODETITLE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ASS_EPISODETITLE and not(ASS_EPISODETITLE)">
					<xsl:attribute name="ASS_EPISODETITLE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="TABID"><xsl:value-of select="TABID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/TABID and not(TABID)">
					<xsl:attribute name="TABID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="TABTYPE"><xsl:value-of select="TABTYPE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/TABTYPE and not(TABTYPE)">
					<xsl:attribute name="TABTYPE"></xsl:attribute>
				</xsl:if>
			</xsl:otherwise>
		</xsl:choose>

	</ROW>
</xsl:template>

<xsl:template match="/">
	<DATAPACKET Version="2.0">
	<xsl:call-template name="Output_Schema" />
	<ROWDATA>
		<xsl:for-each select="//AssetAppliesToRangeByTabDataSet/ASSETAPPLIESTORANGE">
			<xsl:choose>
				<xsl:when test="@diffgr:hasChanges='inserted'">
					<xsl:call-template name="OutputASSETAPPLIESTORANGE">
						<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
					</xsl:call-template>
				</xsl:when>

				<xsl:when test="@diffgr:hasChanges='modified'">
					<xsl:for-each select="key('OriginalASSETAPPLIESTORANGE', @diffgr:id)">
						<xsl:call-template name="OutputASSETAPPLIESTORANGE">
							<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
						</xsl:call-template>
					</xsl:for-each>
					<xsl:call-template name="OutputASSETAPPLIESTORANGE">
						<xsl:with-param name="Original" select="key('OriginalASSETAPPLIESTORANGE', @diffgr:id)" />
						<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
					</xsl:call-template>
				</xsl:when>
			</xsl:choose>
		</xsl:for-each>
		<xsl:for-each select="//diffgr:before/ASSETAPPLIESTORANGE">
			<xsl:if test="count(key('CurrentASSETAPPLIESTORANGE', @diffgr:id)) = 0">
				<xsl:call-template name="OutputASSETAPPLIESTORANGE">
					<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
				</xsl:call-template>
			</xsl:if>
		</xsl:for-each>
	</ROWDATA>
	</DATAPACKET>
</xsl:template>
</xsl:stylesheet>
