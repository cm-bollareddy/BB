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
	/// GetBarCodeClass: Implement the GetBarCode web method using XSLT.
	/// </summary>
	class GetBarCodeClass
	{
		public GetBarCodeClass()
		{
		}

		public void GetBarCode(string strSessionID, int nMediaInventoryID,out byte[] bBarCode)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering GetBarCode.\n strSessionID=" + strSessionID + ", nMediaInventoryID="  + nMediaInventoryID);
		
			TVSServer.rdmPBSMediaInventory oPBSBarCode;

			try
			{
				oPBSBarCode = ComponentFactory.CreateMediaInventoryClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSMediaInventory GetBarCode",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			Array arrBarCode = null;
			object oBarCode =  null;
			try
			{
				nErrorCode = oPBSBarCode.GetBarCode(strSessionID, nMediaInventoryID, out oBarCode, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"nMediaInventoryID= " + nMediaInventoryID ,
					ex);
			}

			if (nErrorCode == 0)
			{
				
				arrBarCode = (Array) oBarCode;
				bBarCode =  new byte[arrBarCode.LongLength];
				//loop through the array to initialize the btye[]
				for (long i = 0 ; i< arrBarCode.LongLength;i++)
				{
					bBarCode[i] = (byte) arrBarCode.GetValue(i);

				}
				oTracer.LogInfo("Leaving GetBarCode.\n strSessionID=" + strSessionID + ", nMediaInventoryID="  + nMediaInventoryID);
								 
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "nMediaInventoryID= " + nMediaInventoryID );
			}
		}
	}
}
