using auexpress.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auexpress.Utils;
using auexpress.model;

namespace auexpress.Service
{
    public class SmsBatchService:BaseService
    {

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public AjaxSmsBatch getList(Dictionary<string, Object> dc)
        {
            var count = network.getApi(url + "smsBatch/getList", dc);
            var pageCount = count.JsonToObject<AjaxSmsBatch>();
            return pageCount;
        }

        /// <summary>
        /// 添加批次号
        /// </summary>
        /// <param name="smsBatch"></param>
        /// <returns>返回如果为0则表示插入失败如果为1则表示插入成功如果为2则表示有重复</returns>
        public int add(SmsBatch smsBatch) {

            var addCount = 0;
            Dictionary<string, object> dc = new Dictionary<string, object>();
            dc.Add("batchNumber", smsBatch.batchNumber);
            dc.Add("createDate", smsBatch.createDate);
            dc.Add("createUser", smsBatch.createUser);
            dc.Add("username", AppGlobal.user.mcaccount);
            dc.Add("token", AppGlobal.user.token);
            var count = network.getApi(url + "smsBatch/add", dc);
            var pageCount = count.JsonToObject<AddSmsBatch>();
            if (pageCount.result) {

                addCount = pageCount.obj.Value;
            }
            return addCount;
        }

        public int delete(Int64 id) {
            var deleteCount = 0;
            Dictionary<string, object> dc = new Dictionary<string, object>(); 
            dc.Add("username", AppGlobal.user.mcaccount);
            dc.Add("token", AppGlobal.user.token);
            dc.Add("id", id);
            var count = network.getApi(url + "smsBatch/delete", dc);
            var pageCount = count.JsonToObject<AddSmsBatch>();
            if (pageCount.result)
            {
                int.TryParse(pageCount.obj.Value.ToString(), out deleteCount);  
            }
            return deleteCount;
        }

    }
}
