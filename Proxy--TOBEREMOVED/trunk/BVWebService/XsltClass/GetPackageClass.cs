using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Globalization;
using Pbs.WebServices.Utility;

using TVSServer = OrionProxy;

namespace BVWebService
{
	/// <summary>
	/// GetPackageClass: Implement the GetPackage web method using XSLT.
	/// </summary>
	class GetPackageClass
	{
		private const string FILE_GET_XSLT = @"GetPackage.xslt";

		public GetPackageClass()
		{
		}

		public DataSet GetPackage(string strSessionID, int nPackageID, bool bLockFlag, out string strLockID)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering GetPackage.\n strSessionID=" + strSessionID + ", nPackageID="  + nPackageID);
		
			TVSServer.rdmPBSProgram oPBSPackage;

			try
			{
				oPBSPackage = ComponentFactory.CreateProgramClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSProgram GetPackage",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSPackage.GetPackage(strSessionID, nPackageID, bLockFlag, out strLockID, out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"PackageID= " + nPackageID + ", LockFlag= " + bLockFlag,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving GetPackage.\n strSessionID=" + strSessionID + ", nPackageID="  + nPackageID);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "PackageID= " + nPackageID + ", LockFlag= " + bLockFlag);
			}
		}
	}
}
