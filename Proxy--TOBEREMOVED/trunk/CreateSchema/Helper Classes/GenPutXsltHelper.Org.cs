using System;
using System.IO;
using System.Data;
using System.Xml;

namespace CreateSchema
{
	/// <summary>
	/// GetPutXsltHelper: Generate the XSLT for converting to a BroadView XML stream.
	/// </summary>
	public class GenPutXsltHelper
	{
		public GenPutXsltHelper()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private static string RepeatString(string s, int n)
		{
			string r = "";
			for (int i = 0; i < n; i++)
			{
				r += s;
			}
			return r;
		}

		private static void WriteColumnTransform(StreamWriter oStreamWriter, DataTable dataTable, int indent)
		{
			string strIndent = RepeatString("\t", indent);

			//
			// Iterate through the fields from given table...
			//
			foreach (DataColumn dc in dataTable.Columns)
			{
				bool bIsMemo = false;
				if ((dc.DataType == Type.GetType("System.String")) &&
					(dc.MaxLength == 2147483647))
				{
					bIsMemo = true;
				}

				if (bIsMemo)
				{
					oStreamWriter.WriteLine(strIndent + "<xsl:if test=\"" + dc.ColumnName + " != ''\">");
					strIndent += "\t";
				}

				oStreamWriter.WriteLine(strIndent + "<xsl:attribute name=\"" + dc.ColumnName + "\"><xsl:value-of select=\"" + dc.ColumnName + "\" /></xsl:attribute>");

				if (bIsMemo)
				{
					strIndent = RepeatString("\t", indent);
					oStreamWriter.WriteLine(strIndent + "</xsl:if>");
				}
			}
		}

		private static void GenTableTransform(StreamWriter oStreamWriter, DataTable parentTable, int indent)
		{
			string strIndent = RepeatString("\t", indent);

			//
			// Output column transformation
			//
			WriteColumnTransform(oStreamWriter, parentTable, indent);
		
			//
			// Repeat for all its children
			//
			foreach (DataRelation dr in parentTable.ChildRelations)
			{
				DataTable childTable = dr.ChildTable;

				oStreamWriter.WriteLine(strIndent + "<xsl:if test=\"count(/" + parentTable.DataSet.DataSetName + "/" + childTable.TableName + ") > 0\">");
				oStreamWriter.WriteLine(strIndent + "<Query" + childTable.TableName + ">");
				oStreamWriter.WriteLine(strIndent + "\t<xsl:for-each select=\"/" + parentTable.DataSet.DataSetName + "/" + childTable.TableName + "\">");
				oStreamWriter.WriteLine(strIndent + "\t\t<ROWQuery" + childTable.TableName + ">");
				GenTableTransform(oStreamWriter, childTable, indent + 3);
				oStreamWriter.WriteLine(strIndent + "\t\t</ROWQuery" + childTable.TableName + ">");
				oStreamWriter.WriteLine(strIndent + "\t</xsl:for-each>");
				oStreamWriter.WriteLine(strIndent + "</Query" + childTable.TableName + ">");
				oStreamWriter.WriteLine(strIndent + "</xsl:if>");
			}
		}

		public static void GenXslTransform(string xsltFile, XmlDocument oXmlDocument, DataSet oDataSet)
		{
			StreamWriter oStreamWriter = new StreamWriter(xsltFile, false);
			oStreamWriter.WriteLine("<?xml version=\"1.0\" ?>");
			oStreamWriter.WriteLine("<xsl:stylesheet xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\" version=\"1.0\">");
			oStreamWriter.WriteLine();

			oStreamWriter.WriteLine("<xsl:output method=\"xml\" />");
			oStreamWriter.WriteLine();

			oStreamWriter.WriteLine("<xsl:template name=\"Output_Schema\">");
			oStreamWriter.WriteLine("<!-- SCHEMA STARTS -->");
			oStreamWriter.WriteLine(oXmlDocument.SelectSingleNode("/DATAPACKET/METADATA").OuterXml);
			oStreamWriter.WriteLine("<!-- SCHEMA ENDS   -->");
			oStreamWriter.WriteLine("</xsl:template>");
			oStreamWriter.WriteLine();

			oStreamWriter.WriteLine("<xsl:include href=\"TransformUtil.xslt\" />");
			oStreamWriter.WriteLine();

			oStreamWriter.WriteLine("<xsl:template match=\"/\">");
			oStreamWriter.WriteLine();

			oStreamWriter.WriteLine("\t<DATAPACKET Version=\"2.0\">");
			oStreamWriter.WriteLine("\t<xsl:call-template name=\"Output_Schema\" />");
	
			oStreamWriter.WriteLine("\t<ROWDATA>");

			DataTable dtRoot = oDataSet.Tables[0];
			oStreamWriter.WriteLine("\t\t<xsl:for-each select=\"/" + oDataSet.DataSetName + "/" + dtRoot.TableName + "\">");
			oStreamWriter.WriteLine("\t\t\t<ROW>");
			GenTableTransform(oStreamWriter, dtRoot, 4);
			oStreamWriter.WriteLine("\t\t\t</ROW>");
			oStreamWriter.WriteLine("\t\t</xsl:for-each>");

			oStreamWriter.WriteLine("\t</ROWDATA>");
			oStreamWriter.WriteLine("\t</DATAPACKET>");
			oStreamWriter.WriteLine("</xsl:template>");

			oStreamWriter.WriteLine("</xsl:stylesheet>");
			oStreamWriter.Flush();
			oStreamWriter.Close();
		}
	}
}
