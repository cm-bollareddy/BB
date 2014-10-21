<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="MediaInventoryRevisionDataSet" targetNamespace="http://localhost/BVWebService/xsd/MediaInventoryRevisionDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/MediaInventoryRevisionDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/MediaInventoryRevisionDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="MediaInventoryRevisionDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="MEDIAINVENTORYREVISION"><xs:complexType><xs:sequence><xs:element name="MEIR_ID" type="xs:int" /><xs:element name="MEI_ASS_ID" type="xs:int" minOccurs="0" /><xs:element name="MEIR_MEI_ID" type="xs:int" minOccurs="0" /><xs:element name="MEI_NUMBER" type="xs:int" minOccurs="0" /><xs:element name="MEI_SLU_ID_STATUS" type="xs:int" minOccurs="0" /><xs:element name="MEI_ISNOINGEST" type="xs:int" minOccurs="0" /><xs:element name="MEI_LASTSUBMITTEDDATE" type="xs:dateTime" minOccurs="0" /><xs:element name="MEI_PBSOPERATINGUNIT" type="xs:int" minOccurs="0" /><xs:element name="MEI_PBSOPERATINGGROUP" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MEI_MIT_ID" type="xs:int" minOccurs="0" /><xs:element name="MEI_MET_ID" type="xs:int" minOccurs="0" /><xs:element name="MEI_ISCOMPLETEPACKAGE" type="xs:short" minOccurs="0" /><xs:element name="MEI_VET_ID" type="xs:int" minOccurs="0" /><xs:element name="MEI_ISDROPFRAME" type="xs:short" minOccurs="0" /><xs:element name="MEI_SLU_ID_PBSMEDIASTATUS" type="xs:int" minOccurs="0" /><xs:element name="MEIR_ISBILLABLE" type="xs:short" minOccurs="0" /><xs:element name="MEI_ISCHANGESALLOWED" type="xs:short" minOccurs="0" /><xs:element name="MEIR_SLU_ID_PBSMEDIASTATUS" type="xs:int" minOccurs="0" /><xs:element name="MEIR_SLU_ID_STATUS" type="xs:int" minOccurs="0" /><xs:element name="MEIR_ISNOINGEST" type="xs:int" minOccurs="0" /><xs:element name="MEI_NOTE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MEI_ISHDINGEST" type="xs:short" minOccurs="0" /><xs:element name="MEIR_REVISIONNO" type="xs:short" minOccurs="0" /><xs:element name="MEIR_MFC_ID_AUDIOTYPE" type="xs:int" minOccurs="0" /><xs:element name="MEIR_ISCC" type="xs:short" minOccurs="0" /><xs:element name="MEIR_ISDVI" type="xs:short" minOccurs="0" /><xs:element name="MEIR_ISSAP" type="xs:short" minOccurs="0" /><xs:element name="MEIR_SLU_ID_ASPECTRATIO" type="xs:int" minOccurs="0" /><xs:element name="MEIR_SLU_ID_HIDEF" type="xs:int" minOccurs="0" /><xs:element name="MEIR_MEF_ID_AUDIO1" type="xs:int" minOccurs="0" /><xs:element name="MEIR_MEF_ID_AUDIO2" type="xs:int" minOccurs="0" /><xs:element name="MEIR_MEF_ID_AUDIO3" type="xs:int" minOccurs="0" /><xs:element name="MEIR_MEF_ID_AUDIO4" type="xs:int" minOccurs="0" /><xs:element name="MEIR_MEF_ID_CAPTION1" type="xs:int" minOccurs="0" /><xs:element name="MEIR_MEF_ID_CAPTION2" type="xs:int" minOccurs="0" /><xs:element name="MEIR_MEF_ID_CAPTION3" type="xs:int" minOccurs="0" /><xs:element name="MEIR_CONTACTMANAGER" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MEIR_CONTACTMANAGER_PHONE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MEIR_CONTACTMANAGER_EMAIL" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="252" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MEIR_CONTACTTECHNICIAN" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MEIR_CONTACTTECHNICIAN_PHONE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MEIR_CONTACTTECHNICIAN_EMAIL" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="252" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MEIR_IS_CC_PBSENCODES" type="xs:short" minOccurs="0" /><xs:element name="MEIR_CC_PROVIDER" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MEIR_IS_CC_PBSCOORDINATES" type="xs:short" minOccurs="0" /><xs:element name="MEIR_PBSCV_ID" type="xs:int" minOccurs="0" /><xs:element name="MEIR_IS_DVI_PBSENCODES" type="xs:short" minOccurs="0" /><xs:element name="MEIR_IS_DVI_PBSCOORDINATES" type="xs:short" minOccurs="0" /><xs:element name="MEIR_IS_SAP_PBSENCODES" type="xs:short" minOccurs="0" /><xs:element name="MEIR_ISREVISIONREQUIRED" type="xs:short" minOccurs="0" /><xs:element name="MEI_CLASS" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="3" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MEI_DESCRIPTION" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MEI_ISPREFEEDONLY" type="xs:short" minOccurs="0" /><xs:element name="MEI_ISCONTAINERIZED" type="xs:short" minOccurs="0" /><xs:element name="MEIR_PBSBT_ID" type="xs:int" minOccurs="0" /><xs:element name="MEIR_PBSBC_ID" type="xs:int" minOccurs="0" /></xs:sequence></xs:complexType></xs:element><xs:element name="MEDIAINVENTORYCUT"><xs:complexType><xs:sequence><xs:element name="MIC_ID" type="xs:int" /><xs:element name="MIC_MEIR_ID" type="xs:int" /><xs:element name="MIC_NUMBER" type="xs:short" minOccurs="0" /><xs:element name="MIC_MICT_ID" type="xs:int" minOccurs="0" /><xs:element name="MIC_DESCRIPTION" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MIC_ISREUSABLE" type="xs:short" minOccurs="0" /><xs:element name="MIC_TIMECODEIN" type="xs:int" minOccurs="0" /><xs:element name="MIC_DURATION" type="xs:int" minOccurs="0" /><xs:element name="MIC_TIMECODEOUT" type="xs:int" minOccurs="0" /><xs:element name="MIC_ISVARIABLELENGTH" type="xs:short" minOccurs="0" /><xs:element name="MIC_DURATIONMINIMUM" type="xs:int" minOccurs="0" /><xs:element name="MIC_ISREPLACEMENTITEM" type="xs:short" minOccurs="0" /><xs:element name="MIC_REPLACEMENTNOTE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MIC_ASS_ID" type="xs:int" minOccurs="0" /><xs:element name="MIC_ASSOCIATEDTITLE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MIC_NEW_DESC" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MIC_NEW_DATEAVAILABLEFROM" type="xs:dateTime" minOccurs="0" /><xs:element name="MIC_NEW_DATEAVAILABLETO" type="xs:dateTime" minOccurs="0" /><xs:element name="ASS_TITLE" msdata:ReadOnly="true" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MIC_MFC_ID_AUDIOTYPE" type="xs:int" minOccurs="0" /><xs:element name="MIC_ISCC" type="xs:short" minOccurs="0" /><xs:element name="MIC_ISDVI" type="xs:short" minOccurs="0" /><xs:element name="MIC_ISSAP" type="xs:short" minOccurs="0" /><xs:element name="MIC_SLU_ID_ASPECTRATIO" type="xs:int" minOccurs="0" /><xs:element name="MIC_SLU_ID_HIDEF" type="xs:int" minOccurs="0" /><xs:element name="MIC_MEF_ID_AUDIO1" type="xs:int" minOccurs="0" /><xs:element name="MIC_MEF_ID_AUDIO2" type="xs:int" minOccurs="0" /><xs:element name="MIC_MEF_ID_AUDIO3" type="xs:int" minOccurs="0" /><xs:element name="MIC_MEF_ID_AUDIO4" type="xs:int" minOccurs="0" /><xs:element name="MIC_MEF_ID_AUDIO5" type="xs:int" minOccurs="0" /><xs:element name="MIC_MEF_ID_AUDIO6" type="xs:int" minOccurs="0" /><xs:element name="MIC_MEF_ID_AUDIO7" type="xs:int" minOccurs="0" /><xs:element name="MIC_MEF_ID_AUDIO8" type="xs:int" minOccurs="0" /><xs:element name="MIC_MEF_ID_CAPTION1" type="xs:int" minOccurs="0" /><xs:element name="MIC_MEF_ID_CAPTION2" type="xs:int" minOccurs="0" /><xs:element name="MIC_MEF_ID_CAPTION3" type="xs:int" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_MEDIAINVENTORYREVISION" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:MEDIAINVENTORYREVISION" /><xs:field xpath="mstns:MEIR_ID" /></xs:unique><xs:unique name="PK_MEDIAINVENTORYCUT" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:MEDIAINVENTORYCUT" /><xs:field xpath="mstns:MIC_ID" /></xs:unique><xs:keyref name="FK_MEDIAINVENTORYREVISION_MEDIAINVENTORYCUT" refer="PK_MEDIAINVENTORYREVISION"><xs:selector xpath=".//mstns:MEDIAINVENTORYCUT" /><xs:field xpath="mstns:MIC_MEIR_ID" /></xs:keyref></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<MediaInventoryRevisionDataSet xmlns="http://localhost/BVWebService/xsd/MediaInventoryRevisionDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<MEDIAINVENTORYREVISION>
				<xsl:attribute name="diffgr:id">MEDIAINVENTORYREVISION<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<MEIR_ID><xsl:value-of select="@MEIR_ID" /></MEIR_ID>
					<xsl:if test="@MEI_ASS_ID != ''">
						<MEI_ASS_ID><xsl:value-of select="@MEI_ASS_ID" /></MEI_ASS_ID>
					</xsl:if>
					<xsl:if test="@MEIR_MEI_ID != ''">
						<MEIR_MEI_ID><xsl:value-of select="@MEIR_MEI_ID" /></MEIR_MEI_ID>
					</xsl:if>
					<xsl:if test="@MEI_NUMBER != ''">
						<MEI_NUMBER><xsl:value-of select="@MEI_NUMBER" /></MEI_NUMBER>
					</xsl:if>
					<xsl:if test="@MEI_SLU_ID_STATUS != ''">
						<MEI_SLU_ID_STATUS><xsl:value-of select="@MEI_SLU_ID_STATUS" /></MEI_SLU_ID_STATUS>
					</xsl:if>
					<xsl:if test="@MEI_ISNOINGEST != ''">
						<MEI_ISNOINGEST><xsl:value-of select="@MEI_ISNOINGEST" /></MEI_ISNOINGEST>
					</xsl:if>
					<xsl:if test="@MEI_LASTSUBMITTEDDATE != ''">
						<MEI_LASTSUBMITTEDDATE>
							<xsl:call-template name="DateConverter">
								<xsl:with-param name="InDate"><xsl:value-of select="@MEI_LASTSUBMITTEDDATE" /></xsl:with-param>
							</xsl:call-template>
						</MEI_LASTSUBMITTEDDATE>
					</xsl:if>
					<xsl:if test="@MEI_PBSOPERATINGUNIT != ''">
						<MEI_PBSOPERATINGUNIT><xsl:value-of select="@MEI_PBSOPERATINGUNIT" /></MEI_PBSOPERATINGUNIT>
					</xsl:if>
						<MEI_PBSOPERATINGGROUP><xsl:value-of select="@MEI_PBSOPERATINGGROUP" /></MEI_PBSOPERATINGGROUP>
					<xsl:if test="@MEI_MIT_ID != ''">
						<MEI_MIT_ID><xsl:value-of select="@MEI_MIT_ID" /></MEI_MIT_ID>
					</xsl:if>
					<xsl:if test="@MEI_MET_ID != ''">
						<MEI_MET_ID><xsl:value-of select="@MEI_MET_ID" /></MEI_MET_ID>
					</xsl:if>
					<xsl:if test="@MEI_ISCOMPLETEPACKAGE != ''">
						<MEI_ISCOMPLETEPACKAGE><xsl:value-of select="@MEI_ISCOMPLETEPACKAGE" /></MEI_ISCOMPLETEPACKAGE>
					</xsl:if>
					<xsl:if test="@MEI_VET_ID != ''">
						<MEI_VET_ID><xsl:value-of select="@MEI_VET_ID" /></MEI_VET_ID>
					</xsl:if>
					<xsl:if test="@MEI_ISDROPFRAME != ''">
						<MEI_ISDROPFRAME><xsl:value-of select="@MEI_ISDROPFRAME" /></MEI_ISDROPFRAME>
					</xsl:if>
					<xsl:if test="@MEI_SLU_ID_PBSMEDIASTATUS != ''">
						<MEI_SLU_ID_PBSMEDIASTATUS><xsl:value-of select="@MEI_SLU_ID_PBSMEDIASTATUS" /></MEI_SLU_ID_PBSMEDIASTATUS>
					</xsl:if>
					<xsl:if test="@MEIR_ISBILLABLE != ''">
						<MEIR_ISBILLABLE><xsl:value-of select="@MEIR_ISBILLABLE" /></MEIR_ISBILLABLE>
					</xsl:if>
					<xsl:if test="@MEI_ISCHANGESALLOWED != ''">
						<MEI_ISCHANGESALLOWED><xsl:value-of select="@MEI_ISCHANGESALLOWED" /></MEI_ISCHANGESALLOWED>
					</xsl:if>
					<xsl:if test="@MEIR_SLU_ID_PBSMEDIASTATUS != ''">
						<MEIR_SLU_ID_PBSMEDIASTATUS><xsl:value-of select="@MEIR_SLU_ID_PBSMEDIASTATUS" /></MEIR_SLU_ID_PBSMEDIASTATUS>
					</xsl:if>
					<xsl:if test="@MEIR_SLU_ID_STATUS != ''">
						<MEIR_SLU_ID_STATUS><xsl:value-of select="@MEIR_SLU_ID_STATUS" /></MEIR_SLU_ID_STATUS>
					</xsl:if>
					<xsl:if test="@MEIR_ISNOINGEST != ''">
						<MEIR_ISNOINGEST><xsl:value-of select="@MEIR_ISNOINGEST" /></MEIR_ISNOINGEST>
					</xsl:if>
					<xsl:if test="@MEI_NOTE != ''">
						<MEI_NOTE><xsl:value-of select="@MEI_NOTE" /></MEI_NOTE>
					</xsl:if>
					<xsl:if test="@MEI_ISHDINGEST != ''">
						<MEI_ISHDINGEST><xsl:value-of select="@MEI_ISHDINGEST" /></MEI_ISHDINGEST>
					</xsl:if>
					<xsl:if test="@MEIR_REVISIONNO != ''">
						<MEIR_REVISIONNO><xsl:value-of select="@MEIR_REVISIONNO" /></MEIR_REVISIONNO>
					</xsl:if>
					<xsl:if test="@MEIR_MFC_ID_AUDIOTYPE != ''">
						<MEIR_MFC_ID_AUDIOTYPE><xsl:value-of select="@MEIR_MFC_ID_AUDIOTYPE" /></MEIR_MFC_ID_AUDIOTYPE>
					</xsl:if>
					<xsl:if test="@MEIR_ISCC != ''">
						<MEIR_ISCC><xsl:value-of select="@MEIR_ISCC" /></MEIR_ISCC>
					</xsl:if>
					<xsl:if test="@MEIR_ISDVI != ''">
						<MEIR_ISDVI><xsl:value-of select="@MEIR_ISDVI" /></MEIR_ISDVI>
					</xsl:if>
					<xsl:if test="@MEIR_ISSAP != ''">
						<MEIR_ISSAP><xsl:value-of select="@MEIR_ISSAP" /></MEIR_ISSAP>
					</xsl:if>
					<xsl:if test="@MEIR_SLU_ID_ASPECTRATIO != ''">
						<MEIR_SLU_ID_ASPECTRATIO><xsl:value-of select="@MEIR_SLU_ID_ASPECTRATIO" /></MEIR_SLU_ID_ASPECTRATIO>
					</xsl:if>
					<xsl:if test="@MEIR_SLU_ID_HIDEF != ''">
						<MEIR_SLU_ID_HIDEF><xsl:value-of select="@MEIR_SLU_ID_HIDEF" /></MEIR_SLU_ID_HIDEF>
					</xsl:if>
					<xsl:if test="@MEIR_MEF_ID_AUDIO1 != ''">
						<MEIR_MEF_ID_AUDIO1><xsl:value-of select="@MEIR_MEF_ID_AUDIO1" /></MEIR_MEF_ID_AUDIO1>
					</xsl:if>
					<xsl:if test="@MEIR_MEF_ID_AUDIO2 != ''">
						<MEIR_MEF_ID_AUDIO2><xsl:value-of select="@MEIR_MEF_ID_AUDIO2" /></MEIR_MEF_ID_AUDIO2>
					</xsl:if>
					<xsl:if test="@MEIR_MEF_ID_AUDIO3 != ''">
						<MEIR_MEF_ID_AUDIO3><xsl:value-of select="@MEIR_MEF_ID_AUDIO3" /></MEIR_MEF_ID_AUDIO3>
					</xsl:if>
					<xsl:if test="@MEIR_MEF_ID_AUDIO4 != ''">
						<MEIR_MEF_ID_AUDIO4><xsl:value-of select="@MEIR_MEF_ID_AUDIO4" /></MEIR_MEF_ID_AUDIO4>
					</xsl:if>
					<xsl:if test="@MEIR_MEF_ID_CAPTION1 != ''">
						<MEIR_MEF_ID_CAPTION1><xsl:value-of select="@MEIR_MEF_ID_CAPTION1" /></MEIR_MEF_ID_CAPTION1>
					</xsl:if>
					<xsl:if test="@MEIR_MEF_ID_CAPTION2 != ''">
						<MEIR_MEF_ID_CAPTION2><xsl:value-of select="@MEIR_MEF_ID_CAPTION2" /></MEIR_MEF_ID_CAPTION2>
					</xsl:if>
					<xsl:if test="@MEIR_MEF_ID_CAPTION3 != ''">
						<MEIR_MEF_ID_CAPTION3><xsl:value-of select="@MEIR_MEF_ID_CAPTION3" /></MEIR_MEF_ID_CAPTION3>
					</xsl:if>
					<xsl:if test="@MEIR_CONTACTMANAGER != ''">
						<MEIR_CONTACTMANAGER><xsl:value-of select="@MEIR_CONTACTMANAGER" /></MEIR_CONTACTMANAGER>
					</xsl:if>
					<xsl:if test="@MEIR_CONTACTMANAGER_PHONE != ''">
						<MEIR_CONTACTMANAGER_PHONE><xsl:value-of select="@MEIR_CONTACTMANAGER_PHONE" /></MEIR_CONTACTMANAGER_PHONE>
					</xsl:if>
					<xsl:if test="@MEIR_CONTACTMANAGER_EMAIL != ''">
						<MEIR_CONTACTMANAGER_EMAIL><xsl:value-of select="@MEIR_CONTACTMANAGER_EMAIL" /></MEIR_CONTACTMANAGER_EMAIL>
					</xsl:if>
					<xsl:if test="@MEIR_CONTACTTECHNICIAN != ''">
						<MEIR_CONTACTTECHNICIAN><xsl:value-of select="@MEIR_CONTACTTECHNICIAN" /></MEIR_CONTACTTECHNICIAN>
					</xsl:if>
					<xsl:if test="@MEIR_CONTACTTECHNICIAN_PHONE != ''">
						<MEIR_CONTACTTECHNICIAN_PHONE><xsl:value-of select="@MEIR_CONTACTTECHNICIAN_PHONE" /></MEIR_CONTACTTECHNICIAN_PHONE>
					</xsl:if>
					<xsl:if test="@MEIR_CONTACTTECHNICIAN_EMAIL != ''">
						<MEIR_CONTACTTECHNICIAN_EMAIL><xsl:value-of select="@MEIR_CONTACTTECHNICIAN_EMAIL" /></MEIR_CONTACTTECHNICIAN_EMAIL>
					</xsl:if>
					<xsl:if test="@MEIR_IS_CC_PBSENCODES != ''">
						<MEIR_IS_CC_PBSENCODES><xsl:value-of select="@MEIR_IS_CC_PBSENCODES" /></MEIR_IS_CC_PBSENCODES>
					</xsl:if>
					<xsl:if test="@MEIR_CC_PROVIDER != ''">
						<MEIR_CC_PROVIDER><xsl:value-of select="@MEIR_CC_PROVIDER" /></MEIR_CC_PROVIDER>
					</xsl:if>
					<xsl:if test="@MEIR_IS_CC_PBSCOORDINATES != ''">
						<MEIR_IS_CC_PBSCOORDINATES><xsl:value-of select="@MEIR_IS_CC_PBSCOORDINATES" /></MEIR_IS_CC_PBSCOORDINATES>
					</xsl:if>
					<xsl:if test="@MEIR_PBSCV_ID != ''">
						<MEIR_PBSCV_ID><xsl:value-of select="@MEIR_PBSCV_ID" /></MEIR_PBSCV_ID>
					</xsl:if>
					<xsl:if test="@MEIR_IS_DVI_PBSENCODES != ''">
						<MEIR_IS_DVI_PBSENCODES><xsl:value-of select="@MEIR_IS_DVI_PBSENCODES" /></MEIR_IS_DVI_PBSENCODES>
					</xsl:if>
					<xsl:if test="@MEIR_IS_DVI_PBSCOORDINATES != ''">
						<MEIR_IS_DVI_PBSCOORDINATES><xsl:value-of select="@MEIR_IS_DVI_PBSCOORDINATES" /></MEIR_IS_DVI_PBSCOORDINATES>
					</xsl:if>
					<xsl:if test="@MEIR_IS_SAP_PBSENCODES != ''">
						<MEIR_IS_SAP_PBSENCODES><xsl:value-of select="@MEIR_IS_SAP_PBSENCODES" /></MEIR_IS_SAP_PBSENCODES>
					</xsl:if>
					<xsl:if test="@MEIR_ISREVISIONREQUIRED != ''">
						<MEIR_ISREVISIONREQUIRED><xsl:value-of select="@MEIR_ISREVISIONREQUIRED" /></MEIR_ISREVISIONREQUIRED>
					</xsl:if>
					<xsl:if test="@MEI_CLASS != ''">
						<MEI_CLASS><xsl:value-of select="@MEI_CLASS" /></MEI_CLASS>
					</xsl:if>
					<xsl:if test="@MEI_DESCRIPTION != ''">
						<MEI_DESCRIPTION><xsl:value-of select="@MEI_DESCRIPTION" /></MEI_DESCRIPTION>
					</xsl:if>
					<xsl:if test="@MEI_ISPREFEEDONLY != ''">
						<MEI_ISPREFEEDONLY><xsl:value-of select="@MEI_ISPREFEEDONLY" /></MEI_ISPREFEEDONLY>
					</xsl:if>
					<xsl:if test="@MEI_ISCONTAINERIZED != ''">
						<MEI_ISCONTAINERIZED><xsl:value-of select="@MEI_ISCONTAINERIZED" /></MEI_ISCONTAINERIZED>
					</xsl:if>
					<xsl:if test="@MEIR_PBSBT_ID != ''">
						<MEIR_PBSBT_ID><xsl:value-of select="@MEIR_PBSBT_ID" /></MEIR_PBSBT_ID>
					</xsl:if>
					<xsl:if test="@MEIR_PBSBC_ID != ''">
						<MEIR_PBSBC_ID><xsl:value-of select="@MEIR_PBSBC_ID" /></MEIR_PBSBC_ID>
					</xsl:if>
				</MEDIAINVENTORYREVISION>
				<xsl:for-each select="MEDIAINVENTORYCUT/ROWMEDIAINVENTORYCUT">
					<MEDIAINVENTORYCUT>
					<xsl:attribute name="diffgr:id">MEDIAINVENTORYCUT<xsl:value-of select="position()" /></xsl:attribute>
					<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
						<MIC_ID><xsl:value-of select="@MIC_ID" /></MIC_ID>
						<MIC_MEIR_ID><xsl:value-of select="@MIC_MEIR_ID" /></MIC_MEIR_ID>
						<xsl:if test="@MIC_NUMBER != ''">
							<MIC_NUMBER><xsl:value-of select="@MIC_NUMBER" /></MIC_NUMBER>
						</xsl:if>
						<xsl:if test="@MIC_MICT_ID != ''">
							<MIC_MICT_ID><xsl:value-of select="@MIC_MICT_ID" /></MIC_MICT_ID>
						</xsl:if>
						<xsl:if test="@MIC_DESCRIPTION != ''">
							<MIC_DESCRIPTION><xsl:value-of select="@MIC_DESCRIPTION" /></MIC_DESCRIPTION>
						</xsl:if>
						<xsl:if test="@MIC_ISREUSABLE != ''">
							<MIC_ISREUSABLE><xsl:value-of select="@MIC_ISREUSABLE" /></MIC_ISREUSABLE>
						</xsl:if>
						<xsl:if test="@MIC_TIMECODEIN != ''">
							<MIC_TIMECODEIN><xsl:value-of select="@MIC_TIMECODEIN" /></MIC_TIMECODEIN>
						</xsl:if>
						<xsl:if test="@MIC_DURATION != ''">
							<MIC_DURATION><xsl:value-of select="@MIC_DURATION" /></MIC_DURATION>
						</xsl:if>
						<xsl:if test="@MIC_TIMECODEOUT != ''">
							<MIC_TIMECODEOUT><xsl:value-of select="@MIC_TIMECODEOUT" /></MIC_TIMECODEOUT>
						</xsl:if>
						<xsl:if test="@MIC_ISVARIABLELENGTH != ''">
							<MIC_ISVARIABLELENGTH><xsl:value-of select="@MIC_ISVARIABLELENGTH" /></MIC_ISVARIABLELENGTH>
						</xsl:if>
						<xsl:if test="@MIC_DURATIONMINIMUM != ''">
							<MIC_DURATIONMINIMUM><xsl:value-of select="@MIC_DURATIONMINIMUM" /></MIC_DURATIONMINIMUM>
						</xsl:if>
						<xsl:if test="@MIC_ISREPLACEMENTITEM != ''">
							<MIC_ISREPLACEMENTITEM><xsl:value-of select="@MIC_ISREPLACEMENTITEM" /></MIC_ISREPLACEMENTITEM>
						</xsl:if>
						<xsl:if test="@MIC_REPLACEMENTNOTE != ''">
							<MIC_REPLACEMENTNOTE><xsl:value-of select="@MIC_REPLACEMENTNOTE" /></MIC_REPLACEMENTNOTE>
						</xsl:if>
						<xsl:if test="@MIC_ASS_ID != ''">
							<MIC_ASS_ID><xsl:value-of select="@MIC_ASS_ID" /></MIC_ASS_ID>
						</xsl:if>
						<xsl:if test="@MIC_ASSOCIATEDTITLE != ''">
							<MIC_ASSOCIATEDTITLE><xsl:value-of select="@MIC_ASSOCIATEDTITLE" /></MIC_ASSOCIATEDTITLE>
						</xsl:if>
						<xsl:if test="@MIC_NEW_DESC != ''">
							<MIC_NEW_DESC><xsl:value-of select="@MIC_NEW_DESC" /></MIC_NEW_DESC>
						</xsl:if>
						<xsl:if test="@MIC_NEW_DATEAVAILABLEFROM != ''">
							<MIC_NEW_DATEAVAILABLEFROM>
								<xsl:call-template name="DateConverter">
									<xsl:with-param name="InDate"><xsl:value-of select="@MIC_NEW_DATEAVAILABLEFROM" /></xsl:with-param>
								</xsl:call-template>
							</MIC_NEW_DATEAVAILABLEFROM>
						</xsl:if>
						<xsl:if test="@MIC_NEW_DATEAVAILABLETO != ''">
							<MIC_NEW_DATEAVAILABLETO>
								<xsl:call-template name="DateConverter">
									<xsl:with-param name="InDate"><xsl:value-of select="@MIC_NEW_DATEAVAILABLETO" /></xsl:with-param>
								</xsl:call-template>
							</MIC_NEW_DATEAVAILABLETO>
						</xsl:if>
						<xsl:if test="@ASS_TITLE != ''">
							<ASS_TITLE><xsl:value-of select="@ASS_TITLE" /></ASS_TITLE>
						</xsl:if>
						<xsl:if test="@MIC_MFC_ID_AUDIOTYPE != ''">
							<MIC_MFC_ID_AUDIOTYPE><xsl:value-of select="@MIC_MFC_ID_AUDIOTYPE" /></MIC_MFC_ID_AUDIOTYPE>
						</xsl:if>
						<xsl:if test="@MIC_ISCC != ''">
							<MIC_ISCC><xsl:value-of select="@MIC_ISCC" /></MIC_ISCC>
						</xsl:if>
						<xsl:if test="@MIC_ISDVI != ''">
							<MIC_ISDVI><xsl:value-of select="@MIC_ISDVI" /></MIC_ISDVI>
						</xsl:if>
						<xsl:if test="@MIC_ISSAP != ''">
							<MIC_ISSAP><xsl:value-of select="@MIC_ISSAP" /></MIC_ISSAP>
						</xsl:if>
						<xsl:if test="@MIC_SLU_ID_ASPECTRATIO != ''">
							<MIC_SLU_ID_ASPECTRATIO><xsl:value-of select="@MIC_SLU_ID_ASPECTRATIO" /></MIC_SLU_ID_ASPECTRATIO>
						</xsl:if>
						<xsl:if test="@MIC_SLU_ID_HIDEF != ''">
							<MIC_SLU_ID_HIDEF><xsl:value-of select="@MIC_SLU_ID_HIDEF" /></MIC_SLU_ID_HIDEF>
						</xsl:if>
						<xsl:if test="@MIC_MEF_ID_AUDIO1 != ''">
							<MIC_MEF_ID_AUDIO1><xsl:value-of select="@MIC_MEF_ID_AUDIO1" /></MIC_MEF_ID_AUDIO1>
						</xsl:if>
						<xsl:if test="@MIC_MEF_ID_AUDIO2 != ''">
							<MIC_MEF_ID_AUDIO2><xsl:value-of select="@MIC_MEF_ID_AUDIO2" /></MIC_MEF_ID_AUDIO2>
						</xsl:if>
						<xsl:if test="@MIC_MEF_ID_AUDIO3 != ''">
							<MIC_MEF_ID_AUDIO3><xsl:value-of select="@MIC_MEF_ID_AUDIO3" /></MIC_MEF_ID_AUDIO3>
						</xsl:if>
						<xsl:if test="@MIC_MEF_ID_AUDIO4 != ''">
							<MIC_MEF_ID_AUDIO4><xsl:value-of select="@MIC_MEF_ID_AUDIO4" /></MIC_MEF_ID_AUDIO4>
						</xsl:if>
						<xsl:if test="@MIC_MEF_ID_AUDIO5 != ''">
							<MIC_MEF_ID_AUDIO5><xsl:value-of select="@MIC_MEF_ID_AUDIO5" /></MIC_MEF_ID_AUDIO5>
						</xsl:if>
						<xsl:if test="@MIC_MEF_ID_AUDIO6 != ''">
							<MIC_MEF_ID_AUDIO6><xsl:value-of select="@MIC_MEF_ID_AUDIO6" /></MIC_MEF_ID_AUDIO6>
						</xsl:if>
						<xsl:if test="@MIC_MEF_ID_AUDIO7 != ''">
							<MIC_MEF_ID_AUDIO7><xsl:value-of select="@MIC_MEF_ID_AUDIO7" /></MIC_MEF_ID_AUDIO7>
						</xsl:if>
						<xsl:if test="@MIC_MEF_ID_AUDIO8 != ''">
							<MIC_MEF_ID_AUDIO8><xsl:value-of select="@MIC_MEF_ID_AUDIO8" /></MIC_MEF_ID_AUDIO8>
						</xsl:if>
						<xsl:if test="@MIC_MEF_ID_CAPTION1 != ''">
							<MIC_MEF_ID_CAPTION1><xsl:value-of select="@MIC_MEF_ID_CAPTION1" /></MIC_MEF_ID_CAPTION1>
						</xsl:if>
						<xsl:if test="@MIC_MEF_ID_CAPTION2 != ''">
							<MIC_MEF_ID_CAPTION2><xsl:value-of select="@MIC_MEF_ID_CAPTION2" /></MIC_MEF_ID_CAPTION2>
						</xsl:if>
						<xsl:if test="@MIC_MEF_ID_CAPTION3 != ''">
							<MIC_MEF_ID_CAPTION3><xsl:value-of select="@MIC_MEF_ID_CAPTION3" /></MIC_MEF_ID_CAPTION3>
						</xsl:if>
					</MEDIAINVENTORYCUT>
				</xsl:for-each>
			</xsl:for-each>
		</MediaInventoryRevisionDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
