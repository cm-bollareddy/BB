<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:template name="DateConverter">
<xsl:param name="InDate">19801021T00:00:12345</xsl:param>
	<xsl:variable name="Length"><xsl:value-of select="string-length($InDate)" /></xsl:variable>
	<xsl:choose>
		<xsl:when test="$Length = 0"></xsl:when>
		<xsl:when test="$Length = 8">
			<xsl:value-of select="substring($InDate, 1, 4)" />-<xsl:value-of select="substring($InDate, 5, 2)" />-<xsl:value-of select="substring($InDate, 7, 2)" />
		</xsl:when>
		<xsl:otherwise>
			<xsl:value-of select="substring($InDate, 1, 4)" />-<xsl:value-of select="substring($InDate, 5, 2)" />-<xsl:value-of select="substring($InDate, 7, 2)" />T<xsl:value-of select="substring($InDate, 10, 5)" />:<xsl:value-of select="substring($InDate, 16, 2)" />
		</xsl:otherwise>
	</xsl:choose>
</xsl:template>
</xsl:stylesheet>

  