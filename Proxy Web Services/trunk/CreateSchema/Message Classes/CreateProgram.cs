using System;
using System.Data;
using System.IO;
using System.Xml;
using System.Text;
using BVWebService;
using TVSServer = OrionProxy;

namespace CreateSchema
{
	/// <summary>
	/// Summary description for CreateProgram.
	/// </summary>
	public class CreateProgram
	{
		public CreateProgram()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void GenSchema(string strTargetDir)
		{

			#region CreateProgram.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\CreateProgramClassTemplate.cs.txt", strTargetDir + @"\xsltClass\CreateProgramClass.cs", "Program", "ProgramCreator");
			#endregion
		}
	}
}
