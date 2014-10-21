<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="OacPostOfferDescriptionTypeDataSet" targetNamespace="http://localhost/BVWebService/xsd/LoadOacPostOfferDescriptionTypeDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/LoadOacPostOfferDescriptionTypeDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/LoadOacPostOfferDescriptionTypeDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="OacPostOfferDescriptionTypeDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="OACPOSTOFFERDESC"><xs:complexType><xs:sequence><xs:element name="POPDT_ID" type="xs:int" /><xs:element name="POPDT_LABEL" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POPDT_DESC" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="POPDT_ORDERBY" type="xs:short" minOccurs="0" /><xs:element name="POPDT_ISTEXTBOX" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_OACPOSTOFFERDESC" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:OACPOSTOFFERDESC" /><xs:field xpath="mstns:POPDT_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<OacPostOfferDescriptionTypeDataSet xmlns="http://localhost/BVWebService/xsd/LoadOacPostOfferDescriptionTypeDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<OACPOSTOFFERDESC>
				<xsl:attribute name="diffgr:id">OACPOSTOFFERDESC<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<POPDT_ID><xsl:value-of select="@POPDT_ID" /></POPDT_ID>
					<xsl:if test="@POPDT_LABEL != ''">
						<POPDT_LABEL><xsl:value-of select="@POPDT_LABEL" /></POPDT_LABEL>
					</xsl:if>
					<xsl:if test="@POPDT_DESC != ''">
						<POPDT_DESC><xsl:value-of select="@POPDT_DESC" /></POPDT_DESC>
					</xsl:if>
					<xsl:if test="@POPDT_ORDERBY != ''">
						<POPDT_ORDERBY><xsl:value-of select="@POPDT_ORDERBY" /></POPDT_ORDERBY>
					</xsl:if>
					<xsl:if test="@POPDT_ISTEXTBOX != ''">
						<POPDT_ISTEXTBOX><xsl:value-of select="@POPDT_ISTEXTBOX" /></POPDT_ISTEXTBOX>
					</xsl:if>
				</OACPOSTOFFERDESC>
			</xsl:for-each>
		</OacPostOfferDescriptionTypeDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
