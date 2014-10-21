<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="FeatureMediaInventoryDataSet" targetNamespace="http://localhost/BVWebService/xsd/FeatureMediaInventoryDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/FeatureMediaInventoryDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/FeatureMediaInventoryDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="FeatureMediaInventoryDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="FEATUREMEDIAINVENTORY"><xs:complexType><xs:sequence><xs:element name="MEI_ID" type="xs:int" /><xs:element name="MEI_ASS_ID" type="xs:int" minOccurs="0" /><xs:element name="MEI_ID_PARENT" msdata:ReadOnly="true" type="xs:int" minOccurs="0" /><xs:element name="MEI_NUMBER" type="xs:int" minOccurs="0" /><xs:element name="MEI_SLU_ID_STATUS" type="xs:int" minOccurs="0" /><xs:element name="MEI_LASTSUBMITTEDDATE" type="xs:dateTime" minOccurs="0" /><xs:element name="MEI_MET_ID" type="xs:int" minOccurs="0" /><xs:element name="MEI_ISBILLABLE" type="xs:short" minOccurs="0" /><xs:element name="MEI_NOTE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MEI_REVISIONNO" type="xs:short" minOccurs="0" /><xs:element name="MEI_MEF_ID" type="xs:int" minOccurs="0" /><xs:element name="MEI_CLASS" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="3" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MEI_SLU_ID_PBSMEDIASTATUS" type="xs:int" minOccurs="0" /><xs:element name="MEI_DESCRIPTION" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MEI_MIT_ID" type="xs:int" minOccurs="0" /><xs:element name="MEIR_ID" type="xs:int" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_FEATUREMEDIAINVENTORY" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:FEATUREMEDIAINVENTORY" /><xs:field xpath="mstns:MEI_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<FeatureMediaInventoryDataSet xmlns="http://localhost/BVWebService/xsd/FeatureMediaInventoryDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<FEATUREMEDIAINVENTORY>
				<xsl:attribute name="diffgr:id">FEATUREMEDIAINVENTORY<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<MEI_ID><xsl:value-of select="@MEI_ID" /></MEI_ID>
					<xsl:if test="@MEI_ASS_ID != ''">
						<MEI_ASS_ID><xsl:value-of select="@MEI_ASS_ID" /></MEI_ASS_ID>
					</xsl:if>
					<xsl:if test="@MEI_ID_PARENT != ''">
						<MEI_ID_PARENT><xsl:value-of select="@MEI_ID_PARENT" /></MEI_ID_PARENT>
					</xsl:if>
					<xsl:if test="@MEI_NUMBER != ''">
						<MEI_NUMBER><xsl:value-of select="@MEI_NUMBER" /></MEI_NUMBER>
					</xsl:if>
					<xsl:if test="@MEI_SLU_ID_STATUS != ''">
						<MEI_SLU_ID_STATUS><xsl:value-of select="@MEI_SLU_ID_STATUS" /></MEI_SLU_ID_STATUS>
					</xsl:if>
					<xsl:if test="@MEI_LASTSUBMITTEDDATE != ''">
						<MEI_LASTSUBMITTEDDATE>
							<xsl:call-template name="DateConverter">
								<xsl:with-param name="InDate"><xsl:value-of select="@MEI_LASTSUBMITTEDDATE" /></xsl:with-param>
							</xsl:call-template>
						</MEI_LASTSUBMITTEDDATE>
					</xsl:if>
					<xsl:if test="@MEI_MET_ID != ''">
						<MEI_MET_ID><xsl:value-of select="@MEI_MET_ID" /></MEI_MET_ID>
					</xsl:if>
					<xsl:if test="@MEI_ISBILLABLE != ''">
						<MEI_ISBILLABLE><xsl:value-of select="@MEI_ISBILLABLE" /></MEI_ISBILLABLE>
					</xsl:if>
					<xsl:if test="@MEI_NOTE != ''">
						<MEI_NOTE><xsl:value-of select="@MEI_NOTE" /></MEI_NOTE>
					</xsl:if>
					<xsl:if test="@MEI_REVISIONNO != ''">
						<MEI_REVISIONNO><xsl:value-of select="@MEI_REVISIONNO" /></MEI_REVISIONNO>
					</xsl:if>
					<xsl:if test="@MEI_MEF_ID != ''">
						<MEI_MEF_ID><xsl:value-of select="@MEI_MEF_ID" /></MEI_MEF_ID>
					</xsl:if>
					<xsl:if test="@MEI_CLASS != ''">
						<MEI_CLASS><xsl:value-of select="@MEI_CLASS" /></MEI_CLASS>
					</xsl:if>
					<xsl:if test="@MEI_SLU_ID_PBSMEDIASTATUS != ''">
						<MEI_SLU_ID_PBSMEDIASTATUS><xsl:value-of select="@MEI_SLU_ID_PBSMEDIASTATUS" /></MEI_SLU_ID_PBSMEDIASTATUS>
					</xsl:if>
					<xsl:if test="@MEI_DESCRIPTION != ''">
						<MEI_DESCRIPTION><xsl:value-of select="@MEI_DESCRIPTION" /></MEI_DESCRIPTION>
					</xsl:if>
					<xsl:if test="@MEI_MIT_ID != ''">
						<MEI_MIT_ID><xsl:value-of select="@MEI_MIT_ID" /></MEI_MIT_ID>
					</xsl:if>
					<xsl:if test="@MEIR_ID != ''">
						<MEIR_ID><xsl:value-of select="@MEIR_ID" /></MEIR_ID>
					</xsl:if>
				</FEATUREMEDIAINVENTORY>
			</xsl:for-each>
		</FeatureMediaInventoryDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
