using auexpress.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auexpress.Utils;

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
            Dictionary<string, object> dc = new Dictionary<string, object>();
            dc.Add("batchNumber", smsBatch.batchNumber);
            dc.Add("createDate", smsBatch.createDate);
            dc.Add("createUser", smsBatch.createUser); 
            var count = network.getApi(url + "smsBatch/add", dc);
            var pageCount = count.JsonToObject<AddSmsBatch>();
            return pageCount.obj;
        }

    }
}
