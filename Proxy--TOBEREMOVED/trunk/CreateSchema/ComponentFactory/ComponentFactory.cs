using System;
using System.Configuration;
using System.Reflection;
using TVSServer = OrionProxy;


namespace BVWebService
{
	/// <summary>
	/// Summary description for ComponentFactory.
	/// </summary>
	public class ComponentFactory
	{
		public ComponentFactory()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static object CreateObject(string strProgId)
		{
			// Read the object guid from our configuration settings...
			Guid oGuid;
			try
			{
				string strCLSID = (string) System.Configuration.ConfigurationManager.AppSettings[strProgId];
				if (strCLSID == "")
				{
					if (strProgId == "TVSServer.PBSDeal")
					{
                        oGuid = typeof(TVSServer.rdmPBSDeal).GUID;
					}
					else if (strProgId == "TVSServer.PBSMasterDeal")
					{
                        oGuid = typeof(TVSServer.rdmPBSGetMasterDeal).GUID;
					}
					else if (strProgId == "TVSServer.PBSMediaInventory")
					{
                        oGuid = typeof(TVSServer.rdmPBSMediaInventory).GUID;
					}

					else if (strProgId == "TVSServer.PBSManageTable")
					{
                        oGuid = typeof(TVSServer.rdmPBSManageTable).GUID;
					}
					else if (strProgId == "TVSServer.PBSSearch")
					{
                        oGuid = typeof(TVSServer.rdmPBSSearch).GUID;
					}
					else if (strProgId == "TVSServer.PBSAuthorization")
					{
                        oGuid = typeof(TVSServer.rdmPBSAuthorization).GUID;
					}
					else if (strProgId == "TVSServer.PBSProgramCreator")
					{
						oGuid = typeof(TVSServer.rdmPBSProgramCreator).GUID;
					}
					else if (strProgId == "TVSServer.PBSProgram")
					{
						oGuid = typeof(TVSServer.rdmPBSProgram).GUID;
					}
					else if (strProgId == "TVSServer.PBSTalent")
					{
						oGuid = typeof(TVSServer.rdmPBSTalent).GUID;
					}
					
					else if (strProgId == "TVSServer.PBSGetLookup")
					{
                        oGuid = typeof(TVSServer.rdmPBSGetLookup).GUID;
					}
					else if (strProgId == "TVSServer.OrionProxyModule")
					{
                        oGuid = typeof(TVSServer.rdmOrionProxyModule).GUID;
					}
					else if (strProgId == "TVSServer.PBSManageAppliesToRange")
					{
                        oGuid = typeof(TVSServer.rdmPBSManageAppliesToRange).GUID;
					}
					else if (strProgId == "TVSServer.PBSDeadlineNotification")
					{
                        oGuid = typeof(TVSServer.rdmPBSDeadlineNotification).GUID;
					}
					else if (strProgId == "TVSServer.PBSRemedy")
					{
                        oGuid = typeof(TVSServer.rdmPBSRemedy).GUID;
					}
						
					else
					{
						return CreateObject(strProgId, "Interop.TVSServer.dll");
					}
				}
				else
				{
					oGuid = new Guid(strCLSID);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(
					"Web Service configuration error. " + 
					"ProgId = " + strProgId, ex);
			}

			//
			// Read the AppServer setting
			//
			string strServer;
			try
			{
                strServer = (string)System.Configuration.ConfigurationManager.AppSettings["TVSServer"];

				if (strServer == "")
					strServer = "localhost";
			}
			catch (Exception ex)
			{
				throw new Exception(
					"Web Service configuration error. AppServer setting not found.", ex);
			}

			Type oType;
			try
			{
				oType = Type.GetTypeFromCLSID(oGuid, strServer, true);
			}
			catch (Exception ex)
			{
				throw new Exception("Application component not found. " + 
					"ProgID = " + strProgId + ", CLSID = " + oGuid.ToString(), ex);
			}

			object o = Activator.CreateInstance(oType);

			if (o == null)
			{
				throw new Exception("Application component instantiation error. " + 
					"ProgID = " + strProgId + ", CLSID = " + oGuid.ToString());
			}

			return o;
		}

		public static object CreateObject(string strProgId, string strAssemblyPath)
		{
			// Create an object from the given assembly
			Guid oGuid;

			try
			{
				Assembly assembly = Assembly.LoadFrom(strAssemblyPath);

				oGuid = assembly.GetType(strProgId).GUID;
			}
			catch (Exception ex)
			{
				throw new Exception(
					"Web Service configuration error. " + 
					"ProgId = " + strProgId, ex);
			}

			//
			// Read the AppServer setting
			//
			string strServer;
			try
			{
                strServer = (string)System.Configuration.ConfigurationManager.AppSettings["TVSServer"];

				if (strServer == "")
					strServer = "localhost";
			}
			catch (Exception ex)
			{
				throw new Exception(
					"Web Service configuration error. AppServer setting not found.", ex);
			}

			Type oType;
			try
			{
				oType = Type.GetTypeFromCLSID(oGuid, strServer, true);
			}
			catch (Exception ex)
			{
				throw new Exception("Application component not found. " + 
					"ProgID = " + strProgId + ", CLSID = " + oGuid.ToString(), ex);
			}

			object o = Activator.CreateInstance(oType);

			if (o == null)
			{
				throw new Exception("Application component instantiation error. " + 
					"ProgID = " + strProgId + ", CLSID = " + oGuid.ToString());
			}

			return o;
		}

		public static TVSServer.rdmPBSDeal CreateDealClass()
		{
            return (TVSServer.rdmPBSDeal)CreateObject("TVSServer.PBSDeal");
		}

		public static TVSServer.rdmPBSGetMasterDeal CreateMasterDealClass()
		{
            return (TVSServer.rdmPBSGetMasterDeal)CreateObject("TVSServer.PBSMasterDeal");
		}

        public static TVSServer.rdmPBSMediaInventory CreateMediaInventoryClass()
        {
            return (TVSServer.rdmPBSMediaInventory)CreateObject("TVSServer.PBSMediaInventory");
        }
		public static TVSServer.rdmPBSManageTable CreateManageTableClass()
		{
            return (TVSServer.rdmPBSManageTable)CreateObject("TVSServer.PBSManageTable");
		}
        
        public static TVSServer.rdmPBSSearch CreateSearchClass()
		{
            return (TVSServer.rdmPBSSearch)CreateObject("TVSServer.PBSSearch");
		}
		public static TVSServer.rdmPBSTalent CreateTalentClass()
		{
            return (TVSServer.rdmPBSTalent)CreateObject("TVSServer.PBSTalent");
		}

		public static TVSServer.rdmPBSAuthorization CreateAuthorizationClass()
		{
            return (TVSServer.rdmPBSAuthorization)CreateObject("TVSServer.PBSAuthorization");
		}

		public static TVSServer.rdmPBSProgramCreator CreateProgramCreatorClass()
		{
            return (TVSServer.rdmPBSProgramCreator)CreateObject("TVSServer.PBSProgramCreator");
		}
		public static TVSServer.rdmPBSProgram CreateProgramClass()
		{
            return (TVSServer.rdmPBSProgram)CreateObject("TVSServer.PBSProgram");
		}
		
		public static TVSServer.rdmPBSGetLookup CreateGetLookupClass()
		{
            return (TVSServer.rdmPBSGetLookup)CreateObject("TVSServer.PBSGetLookup");
		}

		public static TVSServer.rdmOrionProxyModule CreateProxyModuleClass()
		{
            return (TVSServer.rdmOrionProxyModule)CreateObject("TVSServer.OrionProxyModule");
		}

		public static TVSServer.rdmPBSManageAppliesToRange CreateManageAppliesToRangeClass()
		{
            return (TVSServer.rdmPBSManageAppliesToRange)CreateObject("TVSServer.PBSManageAppliesToRange");
		}

		public static TVSServer.rdmPBSDeadlineNotification CreateDeadlineNotificationClass()
		{
            return (TVSServer.rdmPBSDeadlineNotification)CreateObject("TVSServer.PBSDeadlineNotification");
		}
		public static TVSServer.rdmPBSRemedy CreateRemedyClass()
		{
            return (TVSServer.rdmPBSRemedy)CreateObject("TVSServer.PBSRemedy");
		}
		
	}
}
