using System;
using System.IO;
using System.Text;

namespace CreateSchema
{
	/// <summary>
	/// Summary description for GenLoadClassHelper.
	/// </summary>
	public class GenLoadClassHelper
	{
        public GenLoadClassHelper()
		{
		}

        public static void GenClass(string strTemplateFile, string strClassFile, string strClassName, string p_sInterfaceName)
		{
			StreamReader oReader = new StreamReader(strTemplateFile, Encoding.UTF8);
			string strContent = oReader.ReadToEnd();
			oReader.Close();

            string strResult = strContent.Replace("<object>", strClassName);
            strResult = strResult.Replace("<interface>", p_sInterfaceName);

			StreamWriter oWriter = new StreamWriter(strClassFile, false, Encoding.UTF8);
			oWriter.Write(strResult);
			oWriter.Close();
		}


	}
}