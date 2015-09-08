using System;
using System.IO;
using System.Data;
using System.Xml;

namespace CreateSchema
{
	/// <summary>
	/// GenGetXsltHelper: Generate the XSLT for converting to a .NET dataset.
	/// </summary>
	public class GenGetXsltHelper
	{
		public GenGetXsltHelper()
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
				//changed by rs to handle the operating group null and empty string issue
				//the operating group comes in as empty string has to that way so
				// we just exclude the check for all those 
				//piwt_pbsoperatinggroup;poac_operatinggroup;pucc_operatinggroup;dea_pbsoperatinggroup;mei_pbsoperatinggroup
				
				if (dc.AllowDBNull)
				{
					
					if ((dc.ColumnName == "PIWT_PBSOPERATINGGROUP") || (dc.ColumnName == "POAC_OPERATINGGROUP") || (dc.ColumnName == "PUCC_OPERATINGGROUP") || (dc.ColumnName == "DEA_PBSOPERATINGGROUP") || (dc.ColumnName == "MEI_PBSOPERATINGGROUP"))
					{
						strIndent += "\t";
					}
					else
					{
						oStreamWriter.WriteLine(strIndent + "<xsl:if test=\"@" + dc.ColumnName + " != ''\">");
						strIndent += "\t";
					}
				}

				if (dc.DataType == System.Type.GetType("System.DateTime"))
				{
					oStreamWriter.WriteLine(strIndent + "<" + dc.ColumnName + ">");
					oStreamWriter.WriteLine(strIndent + "\t<xsl:call-template name=\"DateConverter\">");
					oStreamWriter.WriteLine(strIndent + "\t\t<xsl:with-param name=\"InDate\"><xsl:value-of select=\"@" + dc.ColumnName + "\" /></xsl:with-param>");
					oStreamWriter.WriteLine(strIndent + "\t</xsl:call-template>");
					oStreamWriter.WriteLine(strIndent + "</" + dc.ColumnName + ">");
				}
				else
				{
					oStreamWriter.WriteLine(strIndent + "<" + dc.ColumnName + ">" +
						"<xsl:value-of select=\"@" + dc.ColumnName + "\" />" + "</" + dc.ColumnName + ">");
				}

				//changed by rs to handle the operating group null and empty string issue
				//the operating group comes in as empty string has to that way so
				// we just exclude the check for all those 
				//piwt_pbsoperatinggroup;poac_operatinggroup;pucc_operatinggroup;dea_pbsoperatinggroup;mei_pbsoperatinggroup
				

				if (dc.AllowDBNull)
				{
					if ((dc.ColumnName == "PIWT_PBSOPERATINGGROUP") || (dc.ColumnName == "POAC_OPERATINGGROUP") || (dc.ColumnName == "PUCC_OPERATINGGROUP") || (dc.ColumnName == "DEA_PBSOPERATINGGROUP") || (dc.ColumnName == "MEI_PBSOPERATINGGROUP"))
					{
						strIndent = RepeatString("\t", indent);
					}
					else
					{
						strIndent = RepeatString("\t", indent);
						oStreamWriter.WriteLine(strIndent + "</xsl:if>");
					}
				}
			}
		}

		private static void GenTableTransform(StreamWriter oStreamWriter, DataTable parentTable, int indent)
		{
			string strIndent = RepeatString("\t", indent);


            ///This is a hack to help address the "corrupt index" issue with the GetPackageAppliesToRange API and ListProgramsByDeal API.  
            ///The corruption appears to occur because the rowOrder sequence is repeated across the child data structures
            ///In both cases there are 0-M parents each with 0-M children.
            ///ex. Parent1Child0Child1Child2, Parent2Child0Child1Child2
            ///In this example, Child rowOrder 0, 1 and 2 would all be repeated.
            ///
            ///So - we're adding some padding to the rowOrder sequence so the children will have unique values, regardless of parent.
            ///ex. Parent1Child((10000*1) + 0)Child((10000*1) + 1)Child((10000*1) + 2), Parent2Child((10000*2) + 0)Child((10000*2) + 1)Child((10000*2) + 2)
            if (
                (parentTable.DataSet.DataSetName == "PackageAppliesToRangeByTabDataSet" && parentTable.TableName == "PROGRAMS")
                ||
                (parentTable.DataSet.DataSetName == "ProgramsByDealDataSet" && parentTable.TableName == "ASSET")
                )
            {
                oStreamWriter.WriteLine(strIndent + "<xsl:variable name=\"PARENTID\"><xsl:value-of select=\"position()\"/></xsl:variable>");
            }


            
			//
			// Generate header...
			//
			oStreamWriter.WriteLine(strIndent + "<" + parentTable.TableName + ">");


            ///See Hack description above.  
            oStreamWriter.WriteLine(strIndent + "<xsl:attribute name=\"diffgr:id\">" + parentTable.TableName + "<xsl:value-of select=\"position()\" /></xsl:attribute>");
            if (
                (parentTable.DataSet.DataSetName == "PackageAppliesToRangeByTabDataSet" && parentTable.TableName == "VW_VERSIONAPPLIESTORANGE")
                ||
                (parentTable.DataSet.DataSetName == "ProgramsByDealDataSet" && parentTable.TableName == "VERSION")
               )
            {
                oStreamWriter.WriteLine(strIndent + "<xsl:attribute name=\"msdata:rowOrder\"><xsl:value-of select=\"($PARENTID*10000) + position()\" /></xsl:attribute>");
            }
            else
            {
                oStreamWriter.WriteLine(strIndent + "<xsl:attribute name=\"msdata:rowOrder\"><xsl:value-of select=\"position() - 1\" /></xsl:attribute>");
            }



            ////This is a workaround for the result of the ListProgramsByDeal Dataset.
            ////The filtering done within the XSLT corrupts the dataset index.
            ////This is a List (read only) interface, so we are removing the position() references.

            //if (!(parentTable.Namespace == "http://localhost/BVWebService/xsd/ListProgramsByDealDataSet.xsd" && (parentTable.TableName == "ASSET" ||parentTable.TableName == "VERSION")))
            //{
            //    oStreamWriter.WriteLine(strIndent + "<xsl:attribute name=\"diffgr:id\">" + parentTable.TableName + "<xsl:value-of select=\"position()\" /></xsl:attribute>");

            //    //			oStreamWriter.Write(strIndent + "<xsl:attribute name=\"diffgr:id\">");
            //    //			string strPrimaryKeys = "";
            //    //			foreach (DataColumn dc in parentTable.PrimaryKey)
            //    //			{
            //    //				if (strPrimaryKeys != "")
            //    //					strPrimaryKeys += "-";
            //    //
            //    //				strPrimaryKeys += "<xsl:value-of select=\"@" + dc.ColumnName + "\" />";
            //    //			}
            //    //			oStreamWriter.WriteLine(parentTable.TableName + "-" + strPrimaryKeys + "</xsl:attribute>");



            //    if (parentTable.Namespace == "http://localhost/BVWebService/xsd/PackageAppliesToRangeByTabDataSet.xsd" && parentTable.TableName == "VW_VERSIONAPPLIESTORANGE")
            //    {
            //        oStreamWriter.WriteLine(strIndent + "<xsl:attribute name=\"msdata:rowOrder\"><xsl:value-of select=\"($PARENTID*10000) + position()\" /></xsl:attribute>");
            //    }
            //    else
            //    {
            //        oStreamWriter.WriteLine(strIndent + "<xsl:attribute name=\"msdata:rowOrder\"><xsl:value-of select=\"position() - 1\" /></xsl:attribute>");
            //    }

               





            //}
			WriteColumnTransform(oStreamWriter, parentTable, indent + 1);
			oStreamWriter.WriteLine(strIndent + "</" + parentTable.TableName + ">");

			//
			// Repeat for all its children
			//
			foreach (DataRelation dr in parentTable.ChildRelations)
			{
				DataTable childTable = dr.ChildTable;
                if (childTable.TableName == "ListPackageCutsInfo_DETAIL"
                    || childTable.TableName == "ListPackageMediaInfo_DETAIL"
                    || childTable.TableName == "ListMediaCutsInfo_DETAIL")
                {
                    //Camel Case - As Is From BroadView
                    oStreamWriter.WriteLine(strIndent + "<xsl:for-each select=\"{0}/ROW{0}\">",
                        childTable.TableName);
                }
                else
                {
                    //UpperCase
                    oStreamWriter.WriteLine(strIndent + "<xsl:for-each select=\"{0}/ROW{0}\">", childTable.TableName.ToUpper());

                }
				GenTableTransform(oStreamWriter, childTable, indent + 1);
				oStreamWriter.WriteLine(strIndent + "</xsl:for-each>");
			}
		}

		public static void GenXslTransform(string xsltFile, DataSet oDataSet)
		{
			StreamWriter oStreamWriter = new StreamWriter(xsltFile, false);
			oStreamWriter.WriteLine("<?xml version=\"1.0\" ?>");
			oStreamWriter.WriteLine("<xsl:stylesheet xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\" version=\"1.0\">");
			oStreamWriter.WriteLine();

			oStreamWriter.WriteLine("<xsl:output method=\"xml\" />");
			oStreamWriter.WriteLine();

			oStreamWriter.WriteLine("<xsl:template name=\"Output_Schema\">");
			oStreamWriter.WriteLine("<!-- SCHEMA STARTS -->");
			XmlDocument oXmlSchema = new XmlDocument();
			oXmlSchema.LoadXml(oDataSet.GetXmlSchema());
			oStreamWriter.WriteLine(oXmlSchema.DocumentElement.OuterXml);
			oStreamWriter.WriteLine("<!-- SCHEMA ENDS   -->");
			oStreamWriter.WriteLine("</xsl:template>");
			oStreamWriter.WriteLine();

			oStreamWriter.WriteLine("<xsl:include href=\"TransformUtil.xslt\" />");
			oStreamWriter.WriteLine();

			oStreamWriter.WriteLine("<xsl:template match=\"/\">");
			oStreamWriter.WriteLine();

			oStreamWriter.WriteLine("\t<DataSet xmlns=\"\">");
			oStreamWriter.WriteLine("\t<xsl:call-template name=\"Output_Schema\" />");
			oStreamWriter.WriteLine();
			oStreamWriter.WriteLine("\t<diffgr:diffgram xmlns:msdata=\"urn:schemas-microsoft-com:xml-msdata\" xmlns:diffgr=\"urn:schemas-microsoft-com:xml-diffgram-v1\">");
			oStreamWriter.WriteLine("\t\t<" + oDataSet.DataSetName + " xmlns=\"" + oDataSet.Namespace + "\">");

			//
			// Starting from the first table, iterate through each of its children...
			//
			DataTable dtRoot = oDataSet.Tables[0];
			oStreamWriter.WriteLine("\t\t\t<xsl:for-each select=\"DATAPACKET/ROWDATA/ROW\">");
			GenTableTransform(oStreamWriter, dtRoot, 4);
			oStreamWriter.WriteLine("\t\t\t</xsl:for-each>");
				
			oStreamWriter.WriteLine("\t\t</" + oDataSet.DataSetName + ">");
			oStreamWriter.WriteLine("\t</diffgr:diffgram>");
			oStreamWriter.WriteLine("\t</DataSet>");
			oStreamWriter.WriteLine("</xsl:template>");

			oStreamWriter.WriteLine("</xsl:stylesheet>");
			oStreamWriter.Flush();
			oStreamWriter.Close();
		}
	}
}
