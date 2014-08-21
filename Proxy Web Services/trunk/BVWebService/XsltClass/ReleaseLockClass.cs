using System;
using Pbs.WebServices.Utility;
using TVSServer = OrionProxy;

namespace BVWebService
{
	/// <summary>
	/// Summary description for ReleaseLockClass.
	/// </summary>
	public class ReleaseLockClass
	{
		public ReleaseLockClass()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void ReleaseLock(string strSessionID, string strLockID)
		{
			//
			// Filter out lockid which is "" or "0"...
			//
			if ((strLockID == null) || (strLockID == "") || (strLockID == "0"))
			{
				// Do nothing!
				return;
			}

			TVSServer.rdmPBSAuthorization oPBSAuthorization;
			

			try
			{
				oPBSAuthorization = ComponentFactory.CreateAuthorizationClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= pbsInterface.PBSAuthorization",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			try
			{
				nErrorCode = oPBSAuthorization.ReleaseLock(strSessionID, strLockID, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"SessionID= " + strSessionID + ", LockID= " + strLockID,
					ex);
			}

			if (nErrorCode != 0)
			{
				throw new BVException(nErrorCode, strErrorText, "SessionID= " + strSessionID + ", LockID= " + strLockID);
			}
		}
	}
}
