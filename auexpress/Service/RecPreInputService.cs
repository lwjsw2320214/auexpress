using auexpress.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auexpress.Utils;
using auexpress.model;

namespace auexpress.Service
{
    public class RecPreInputService:BaseService
    {

        public RecPreInputInfo getRecPreInput(Int64 iid, Int64 icid, string waybillId)
        {
            Dictionary<string, object> dc = new Dictionary<string, object>();
            dc.Add("iid", iid);
            dc.Add("icid", icid);
            dc.Add("waybillId", waybillId);
            dc.Add("username", AppGlobal.user.mcaccount);
            dc.Add("token", AppGlobal.user.token);
            dc.Add("batchId", AppGlobal.SmsBatchId);
            var pageCount = network.getApi(url + "recPreInput/getRecPreInput", dc);
            var count = pageCount.JsonToObject<RecPreInputInfo>();
            return count;

        }

        public RecPreInputPage getAllBatcrRec()
        { 
            Dictionary<string, object> dc = new Dictionary<string, object>(); 
            dc.Add("username", AppGlobal.user.mcaccount);
            dc.Add("token", AppGlobal.user.token);
            dc.Add("batchId", AppGlobal.SmsBatchId);
            var pageCount = network.getApi(url + "recPreInput/getAllBatcrRec", dc);
            var count = pageCount.JsonToObject<RecPreInputPage>();
            return count;

        }

    }
}
