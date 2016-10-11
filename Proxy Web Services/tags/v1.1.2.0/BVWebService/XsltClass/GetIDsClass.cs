using System;
using System.Collections;
using Pbs.WebServices.Utility;
using TVSServer = OrionProxy;

namespace BVWebService
{
	/// <summary>
	/// Summary description for GetIDs.
	/// </summary>
	public class GetIDsClass
	{
		public GetIDsClass()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public int[] GetIDs(int nHowMany)
		{
			if (nHowMany <= 0)
			{
				throw new ServiceException(
					ServiceException.ExceptionCode.InvalidParameters,
					"Parameter nHowMany must be at least 1",
					"nHowMany = " + nHowMany);
			}

			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering GetIDs(" + nHowMany.ToString() + ");");

			int[] myID = new int[nHowMany];

            //TVSServer.rdmOrionProxyModule oOrionProxyModuleClass;
            TVSServer.rdmPBSGetLookup oOrionProxyModuleClass;
			try
			{
				//oOrionProxyModuleClass = ComponentFactory.CreateProxyModuleClass();
                oOrionProxyModuleClass = ComponentFactory.CreateGetLookupClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= GetIDs",
					ex);
			}

			for (int i = 0; i < nHowMany; i++)
			{
				int nErrorCode = 0;
				string strErrorText = "";
				int n;
				try
				{

                    nErrorCode = oOrionProxyModuleClass.GetID(out n, out strErrorText);
				}
				catch (Exception ex)
				{
					throw new BVException(
						BVException.ExceptionCode.ComponentExecutionFailure,
						"Error while executing server component method: " + ex.Message,
						"nHowMany= " + nHowMany + ", iteration= " + i,
						ex);
				}

				if (nErrorCode == 0)
				{
					//myID.Add(n);
					myID[i] = n;
				}
				else
				{
					throw new BVException(nErrorCode, strErrorText, "nHowMany= " + nHowMany + ", iteration= " + i);
				}
			}

            //if (oTracer.IsDebugEnabled)
            //{
            //    string strID = "{";
            //    for (int i = 0; i < nHowMany; i++)
            //    {
            //        strID += myID[i] + " ";
            //    }
            //    strID += "}";
            //    oTracer.LogInfo("Leaving GetIDs.\n ID=" + strID);
            //}

            oTracer.LogInfo("Exiting GetIDs(" + nHowMany.ToString() + ");");

			return myID;
		}
	}
}
