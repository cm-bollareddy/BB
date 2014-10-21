using System;
using System.Data;
using TestWebService.BVWebService;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;


namespace TestWebService
{
	/// <summary>
	/// Summary description for TestWebServiceHelper.
	/// </summary>
	public class TestWebServiceHelper
	{

		public const string SEARCH_WILDCARD = "%";
		public const string MEDIA_INVENTORY_SEARCH_CRITERIA			= "MediaInventorySearchCriteria";
		public const string DEAL_SEARCH_CRITERIA					= "DealSearchCriteria";
		public const string MASTER_DEAL_SEARCH_CRITERIA				= "MasterDealSearchCriteria";
		public const string PROGRAM_SEARCH_CRITERIA					= "ProgramSearchCriteria";
		public const string TRAFFIC_ITEM_SEARCH_CRITERIA			= "TrafficItemSearchCriteria";
		public const string AD_COPY_SEARCH_CRITERIA					= "AdCopySearchCriteria";
		public const string SEARCH_PACKAGE_INFO_SEARCH_CRITERIA		= "SearchPackageInfoSearchCriteria";
		public const string SEARCH_MEDIA_INFO_SEARCH_CRITERIA		= "SearchMediaInfoSearchCriteria";
		public const string LIST_PACKAGE_CUTS_INFO_SEARCH_CRITERIA	= "ListPackageCutsInfoSearchCriteria";
		public const string LIST_MEDIA_CUTS_INFO_SEARCH_CRITERIA	= "ListMediaCutsInfoSearchCriteria";
		public const string LIST_PACKAGE_MEDIA_INFO_SEARCH_CRITERIA	= "ListPackageMediaInfoSearchCriteria";
		public const string GET_PROXY_ENVIRONMENTS					= "GetProxyEnvironments";

		public TestWebServiceHelper()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		
		public static System.Data.DataTable GetEnvironmentList()
		{

            List<EnvironmentConfig> oEnvironmentConfigs = null;

            try
            {
               
                oEnvironmentConfigs = EnvironmentConfigConfigurationSection.GetConfig().EnvironmentConfigs.ToList<EnvironmentConfig>();
            }
            catch
            {

            }
                

            

			DataTable oTable = new DataTable(GET_PROXY_ENVIRONMENTS);
			
			DataColumn oColumn;
			
			oColumn = new DataColumn("Name", typeof(string));
			oColumn.ReadOnly = true;
			oTable.Columns.Add(oColumn);
			oTable.Columns.Add(new DataColumn("Value", typeof(string)));

            DataRow oRow = null;
            if (oEnvironmentConfigs != null)
            {
                foreach (EnvironmentConfig oConfig in oEnvironmentConfigs)
                {
                    oRow = oTable.NewRow();
                    oRow.ItemArray = new object[2] { oConfig.sEnvironmentDescription, oConfig.sBaseWSURL };
                    oTable.Rows.Add(oRow);
                }
            }

			return oTable;
		}


		public static System.Data.DataTable GetMediaInventorySearchCriteria()
		{
			DataTable oTable = new DataTable(MEDIA_INVENTORY_SEARCH_CRITERIA);
			
			DataColumn oColumn;
			
			oColumn = new DataColumn("Key", typeof(string));
			oColumn.ReadOnly = true;
			oTable.Columns.Add(oColumn);
			oTable.Columns.Add(new DataColumn("Value", typeof(string)));

			DataRow oRow = null;
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"program_id", string.Empty};
			oTable.Rows.Add(oRow);
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"deal_id", string.Empty};
			oTable.Rows.Add(oRow);
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"operating_unit", string.Empty};
			oTable.Rows.Add(oRow);
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"operating_group", string.Empty};
			oTable.Rows.Add(oRow);
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"title", string.Empty};
			oTable.Rows.Add(oRow);

			return oTable;
		}

		public static System.Data.DataTable GetDealSearchCriteria()
		{
			DataTable oTable = new DataTable(DEAL_SEARCH_CRITERIA );
			
			DataColumn oColumn;
			
			oColumn = new DataColumn("Key", typeof(string));
			oColumn.ReadOnly = true;
			oTable.Columns.Add(oColumn);
			oTable.Columns.Add(new DataColumn("Value", typeof(string)));

			DataRow oRow = null;
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"sub_deal_description", string.Empty};
			oTable.Rows.Add(oRow);
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"sub_deal_season", string.Empty};
			oTable.Rows.Add(oRow);

			return oTable;
		}

		public static System.Data.DataTable GetMasterDealSearchCriteria()
		{
			DataTable oTable = new DataTable(MASTER_DEAL_SEARCH_CRITERIA);
			
			DataColumn oColumn;
			
			oColumn = new DataColumn("Key", typeof(string));
			oColumn.ReadOnly = true;
			oTable.Columns.Add(oColumn);
			oTable.Columns.Add(new DataColumn("Value", typeof(string)));

			DataRow oRow = null;
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"title", string.Empty};
			oTable.Rows.Add(oRow);
			return oTable;
		}

		public static System.Data.DataTable GetProgramSearchSearchCriteria()
		{
			DataTable oTable = new DataTable(PROGRAM_SEARCH_CRITERIA);
			
			DataColumn oColumn;
			
			oColumn = new DataColumn("Key", typeof(string));
			oColumn.ReadOnly = true;
			oTable.Columns.Add(oColumn);
			oTable.Columns.Add(new DataColumn("Value", typeof(string)));

			DataRow oRow = null;
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"program_title", string.Empty};
			oTable.Rows.Add(oRow);
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"episode_title", string.Empty};
			oTable.Rows.Add(oRow);
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"program_season", string.Empty};
			oTable.Rows.Add(oRow);
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"episode_nola", string.Empty};
			oTable.Rows.Add(oRow);

			return oTable;
		}

		public static System.Data.DataTable GetTrafficItemSearchCriteria()
		{
			DataTable oTable = new DataTable(TRAFFIC_ITEM_SEARCH_CRITERIA);
			
			DataColumn oColumn;
			
			oColumn = new DataColumn("Key", typeof(string));
			oColumn.ReadOnly = true;
			oTable.Columns.Add(oColumn);
			oTable.Columns.Add(new DataColumn("Value", typeof(string)));

			DataRow oRow = null;
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"Title", string.Empty};
			oTable.Rows.Add(oRow);
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"Duration", string.Empty};
			oTable.Rows.Add(oRow);
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"Category", string.Empty};
			oTable.Rows.Add(oRow);
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"Is_Approved", "0"};
			oTable.Rows.Add(oRow);
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"EXCLUDEINUSE", "0"};
			oTable.Rows.Add(oRow);

			return oTable;
		}

		public static System.Data.DataTable GetAdCopySearchCriteria()
		{
			DataTable oTable = new DataTable(AD_COPY_SEARCH_CRITERIA);
			
			DataColumn oColumn;
			
			oColumn = new DataColumn("Key", typeof(string));
			oColumn.ReadOnly = true;
			oTable.Columns.Add(oColumn);
			oTable.Columns.Add(new DataColumn("Value", typeof(string)));

			DataRow oRow = null;
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"Title", string.Empty};
			oTable.Rows.Add(oRow);
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"Duration", string.Empty};
			oTable.Rows.Add(oRow);
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"Underwriter_Id", string.Empty};
			oTable.Rows.Add(oRow);
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"Is_Approved", "0"};
			oTable.Rows.Add(oRow);
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"EXCLUDEINUSE", "0"};
			oTable.Rows.Add(oRow);

			return oTable;
		}

		public static System.Data.DataTable GetSearchPackageInfoSearchCriteria()
		{
			DataTable oTable = new DataTable(SEARCH_PACKAGE_INFO_SEARCH_CRITERIA);
			
			DataColumn oColumn;
			
			oColumn = new DataColumn("Key", typeof(string));
			oColumn.ReadOnly = true;
			oTable.Columns.Add(oColumn);
			oTable.Columns.Add(new DataColumn("Value", typeof(string)));

			DataRow oRow = null;
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"PACKAGENAME", string.Empty};
			oTable.Rows.Add(oRow);
			return oTable;
		}

		public static System.Data.DataTable GetSearchMediaInfoSearchCriteria()
		{
			DataTable oTable = new DataTable(SEARCH_MEDIA_INFO_SEARCH_CRITERIA);
			
			DataColumn oColumn;
			
			oColumn = new DataColumn("Key", typeof(string));
			oColumn.ReadOnly = true;
			oTable.Columns.Add(oColumn);
			oTable.Columns.Add(new DataColumn("Value", typeof(string)));

			DataRow oRow = null;
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"REVISIONHOUSENUMBER", string.Empty};
			oTable.Rows.Add(oRow);
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"DESCRIPTION", string.Empty};
			oTable.Rows.Add(oRow);
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"NOLACODE", string.Empty};
			oTable.Rows.Add(oRow);

			return oTable;
		}

		public static System.Data.DataTable GetListPackageCutsInfoSearchCriteria()
		{
			DataTable oTable = new DataTable(LIST_PACKAGE_CUTS_INFO_SEARCH_CRITERIA);
			
			DataColumn oColumn;
			
			oColumn = new DataColumn("Key", typeof(string));
			oColumn.ReadOnly = true;
			oTable.Columns.Add(oColumn);
			oTable.Columns.Add(new DataColumn("Value", typeof(string)));

			DataRow oRow = null;
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"REVISIONHOUSENUMBER", string.Empty};
			oTable.Rows.Add(oRow);
			return oTable;
		}

		public static System.Data.DataTable GetListMediaCutsInfoSearchCriteria()
		{
			DataTable oTable = new DataTable(LIST_MEDIA_CUTS_INFO_SEARCH_CRITERIA);
			
			DataColumn oColumn;
			
			oColumn = new DataColumn("Key", typeof(string));
			oColumn.ReadOnly = true;
			oTable.Columns.Add(oColumn);
			oTable.Columns.Add(new DataColumn("Value", typeof(string)));

			DataRow oRow = null;
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"REVISIONHOUSENUMBER", string.Empty};
			oTable.Rows.Add(oRow);
			return oTable;
		}

		public static System.Data.DataTable GetListPackageMediaInfoSearchCriteria()
		{
			DataTable oTable = new DataTable(LIST_PACKAGE_MEDIA_INFO_SEARCH_CRITERIA) ;
			
			DataColumn oColumn;
			
			oColumn = new DataColumn("Key", typeof(string));
			oColumn.ReadOnly = true;
			oTable.Columns.Add(oColumn);
			oTable.Columns.Add(new DataColumn("Value", typeof(string)));

			DataRow oRow = null;
			oRow = oTable.NewRow();			
			oRow.ItemArray = new object[2]{"REVISIONHOUSENUMBER", string.Empty};
			oTable.Rows.Add(oRow);
			return oTable;
		}
		public static BVWebService.UserProfile GetUserProfile()
		{



            UserProfile oUserProfile = new UserProfile();

            // Use a default profile 
            if (!File.Exists("UserProfile.config"))
            {
                oUserProfile.sConnectId = "RSYED";
                oUserProfile.oOperatingGroup = new string[] { "Administrators", "Users" };
                oUserProfile.nUnitType = 1;
                oUserProfile.nRole = 1;
                oUserProfile.nOperatingUnit = 369;
                //userProfile.sExternalEmail = "faithfulc@avanade.com";
                //userProfile.sFirstName = "Rahiq";
                //userProfile.sLastName = "Syed";


                //XmlSerializer oXmlSerializer = new XmlSerializer(typeof(UserProfile));
                //using (StreamWriter oWriter = new StreamWriter("temp.xml"))
                //{
                //    oXmlSerializer.Serialize(oWriter, oUserProfile);
                //}
                

            }
            else
            {
                XmlSerializer oXmlSerializer = new XmlSerializer(typeof(BVWebService.UserProfile));
                using (StreamReader oReader = new StreamReader("UserProfile.config"))
                {
                    oUserProfile = (UserProfile)oXmlSerializer.Deserialize(oReader);
                }
            }







            //BVWebService.UserProfile oUserProfile		= new BVWebService.UserProfile();
            //oUserProfile.sConnectId			= "RSYED";
            //oUserProfile.oOperatingGroup	= new string[] { "Administrators", "Users" };
            //oUserProfile.nUnitType			= 1;
            //oUserProfile.nRole				= 1;
            //oUserProfile.nOperatingUnit		= 369;

			return oUserProfile;
		}

		public static int GetSelectedItemValue(System.Windows.Forms.ComboBox p_oList)
		{
			int iReturn = -1;


			if (p_oList != null)
			{
				if (p_oList.SelectedItem != null)
				{


					string[] oKeyValue = p_oList.SelectedItem.ToString().Split(new char[]{'|'});
				
					iReturn = int.Parse(oKeyValue[1].ToString());
				}
				else
				{
					throw new Exception("Required Field - Value is required." + p_oList.Name);
				}
			}
			else
			{
				throw new Exception("Required Field - Value is required." + p_oList.Name);
			}

			return iReturn;
		}


	}


    public class PBSComboItem
    {
        public int iKey { get; set; }
        public string sValue { get; set; }
        public PBSComboItem(int p_iKey, string p_sValue)
        {
            iKey = p_iKey; sValue = p_sValue;
        }
        public override string ToString()
        {
            return sValue;
        }
    }
}
