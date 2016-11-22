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
		}


        /// <summary>
        /// Take the Dataset from the caller and export it to XML (Diffgram).
        /// Load the XML (Diffgram) into an XML Document.
        /// Load up the appropriate XSLT into an XML document to transform Dataset XML into Broadview XML.
        /// Transform the source DataSet XML into BroadView XML
        /// Return the transformed BroadView XML result to the caller.        
        /// </summary>
        /// <param name="dataSet"></param>
        /// <param name="xsltFile"></param>
        /// <returns></returns>
		public static string ToXml(DataSet dataSet, string xsltFile)
		{
			// Trace the input data
			Tracer oTracer = new Tracer();

            if (oTracer.IsDebugEnabled)	
			{
                oTracer.LogDebug(string.Format("In SchemaConverter.ToXml().\nSource DataSet=\n{0}\nSource XSLT=\n{1}\n", dataSet.GetXml(), xsltFile));

                //using (StringWriter oStringWriter = new StringWriter())
                //{
                //    dataSet.WriteXml(oStringWriter, XmlWriteMode.WriteSchema | XmlWriteMode.DiffGram);
                //    
                //}
			}

			//
			// We don't want the namespace, so null it out!
			// (Not sure how to handle the tricky namespace issue... LATER!)
			dataSet.Namespace = "";

			// Load the DataSet into an XML document (DiffGram approach)
			XmlDocument oXmlDataDocument = new XmlDocument();
			{
                using (StringWriter oStringWriter = new StringWriter())
                {
                    dataSet.WriteXml(oStringWriter, XmlWriteMode.DiffGram);
                    oXmlDataDocument.LoadXml(oStringWriter.ToString());
                }
			}

			// Take a look at the XmlDataDocument
            if (oTracer.IsDebugEnabled)	// Check the switch before tracing (we don't want to extract the XML if the switch is OFF)...
			{
                oTracer.LogDebug(string.Format("In SchemaConverter.ToXml().\nSource Dataset DiffGram XmlDocument=\n{0}\n", oXmlDataDocument.OuterXml));
			}

			//
			// Load the stylesheet and transform the DataSet, saving it in a memory stream
			//
            XslCompiledTransform oXsl = new XslCompiledTransform();
			try
			{
                oTracer.LogDebug(string.Format("In SchemaConverter.ToXml().Loading Source XSLT=\n{0}\n", xsltFile));
                oXsl.Load(xsltFile);
			}
			catch(Exception ex)
			{
				throw new ServiceException(
					ServiceException.ExceptionCode.InvalidXslt,
					"WebService has failed to load the xslt transformation file: " + xsltFile,
					ex);
            }

            #region ApproachDifferences
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
            #endregion

            // StringWriter Approach
			string strResult;
			using (StringWriter oStringWriter = new StringWriter())
			{
				try
				{
                    oTracer.LogDebug("In SchemaConverter.ToXml().Transforming XML.");
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

		

            if (oTracer.IsDebugEnabled)	
            {
                oTracer.LogDebug(string.Format("Leaving SchemaConverter.ToXml().\nTransformed XML Result=\n{0}\n", strResult));
            }

			return strResult;
		}


        /// <summary>
        /// Take XML response from BroadView, load it into an XML document.
        /// Load up the appropriate XSLT into an XML document to transform Broadview XML into Dataset XML.
        /// Transform the source XML into DataSet XML.
        /// Load the Dataset XML into a Dataset and return it to the caller.
        /// </summary>
        /// <param name="xmlString"></param>
        /// <param name="xsltFile"></param>
        /// <returns></returns>
		public static DataSet ToDataSet(string xmlString, string xsltFile)
		{
			Tracer oTracer = new Tracer();
            if (oTracer.IsDebugEnabled)	
            {
                oTracer.LogDebug(string.Format("In SchemaConverter.ToDataSet().\nSource XML String=\n{0}\nSource XSLT=\n{1}\n", xmlString, xsltFile));
            }
            
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
                oTracer.LogDebug(string.Format("In SchemaConverter.ToDataSet().Loading Source XSLT=\n{0}\n", xsltFile));
                oXsl.Load(xsltFile);
			}
			catch(Exception ex)
			{
				throw new ServiceException(
					ServiceException.ExceptionCode.InvalidXslt,
					"WebService has failed to load the xslt transformation file: " + xsltFile,
					ex);
			}

			MemoryStream oMemoryStream = new MemoryStream();
			//oMemoryStream.Position = 0;
			//oXsl.Transform(oXmlDocument, (XsltArgumentList) null, oMemoryStream);
			//oMemoryStream.Flush();

			try
			{
                oTracer.LogDebug("In SchemaConverter.ToDataSet().Transforming XML.");
                oMemoryStream.Position = 0;
                oXsl.Transform(oXmlDocument, (XsltArgumentList)null, oMemoryStream);
                oMemoryStream.Flush();
			}
			catch(Exception ex)
			{
				throw new ServiceException(
					ServiceException.ExceptionCode.XsltTransformationError,
					"WebService has run into a problem transforming the incoming XML to DataSet.",
					"Input: " + oXmlDocument.OuterXml,
					ex);
			}

            DataSet oDataSet = new DataSet();

			//
			// Take a look at the transformation result!
			//
            using (StreamReader oStreamReader = new StreamReader(oMemoryStream))
            {
                if (oTracer.IsDebugEnabled)
                {
                    oMemoryStream.Position = 0;
                    oTracer.LogDebug(string.Format("In SchemaConverter.ToDataSet().\nTransformed XML Result=\n{0}\n", oStreamReader.ReadToEnd()));
                }


                //
                // Load the result back into a dataset
                //
                try
                {
                    oMemoryStream.Position = 0;
                    oDataSet.ReadXml(oMemoryStream);
                }
                catch (Exception ex)
                {
                    oMemoryStream.Position = 0;
                    throw new ServiceException(
                        ServiceException.ExceptionCode.InvalidDataSet,
                        "WebService has run into a problem converting xslt output into a dataset.",
                        "Input: " + oStreamReader.ReadToEnd(),
                        ex);
                }
            }
           

			


            if (oTracer.IsDebugEnabled)	// Check the switch before tracing (we don't want to extract the XML if the switch is OFF)...
			{
				using (StringWriter oStringWriter = new StringWriter())
				{
					oDataSet.WriteXml(oStringWriter, XmlWriteMode.WriteSchema | XmlWriteMode.DiffGram);
                    oTracer.LogDebug(string.Format("In SchemaConverter.ToDataSet().\nResult Dataset DiffGram=\n{0}\n", oStringWriter.ToString()));
				}

			}

			//string sXML = oDataSet.GetXml();

			return oDataSet;
		}
	}
}
