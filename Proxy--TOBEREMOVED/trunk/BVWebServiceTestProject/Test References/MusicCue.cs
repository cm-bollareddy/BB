using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BVWebServiceTestProject.Test_References
{
    [Serializable]    
    public class MUSICCUE
    {
        public int PMC_ID { get; set; }
        public int? PMC_DEA_ID { get; set; }
        public short PMC_FORMSTATUS { get; set; }
    }
}
