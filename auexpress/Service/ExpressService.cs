﻿using auexpress.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auexpress.Utils;
using auexpress.model;

namespace auexpress.Service
{
    public class ExpressService:BaseService
    {

        /// <summary>
        /// 获取快递列别
        /// </summary>
        /// <returns></returns>
        public AjaxExpressType getExpressTypeList() {

            Dictionary<string, object> dc = new Dictionary<string, object>();
            dc.Add("username", AppGlobal.user.mcaccount);
            dc.Add("token", AppGlobal.user.token);
            var pageCount = network.getApi(url + "parameter/getExpressTypeList", dc);
            var count = pageCount.JsonToObject<AjaxExpressType>();
            return count;
        }
    }
}
