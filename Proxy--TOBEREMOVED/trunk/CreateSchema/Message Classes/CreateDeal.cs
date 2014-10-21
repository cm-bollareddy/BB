using System;
using System.Data;
using System.IO;
using System.Xml;
using System.Text;
using BVWebService;
using TVSServer = OrionProxy;

namespace CreateSchema
{
    public class CreateDeal
    {
        public CreateDeal()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void GenSchema(string strTargetDir)
		{

			#region CreateProgram.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\CreateDealClassTemplate.cs.txt", strTargetDir + @"\xsltClass\CreateDealClass.cs", "Deal", "Deal");
			#endregion
		}
    }
}
