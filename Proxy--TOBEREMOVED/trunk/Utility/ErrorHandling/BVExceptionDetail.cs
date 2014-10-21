using System;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Pbs.WebServices.Utility
{
	/// <summary>
	/// Summary description for BVExceptionDetail.
	/// </summary>
	[XmlRoot("detail")]
	public class BVExceptionDetail
	{
		// Private variables
		private long m_ErrorLogKey;
		private DateTime m_ServerTime;
		private long m_ErrorCode;
		private string m_Action;

		// Public properties
		[XmlElement("errorlogkey")]
		public long ErrorLogKey
		{
			get
			{
				return m_ErrorLogKey;
			}
			set
			{
				m_ErrorLogKey = value;
			}
		}

		[XmlElement("servertime")]
		public DateTime ServerTime
		{
			get
			{
				return m_ServerTime;
			}
			set
			{
				m_ServerTime = value;
			}
		}

		[XmlElement("errorcode")]
		public long ErrorCode
		{
			get
			{
				return m_ErrorCode;
			}
			set
			{
				m_ErrorCode = value;
			}
		}

		[XmlElement("action")]
		public string Action
		{
			get
			{
				return m_Action;
			}
			set
			{
				m_Action = value;
			}
		}

		//
		// CONSTRUCTORS
		//
		public BVExceptionDetail()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public BVExceptionDetail(
			long ErrorLogKey,
			long ErrorCode,
			string Action)
		{
			m_ErrorLogKey = ErrorLogKey;
			m_ServerTime = DateTime.Now;
			m_ErrorCode = ErrorCode;
			m_Action = Action;
		}

		//
		// Convertion routine to and from XmlNode
		//
		public static explicit operator XmlNode(BVExceptionDetail d)
		{
			XmlSerializer oXmlSerializer = new XmlSerializer(d.GetType());
			using (StringWriter oStringWriter = new StringWriter())
			{
				oXmlSerializer.Serialize((TextWriter) oStringWriter, d);
				oStringWriter.Flush();
				string strXML = oStringWriter.ToString();

				XmlDocument oXmlDocument = new XmlDocument();
				oXmlDocument.LoadXml(strXML);
				return oXmlDocument.DocumentElement;
			}
		}

		public static explicit operator BVExceptionDetail(XmlNode oXmlNode)
		{
			BVExceptionDetail d = new BVExceptionDetail();
			foreach (XmlNode oNode in oXmlNode.ChildNodes)
			{
				try
				{
					switch (oNode.Name)
					{
						case "errorlogkey":
							d.ErrorLogKey = long.Parse(oNode.InnerText.Trim());
							break;

						case "errorcode":
							d.ErrorCode = long.Parse(oNode.InnerText.Trim());
							break;

						case "servertime":
							d.ServerTime = DateTime.Parse(oNode.InnerText.Trim());
							break;

						case "action":
							d.Action = oNode.InnerText.Trim();
							break;
					}
				}
				catch
				{}
			}
			return d;
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			//
			// TODO: Add code to start application here
			//
			BVExceptionDetail d = new BVExceptionDetail(12345, 54321, "Test action...");
			XmlNode oNode = (XmlNode) d;

			XmlTextWriter oXmlTextWriter = new XmlTextWriter(Console.Out);
			oNode.WriteTo(oXmlTextWriter);
			oXmlTextWriter.Flush();
			oXmlTextWriter.Close();

			BVExceptionDetail d1 = (BVExceptionDetail) oNode;
			Console.Out.WriteLine("ErrorCode = " + d1.ErrorCode + ". Action = " + d1.Action);
		}
	}
}
