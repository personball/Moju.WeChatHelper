using Moju.WeChatHelper;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Web;
namespace Demo.Models
{
    public class Tools
    {
        public static string GetToken()
        {
            string AccessToken = WeChatHelper.GetAccessToken();//实际开发时，请勿过多请求AccessToken，保存后未过期则沿用
            //正常结果：{"access_token":"ACCESS_TOKEN","expires_in":7200}
            //异常结果：{"errcode":40013,"errmsg":"invalid appid"}
            var tokenObj = new { access_token = "", expires_in = 0 };
            var tokenRes = JsonConvert.DeserializeAnonymousType(AccessToken, tokenObj);
            return tokenRes.access_token;
        }
        /// <summary>
        /// 简单日志，调试用
        /// </summary>
        /// <param name="str"></param>
        public static void Log(string str)
        {
            using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath("~/" + DateTime.Now.ToString("yyyyMMdd") + ".log"), true))
            {
                sw.WriteLine("{0}\t :{1}", DateTime.Now, str);
            }
        }

    }
}