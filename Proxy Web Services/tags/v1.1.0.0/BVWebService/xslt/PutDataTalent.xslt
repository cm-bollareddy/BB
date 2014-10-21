<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1" xmlns:msxsl="urn:schemas-microsoft-com:xslt" version="1.0">

<xsl:output method="xml" />

<xsl:variable name="ROWSTATE_BEFORE">1</xsl:variable>
<xsl:variable name="ROWSTATE_DELETED">2</xsl:variable>
<xsl:variable name="ROWSTATE_NEW">4</xsl:variable>
<xsl:variable name="ROWSTATE_DETACHED">6</xsl:variable> <!-- This one we do not use -->
<xsl:variable name="ROWSTATE_AFTER">8</xsl:variable>
<xsl:variable name="ROWSTATE_UNCHANGED">64</xsl:variable>

<xsl:key name="OriginalTALENT" match="//diffgr:before/TALENT" use="@diffgr:id" />
<xsl:key name="CurrentTALENT" match="//TalentDataSet/TALENT" use="@diffgr:id" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<METADATA><FIELDS><FIELD attrname="TAL_ID" fieldtype="i4" required="true"><PARAM Name="PROVFLAGS" Value="7" Type="i4" Roundtrip="True" /><PARAM Name="ORIGIN" Value="TALENT.TAL_ID" Roundtrip="True" /></FIELD><FIELD attrname="TAL_NAME" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="TALENT.TAL_NAME" Roundtrip="True" /></FIELD><FIELD attrname="TAL_NAMEFIRST" fieldtype="string" WIDTH="40"><PARAM Name="ORIGIN" Value="TALENT.TAL_NAMEFIRST" Roundtrip="True" /></FIELD><FIELD attrname="TAL_NAMELAST" fieldtype="string" WIDTH="40"><PARAM Name="ORIGIN" Value="TALENT.TAL_NAMELAST" Roundtrip="True" /></FIELD></FIELDS><PARAMS DATASET_DELTA="TRUE" PRIMARY_KEY="1" /></METADATA>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template name="OutputTALENT">
<xsl:param name="Original" />
<xsl:param name="RowState"><xsl:value-of select="$ROWSTATE_UNCHANGED" /></xsl:param>
	<ROW>
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
				<xsl:if test="(not(msxsl:node-set($Original)/TAL_NAMEFIRST) and TAL_NAMEFIRST) or (msxsl:node-set($Original)/TAL_NAMEFIRST != TAL_NAMEFIRST)">
					<xsl:attribute name="TAL_NAMEFIRST"><xsl:value-of select="TAL_NAMEFIRST" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/TAL_NAMEFIRST and not(TAL_NAMEFIRST)">
					<xsl:attribute name="TAL_NAMEFIRST"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/TAL_NAMELAST) and TAL_NAMELAST) or (msxsl:node-set($Original)/TAL_NAMELAST != TAL_NAMELAST)">
					<xsl:attribute name="TAL_NAMELAST"><xsl:value-of select="TAL_NAMELAST" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/TAL_NAMELAST and not(TAL_NAMELAST)">
					<xsl:attribute name="TAL_NAMELAST"></xsl:attribute>
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
				<xsl:attribute name="TAL_NAMEFIRST"><xsl:value-of select="TAL_NAMEFIRST" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/TAL_NAMEFIRST and not(TAL_NAMEFIRST)">
					<xsl:attribute name="TAL_NAMEFIRST"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="TAL_NAMELAST"><xsl:value-of select="TAL_NAMELAST" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/TAL_NAMELAST and not(TAL_NAMELAST)">
					<xsl:attribute name="TAL_NAMELAST"></xsl:attribute>
				</xsl:if>
			</xsl:otherwise>
		</xsl:choose>

	</ROW>
</xsl:template>

<xsl:template match="/">
	<DATAPACKET Version="2.0">
	<xsl:call-template name="Output_Schema" />
	<ROWDATA>
		<xsl:for-each select="//TalentDataSet/TALENT">
			<xsl:choose>
				<xsl:when test="@diffgr:hasChanges='inserted'">
					<xsl:call-template name="OutputTALENT">
						<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
					</xsl:call-template>
				</xsl:when>

				<xsl:when test="@diffgr:hasChanges='modified'">
					<xsl:for-each select="key('OriginalTALENT', @diffgr:id)">
						<xsl:call-template name="OutputTALENT">
							<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
						</xsl:call-template>
					</xsl:for-each>
					<xsl:call-template name="OutputTALENT">
						<xsl:with-param name="Original" select="key('OriginalTALENT', @diffgr:id)" />
						<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
					</xsl:call-template>
				</xsl:when>
			</xsl:choose>
		</xsl:for-each>
		<xsl:for-each select="//diffgr:before/TALENT">
			<xsl:if test="count(key('CurrentTALENT', @diffgr:id)) = 0">
				<xsl:call-template name="OutputTALENT">
					<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
				</xsl:call-template>
			</xsl:if>
		</xsl:for-each>
	</ROWDATA>
	</DATAPACKET>
</xsl:template>
</xsl:stylesheet>
