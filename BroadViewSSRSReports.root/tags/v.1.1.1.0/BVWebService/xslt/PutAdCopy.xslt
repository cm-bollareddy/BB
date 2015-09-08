<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1" xmlns:msxsl="urn:schemas-microsoft-com:xslt" version="1.0">

<xsl:output method="xml" />

<xsl:variable name="ROWSTATE_BEFORE">1</xsl:variable>
<xsl:variable name="ROWSTATE_DELETED">2</xsl:variable>
<xsl:variable name="ROWSTATE_NEW">4</xsl:variable>
<xsl:variable name="ROWSTATE_DETACHED">6</xsl:variable> <!-- This one we do not use -->
<xsl:variable name="ROWSTATE_AFTER">8</xsl:variable>
<xsl:variable name="ROWSTATE_UNCHANGED">64</xsl:variable>

<xsl:key name="OriginalADCOPY" match="//diffgr:before/ADCOPY" use="@diffgr:id" />
<xsl:key name="CurrentADCOPY" match="//AdCopyDataSet/ADCOPY" use="@diffgr:id" />
<xsl:key name="OriginalASSETRIGHTWINDOW" match="//diffgr:before/ASSETRIGHTWINDOW" use="@diffgr:id" />
<xsl:key name="CurrentASSETRIGHTWINDOW" match="//AdCopyDataSet/ASSETRIGHTWINDOW" use="@diffgr:id" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<METADATA><FIELDS><FIELD attrname="ASS_ID" fieldtype="i4" required="true"><PARAM Name="PROVFLAGS" Value="7" Type="i4" Roundtrip="True" /><PARAM Name="ORIGIN" Value="ASSET.ASS_ID" Roundtrip="True" /></FIELD><FIELD attrname="ASS_TITLE" fieldtype="string" required="true" WIDTH="80"><PARAM Name="ORIGIN" Value="ASSET.ASS_TITLE" Roundtrip="True" /></FIELD><FIELD attrname="ASS_DURATIONSCHEDULED" fieldtype="i4"><PARAM Name="ORIGIN" Value="ASSET.ASS_DURATIONSCHEDULED" Roundtrip="True" /></FIELD><FIELD attrname="ASS_VIDEOTEXT" fieldtype="bin.hex" SUBTYPE="Text" WIDTH="8"><PARAM Name="ORIGIN" Value="ASSET.ASS_VIDEOTEXT" Roundtrip="True" /></FIELD><FIELD attrname="ASS_AUDIOTEXT" fieldtype="bin.hex" SUBTYPE="Text" WIDTH="8"><PARAM Name="ORIGIN" Value="ASSET.ASS_AUDIOTEXT" Roundtrip="True" /></FIELD><FIELD attrname="ASS_COM_ID_ADVERTISER" fieldtype="i4"><PARAM Name="ORIGIN" Value="ASSET.ASS_COM_ID_ADVERTISER" Roundtrip="True" /></FIELD><FIELD attrname="ASS_ISPBSAPPROVED" fieldtype="i2"><PARAM Name="ORIGIN" Value="ASSET.ASS_ISPBSAPPROVED" Roundtrip="True" /></FIELD><FIELD attrname="ASSETRIGHTWINDOW" fieldtype="nested"><FIELDS><FIELD attrname="ARW_ID" fieldtype="i4" required="true"><PARAM Name="PROVFLAGS" Value="7" Type="i4" Roundtrip="True" /><PARAM Name="ORIGIN" Value="ASSETRIGHTWINDOW.ARW_ID" Roundtrip="True" /></FIELD><FIELD attrname="ARW_ASS_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="ASSETRIGHTWINDOW.ARW_ASS_ID" Roundtrip="True" /></FIELD><FIELD attrname="ARW_DATEAVAILABLEFROM" fieldtype="dateTime"><PARAM Name="ORIGIN" Value="ASSETRIGHTWINDOW.ARW_DATEAVAILABLEFROM" Roundtrip="True" /></FIELD><FIELD attrname="ARW_DATEAVAILABLETO" fieldtype="dateTime"><PARAM Name="ORIGIN" Value="ASSETRIGHTWINDOW.ARW_DATEAVAILABLETO" Roundtrip="True" /></FIELD></FIELDS><PARAMS DATASET_DELTA="TRUE" PRIMARY_KEY="1" /></FIELD></FIELDS><PARAMS DATASET_DELTA="TRUE" PRIMARY_KEY="1" /></METADATA>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template name="OutputASSETRIGHTWINDOW">
<xsl:param name="Original" />
<xsl:param name="RowState"><xsl:value-of select="$ROWSTATE_UNCHANGED" /></xsl:param>
	<ROWASSETRIGHTWINDOW>
		<xsl:attribute name="RowState"><xsl:value-of select="$RowState" /></xsl:attribute>
		<xsl:choose>
			<xsl:when test="$RowState = $ROWSTATE_AFTER">
				<xsl:if test="(not(msxsl:node-set($Original)/ARW_ID) and ARW_ID) or (msxsl:node-set($Original)/ARW_ID != ARW_ID)">
					<xsl:attribute name="ARW_ID"><xsl:value-of select="ARW_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ARW_ID and not(ARW_ID)">
					<xsl:attribute name="ARW_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/ARW_ASS_ID) and ARW_ASS_ID) or (msxsl:node-set($Original)/ARW_ASS_ID != ARW_ASS_ID)">
					<xsl:attribute name="ARW_ASS_ID"><xsl:value-of select="ARW_ASS_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/ARW_ASS_ID and not(ARW_ASS_ID)">
					<xsl:attribute name="ARW_ASS_ID"></xsl:attribute>
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
				<xsl:attribute name="ARW_ID"><xsl:value-of select="ARW_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ARW_ID and not(ARW_ID)">
					<xsl:attribute name="ARW_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="ARW_ASS_ID"><xsl:value-of select="ARW_ASS_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/ARW_ASS_ID and not(ARW_ASS_ID)">
					<xsl:attribute name="ARW_ASS_ID"></xsl:attribute>
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

	</ROWASSETRIGHTWINDOW>
</xsl:template>

<xsl:template name="OutputADCOPY">
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
			</xsl:otherwise>
		</xsl:choose>

		<ASSETRIGHTWINDOW>
			<xsl:if test="($RowState=$ROWSTATE_NEW) or ($RowState=$ROWSTATE_BEFORE) or ($RowState=$ROWSTATE_UNCHANGED)">
				<xsl:for-each select="//AdCopyDataSet/ASSETRIGHTWINDOW">
					<xsl:choose>
						<xsl:when test="@diffgr:hasChanges='inserted'">
							<xsl:call-template name="OutputASSETRIGHTWINDOW">
								<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
							</xsl:call-template>
						</xsl:when>

						<xsl:when test="@diffgr:hasChanges='modified'">
							<xsl:for-each select="key('OriginalASSETRIGHTWINDOW', @diffgr:id)">
								<xsl:call-template name="OutputASSETRIGHTWINDOW">
									<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
								</xsl:call-template>
							</xsl:for-each>
							<xsl:call-template name="OutputASSETRIGHTWINDOW">
								<xsl:with-param name="Original" select="key('OriginalASSETRIGHTWINDOW', @diffgr:id)" />
								<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
							</xsl:call-template>
						</xsl:when>
					</xsl:choose>
				</xsl:for-each>
				<xsl:for-each select="//diffgr:before/ASSETRIGHTWINDOW">
					<xsl:if test="count(key('CurrentASSETRIGHTWINDOW', @diffgr:id)) = 0">
						<xsl:call-template name="OutputASSETRIGHTWINDOW">
							<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
						</xsl:call-template>
					</xsl:if>
				</xsl:for-each>
			</xsl:if>
		</ASSETRIGHTWINDOW>
	</ROW>
</xsl:template>

<xsl:template match="/">
	<DATAPACKET Version="2.0">
	<xsl:call-template name="Output_Schema" />
	<ROWDATA>
		<xsl:for-each select="//AdCopyDataSet/ADCOPY">
			<xsl:choose>
				<xsl:when test="@diffgr:hasChanges='inserted'">
					<xsl:call-template name="OutputADCOPY">
						<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
					</xsl:call-template>
				</xsl:when>

				<xsl:when test="@diffgr:hasChanges='modified'">
					<xsl:for-each select="key('OriginalADCOPY', @diffgr:id)">
						<xsl:call-template name="OutputADCOPY">
							<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
						</xsl:call-template>
					</xsl:for-each>
					<xsl:call-template name="OutputADCOPY">
						<xsl:with-param name="Original" select="key('OriginalADCOPY', @diffgr:id)" />
						<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
					</xsl:call-template>
				</xsl:when>

				<xsl:otherwise>
					<xsl:call-template name="OutputADCOPY">
						<xsl:with-param name="RowState" select="$ROWSTATE_UNCHANGED" />
					</xsl:call-template>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:for-each>
		<xsl:for-each select="//diffgr:before/ADCOPY">
			<xsl:if test="count(key('CurrentADCOPY', @diffgr:id)) = 0">
				<xsl:call-template name="OutputADCOPY">
					<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
				</xsl:call-template>
			</xsl:if>
		</xsl:for-each>
	</ROWDATA>
	</DATAPACKET>
</xsl:template>
</xsl:stylesheet>
