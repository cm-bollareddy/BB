using System;
using System.Data;
using System.Xml;

namespace CreateSchema
{
	/// <summary>
	/// Summary description for GenSchemaHelper.
	/// </summary>
	public class GenSchemaHelper
	{
		public GenSchemaHelper()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private static Type BV2WSType(string FieldTypeString)
		{
			switch (FieldTypeString)
			{
				case "i2":
					return System.Type.GetType("System.Int16");

				case "i4":
					return System.Type.GetType("System.Int32");

				case "r8":
					return System.Type.GetType("System.Double");

				case "fixed":
					return System.Type.GetType("System.Decimal");

				case "dateTime":
					return System.Type.GetType("System.DateTime");

				case "bin.hex":
				case "string":
					return System.Type.GetType("System.String");

				default:
					return null;
			}
		}

		public static void LoadColumns(DataTable dt, XmlNodeList oNodeList)
		{
			foreach (XmlNode oXmlNode in oNodeList)
			{
				string FieldTypeString = oXmlNode.Attributes["fieldtype"].Value;

				if (FieldTypeString != "nested")
				{
					Type oColumnType = BV2WSType(FieldTypeString);
					if (oColumnType == null)
					{
						throw new Exception("Unsupported Delphi type: " + FieldTypeString);
					}
					else
					{
						DataColumn dc = dt.Columns.Add(oXmlNode.Attributes["attrname"].Value, oColumnType);

						// Set the NULL/NONNULL attribute
						if (oXmlNode.Attributes["required"] != null)
						{
							string FieldRequiredString = oXmlNode.Attributes["required"].Value;
							if (FieldRequiredString == "true")
							{
								dc.AllowDBNull = false;
							}
						}

						// Set the readonly attribute
						if (oXmlNode.Attributes["readonly"] != null)
						{
							string FieldReadonlyString = oXmlNode.Attributes["readonly"].Value;
							if (FieldReadonlyString == "true")
							{
								dc.ReadOnly = true;
							}
						}

						// Set the maximum length for string (DO WE CARE?)
						if ((FieldTypeString == "string") &&
							(oXmlNode.Attributes["WIDTH"] != null))
						{
							int w = int.Parse(oXmlNode.Attributes["WIDTH"].Value);
							dc.MaxLength = w;
						}
						else if (FieldTypeString == "bin.hex")
						{
							dc.MaxLength = 2147483647;
						}
					}
				}
			}
		}
	}
}
