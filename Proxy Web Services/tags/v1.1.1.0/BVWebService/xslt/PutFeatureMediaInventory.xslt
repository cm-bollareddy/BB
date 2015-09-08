<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1" xmlns:msxsl="urn:schemas-microsoft-com:xslt" version="1.0">

<xsl:output method="xml" />

<xsl:variable name="ROWSTATE_BEFORE">1</xsl:variable>
<xsl:variable name="ROWSTATE_DELETED">2</xsl:variable>
<xsl:variable name="ROWSTATE_NEW">4</xsl:variable>
<xsl:variable name="ROWSTATE_DETACHED">6</xsl:variable> <!-- This one we do not use -->
<xsl:variable name="ROWSTATE_AFTER">8</xsl:variable>
<xsl:variable name="ROWSTATE_UNCHANGED">64</xsl:variable>

<xsl:key name="OriginalFEATUREMEDIAINVENTORY" match="//diffgr:before/FEATUREMEDIAINVENTORY" use="@diffgr:id" />
<xsl:key name="CurrentFEATUREMEDIAINVENTORY" match="//FeatureMediaInventoryDataSet/FEATUREMEDIAINVENTORY" use="@diffgr:id" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<METADATA><FIELDS><FIELD attrname="MEI_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYFEATURE.MEI_ID" Roundtrip="True" /></FIELD><FIELD attrname="MEI_ASS_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYFEATURE.MEI_ASS_ID" Roundtrip="True" /></FIELD><FIELD attrname="MEI_ID_PARENT" fieldtype="i4" readonly="true" /><FIELD attrname="MEI_NUMBER" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYFEATURE.MEI_NUMBER" Roundtrip="True" /></FIELD><FIELD attrname="MEI_SLU_ID_STATUS" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYFEATURE.MEI_SLU_ID_STATUS" Roundtrip="True" /></FIELD><FIELD attrname="MEI_LASTSUBMITTEDDATE" fieldtype="dateTime"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYFEATURE.MEI_LASTSUBMITTEDDATE" Roundtrip="True" /></FIELD><FIELD attrname="MEI_MET_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYFEATURE.MEI_MET_ID" Roundtrip="True" /></FIELD><FIELD attrname="MEI_ISBILLABLE" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYFEATURE.MEI_ISBILLABLE" Roundtrip="True" /></FIELD><FIELD attrname="MEI_NOTE" fieldtype="bin.hex" SUBTYPE="Text" WIDTH="8"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYFEATURE.MEI_NOTE" Roundtrip="True" /></FIELD><FIELD attrname="MEI_REVISIONNO" fieldtype="i2"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYFEATURE.MEI_REVISIONNO" Roundtrip="True" /></FIELD><FIELD attrname="MEI_MEF_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYFEATURE.MEI_MEF_ID" Roundtrip="True" /></FIELD><FIELD attrname="MEI_CLASS" fieldtype="string" SUBTYPE="FixedChar" WIDTH="3"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYFEATURE.MEI_CLASS" Roundtrip="True" /></FIELD><FIELD attrname="MEI_SLU_ID_PBSMEDIASTATUS" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYFEATURE.MEI_SLU_ID_PBSMEDIASTATUS" Roundtrip="True" /></FIELD><FIELD attrname="MEI_DESCRIPTION" fieldtype="string" WIDTH="80"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYFEATURE.MEI_DESCRIPTION" Roundtrip="True" /></FIELD><FIELD attrname="MEI_MIT_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYFEATURE.MEI_MIT_ID" Roundtrip="True" /></FIELD><FIELD attrname="MEIR_ID" fieldtype="i4"><PARAM Name="ORIGIN" Value="VW_MEDIAINVENTORYFEATURE.MEIR_ID" Roundtrip="True" /></FIELD></FIELDS><PARAMS DATASET_DELTA="TRUE" /></METADATA>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template name="OutputFEATUREMEDIAINVENTORY">
<xsl:param name="Original" />
<xsl:param name="RowState"><xsl:value-of select="$ROWSTATE_UNCHANGED" /></xsl:param>
	<ROW>
		<xsl:attribute name="RowState"><xsl:value-of select="$RowState" /></xsl:attribute>
		<xsl:choose>
			<xsl:when test="$RowState = $ROWSTATE_AFTER">
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_ID) and MEI_ID) or (msxsl:node-set($Original)/MEI_ID != MEI_ID)">
					<xsl:attribute name="MEI_ID"><xsl:value-of select="MEI_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_ID and not(MEI_ID)">
					<xsl:attribute name="MEI_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_ASS_ID) and MEI_ASS_ID) or (msxsl:node-set($Original)/MEI_ASS_ID != MEI_ASS_ID)">
					<xsl:attribute name="MEI_ASS_ID"><xsl:value-of select="MEI_ASS_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_ASS_ID and not(MEI_ASS_ID)">
					<xsl:attribute name="MEI_ASS_ID"></xsl:attribute>
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
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_LASTSUBMITTEDDATE) and MEI_LASTSUBMITTEDDATE) or (msxsl:node-set($Original)/MEI_LASTSUBMITTEDDATE != MEI_LASTSUBMITTEDDATE)">
					<xsl:attribute name="MEI_LASTSUBMITTEDDATE"><xsl:value-of select="MEI_LASTSUBMITTEDDATE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_LASTSUBMITTEDDATE and not(MEI_LASTSUBMITTEDDATE)">
					<xsl:attribute name="MEI_LASTSUBMITTEDDATE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_MET_ID) and MEI_MET_ID) or (msxsl:node-set($Original)/MEI_MET_ID != MEI_MET_ID)">
					<xsl:attribute name="MEI_MET_ID"><xsl:value-of select="MEI_MET_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_MET_ID and not(MEI_MET_ID)">
					<xsl:attribute name="MEI_MET_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_ISBILLABLE) and MEI_ISBILLABLE) or (msxsl:node-set($Original)/MEI_ISBILLABLE != MEI_ISBILLABLE)">
					<xsl:attribute name="MEI_ISBILLABLE"><xsl:value-of select="MEI_ISBILLABLE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_ISBILLABLE and not(MEI_ISBILLABLE)">
					<xsl:attribute name="MEI_ISBILLABLE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="MEI_NOTE != '' and (not(msxsl:node-set($Original)/MEI_NOTE) and MEI_NOTE) or (msxsl:node-set($Original)/MEI_NOTE != MEI_NOTE)">
					<xsl:attribute name="MEI_NOTE"><xsl:value-of select="MEI_NOTE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_NOTE and not(MEI_NOTE)">
					<xsl:attribute name="MEI_NOTE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_REVISIONNO) and MEI_REVISIONNO) or (msxsl:node-set($Original)/MEI_REVISIONNO != MEI_REVISIONNO)">
					<xsl:attribute name="MEI_REVISIONNO"><xsl:value-of select="MEI_REVISIONNO" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_REVISIONNO and not(MEI_REVISIONNO)">
					<xsl:attribute name="MEI_REVISIONNO"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_MEF_ID) and MEI_MEF_ID) or (msxsl:node-set($Original)/MEI_MEF_ID != MEI_MEF_ID)">
					<xsl:attribute name="MEI_MEF_ID"><xsl:value-of select="MEI_MEF_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_MEF_ID and not(MEI_MEF_ID)">
					<xsl:attribute name="MEI_MEF_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_CLASS) and MEI_CLASS) or (msxsl:node-set($Original)/MEI_CLASS != MEI_CLASS)">
					<xsl:attribute name="MEI_CLASS"><xsl:value-of select="MEI_CLASS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_CLASS and not(MEI_CLASS)">
					<xsl:attribute name="MEI_CLASS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_SLU_ID_PBSMEDIASTATUS) and MEI_SLU_ID_PBSMEDIASTATUS) or (msxsl:node-set($Original)/MEI_SLU_ID_PBSMEDIASTATUS != MEI_SLU_ID_PBSMEDIASTATUS)">
					<xsl:attribute name="MEI_SLU_ID_PBSMEDIASTATUS"><xsl:value-of select="MEI_SLU_ID_PBSMEDIASTATUS" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_SLU_ID_PBSMEDIASTATUS and not(MEI_SLU_ID_PBSMEDIASTATUS)">
					<xsl:attribute name="MEI_SLU_ID_PBSMEDIASTATUS"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_DESCRIPTION) and MEI_DESCRIPTION) or (msxsl:node-set($Original)/MEI_DESCRIPTION != MEI_DESCRIPTION)">
					<xsl:attribute name="MEI_DESCRIPTION"><xsl:value-of select="MEI_DESCRIPTION" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_DESCRIPTION and not(MEI_DESCRIPTION)">
					<xsl:attribute name="MEI_DESCRIPTION"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEI_MIT_ID) and MEI_MIT_ID) or (msxsl:node-set($Original)/MEI_MIT_ID != MEI_MIT_ID)">
					<xsl:attribute name="MEI_MIT_ID"><xsl:value-of select="MEI_MIT_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_MIT_ID and not(MEI_MIT_ID)">
					<xsl:attribute name="MEI_MIT_ID"></xsl:attribute>
				</xsl:if>
				<xsl:if test="(not(msxsl:node-set($Original)/MEIR_ID) and MEIR_ID) or (msxsl:node-set($Original)/MEIR_ID != MEIR_ID)">
					<xsl:attribute name="MEIR_ID"><xsl:value-of select="MEIR_ID" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEIR_ID and not(MEIR_ID)">
					<xsl:attribute name="MEIR_ID"></xsl:attribute>
				</xsl:if>
			</xsl:when>
			<xsl:otherwise>
				<xsl:attribute name="MEI_ID"><xsl:value-of select="MEI_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_ID and not(MEI_ID)">
					<xsl:attribute name="MEI_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_ASS_ID"><xsl:value-of select="MEI_ASS_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_ASS_ID and not(MEI_ASS_ID)">
					<xsl:attribute name="MEI_ASS_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_NUMBER"><xsl:value-of select="MEI_NUMBER" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_NUMBER and not(MEI_NUMBER)">
					<xsl:attribute name="MEI_NUMBER"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_SLU_ID_STATUS"><xsl:value-of select="MEI_SLU_ID_STATUS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_SLU_ID_STATUS and not(MEI_SLU_ID_STATUS)">
					<xsl:attribute name="MEI_SLU_ID_STATUS"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_LASTSUBMITTEDDATE"><xsl:value-of select="MEI_LASTSUBMITTEDDATE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_LASTSUBMITTEDDATE and not(MEI_LASTSUBMITTEDDATE)">
					<xsl:attribute name="MEI_LASTSUBMITTEDDATE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_MET_ID"><xsl:value-of select="MEI_MET_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_MET_ID and not(MEI_MET_ID)">
					<xsl:attribute name="MEI_MET_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_ISBILLABLE"><xsl:value-of select="MEI_ISBILLABLE" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_ISBILLABLE and not(MEI_ISBILLABLE)">
					<xsl:attribute name="MEI_ISBILLABLE"></xsl:attribute>
				</xsl:if>
				<xsl:if test="MEI_NOTE != ''">
					<xsl:attribute name="MEI_NOTE"><xsl:value-of select="MEI_NOTE" /></xsl:attribute>
				</xsl:if>
				<xsl:if test="msxsl:node-set($Original)/MEI_NOTE and not(MEI_NOTE)">
					<xsl:attribute name="MEI_NOTE"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_REVISIONNO"><xsl:value-of select="MEI_REVISIONNO" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_REVISIONNO and not(MEI_REVISIONNO)">
					<xsl:attribute name="MEI_REVISIONNO"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_MEF_ID"><xsl:value-of select="MEI_MEF_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_MEF_ID and not(MEI_MEF_ID)">
					<xsl:attribute name="MEI_MEF_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_CLASS"><xsl:value-of select="MEI_CLASS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_CLASS and not(MEI_CLASS)">
					<xsl:attribute name="MEI_CLASS"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_SLU_ID_PBSMEDIASTATUS"><xsl:value-of select="MEI_SLU_ID_PBSMEDIASTATUS" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_SLU_ID_PBSMEDIASTATUS and not(MEI_SLU_ID_PBSMEDIASTATUS)">
					<xsl:attribute name="MEI_SLU_ID_PBSMEDIASTATUS"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_DESCRIPTION"><xsl:value-of select="MEI_DESCRIPTION" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_DESCRIPTION and not(MEI_DESCRIPTION)">
					<xsl:attribute name="MEI_DESCRIPTION"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEI_MIT_ID"><xsl:value-of select="MEI_MIT_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEI_MIT_ID and not(MEI_MIT_ID)">
					<xsl:attribute name="MEI_MIT_ID"></xsl:attribute>
				</xsl:if>
				<xsl:attribute name="MEIR_ID"><xsl:value-of select="MEIR_ID" /></xsl:attribute>
				<xsl:if test="msxsl:node-set($Original)/MEIR_ID and not(MEIR_ID)">
					<xsl:attribute name="MEIR_ID"></xsl:attribute>
				</xsl:if>
			</xsl:otherwise>
		</xsl:choose>

	</ROW>
</xsl:template>

<xsl:template match="/">
	<DATAPACKET Version="2.0">
	<xsl:call-template name="Output_Schema" />
	<ROWDATA>
		<xsl:for-each select="//FeatureMediaInventoryDataSet/FEATUREMEDIAINVENTORY">
			<xsl:choose>
				<xsl:when test="@diffgr:hasChanges='inserted'">
					<xsl:call-template name="OutputFEATUREMEDIAINVENTORY">
						<xsl:with-param name="RowState" select="$ROWSTATE_NEW" />
					</xsl:call-template>
				</xsl:when>

				<xsl:when test="@diffgr:hasChanges='modified'">
					<xsl:for-each select="key('OriginalFEATUREMEDIAINVENTORY', @diffgr:id)">
						<xsl:call-template name="OutputFEATUREMEDIAINVENTORY">
							<xsl:with-param name="RowState" select="$ROWSTATE_BEFORE" />
						</xsl:call-template>
					</xsl:for-each>
					<xsl:call-template name="OutputFEATUREMEDIAINVENTORY">
						<xsl:with-param name="Original" select="key('OriginalFEATUREMEDIAINVENTORY', @diffgr:id)" />
						<xsl:with-param name="RowState" select="$ROWSTATE_AFTER" />
					</xsl:call-template>
				</xsl:when>
			</xsl:choose>
		</xsl:for-each>
		<xsl:for-each select="//diffgr:before/FEATUREMEDIAINVENTORY">
			<xsl:if test="count(key('CurrentFEATUREMEDIAINVENTORY', @diffgr:id)) = 0">
				<xsl:call-template name="OutputFEATUREMEDIAINVENTORY">
					<xsl:with-param name="RowState" select="$ROWSTATE_DELETED" />
				</xsl:call-template>
			</xsl:if>
		</xsl:for-each>
	</ROWDATA>
	</DATAPACKET>
</xsl:template>
</xsl:stylesheet>
