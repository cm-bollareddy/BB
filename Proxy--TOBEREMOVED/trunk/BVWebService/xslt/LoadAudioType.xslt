<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="AudioTypeDataSet" targetNamespace="http://localhost/BVWebService/LoadAudioTypeDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/LoadAudioTypeDataSet.xsd" xmlns="http://localhost/BVWebService/LoadAudioTypeDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="AudioTypeDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="AUDIOTYPE"><xs:complexType><xs:sequence><xs:element name="MFC_ID" type="xs:int" /><xs:element name="MFC_CODE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="6" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MFC_DESC"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MFC_ISARCHIVED" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_AUDIOTYPE" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:AUDIOTYPE" /><xs:field xpath="mstns:MFC_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<AudioTypeDataSet xmlns="http://localhost/BVWebService/LoadAudioTypeDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<AUDIOTYPE>
				<xsl:attribute name="diffgr:id">AUDIOTYPE<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<MFC_ID><xsl:value-of select="@MFC_ID" /></MFC_ID>
					<xsl:if test="@MFC_CODE != ''">
						<MFC_CODE><xsl:value-of select="@MFC_CODE" /></MFC_CODE>
					</xsl:if>
					<MFC_DESC><xsl:value-of select="@MFC_DESC" /></MFC_DESC>
					<xsl:if test="@MFC_ISARCHIVED != ''">
						<MFC_ISARCHIVED><xsl:value-of select="@MFC_ISARCHIVED" /></MFC_ISARCHIVED>
					</xsl:if>
				</AUDIOTYPE>
			</xsl:for-each>
		</AudioTypeDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
