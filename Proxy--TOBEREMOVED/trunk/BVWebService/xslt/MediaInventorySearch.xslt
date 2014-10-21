<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="MediaInventoryDataSet" targetNamespace="http://localhost/BVWebService/xsd/MediaInventorySearchDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/MediaInventorySearchDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/MediaInventorySearchDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="MediaInventoryDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="MEDIAINVENTORYSEARCH"><xs:complexType><xs:sequence><xs:element name="MEI_ID" type="xs:int" /><xs:element name="MEI_UPDATEDATETIME" type="xs:dateTime" minOccurs="0" /><xs:element name="MEI_DESCRIPTION"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MEI_VET_ID" type="xs:int" minOccurs="0" /><xs:element name="MEI_ASS_ID" type="xs:int" minOccurs="0" /><xs:element name="MEI_ISFEATUREONLY" type="xs:short" minOccurs="0" /><xs:element name="MEI_CLASS"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="3" /></xs:restriction></xs:simpleType></xs:element><xs:element name="MEIR_ID" msdata:ReadOnly="true" type="xs:int" minOccurs="0" /><xs:element name="MEIR_ISREVISIONREQUIRED" msdata:ReadOnly="true" type="xs:short" minOccurs="0" /><xs:element name="MEIR_ISARCHIVED" msdata:ReadOnly="true" type="xs:short" minOccurs="0" /><xs:element name="MEI_ID_PARENT" msdata:ReadOnly="true" type="xs:int" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<MediaInventoryDataSet xmlns="http://localhost/BVWebService/xsd/MediaInventorySearchDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<MEDIAINVENTORYSEARCH>
				<xsl:attribute name="diffgr:id">MEDIAINVENTORYSEARCH<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<MEI_ID><xsl:value-of select="@MEI_ID" /></MEI_ID>
					<xsl:if test="@MEI_UPDATEDATETIME != ''">
						<MEI_UPDATEDATETIME>
							<xsl:call-template name="DateConverter">
								<xsl:with-param name="InDate"><xsl:value-of select="@MEI_UPDATEDATETIME" /></xsl:with-param>
							</xsl:call-template>
						</MEI_UPDATEDATETIME>
					</xsl:if>
					<MEI_DESCRIPTION><xsl:value-of select="@MEI_DESCRIPTION" /></MEI_DESCRIPTION>
					<xsl:if test="@MEI_VET_ID != ''">
						<MEI_VET_ID><xsl:value-of select="@MEI_VET_ID" /></MEI_VET_ID>
					</xsl:if>
					<xsl:if test="@MEI_ASS_ID != ''">
						<MEI_ASS_ID><xsl:value-of select="@MEI_ASS_ID" /></MEI_ASS_ID>
					</xsl:if>
					<xsl:if test="@MEI_ISFEATUREONLY != ''">
						<MEI_ISFEATUREONLY><xsl:value-of select="@MEI_ISFEATUREONLY" /></MEI_ISFEATUREONLY>
					</xsl:if>
					<MEI_CLASS><xsl:value-of select="@MEI_CLASS" /></MEI_CLASS>
					<xsl:if test="@MEIR_ID != ''">
						<MEIR_ID><xsl:value-of select="@MEIR_ID" /></MEIR_ID>
					</xsl:if>
					<xsl:if test="@MEIR_ISREVISIONREQUIRED != ''">
						<MEIR_ISREVISIONREQUIRED><xsl:value-of select="@MEIR_ISREVISIONREQUIRED" /></MEIR_ISREVISIONREQUIRED>
					</xsl:if>
					<xsl:if test="@MEIR_ISARCHIVED != ''">
						<MEIR_ISARCHIVED><xsl:value-of select="@MEIR_ISARCHIVED" /></MEIR_ISARCHIVED>
					</xsl:if>
					<xsl:if test="@MEI_ID_PARENT != ''">
						<MEI_ID_PARENT><xsl:value-of select="@MEI_ID_PARENT" /></MEI_ID_PARENT>
					</xsl:if>
				</MEDIAINVENTORYSEARCH>
			</xsl:for-each>
		</MediaInventoryDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
