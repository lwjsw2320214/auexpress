using auexpress.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace auexpress.Service
{
    public class BaseService
    {

        public ContentNetWork network = new ContentNetWork();

        public string url = "http://api.au-express.com:8080/auexpress-api/";

    }
}
