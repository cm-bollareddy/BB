using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace SAWebService
{
	/// <summary>
	/// Summary description for UserProfile.
	/// </summary>
	public class UserProfile : UserProfileBase
	{

		public UserProfile()
		{
		}

		public UserProfile (string p_sConnectId,
			string p_sFirstName,
			string p_sLastName,
			string[] p_sOperatingGroup,
			short p_nOperatingUnit,
			short p_nUnitType,
			short p_nRole,
			string p_sExternalEmail,
			string p_sPhoneNumber) : base(p_sConnectId, p_sFirstName, p_sLastName)
		{
			m_sOperatingGroup = p_sOperatingGroup;
			m_nOperatingUnit = p_nOperatingUnit;
			m_nUnitType = p_nUnitType;
			m_nRole = p_nRole;
			m_sExternalEmail = p_sExternalEmail;
			m_sPhoneNumber = p_sPhoneNumber;
		}



		private string[] m_sOperatingGroup;
		[XmlArrayItemAttribute("sCode")]
		public string[] oOperatingGroup
		{
			get
			{
				return m_sOperatingGroup;
			}
			set
			{
				m_sOperatingGroup = value;
			}
		}

		private short m_nOperatingUnit; 
		public short nOperatingUnit
		{
			get
			{
				return m_nOperatingUnit;
			}
			set
			{
				m_nOperatingUnit = value;
			}
		}

		private short m_nUnitType; 
		public short nUnitType
		{
			get
			{
				return m_nUnitType;
			}
			set
			{
				m_nUnitType = value;
			}
		}

		private short m_nRole; 
		public short nRole
		{
			get
			{
				return m_nRole;
			}
			set
			{
				m_nRole = value;
			}
		}

		private string m_sExternalEmail; 
		public string sExternalEmail
		{
			get
			{
				return m_sExternalEmail;
			}
			set
			{
				m_sExternalEmail = value;
			}
		}

		private string m_sPhoneNumber; 
		public string sPhoneNumber
		{
			get
			{
				return m_sPhoneNumber;
			}
			set
			{
				m_sPhoneNumber = value;
			}
		}


#if FALSE
		public bool IsPBS()
		{
			if (m_nUnitType == UnitTypeValue.UNIT_PBS)
				return true;

			return false;
		}

		public bool IsProducer()
		{
			if (m_nUnitType == UnitTypeValue.UNIT_PROD)
				return true;

			return false;
		}

		public bool IsDistributor()
		{
			if (m_nUnitType == UnitTypeValue.UNIT_DIST)
				return true;

			return false;
		}
#endif
	}
}
