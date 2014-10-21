using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace SAWebService
{
	/// <summary>
	/// Summary description for UserProfileBase.
	/// </summary>
	public class UserProfileBase
	{

		public UserProfileBase()
		{
		}

		public UserProfileBase (string p_sConnectId,
			string p_sFirstName,
			string p_sLastName)
		{
			m_sConnectId = p_sConnectId;
			m_sFirstName = p_sFirstName;
			m_sLastName = p_sLastName;
		}

		private string m_sConnectId; 
		public string sConnectId
		{
			get
			{
				return m_sConnectId;
			}
			set
			{
				m_sConnectId = value;
			}
		}

		private string m_sFirstName; 
		public string sFirstName
		{
			get
			{
				return m_sFirstName;
			}
			set
			{
				m_sFirstName = value;
			}
		}

		private string m_sLastName; 
		public string sLastName
		{
			get
			{
				return m_sLastName;
			}
			set
			{
				m_sLastName = value;
			}
		}
	}
}
