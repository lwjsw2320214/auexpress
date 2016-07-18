using auexpress.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auexpress.Utils;

namespace auexpress.Service
{
    public class WaybillProcessingService:BaseService
    {

        /// <summary>
        /// 加载快递数据
        /// </summary>
        /// <param name="dc"></param>
        /// <returns></returns>
        public RecPreInputPage LoadExpressMenu(Dictionary<string, object> dc)
        {
            var pageCount = network.getApi(url + "recPreInput", dc);
            var Count = pageCount.JsonToObject<RecPreInputPage>();
            return Count;
        }


        /// <summary>
        /// 获取页面数据
        /// </summary>
        /// <param name="dc"></param>
        /// <returns></returns>
        public RecPreInputPage GetPage(Dictionary<string, object> dc)
        {
            var pageCount = network.getApi(url + "recPreInput", dc);
            var Count = pageCount.JsonToObject<RecPreInputPage>();

            return Count;

        }
    }
}
