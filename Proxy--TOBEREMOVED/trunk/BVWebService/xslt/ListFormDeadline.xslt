<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="FormDeadlineDataSet" targetNamespace="http://localhost/BVWebService/xsd/ListFormDeadlineDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/ListFormDeadlineDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/ListFormDeadlineDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="FormDeadlineDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="FORM_DEADLINE_TEMP"><xs:complexType><xs:sequence><xs:element name="DEA_ID" type="xs:int" /><xs:element name="DEA_DESC" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="TABID" type="xs:int" /><xs:element name="TABTYPE"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="3" /></xs:restriction></xs:simpleType></xs:element><xs:element name="PREMIEREDATE" type="xs:dateTime" minOccurs="0" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_FORM_DEADLINE_TEMP" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:FORM_DEADLINE_TEMP" /><xs:field xpath="mstns:DEA_ID" /><xs:field xpath="mstns:TABID" /><xs:field xpath="mstns:TABTYPE" /></xs:unique></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<FormDeadlineDataSet xmlns="http://localhost/BVWebService/xsd/ListFormDeadlineDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<FORM_DEADLINE_TEMP>
				<xsl:attribute name="diffgr:id">FORM_DEADLINE_TEMP<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<DEA_ID><xsl:value-of select="@DEA_ID" /></DEA_ID>
					<xsl:if test="@DEA_DESC != ''">
						<DEA_DESC><xsl:value-of select="@DEA_DESC" /></DEA_DESC>
					</xsl:if>
					<TABID><xsl:value-of select="@TABID" /></TABID>
					<TABTYPE><xsl:value-of select="@TABTYPE" /></TABTYPE>
					<xsl:if test="@PREMIEREDATE != ''">
						<PREMIEREDATE>
							<xsl:call-template name="DateConverter">
								<xsl:with-param name="InDate"><xsl:value-of select="@PREMIEREDATE" /></xsl:with-param>
							</xsl:call-template>
						</PREMIEREDATE>
					</xsl:if>
				</FORM_DEADLINE_TEMP>
			</xsl:for-each>
		</FormDeadlineDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
