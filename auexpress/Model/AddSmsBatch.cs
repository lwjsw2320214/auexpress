using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace auexpress.Model
{
    public class AddSmsBatch
    {

        //结果成功失败；
        public Boolean result { get; set; }

        //结果集
        public int obj { get; set; }

        public int pageCount { get; set; }

        public int page { get; set; }

    }
}
