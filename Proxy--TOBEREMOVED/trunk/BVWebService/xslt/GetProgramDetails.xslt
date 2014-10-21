<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="xml" />

<xsl:template name="Output_Schema">
<!-- SCHEMA STARTS -->
<xs:schema id="ProgramDetailsDataSet" targetNamespace="http://localhost/BVWebService/xsd/ProgramDetailsDataSet.xsd" xmlns:mstns="http://localhost/BVWebService/xsd/ProgramDetailsDataSet.xsd" xmlns="http://localhost/BVWebService/xsd/ProgramDetailsDataSet.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" attributeFormDefault="qualified" elementFormDefault="qualified"><xs:element name="ProgramDetailsDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true"><xs:complexType><xs:choice minOccurs="0" maxOccurs="unbounded"><xs:element name="ASSET"><xs:complexType><xs:sequence><xs:element name="ASS_ID" type="xs:int" /><xs:element name="ASS_EPISODENUMBER" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_TITLE"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_EPISODETITLE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_PBS_ISFINALTITLE" type="xs:short" minOccurs="0" /><xs:element name="ASS_PBSTITLEPREVIOUS" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_EPISODESLATE" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="20" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_SYNOPSIS" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_PBSPICTURELOCKDATE" type="xs:dateTime" minOccurs="0" /><xs:element name="ASS_EPGTEXT" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="2147483647" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_TITLELISTING" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="DEAL_ID" msdata:ReadOnly="true" type="xs:int" minOccurs="0" /><xs:element name="ASS_ACA_ID" type="xs:int" minOccurs="0" /><xs:element name="ASS_PMC_ID" type="xs:int" minOccurs="0" /><xs:element name="ASS_PVA_ID" type="xs:int" minOccurs="0" /><xs:element name="PREMIEREDATETIME" msdata:ReadOnly="true" type="xs:dateTime" minOccurs="0" /></xs:sequence></xs:complexType></xs:element><xs:element name="CASTTABLE"><xs:complexType><xs:sequence><xs:element name="TAL_ID" type="xs:int" /><xs:element name="TAL_NAME" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="TRO_ID" type="xs:int" /><xs:element name="ASS_TAL_DESC" minOccurs="0"><xs:simpleType><xs:restriction base="xs:string"><xs:maxLength value="80" /></xs:restriction></xs:simpleType></xs:element><xs:element name="ASS_ID" type="xs:int" /></xs:sequence></xs:complexType></xs:element><xs:element name="ASSET_PBSPROGRAMKEYWORD"><xs:complexType><xs:sequence><xs:element name="PBSPK_ID" type="xs:int" /><xs:element name="ASS_ID" type="xs:int" /></xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType><xs:unique name="PK_ASSET" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:ASSET" /><xs:field xpath="mstns:ASS_ID" /></xs:unique><xs:unique name="PK_CASTTABLE" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:CASTTABLE" /><xs:field xpath="mstns:TAL_ID" /><xs:field xpath="mstns:TRO_ID" /><xs:field xpath="mstns:ASS_ID" /></xs:unique><xs:unique name="PK_ASSET_PBSPROGRAMKEYWORD" msdata:PrimaryKey="true"><xs:selector xpath=".//mstns:ASSET_PBSPROGRAMKEYWORD" /><xs:field xpath="mstns:PBSPK_ID" /></xs:unique><xs:keyref name="FK_ASSET_ASSET_PBSPROGRAMKEYWORD" refer="PK_ASSET"><xs:selector xpath=".//mstns:ASSET_PBSPROGRAMKEYWORD" /><xs:field xpath="mstns:ASS_ID" /></xs:keyref><xs:keyref name="FK_ASSET_CASTTABLE" refer="PK_ASSET"><xs:selector xpath=".//mstns:CASTTABLE" /><xs:field xpath="mstns:ASS_ID" /></xs:keyref></xs:element></xs:schema>
<!-- SCHEMA ENDS   -->
</xsl:template>

<xsl:include href="TransformUtil.xslt" />

<xsl:template match="/">

	<DataSet xmlns="">
	<xsl:call-template name="Output_Schema" />

	<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
		<ProgramDetailsDataSet xmlns="http://localhost/BVWebService/xsd/ProgramDetailsDataSet.xsd">
			<xsl:for-each select="DATAPACKET/ROWDATA/ROW">
				<ASSET>
				<xsl:attribute name="diffgr:id">ASSET<xsl:value-of select="position()" /></xsl:attribute>
				<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
					<ASS_ID><xsl:value-of select="@ASS_ID" /></ASS_ID>
					<xsl:if test="@ASS_EPISODENUMBER != ''">
						<ASS_EPISODENUMBER><xsl:value-of select="@ASS_EPISODENUMBER" /></ASS_EPISODENUMBER>
					</xsl:if>
					<ASS_TITLE><xsl:value-of select="@ASS_TITLE" /></ASS_TITLE>
					<xsl:if test="@ASS_EPISODETITLE != ''">
						<ASS_EPISODETITLE><xsl:value-of select="@ASS_EPISODETITLE" /></ASS_EPISODETITLE>
					</xsl:if>
					<xsl:if test="@ASS_PBS_ISFINALTITLE != ''">
						<ASS_PBS_ISFINALTITLE><xsl:value-of select="@ASS_PBS_ISFINALTITLE" /></ASS_PBS_ISFINALTITLE>
					</xsl:if>
					<xsl:if test="@ASS_PBSTITLEPREVIOUS != ''">
						<ASS_PBSTITLEPREVIOUS><xsl:value-of select="@ASS_PBSTITLEPREVIOUS" /></ASS_PBSTITLEPREVIOUS>
					</xsl:if>
					<xsl:if test="@ASS_EPISODESLATE != ''">
						<ASS_EPISODESLATE><xsl:value-of select="@ASS_EPISODESLATE" /></ASS_EPISODESLATE>
					</xsl:if>
					<xsl:if test="@ASS_SYNOPSIS != ''">
						<ASS_SYNOPSIS><xsl:value-of select="@ASS_SYNOPSIS" /></ASS_SYNOPSIS>
					</xsl:if>
					<xsl:if test="@ASS_PBSPICTURELOCKDATE != ''">
						<ASS_PBSPICTURELOCKDATE>
							<xsl:call-template name="DateConverter">
								<xsl:with-param name="InDate"><xsl:value-of select="@ASS_PBSPICTURELOCKDATE" /></xsl:with-param>
							</xsl:call-template>
						</ASS_PBSPICTURELOCKDATE>
					</xsl:if>
					<xsl:if test="@ASS_EPGTEXT != ''">
						<ASS_EPGTEXT><xsl:value-of select="@ASS_EPGTEXT" /></ASS_EPGTEXT>
					</xsl:if>
					<xsl:if test="@ASS_TITLELISTING != ''">
						<ASS_TITLELISTING><xsl:value-of select="@ASS_TITLELISTING" /></ASS_TITLELISTING>
					</xsl:if>
					<xsl:if test="@DEAL_ID != ''">
						<DEAL_ID><xsl:value-of select="@DEAL_ID" /></DEAL_ID>
					</xsl:if>
					<xsl:if test="@ASS_ACA_ID != ''">
						<ASS_ACA_ID><xsl:value-of select="@ASS_ACA_ID" /></ASS_ACA_ID>
					</xsl:if>
					<xsl:if test="@ASS_PMC_ID != ''">
						<ASS_PMC_ID><xsl:value-of select="@ASS_PMC_ID" /></ASS_PMC_ID>
					</xsl:if>
					<xsl:if test="@ASS_PVA_ID != ''">
						<ASS_PVA_ID><xsl:value-of select="@ASS_PVA_ID" /></ASS_PVA_ID>
					</xsl:if>
					<xsl:if test="@PREMIEREDATETIME != ''">
						<PREMIEREDATETIME>
							<xsl:call-template name="DateConverter">
								<xsl:with-param name="InDate"><xsl:value-of select="@PREMIEREDATETIME" /></xsl:with-param>
							</xsl:call-template>
						</PREMIEREDATETIME>
					</xsl:if>
				</ASSET>
				<xsl:for-each select="CASTTABLE/ROWCASTTABLE">
					<CASTTABLE>
					<xsl:attribute name="diffgr:id">CASTTABLE<xsl:value-of select="position()" /></xsl:attribute>
					<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
						<TAL_ID><xsl:value-of select="@TAL_ID" /></TAL_ID>
						<xsl:if test="@TAL_NAME != ''">
							<TAL_NAME><xsl:value-of select="@TAL_NAME" /></TAL_NAME>
						</xsl:if>
						<TRO_ID><xsl:value-of select="@TRO_ID" /></TRO_ID>
						<xsl:if test="@ASS_TAL_DESC != ''">
							<ASS_TAL_DESC><xsl:value-of select="@ASS_TAL_DESC" /></ASS_TAL_DESC>
						</xsl:if>
						<ASS_ID><xsl:value-of select="@ASS_ID" /></ASS_ID>
					</CASTTABLE>
				</xsl:for-each>
				<xsl:for-each select="ASSET_PBSPROGRAMKEYWORD/ROWASSET_PBSPROGRAMKEYWORD">
					<ASSET_PBSPROGRAMKEYWORD>
					<xsl:attribute name="diffgr:id">ASSET_PBSPROGRAMKEYWORD<xsl:value-of select="position()" /></xsl:attribute>
					<xsl:attribute name="msdata:rowOrder"><xsl:value-of select="position() - 1" /></xsl:attribute>
						<PBSPK_ID><xsl:value-of select="@PBSPK_ID" /></PBSPK_ID>
						<ASS_ID><xsl:value-of select="@ASS_ID" /></ASS_ID>
					</ASSET_PBSPROGRAMKEYWORD>
				</xsl:for-each>
			</xsl:for-each>
		</ProgramDetailsDataSet>
	</diffgr:diffgram>
	</DataSet>
</xsl:template>
</xsl:stylesheet>
