using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BVWebServiceTestProject.Test_References
{
    [Serializable]
    public class Genre
    {
        public int GNR_ID { get; set; }
        public string GNR_CODE { get; set; }
        public string GNR_DESC { get; set; }
        public short GNR_ISARCHIVED { get; set; }
    }
}
