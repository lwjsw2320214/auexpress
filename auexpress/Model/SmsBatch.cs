using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace auexpress.Model
{
    public class SmsBatch
    {

        public Int64 id { get; set; }

        public string batchNumber { get; set; }

        public Int64 createUser { get; set; }

        public string createDate { get; set; }

    }
}
