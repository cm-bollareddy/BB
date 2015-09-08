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

		private static void WriteColumnTransform(StreamWriter oStreamWriter, DataTable dataTable, int indent, bool bOutputDiffOnly)
		{
			string strIndent = RepeatString("\t", indent);

			//
			// Iterate through the fields from given table...
			//
			foreach (DataColumn dc in dataTable.Columns)
			{
				if (dc.ReadOnly)
					continue;	// Skip readonly fields...

				bool bIsMemo = false;
				if ((dc.DataType == Type.GetType("System.String")) &&
					(dc.MaxLength == 2147483647))
				{
					bIsMemo = true;
				}
				//not($Original/DEA_ISPBSCANADIANPRERELEASE) and DEA_ISPBSCANADIANPRERELEASE) or ($Original/DEA_ISPBSCANADIANPRERELEASE != DEA_ISPBSCANADIANPRERELEASE)
				if (bIsMemo)
				{
					if (bOutputDiffOnly)
					{
                        
                        //oStreamWriter.WriteLine(strIndent + "<xsl:if test=\"{0} != '' and (not($Original/{0}) and {0}) or ($Original/{0} != {0})\">", dc.ColumnName);
                        oStreamWriter.WriteLine(strIndent + "<xsl:if test=\"{0} != '' and (not(msxsl:node-set($Original)/{0}) and {0}) or (msxsl:node-set($Original)/{0} != {0})\">", dc.ColumnName);
					}
					else
					{
						oStreamWriter.WriteLine(strIndent + "<xsl:if test=\"{0} != ''\">", dc.ColumnName);
					}
					strIndent += "\t";
				}
				else if (bOutputDiffOnly)
				{
                    
					//oStreamWriter.WriteLine(strIndent + "<xsl:if test=\"(not($Original/{0}) and {0}) or ($Original/{0} != {0})\">", dc.ColumnName);
                    oStreamWriter.WriteLine(strIndent + "<xsl:if test=\"(not(msxsl:node-set($Original)/{0}) and {0}) or (msxsl:node-set($Original)/{0} != {0})\">", dc.ColumnName);
					strIndent += "\t";
				}

				oStreamWriter.WriteLine(strIndent + "<xsl:attribute name=\"" + dc.ColumnName + "\"><xsl:value-of select=\"" + dc.ColumnName + "\" /></xsl:attribute>");

				if (bIsMemo || bOutputDiffOnly)
				{
					strIndent = RepeatString("\t", indent);
					oStreamWriter.WriteLine(strIndent + "</xsl:if>");
				}
				//handling of null values coming from Orion
				//Passing empty strings for all dataType if null
				//changes by -rs
				if (dc.ReadOnly)
					continue;	// Skip readonly fields...

				////bool bIsMemo = false;
				if ((dc.DataType == Type.GetType("System.String")) &&
					(dc.MaxLength == 2147483647))
				{
					//bIsMemo = true;

					//oStreamWriter.WriteLine(strIndent + "<xsl:if test=\"$Original/{0} and not({0})\">", dc.ColumnName);
                    oStreamWriter.WriteLine(strIndent + "<xsl:if test=\"msxsl:node-set($Original)/{0} and not({0})\">", dc.ColumnName);
				
					//not($Original/DEA_ISPBSCANADIANPRERELEASE) and DEA_ISPBSCANADIANPRERELEASE) or ($Original/DEA_ISPBSCANADIANPRERELEASE != DEA_ISPBSCANADIANPRERELEASE)
					strIndent += "\t";

					oStreamWriter.WriteLine(strIndent + "<xsl:attribute name=\"" + dc.ColumnName + "\"></xsl:attribute>");
				}
				else if (dc.DataType == Type.GetType("System.String"))
				{

                    oStreamWriter.WriteLine(strIndent + "<xsl:if test=\"msxsl:node-set($Original)/{0} and not({0})\">", dc.ColumnName);
                    //oStreamWriter.WriteLine(strIndent + "<xsl:if test=\"$Original/{0} and not({0})\">", dc.ColumnName);
				
					//not($Original/DEA_ISPBSCANADIANPRERELEASE) and DEA_ISPBSCANADIANPRERELEASE) or ($Original/DEA_ISPBSCANADIANPRERELEASE != DEA_ISPBSCANADIANPRERELEASE)
					strIndent += "\t";

					oStreamWriter.WriteLine(strIndent + "<xsl:attribute name=\"" + dc.ColumnName + "\"></xsl:attribute>");



				}
				else 
				{

                    oStreamWriter.WriteLine(strIndent + "<xsl:if test=\"msxsl:node-set($Original)/{0} and not({0})\">", dc.ColumnName);
                    //oStreamWriter.WriteLine(strIndent + "<xsl:if test=\"$Original/{0} and not({0})\">", dc.ColumnName);
					strIndent += "\t";

					oStreamWriter.WriteLine(strIndent + "<xsl:attribute name=\"" + dc.ColumnName + "\"></xsl:attribute>");


				}

								
				strIndent = RepeatString("\t", indent);
				oStreamWriter.WriteLine(strIndent + "</xsl:if>");
				
			}
		
		}

		private static void GenNestedTransform(StreamWriter oStreamWriter, DataTable thisTable, int indent)
		{
            string strIndent = RepeatString("\t", indent);

			oStreamWriter.WriteLine(strIndent + "<xsl:for-each select=\"//{0}/{1}\">", thisTable.DataSet.DataSetName, thisTable.TableName);

            //This is hack to address the PackageAppliesToRange
            if (thisTable.TableName == "VW_VERSIONAPPLIESTORANGE" && thisTable.DataSet.DataSetName == "PackageAppliesToRangeByTabDataSet")
            {
                oStreamWriter.WriteLine(strIndent + "<xsl:if test=\"($COMPAREID = VER_ASS_ID)\">");
            }

            oStreamWriter.WriteLine(strIndent + "\t<xsl:choose>");
			oStreamWriter.WriteLine(strIndent + "\t\t<xsl:when test=\"@diffgr:hasChanges='inserted'\">");
			oStreamWriter.WriteLine(strIndent + "\t\t\t<xsl:call-template name=\"Output{0}\">", thisTable.TableName);
			oStreamWriter.WriteLine(strIndent + "\t\t\t\t<xsl:with-param name=\"RowState\" select=\"$ROWSTATE_NEW\" />");
			oStreamWriter.WriteLine(strIndent + "\t\t\t</xsl:call-template>");
			oStreamWriter.WriteLine(strIndent + "\t\t</xsl:when>");
			oStreamWriter.WriteLine();
			oStreamWriter.WriteLine(strIndent + "\t\t<xsl:when test=\"@diffgr:hasChanges='modified'\">");
			oStreamWriter.WriteLine(strIndent + "\t\t\t<xsl:for-each select=\"key('Original{0}', @diffgr:id)\">", thisTable.TableName);
			oStreamWriter.WriteLine(strIndent + "\t\t\t\t<xsl:call-template name=\"Output{0}\">", thisTable.TableName);
			oStreamWriter.WriteLine(strIndent + "\t\t\t\t\t<xsl:with-param name=\"RowState\" select=\"$ROWSTATE_BEFORE\" />");
			oStreamWriter.WriteLine(strIndent + "\t\t\t\t</xsl:call-template>");
			oStreamWriter.WriteLine(strIndent + "\t\t\t</xsl:for-each>");
			oStreamWriter.WriteLine(strIndent + "\t\t\t<xsl:call-template name=\"Output{0}\">", thisTable.TableName);
			oStreamWriter.WriteLine(strIndent + "\t\t\t\t<xsl:with-param name=\"Original\" select=\"key('Original{0}', @diffgr:id)\" />", thisTable.TableName);
			oStreamWriter.WriteLine(strIndent + "\t\t\t\t<xsl:with-param name=\"RowState\" select=\"$ROWSTATE_AFTER\" />");
			oStreamWriter.WriteLine(strIndent + "\t\t\t</xsl:call-template>");
			oStreamWriter.WriteLine(strIndent + "\t\t</xsl:when>");
			if (thisTable.ChildRelations.Count > 0)
			{
				oStreamWriter.WriteLine();
				oStreamWriter.WriteLine(strIndent + "\t\t<xsl:otherwise>");
				oStreamWriter.WriteLine(strIndent + "\t\t\t<xsl:call-template name=\"Output{0}\">", thisTable.TableName);
				oStreamWriter.WriteLine(strIndent + "\t\t\t\t<xsl:with-param name=\"RowState\" select=\"$ROWSTATE_UNCHANGED\" />");
				oStreamWriter.WriteLine(strIndent + "\t\t\t</xsl:call-template>");
				oStreamWriter.WriteLine(strIndent + "\t\t</xsl:otherwise>");
			}

			oStreamWriter.WriteLine(strIndent + "\t</xsl:choose>");

            //This is hack to address the PackageAppliesToRange
            if (thisTable.TableName == "VW_VERSIONAPPLIESTORANGE" && thisTable.DataSet.DataSetName == "PackageAppliesToRangeByTabDataSet")
            {
                oStreamWriter.WriteLine(strIndent + "</xsl:if>");
            }


			oStreamWriter.WriteLine(strIndent + "</xsl:for-each>");

			oStreamWriter.WriteLine(strIndent + "<xsl:for-each select=\"//diffgr:before/{1}\">", thisTable.DataSet.DataSetName, thisTable.TableName);
			oStreamWriter.WriteLine(strIndent + "\t<xsl:if test=\"count(key('Current{0}', @diffgr:id)) = 0\">", thisTable.TableName);
			oStreamWriter.WriteLine(strIndent + "\t\t<xsl:call-template name=\"Output{0}\">", thisTable.TableName);
			oStreamWriter.WriteLine(strIndent + "\t\t\t<xsl:with-param name=\"RowState\" select=\"$ROWSTATE_DELETED\" />");
			oStreamWriter.WriteLine(strIndent + "\t\t</xsl:call-template>");
			oStreamWriter.WriteLine(strIndent + "\t</xsl:if>");
			oStreamWriter.WriteLine(strIndent + "</xsl:for-each>");
		}

		private static void GenTableTransform(StreamWriter oStreamWriter, DataTable thisTable, bool bIsRoot)
		{
			oStreamWriter.WriteLine("<xsl:template name=\"Output{0}\">", thisTable.TableName);
			oStreamWriter.WriteLine("<xsl:param name=\"Original\" />");
			oStreamWriter.WriteLine("<xsl:param name=\"RowState\"><xsl:value-of select=\"$ROWSTATE_UNCHANGED\" /></xsl:param>");

            //This is hack to address the PackageAppliesToRange
            if (thisTable.TableName == "PROGRAMS" && thisTable.DataSet.DataSetName == "PackageAppliesToRangeByTabDataSet")
            {
                oStreamWriter.WriteLine("<xsl:variable name=\"COMPAREID\"><xsl:value-of select=\"ASS_ID\" /></xsl:variable>");
            }

			if (bIsRoot)
			{
				oStreamWriter.WriteLine("\t<ROW>");
			}
			else
			{
				oStreamWriter.WriteLine("\t<ROW{0}>", thisTable.TableName.ToUpper());
			}

			// Output the RowState attribute
			oStreamWriter.WriteLine("\t\t<xsl:attribute name=\"RowState\"><xsl:value-of select=\"$RowState\" /></xsl:attribute>");

			//
			// Output column transformation (based upon RowState)
			//
			oStreamWriter.WriteLine("\t\t<xsl:choose>");
			oStreamWriter.WriteLine("\t\t\t<xsl:when test=\"$RowState = $ROWSTATE_AFTER\">");

			int indent = 4;
			bool bOutputDiffOnly = true;
			WriteColumnTransform(oStreamWriter, thisTable, indent, bOutputDiffOnly);
		
			oStreamWriter.WriteLine("\t\t\t</xsl:when>");
			oStreamWriter.WriteLine("\t\t\t<xsl:otherwise>");

			bOutputDiffOnly = false;
			WriteColumnTransform(oStreamWriter, thisTable, indent, bOutputDiffOnly);
			oStreamWriter.WriteLine("\t\t\t</xsl:otherwise>");
			oStreamWriter.WriteLine("\t\t</xsl:choose>");
			oStreamWriter.WriteLine();

			//
			// Repeat for all its children
			//
			foreach (DataRelation dr in thisTable.ChildRelations)
			{
				DataTable childTable = dr.ChildTable;
				oStreamWriter.WriteLine("\t\t<{0}>", childTable.TableName.ToUpper());
				oStreamWriter.WriteLine("\t\t\t<xsl:if test=\"($RowState=$ROWSTATE_NEW) or ($RowState=$ROWSTATE_BEFORE) or ($RowState=$ROWSTATE_UNCHANGED)\">");
				GenNestedTransform(oStreamWriter, childTable, 4);
				oStreamWriter.WriteLine("\t\t\t</xsl:if>");
				oStreamWriter.WriteLine("\t\t</{0}>", childTable.TableName.ToUpper());
			}

			if (bIsRoot)
			{
				oStreamWriter.WriteLine("\t</ROW>");
			}
			else
			{
				oStreamWriter.WriteLine("\t</ROW{0}>", thisTable.TableName.ToUpper());
			}
			
			// End this template
			oStreamWriter.WriteLine("</xsl:template>");
			oStreamWriter.WriteLine();
		}

		private static void GenXslProlog(StreamWriter oStreamWriter)
		{
			oStreamWriter.WriteLine("<?xml version=\"1.0\" ?>");
			//oStreamWriter.WriteLine("<xsl:stylesheet xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\" xmlns:diffgr=\"urn:schemas-microsoft-com:xml-diffgram-v1\" version=\"1.0\">");
            oStreamWriter.WriteLine("<xsl:stylesheet xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\" xmlns:diffgr=\"urn:schemas-microsoft-com:xml-diffgram-v1\" xmlns:msxsl=\"urn:schemas-microsoft-com:xslt\" version=\"1.0\">");
			oStreamWriter.WriteLine();

			oStreamWriter.WriteLine("<xsl:output method=\"xml\" />");
			oStreamWriter.WriteLine();
		}

		private static void GenXslHeader(StreamWriter oStreamWriter, DataSet oDataSet)
		{
			// Define our global constants
			oStreamWriter.WriteLine("<xsl:variable name=\"ROWSTATE_BEFORE\">1</xsl:variable>");
			oStreamWriter.WriteLine("<xsl:variable name=\"ROWSTATE_DELETED\">2</xsl:variable>");
			oStreamWriter.WriteLine("<xsl:variable name=\"ROWSTATE_NEW\">4</xsl:variable>");
			oStreamWriter.WriteLine("<xsl:variable name=\"ROWSTATE_DETACHED\">6</xsl:variable> <!-- This one we do not use -->");
			oStreamWriter.WriteLine("<xsl:variable name=\"ROWSTATE_AFTER\">8</xsl:variable>");
			oStreamWriter.WriteLine("<xsl:variable name=\"ROWSTATE_UNCHANGED\">64</xsl:variable>");
			oStreamWriter.WriteLine();

			// Create two keys for each table, one for indexing the original value, the other the current value...
			foreach (DataTable dt in oDataSet.Tables)
			{
				oStreamWriter.WriteLine("<xsl:key name=\"Original{1}\" match=\"//diffgr:before/{1}\" use=\"@diffgr:id\" />",
					oDataSet.DataSetName, dt.TableName);
				oStreamWriter.WriteLine("<xsl:key name=\"Current{1}\" match=\"//{0}/{1}\" use=\"@diffgr:id\" />",
					oDataSet.DataSetName, dt.TableName);
			}
			oStreamWriter.WriteLine();
		}

		public static void GenXslTransform(string xsltFile, XmlDocument oXmlDocument, DataSet oDataSet)
		{
			StreamWriter oStreamWriter = new StreamWriter(xsltFile, false);

			// Create the XSL prolog
			GenXslProlog(oStreamWriter);

			// Define our global constants, variables and keys
			GenXslHeader(oStreamWriter, oDataSet);

			// Define the template for resulting schema
			oStreamWriter.WriteLine("<xsl:template name=\"Output_Schema\">");
			oStreamWriter.WriteLine("<!-- SCHEMA STARTS -->");

			foreach (XmlNode oNode in oXmlDocument.SelectNodes("descendant::PARAMS"))
			{
//				if (oNode.Attributes["UNIQUE_KEY"] != null)
//				{
					XmlAttribute oAttribute = oXmlDocument.CreateAttribute("DATASET_DELTA");
					oAttribute.Value = "TRUE";
					oNode.Attributes.Prepend(oAttribute);
//				}
			}
			oStreamWriter.WriteLine(oXmlDocument.SelectSingleNode("/DATAPACKET/METADATA").OuterXml);
			oStreamWriter.WriteLine("<!-- SCHEMA ENDS   -->");
			oStreamWriter.WriteLine("</xsl:template>");
			oStreamWriter.WriteLine();

			// Import this utility transformation
			oStreamWriter.WriteLine("<xsl:include href=\"TransformUtil.xslt\" />");
			oStreamWriter.WriteLine();

			// Define the template for transforming child tables...
			for (int i = 1; i < oDataSet.Tables.Count; i++)
			{
				DataTable dt = oDataSet.Tables[i];
				GenTableTransform(oStreamWriter, dt, false);
			}
			GenTableTransform(oStreamWriter, oDataSet.Tables[0], true);

			oStreamWriter.WriteLine("<xsl:template match=\"/\">");

			oStreamWriter.WriteLine("\t<DATAPACKET Version=\"2.0\">");
			oStreamWriter.WriteLine("\t<xsl:call-template name=\"Output_Schema\" />");
	
			oStreamWriter.WriteLine("\t<ROWDATA>");

			DataTable dtRoot = oDataSet.Tables[0];
			GenNestedTransform(oStreamWriter, dtRoot, 2);

			oStreamWriter.WriteLine("\t</ROWDATA>");
			oStreamWriter.WriteLine("\t</DATAPACKET>");
			oStreamWriter.WriteLine("</xsl:template>");

			oStreamWriter.WriteLine("</xsl:stylesheet>");
			oStreamWriter.Flush();
			oStreamWriter.Close();
		}
	}
}
