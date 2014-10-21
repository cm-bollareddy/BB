using System;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using BVWebService;
using TVSServer = OrionProxy;

namespace CreateSchema
{
	/// <summary>
    /// Summary description for SearchMediaAirDate
	/// </summary>
	public class SearchMediaAirDate
	{
        public SearchMediaAirDate()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void GenSchema(string strTargetDir)
		{
			
			string strSessionID = "";

			//
			// Start a BroadView session
			//
			BVSession s = new BVSession();
			strSessionID = s.Login();

			//
			// Generate the BroadView Schema
			//
			TVSServer.rdmPBSSearch p = ComponentFactory.CreateSearchClass();

			// Invoke the object to get the XML result string
			int nErrorCode		= 0;
			string sErrorText	= string.Empty;
			string sXmlString	= string.Empty;
            string sId = "8073570";
            int iTuneValue = 1;

			nErrorCode = p.SearchMediaAirDate(strSessionID, sId, iTuneValue ,out sXmlString, out sErrorText);

			if (nErrorCode != 0)
			{
				MessageBox.Show(sErrorText);
				return;
			}
			//
			// End our session
			//
			s.Logout(strSessionID);



            #region SearchMediaAirDate.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\SearchAirDateClassTemplate.cs.txt", strTargetDir + @"\xsltClass\MediaAirDateClass.cs", "MediaAirDate", "Search");
			#endregion
		}
	}
}
