using System;
using System.Data;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using Pbs.WebServices.Utility;

namespace BVWebService
{
	/// <summary>
	/// Summary description for SchemaConverter.
	/// </summary>
	public class SchemaConverter
	{
		public SchemaConverter()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static string ToXml(DataSet dataSet, string xsltFile)
		{
			//
			// Trace the input data
			//
			Tracer oTracer = new Tracer();
            if (oTracer.IsDebugEnabled)	// Check the switch before tracing (we don't want to extract the XML if the switch is OFF)...
			{
				StringWriter oStringWriter = new StringWriter();
				dataSet.WriteXml(oStringWriter, XmlWriteMode.WriteSchema | XmlWriteMode.DiffGram);
				oTracer.LogInfo("Entering SchemaConverter.ToXml.\nDataSet=\n" + oStringWriter.ToString());
			}

			//
			// We don't want the namespace, so null it out!
			// (Not sure how to handle the tricky namespace issue... LATER!)
			//
			dataSet.Namespace = "";

			// 
			// Load the DataSet into an XML document (DiffGram approach)
			//
			XmlDocument oXmlDataDocument = new XmlDocument();
			{
				StringWriter oStringWriter = new StringWriter();
				dataSet.WriteXml(oStringWriter, XmlWriteMode.DiffGram);
				oXmlDataDocument.LoadXml(oStringWriter.ToString());
			}

			//
			// Take a look at the XmlDataDocument
			//
            if (oTracer.IsDebugEnabled)	// Check the switch before tracing (we don't want to extract the XML if the switch is OFF)...
			{
				oTracer.LogInfo("Within SchemaConverter.ToXml.\nXmlDataDocument=\n" + oXmlDataDocument.OuterXml);
			}

			//
			// Load the stylesheet and transform the DataSet, saving it in a memory stream
			//
            XslCompiledTransform oXsl = new XslCompiledTransform();
			try
			{

                //oXsl.Load(xsltFile, XsltSettings.TrustedXslt, new XmlUrlResolver());
                oXsl.Load(xsltFile);
			}
			catch(Exception ex)
			{
				throw new ServiceException(
					ServiceException.ExceptionCode.InvalidXslt,
					"WebService has failed to load the xslt transformation file: " + xsltFile,
					ex);
			}

			// XmlReader Approach
			//				XmlReader oXmlReader = oXsl.Transform(oXmlDataDocument, (XsltArgumentList) null, (XmlResolver) null);
			//				oXmlReader.MoveToContent();
			//				string strResult = "<?xml version=\"1.0\" ?>" + oXmlReader.ReadOuterXml());

			// MemoryStream Approach
			//				MemoryStream oMemoryStream = new MemoryStream();
			//				oXsl.Transform(oXmlDataDocument, null, oMemoryStream, null);
			//				oMemoryStream.Flush();
			//
			//				StreamReader oReader = new StreamReader(oMemoryStream);
			//				oMemoryStream.Position = 0;
			//				string strResult = oReader.ReadToEnd();
			//				
			//				// DEBUG: Save a copy of output
						
			//				// DEBUG: Save a copy of output

			// StringWriter Approach
			string strResult;
			using (StringWriter oStringWriter = new StringWriter())
			{
				try
				{
					oXsl.Transform(oXmlDataDocument, (XsltArgumentList) null, (TextWriter) oStringWriter);
				}
				catch(Exception ex)
				{
					throw new ServiceException(
						ServiceException.ExceptionCode.XsltTransformationError,
						"WebService has run into a problem transforming the incoming DataSet.",
						"Input: " + oXmlDataDocument.OuterXml,
						ex);
				}

				strResult = oStringWriter.ToString();
				
			}

			
			oTracer.LogInfo("Leaving SchemaConverter.ToXml.\nstrResult = \n" + strResult);
			return strResult;
		}

		public static DataSet ToDataSet(string xmlString, string xsltFile)
		{
			//
			// Trace the input data
			//
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering SchemaConvert.ToDataSet.\nxmlString =\n" + xmlString);

			//
			// Load and transform the given XML
			//
			XmlDocument oXmlDocument = new XmlDocument();

			try
			{
				oXmlDocument.LoadXml(xmlString);
			}
			catch(Exception ex)
			{
				throw new ServiceException(
					ServiceException.ExceptionCode.InvalidXml,
					"WebService has failed to load an invalid XML string.",
					"Input: " + xmlString,
					ex);
			}

            XslCompiledTransform oXsl = new XslCompiledTransform();
			try
			{
                oXsl.Load(xsltFile);
                //oXsl.Load(xsltFile, XsltSettings.TrustedXslt, new XmlUrlResolver());
			}
			catch(Exception ex)
			{
				throw new ServiceException(
					ServiceException.ExceptionCode.InvalidXslt,
					"WebService has failed to load the xslt transformation file: " + xsltFile,
					ex);
			}

//			XmlReader oXmlReader = null;
//			try
//			{
//				oXmlReader = oXsl.Transform(oXmlDocument, (XsltArgumentList) null, (XmlResolver) null);
//			}
//			catch(Exception ex)
//			{
//				throw new ServiceException(
//					ServiceException.ExceptionCode.XsltTransformationError,
//					"WebService has run into a problem transforming the incoming XML stream.",
//					"Input: " + xmlString,
//					ex);
//			}

			MemoryStream oMemoryStream = new MemoryStream();
			oMemoryStream.Position = 0;
			oXsl.Transform(oXmlDocument, (XsltArgumentList) null, oMemoryStream);
			oMemoryStream.Flush();

			//
			// Take a look at the transformation result!
			//
			StreamReader oStreamReader = new StreamReader(oMemoryStream);
            if (oTracer.IsDebugEnabled)
			{
				oMemoryStream.Position = 0;
				oTracer.LogInfo("In SchemaConverter.ToDataSet.\nTransformed result=\n" + oStreamReader.ReadToEnd());
			}

			//
			// Load the result back into a dataset
			//
			DataSet oDataSet = new DataSet();

			try
			{
				oMemoryStream.Position = 0;
                oDataSet.ReadXml(oMemoryStream);

			}
			catch(Exception ex)
			{
				oMemoryStream.Position = 0;
				throw new ServiceException(
					ServiceException.ExceptionCode.InvalidDataSet,
					"WebService has run into a problem converting xslt output into a dataset.",
					"Input: " + oStreamReader.ReadToEnd(),
					ex);
			}
			//oXmlReader.Close();
			oStreamReader.Close();

			//
			// Trace the DataSet if needed
			//
            if (oTracer.IsDebugEnabled)	// Check the switch before tracing (we don't want to extract the XML if the switch is OFF)...
			{
				using (StringWriter oStringWriter = new StringWriter())
				{
					oDataSet.WriteXml(oStringWriter, XmlWriteMode.WriteSchema | XmlWriteMode.DiffGram);
					oTracer.LogInfo("Leaving SchemaConverter.ToDataSet.\nDataSet= \n" + oStringWriter.ToString());
				}
			}

			string sXML = oDataSet.GetXml();

			return oDataSet;
		}
	}
}
