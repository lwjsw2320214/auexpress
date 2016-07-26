using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace auexpress.model
{
    public class User
    {

        public int icid{get;set;}
        public String mcaccount { get; set; }
        public String clientpassword { get; set; }
        public String token { get; set; }

        /**
        * 姓名
        * */
        public String csender { get; set; }
        /**
         * 单位
         * */
        public String cunitname { get; set; }

        /**
         * 电话
         * */
        public String cphone { get; set; }

        /**
         * 详细地址
         * */
        public String caddr { get; set; }

        /**
         * 邮编
         * */
        public String cpostcode { get; set; }

        /**
         * 国家
         * */
        public String ccountry{get;set;}

        /**
         * 省/州
         * */
        public String cprovince { get; set; }

        /**
         * 城市
         * */
        public String ccity{get;set;}

    }
}
