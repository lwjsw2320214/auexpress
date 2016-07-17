using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace auexpress.Utils
{
     public class ContentNetWork
    {

         /// <summary>
         /// 访问网络
         /// </summary>
         /// <param name="url"></param>
         /// <param name="para"></param>
         /// <returns></returns>
         public string getApi(string url,Dictionary<string, object> para)
         {
             var sb = new StringBuilder();
              var paraStr="";
             if (para.Count > 0) { 
             foreach (var item in para)
             {
                 sb.Append(item.Key + "=" + item.Value + "&");
             }
                 paraStr = sb.ToString().Substring(0, sb.ToString().Length - 1);
             }
             byte[] postData = Encoding.UTF8.GetBytes(paraStr);

             WebClient webClient = new WebClient();
             webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

             byte[] responseData = webClient.UploadData(url, "POST", postData);
             string content = Encoding.UTF8.GetString(responseData);
             return content;
         }

    }
}
