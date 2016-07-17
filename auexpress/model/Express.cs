using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace auexpress.model
{
    public class Express
    {

        /// <summary>
        /// 主键id
        /// </summary>
        public Int64 iid { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public Int64 icid { get; set; }

        /// <summary>
        /// 发货id
        /// </summary>
        public Int64 irid { get; set; }

        /// <summary>
        /// 录入日期
        /// </summary>
        public string ddate { get; set; }
          
        /// <summary>
        /// 快递类别
        /// </summary>
        public string cemskind { get; set; }

        /// <summary>
        /// 运单号
        /// </summary>
        public string cnum { get; set; }

        /// <summary>
        /// 目的地
        /// </summary>
        public string cdes { get; set; }

        /// <summary>
        /// 中文品名
        /// </summary>
        public string cgoods { get; set; }

        /// <summary>
        /// 产品重量
        /// </summary>
        public Decimal fweight { get; set; }

        /// <summary>
        /// 收货人
        /// </summary>
        public string creceiver { get; set; }

        /// <summary>
        /// 收货电话
        /// </summary>
        public string cphone { get; set; }

        /// <summary>
        /// 收货人详细地址
        /// </summary>
        public string caddr { get; set; }
        /// <summary>
        /// 收件人省份
        /// </summary>
        public string cprovince { get; set; }

        /// <summary>
        /// 收件人城市
        /// </summary>
        public string ccity { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        public Decimal total { get; set; }
        

    }
}
