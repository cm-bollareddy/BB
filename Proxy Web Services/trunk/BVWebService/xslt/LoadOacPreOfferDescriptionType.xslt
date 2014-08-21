<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="OacPreOfferDescriptionTypeDataSet" targetNamespace="http://localhost/BVWebService/xsd/LoadOacPreOfferDescriptionTypeDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/LoadOacPreOfferDescriptionTypeDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/LoadOacPreOfferDescriptionTypeDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="OacPreOfferDescriptionTypeDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="OACPREOFFERDESC"><xs:complexType><xs:sequence><xs:element name="PODT_ID" type="xs:int" /><xs:element name="PODT_LABEL" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="40" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PODT_DESC" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PODT_ORDERBY" type="xs:short" minOccurs="0" /><xs:element name="PODT_ISTEXTBOX" type="xs:short" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_OACPREOFFER" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:OACPREOFFERDESC" /><xs:field xpath="mstns:PODT_ID" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<OacPreOfferDescriptionTypeDataSet xmlns="http://localhost/BVWebService/xsd/LoadOacPreOfferDescriptionTypeDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<OACPREOFFERDESC>
				<xsl:attribute name="diffgr:id">OACPREOFFERDESC<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<PODT_ID><xsl:value-of select="@PODT_ID" /></PODT_ID>
					<xsl:if test="@PODT_LABEL != ''">
						<PODT_LABEL><xsl:value-of select="@PODT_LABEL" /></PODT_LABEL>
					</xsl:if>
					<xsl:if test="@PODT_DESC != ''">
						<PODT_DESC><xsl:value-of select="@PODT_DESC" /></PODT_DESC>
					</xsl:if>
					<xsl:if test="@PODT_ORDERBY != ''">
						<PODT_ORDERBY><xsl:value-of select="@PODT_ORDERBY" /></PODT_ORDERBY>
					</xsl:if>
					<xsl:if test="@PODT_ISTEXTBOX != ''">
						<PODT_ISTEXTBOX><xsl:value-of select="@PODT_ISTEXTBOX" /></PODT_ISTEXTBOX>
					</xsl:if>
				</OACPREOFFERDESC>
			</xsl:for-each>
		</OacPreOfferDescriptionTypeDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
