<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1" xmlns:msxsl="urn:schemas-microsoft-com:xslt" version="1.0">

<xsl:output method="xml" />

<xsl:variable name="ROWSTATE_BEFORE">1</xsl:variable>
<xsl:variable name="ROWSTATE_DELETED">2</xsl:variable>
<xsl:variable name="ROWSTATE_NEW">4</xsl:variable>
<xsl:variable name="ROWSTATE_DETACHED">6</xsl:variable> <!-- This one we do not use -->
<xsl:variable name="ROWSTATE_AFTER">8</xsl:variable>
<xsl:variable name="ROWSTATE_UNCHANGED">64</xsl:variable>

<xsl:key name="OriginalPROGRAMS" match="//diffgr:before/PROGRAMS" use="@diffgr:id" />
<xsl:key name="CurrentPROGRAMS" match="//PackageAppliesToRangeByTabDataSet/PROGRAMS" use="@diffgr:id" />
<xsl:key name="OriginalVW_VERSIONAPPLIESTORANGE" match="//diffgr:before/VW_VERSIONAPPLIESTORANGE" use="@diffgr:id" />
<xsl:key name="CurrentVW_VERSIONAPPLIESTORANGE" match="//PackageAppliesToRangeByTabDataSet/VW_VERSIONAPPLIESTORANGE" use="@diffgr:id" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<METADATA><FIELDS><FIELD attrname="ASS_ID" fieldtype="i4" required="true"><PARAM Name="PROVFLAGS" Value="7" Type="i4" Roundtrip="True" /><PARAM Name="ORIGIN" Value="ASSET.ASS_ID" Roundtrip="True" /></FIELD><FIELD attrname="ASS_TITLE" fieldtype="string" required="true" WIDTH="80"><PARAM Name="ORIGIN" Value="ASSET.ASS_TITLE" Roundtrip="True" /></FIELD><FIELD attrname="ASS_EPISODENUMBER" fieldtype="string" WIDTH="20"><PARAM Name="ORIGIN" Value="ASSET.ASS_EPISODENUMBER" Roundtrip="True" /></FIELD><FIELD attrname="ASS_EPISODETITLE" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="ASSET.ASS_EPISODETITLE" Roundtrip="True" /></FIELD><FIELD attrname="VW_VERSIONAPPLIESTORANGE" fieldtype="nested"><FIELDS><FIELD attrname="VER_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_VERSIONAPPLIESTORANGE.VER_ID" Roundtrip="True" /></FIELD><FIELD attrname="VER_ASS_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_VERSIONAPPLIESTORANGE.VER_ASS_ID" Roundtrip="True" /></FIELD><FIELD attrname="TABID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_VERSIONAPPLIESTORANGE.TABID" Roundtrip="True" /></FIELD><FIELD attrname="TABTYPE" fieldtype="string" SUBTYPE="FixedChar" WIDTH="3"><PARAM Name="ORIGIN" Value="VW_VERSIONAPPLIESTORANGE.TABTYPE" Roundtrip="True" /></FIELD><FIELD attrname="IS_APPROVED" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_VERSIONAPPLIESTORANGE.IS_APPROVED" Roundtrip="True" /></FIELD><FIELD attrname="PACKAGE_MEDIA_STATUS" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_VERSIONAPPLIESTORANGE.PACKAGE_MEDIA_STATUS" Roundtrip="True" /></FIELD><FIELD attrname="PACKAGE_TYPE" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_VERSIONAPPLIESTORANGE.PACKAGE_TYPE" Roundtrip="True" /></FIELD><FIELD attrname="PACKAGE_REVISION_NUMBER" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_VERSIONAPPLIESTORANGE.PACKAGE_REVISION_NUMBER" Roundtrip="True" /></FIELD><FIELD attrname="IS_UPDATEABLE" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_VERSIONAPPLIESTORANGE.IS_UPDATEABLE" Roundtrip="True" /></FIELD><FIELD attrname="PACKAGE_HOUSENUMBER" fieldtype="string" WIDTH="40"><PARAM Name="ORIGIN" Value="VW_VERSIONAPPLIESTORANGE.PACKAGE_HOUSENUMBER" Roundtrip="True" /></FIELD><FIELD attrname="DEALID" fieldtype="i4" readonly="true" /><FIELD attrname="VIDEO_FORMAT" fieldtype="i4" readonly="true" /></FIELDS><PARAMS DATASET_DELTA="TRUE" /></FIELD></FIELDS><PARAMS DATASET_DELTA="TRUE" PRIMARY_KEY="1" /></METADATA>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template name="OutputVW_VERSIONAPPLIESTORANGE">
<xsl:param name="Original" />
<xsl:param name="RowState"><xsl:value-of select="$ROWSTATE_UNCHANGED" /></xsl:param>
	<ROWVW_VERSIONAPPLIESTORANGE>
		<xsl:attribute name="RowState"><xsl:value-of select="$RowState" /></xsl:attribute>
		<xsl:choose>
			<xsl:when test="$RowState = $ROWSTATE_AFTER">
				<xsl:if test="(not(msxsl:node-set($Original)/VER_ID) and VER_ID) or (msxsl:node-set($Original)/VER_ID != VER_ID)">
					<xsl:attribute name="VER_ID"><xsl:value-of select="VER_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/VER_ID and not(VER_ID)">
					<xsl:attribute name="VER_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/VER_ASS_ID) and VER_ASS_ID) or (msxsl:node-set($Original)/VER_ASS_ID != VER_ASS_ID)">
					<xsl:attribute name="VER_ASS_ID"><xsl:value-of select="VER_ASS_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/VER_ASS_ID and not(VER_ASS_ID)">
					<xsl:attribute name="VER_ASS_ID"></xsl:attribute>
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
				<xsl:if test="(not(msxsl:node-set($Original)/IS_APPROVED) and IS_APPROVED) or (msxsl:node-set($Original)/IS_APPROVED != IS_APPROVED)">
					<xsl:attribute name="IS_APPROVED"><xsl:value-of select="IS_APPROVED" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/IS_APPROVED and not(IS_APPROVED)">
					<xsl:attribute name="IS_APPROVED"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PACKAGE_MEDIA_STATUS) and PACKAGE_MEDIA_STATUS) or (msxsl:node-set($Original)/PACKAGE_MEDIA_STATUS != PACKAGE_MEDIA_STATUS)">
					<xsl:attribute name="PACKAGE_MEDIA_STATUS"><xsl:value-of select="PACKAGE_MEDIA_STATUS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PACKAGE_MEDIA_STATUS and not(PACKAGE_MEDIA_STATUS)">
					<xsl:attribute name="PACKAGE_MEDIA_STATUS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PACKAGE_TYPE) and PACKAGE_TYPE) or (msxsl:node-set($Original)/PACKAGE_TYPE != PACKAGE_TYPE)">
					<xsl:attribute name="PACKAGE_TYPE"><xsl:value-of select="PACKAGE_TYPE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PACKAGE_TYPE and not(PACKAGE_TYPE)">
					<xsl:attribute name="PACKAGE_TYPE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PACKAGE_REVISION_NUMBER) and PACKAGE_REVISION_NUMBER) or (msxsl:node-set($Original)/PACKAGE_REVISION_NUMBER != PACKAGE_REVISION_NUMBER)">
					<xsl:attribute name="PACKAGE_REVISION_NUMBER"><xsl:value-of select="PACKAGE_REVISION_NUMBER" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PACKAGE_REVISION_NUMBER and not(PACKAGE_REVISION_NUMBER)">
					<xsl:attribute name="PACKAGE_REVISION_NUMBER"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/IS_UPDATEABLE) and IS_UPDATEABLE) or (msxsl:node-set($Original)/IS_UPDATEABLE != IS_UPDATEABLE)">
					<xsl:attribute name="IS_UPDATEABLE"><xsl:value-of select="IS_UPDATEABLE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/IS_UPDATEABLE and not(IS_UPDATEABLE)">
					<xsl:attribute name="IS_UPDATEABLE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/PACKAGE_HOUSENUMBER) and PACKAGE_HOUSENUMBER) or (msxsl:node-set($Original)/PACKAGE_HOUSENUMBER != PACKAGE_HOUSENUMBER)">
					<xsl:attribute name="PACKAGE_HOUSENUMBER"><xsl:value-of select="PACKAGE_HOUSENUMBER" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/PACKAGE_HOUSENUMBER and not(PACKAGE_HOUSENUMBER)">
					<xsl:attribute name="PACKAGE_HOUSENUMBER"></xsl:attribute>
				</xsl:if>
			</xsl:when>
			<xsl:otherwise>
				<xsl:attribute name="VER_ID"><xsl:value-of select="VER_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/VER_ID and not(VER_ID)">
					<xsl:attribute name="VER_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="VER_ASS_ID"><xsl:value-of select="VER_ASS_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/VER_ASS_ID and not(VER_ASS_ID)">
					<xsl:attribute name="VER_ASS_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="TABID"><xsl:value-of select="TABID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/TABID and not(TABID)">
					<xsl:attribute name="TABID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="TABTYPE"><xsl:value-of select="TABTYPE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/TABTYPE and not(TABTYPE)">
					<xsl:attribute name="TABTYPE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="IS_APPROVED"><xsl:value-of select="IS_APPROVED" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/IS_APPROVED and not(IS_APPROVED)">
					<xsl:attribute name="IS_APPROVED"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PACKAGE_MEDIA_STATUS"><xsl:value-of select="PACKAGE_MEDIA_STATUS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PACKAGE_MEDIA_STATUS and not(PACKAGE_MEDIA_STATUS)">
					<xsl:attribute name="PACKAGE_MEDIA_STATUS"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PACKAGE_TYPE"><xsl:value-of select="PACKAGE_TYPE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PACKAGE_TYPE and not(PACKAGE_TYPE)">
					<xsl:attribute name="PACKAGE_TYPE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PACKAGE_REVISION_NUMBER"><xsl:value-of select="PACKAGE_REVISION_NUMBER" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PACKAGE_REVISION_NUMBER and not(PACKAGE_REVISION_NUMBER)">
					<xsl:attribute name="PACKAGE_REVISION_NUMBER"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="IS_UPDATEABLE"><xsl:value-of select="IS_UPDATEABLE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/IS_UPDATEABLE and not(IS_UPDATEABLE)">
					<xsl:attribute name="IS_UPDATEABLE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="PACKAGE_HOUSENUMBER"><xsl:value-of select="PACKAGE_HOUSENUMBER" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/PACKAGE_HOUSENUMBER and not(PACKAGE_HOUSENUMBER)">
					<xsl:attribute name="PACKAGE_HOUSENUMBER"></xsl:attribute>
				</xsl:if>
			</xsl:otherwise>
		</xsl:choose>

	</ROWVW_VERSIONAPPLIESTORANGE>
</xsl:template>

<xsl:template name="OutputPROGRAMS">
<xsl:param name="Original" />
<xsl:param name="RowState"><xsl:value-of select="$ROWSTATE_UNCHANGED" /></xsl:param>
<xsl:variable name="COMPAREID"><xsl:value-of select="ASS_ID" /></xsl:variable>
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
			</xsl:otherwise>
		</xsl:choose>

		<VW_VERSIONAPPLIESTORANGE>
			<xsl:if test="($RowState=$ROWSTATE_NEW) or ($RowState=$ROWSTATE_BEFORE) or ($RowState=$ROWSTATE_UNCHANGED)">
				<xsl:for-each select="//PackageAppliesToRangeByTabDataSet/VW_VERSIONAPPLIESTORANGE">
				<xsl:if test="($COMPAREID = VER_ASS_ID)">
					<xsl:choose>
						<xsl:when test="@diffgr:hasChanges='inserted'">
							<xsl:call-template name="OutputVW_VERSIONAPPLIESTORANGE">
								<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
							</xsl:call-template>
						</xsl:when>

						<xsl:when test="@diffgr:hasChanges='modified'">
							<xsl:for-each select="key('OriginalVW_VERSIONAPPLIESTORANGE', @diffgr:id)">
								<xsl:call-template name="OutputVW_VERSIONAPPLIESTORANGE">
									<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
								</xsl:call-template>
							</xsl:for-each>
							<xsl:call-template name="OutputVW_VERSIONAPPLIESTORANGE">
								<xsl:with-param name="Original" select="key('OriginalVW_VERSIONAPPLIESTORANGE', @diffgr:id)" />
								<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
							</xsl:call-template>
						</xsl:when>
					</xsl:choose>
				</xsl:if>
				</xsl:for-each>
				<xsl:for-each select="//diffgr:before/VW_VERSIONAPPLIESTORANGE">
					<xsl:if test="count(key('CurrentVW_VERSIONAPPLIESTORANGE', @diffgr:id)) = 0">
						<xsl:call-template name="OutputVW_VERSIONAPPLIESTORANGE">
							<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
						</xsl:call-template>
					</xsl:if>
				</xsl:for-each>
			</xsl:if>
		</VW_VERSIONAPPLIESTORANGE>
	</ROW>
</xsl:template>

<xsl:template match="/">
	<DATAPACKET Version="2.0">
	<xsl:call-template name="Output_Schema" />
	<ROWDATA>
		<xsl:for-each select="//PackageAppliesToRangeByTabDataSet/PROGRAMS">
			<xsl:choose>
				<xsl:when test="@diffgr:hasChanges='inserted'">
					<xsl:call-template name="OutputPROGRAMS">
						<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
					</xsl:call-template>
				</xsl:when>

				<xsl:when test="@diffgr:hasChanges='modified'">
					<xsl:for-each select="key('OriginalPROGRAMS', @diffgr:id)">
						<xsl:call-template name="OutputPROGRAMS">
							<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
						</xsl:call-template>
					</xsl:for-each>
					<xsl:call-template name="OutputPROGRAMS">
						<xsl:with-param name="Original" select="key('OriginalPROGRAMS', @diffgr:id)" />
						<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
					</xsl:call-template>
				</xsl:when>

				<xsl:otherwise>
					<xsl:call-template name="OutputPROGRAMS">
						<xsl:with-param name="RowState" select="$ROWSTATE_UNCHANGED" />
					</xsl:call-template>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:for-each>
		<xsl:for-each select="//diffgr:before/PROGRAMS">
			<xsl:if test="count(key('CurrentPROGRAMS', @diffgr:id)) = 0">
				<xsl:call-template name="OutputPROGRAMS">
					<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
				</xsl:call-template>
			</xsl:if>
		</xsl:for-each>
	</ROWDATA>
	</DATAPACKET>
</xsl:template>
</xsl:stylesheet>
