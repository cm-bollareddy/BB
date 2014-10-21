<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1" xmlns:msxsl="urn:schemas-microsoft-com:xslt" version="1.0">

<xsl:output method="xml" />

<xsl:variable name="ROWSTATE_BEFORE">1</xsl:variable>
<xsl:variable name="ROWSTATE_DELETED">2</xsl:variable>
<xsl:variable name="ROWSTATE_NEW">4</xsl:variable>
<xsl:variable name="ROWSTATE_DETACHED">6</xsl:variable> <!-- This one we do not use -->
<xsl:variable name="ROWSTATE_AFTER">8</xsl:variable>
<xsl:variable name="ROWSTATE_UNCHANGED">64</xsl:variable>

<xsl:key name="OriginalVISUALART" match="//diffgr:before/VISUALART" use="@diffgr:id" />
<xsl:key name="CurrentVISUALART" match="//VisualArtDataSet/VISUALART" use="@diffgr:id" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<METADATA><FIELDS><FIELD attrname="PVA_ID" fieldtype="i4" required="true"><PARAM Name="PROVFLAGS" Value="7" Type="i4" Roundtrip="True" /><PARAM Name="ORIGIN" Value="PBSVISUALART.PVA_ID" Roundtrip="True" /></FIELD><FIELD attrname="PVA_DEA_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="PBSVISUALART.PVA_DEA_ID" Roundtrip="True" /></FIELD><FIELD attrname="PVA_FORMSTATUS" fieldtype="i2"><PARAM Name="ORIGIN" Value="PBSVISUALART.PVA_FORMSTATUS" Roundtrip="True" /></FIELD></FIELDS><PARAMS DATASET_DELTA="TRUE" PRIMARY_KEY="1" /></METADATA>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template name="OutputVISUALART">
<xsl:param name="Original" />
<xsl:param name="RowState"><xsl:value-of select="$ROWSTATE_UNCHANGED" /></xsl:param>
	<ROW>
		<xsl:attribute name="RowState"><xsl:value-of select="$RowState" /></xsl:attribute>
		<xsl:choose>
			<xsl:when test="$RowState = $ROWSTATE_AFTER">
				<xsl:if test="(not(msxsl:node-set($Original)/PVA_ID) and PVA_ID) or (msxsl:node-set($Original)/PVA_ID != PVA_ID)">
					<xsl:attribute name="PVA_ID"><xsl:value-of select="PVA_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PVA_ID and not(PVA_ID)">
					<xsl:attribute name="PVA_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PVA_DEA_ID) and PVA_DEA_ID) or (msxsl:node-set($Original)/PVA_DEA_ID != PVA_DEA_ID)">
					<xsl:attribute name="PVA_DEA_ID"><xsl:value-of select="PVA_DEA_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PVA_DEA_ID and not(PVA_DEA_ID)">
					<xsl:attribute name="PVA_DEA_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PVA_FORMSTATUS) and PVA_FORMSTATUS) or (msxsl:node-set($Original)/PVA_FORMSTATUS != PVA_FORMSTATUS)">
					<xsl:attribute name="PVA_FORMSTATUS"><xsl:value-of select="PVA_FORMSTATUS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PVA_FORMSTATUS and not(PVA_FORMSTATUS)">
					<xsl:attribute name="PVA_FORMSTATUS"></xsl:attribute>
				</xsl:if>
			</xsl:when>
			<xsl:otherwise>
				<xsl:attribute name="PVA_ID"><xsl:value-of select="PVA_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PVA_ID and not(PVA_ID)">
					<xsl:attribute name="PVA_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PVA_DEA_ID"><xsl:value-of select="PVA_DEA_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PVA_DEA_ID and not(PVA_DEA_ID)">
					<xsl:attribute name="PVA_DEA_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PVA_FORMSTATUS"><xsl:value-of select="PVA_FORMSTATUS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PVA_FORMSTATUS and not(PVA_FORMSTATUS)">
					<xsl:attribute name="PVA_FORMSTATUS"></xsl:attribute>
				</xsl:if>
			</xsl:otherwise>
		</xsl:choose>

	</ROW>
</xsl:template>

<xsl:template match="/">
	<DATAPACKET Version="2.0">
	<xsl:call-template name="Output_Schema" />
	<ROWDATA>
		<xsl:for-each select="//VisualArtDataSet/VISUALART">
			<xsl:choose>
				<xsl:when test="@diffgr:hasChanges='inserted'">
					<xsl:call-template name="OutputVISUALART">
						<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
					</xsl:call-template>
				</xsl:when>

				<xsl:when test="@diffgr:hasChanges='modified'">
					<xsl:for-each select="key('OriginalVISUALART', @diffgr:id)">
						<xsl:call-template name="OutputVISUALART">
							<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
						</xsl:call-template>
					</xsl:for-each>
					<xsl:call-template name="OutputVISUALART">
						<xsl:with-param name="Original" select="key('OriginalVISUALART', @diffgr:id)" />
						<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
					</xsl:call-template>
				</xsl:when>
			</xsl:choose>
		</xsl:for-each>
		<xsl:for-each select="//diffgr:before/VISUALART">
			<xsl:if test="count(key('CurrentVISUALART', @diffgr:id)) = 0">
				<xsl:call-template name="OutputVISUALART">
					<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
				</xsl:call-template>
			</xsl:if>
		</xsl:for-each>
	</ROWDATA>
	</DATAPACKET>
</xsl:template>
</xsl:stylesheet>
