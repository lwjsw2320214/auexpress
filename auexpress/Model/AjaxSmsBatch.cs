using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace auexpress.Model
{
    public class AjaxSmsBatch
    {

        //结果成功失败；
        public Boolean result { get; set; }

        //结果集
        public List<SmsBatch> obj { get; set; }

        public int pageCount { get; set; }

        public int page { get; set; }

    }
}
