using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace auexpress.model
{
    public class RecPreInputPage
    {

        //结果成功失败；
        public Boolean result { get; set; }

        //结果集
        public List<Express> obj { get; set; }

        public int pageCount { get; set; }

        public int page { get; set; }

    }
}
