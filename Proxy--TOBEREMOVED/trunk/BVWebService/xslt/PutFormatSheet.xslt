<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1" xmlns:msxsl="urn:schemas-microsoft-com:xslt" version="1.0">

<xsl:output method="xml" />

<xsl:variable name="ROWSTATE_BEFORE">1</xsl:variable>
<xsl:variable name="ROWSTATE_DELETED">2</xsl:variable>
<xsl:variable name="ROWSTATE_NEW">4</xsl:variable>
<xsl:variable name="ROWSTATE_DETACHED">6</xsl:variable> <!-- This one we do not use -->
<xsl:variable name="ROWSTATE_AFTER">8</xsl:variable>
<xsl:variable name="ROWSTATE_UNCHANGED">64</xsl:variable>

<xsl:key name="OriginalFORMATSHEET" match="//diffgr:before/FORMATSHEET" use="@diffgr:id" />
<xsl:key name="CurrentFORMATSHEET" match="//FormatSheetDataSet/FORMATSHEET" use="@diffgr:id" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<METADATA><FIELDS><FIELD attrname="PFS_ID" fieldtype="i4" required="true"><PARAM Name="PROVFLAGS" Value="7" Type="i4" Roundtrip="True" /><PARAM Name="ORIGIN" Value="PBSFORMATSHEET.PFS_ID" Roundtrip="True" /></FIELD><FIELD attrname="PFS_DEA_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="PBSFORMATSHEET.PFS_DEA_ID" Roundtrip="True" /></FIELD><FIELD attrname="PFS_FORMSTATUS" fieldtype="i2"><PARAM Name="ORIGIN" Value="PBSFORMATSHEET.PFS_FORMSTATUS" Roundtrip="True" /></FIELD><FIELD attrname="PREMIEREDATE" fieldtype="dateTime" readonly="true" /></FIELDS><PARAMS DATASET_DELTA="TRUE" PRIMARY_KEY="1" /></METADATA>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template name="OutputFORMATSHEET">
<xsl:param name="Original" />
<xsl:param name="RowState"><xsl:value-of select="$ROWSTATE_UNCHANGED" /></xsl:param>
	<ROW>
		<xsl:attribute name="RowState"><xsl:value-of select="$RowState" /></xsl:attribute>
		<xsl:choose>
			<xsl:when test="$RowState = $ROWSTATE_AFTER">
				<xsl:if test="(not(msxsl:node-set($Original)/PFS_ID) and PFS_ID) or (msxsl:node-set($Original)/PFS_ID != PFS_ID)">
					<xsl:attribute name="PFS_ID"><xsl:value-of select="PFS_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PFS_ID and not(PFS_ID)">
					<xsl:attribute name="PFS_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PFS_DEA_ID) and PFS_DEA_ID) or (msxsl:node-set($Original)/PFS_DEA_ID != PFS_DEA_ID)">
					<xsl:attribute name="PFS_DEA_ID"><xsl:value-of select="PFS_DEA_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PFS_DEA_ID and not(PFS_DEA_ID)">
					<xsl:attribute name="PFS_DEA_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PFS_FORMSTATUS) and PFS_FORMSTATUS) or (msxsl:node-set($Original)/PFS_FORMSTATUS != PFS_FORMSTATUS)">
					<xsl:attribute name="PFS_FORMSTATUS"><xsl:value-of select="PFS_FORMSTATUS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PFS_FORMSTATUS and not(PFS_FORMSTATUS)">
					<xsl:attribute name="PFS_FORMSTATUS"></xsl:attribute>
				</xsl:if>
			</xsl:when>
			<xsl:otherwise>
				<xsl:attribute name="PFS_ID"><xsl:value-of select="PFS_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PFS_ID and not(PFS_ID)">
					<xsl:attribute name="PFS_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PFS_DEA_ID"><xsl:value-of select="PFS_DEA_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PFS_DEA_ID and not(PFS_DEA_ID)">
					<xsl:attribute name="PFS_DEA_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PFS_FORMSTATUS"><xsl:value-of select="PFS_FORMSTATUS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PFS_FORMSTATUS and not(PFS_FORMSTATUS)">
					<xsl:attribute name="PFS_FORMSTATUS"></xsl:attribute>
				</xsl:if>
			</xsl:otherwise>
		</xsl:choose>

	</ROW>
</xsl:template>

<xsl:template match="/">
	<DATAPACKET Version="2.0">
	<xsl:call-template name="Output_Schema" />
	<ROWDATA>
		<xsl:for-each select="//FormatSheetDataSet/FORMATSHEET">
			<xsl:choose>
				<xsl:when test="@diffgr:hasChanges='inserted'">
					<xsl:call-template name="OutputFORMATSHEET">
						<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
					</xsl:call-template>
				</xsl:when>

				<xsl:when test="@diffgr:hasChanges='modified'">
					<xsl:for-each select="key('OriginalFORMATSHEET', @diffgr:id)">
						<xsl:call-template name="OutputFORMATSHEET">
							<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
						</xsl:call-template>
					</xsl:for-each>
					<xsl:call-template name="OutputFORMATSHEET">
						<xsl:with-param name="Original" select="key('OriginalFORMATSHEET', @diffgr:id)" />
						<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
					</xsl:call-template>
				</xsl:when>
			</xsl:choose>
		</xsl:for-each>
		<xsl:for-each select="//diffgr:before/FORMATSHEET">
			<xsl:if test="count(key('CurrentFORMATSHEET', @diffgr:id)) = 0">
				<xsl:call-template name="OutputFORMATSHEET">
					<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
				</xsl:call-template>
			</xsl:if>
		</xsl:for-each>
	</ROWDATA>
	</DATAPACKET>
</xsl:template>
</xsl:stylesheet>
