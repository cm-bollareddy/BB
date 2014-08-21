<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="MediaFeatureClassDataSet" targetNamespace="http://localhost/BVWebService/xsd/LoadMediaFeatureClassDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/LoadMediaFeatureClassDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/LoadMediaFeatureClassDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="MediaFeatureClassDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="MEDIAFEATURECLASS"><xs:complexType><xs:sequence><xs:element name="MFC_ID" type="xs:int" /><xs:element name="MFC_DESC"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MFC_CODE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="6" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MFC_ISAUDIOCLASS" type="xs:short" minOccurs="0" /><xs:element name="MFC_MEF_ID_AUDIO1" type="xs:int" minOccurs="0" /><xs:element name="MFC_MEF_ID_AUDIO2" type="xs:int" minOccurs="0" /><xs:element name="MFC_MEF_ID_AUDIO3" type="xs:int" minOccurs="0" /><xs:element name="MFC_MEF_ID_AUDIO4" type="xs:int" minOccurs="0" /><xs:element name="MFC_ISARCHIVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_MEDIAFEATURECLASS" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:MEDIAFEATURECLASS" /><xs:field xpath="mstns:MFC_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<MediaFeatureClassDataSet xmlns="http://localhost/BVWebService/xsd/LoadMediaFeatureClassDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<MEDIAFEATURECLASS>
				<xsl:attribute name="diffgr:id">MEDIAFEATURECLASS<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<MFC_ID><xsl:value-of select="@MFC_ID" /></MFC_ID>
					<MFC_DESC><xsl:value-of select="@MFC_DESC" /></MFC_DESC>
					<xsl:if test="@MFC_CODE != ''">
						<MFC_CODE><xsl:value-of select="@MFC_CODE" /></MFC_CODE>
					</xsl:if>
					<xsl:if test="@MFC_ISAUDIOCLASS != ''">
						<MFC_ISAUDIOCLASS><xsl:value-of select="@MFC_ISAUDIOCLASS" /></MFC_ISAUDIOCLASS>
					</xsl:if>
					<xsl:if test="@MFC_MEF_ID_AUDIO1 != ''">
						<MFC_MEF_ID_AUDIO1><xsl:value-of select="@MFC_MEF_ID_AUDIO1" /></MFC_MEF_ID_AUDIO1>
					</xsl:if>
					<xsl:if test="@MFC_MEF_ID_AUDIO2 != ''">
						<MFC_MEF_ID_AUDIO2><xsl:value-of select="@MFC_MEF_ID_AUDIO2" /></MFC_MEF_ID_AUDIO2>
					</xsl:if>
					<xsl:if test="@MFC_MEF_ID_AUDIO3 != ''">
						<MFC_MEF_ID_AUDIO3><xsl:value-of select="@MFC_MEF_ID_AUDIO3" /></MFC_MEF_ID_AUDIO3>
					</xsl:if>
					<xsl:if test="@MFC_MEF_ID_AUDIO4 != ''">
						<MFC_MEF_ID_AUDIO4><xsl:value-of select="@MFC_MEF_ID_AUDIO4" /></MFC_MEF_ID_AUDIO4>
					</xsl:if>
					<xsl:if test="@MFC_ISARCHIVED != ''">
						<MFC_ISARCHIVED><xsl:value-of select="@MFC_ISARCHIVED" /></MFC_ISARCHIVED>
					</xsl:if>
				</MEDIAFEATURECLASS>
			</xsl:for-each>
		</MediaFeatureClassDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
