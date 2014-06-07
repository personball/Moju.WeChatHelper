using Moju.WeChatHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Newtonsoft.Json;
namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 接入时验证
        /// </summary>
        /// <param name="echostr"></param>
        /// <returns></returns>
        [HttpGet]
        [WeChatVerify]
        public ContentResult WeChat(string echostr)
        {
            return Content(echostr);
        }
        /// <summary>
        /// 接收微信发送的消息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [WeChatVerify]
        public ActionResult WeChat()
        {
            XDocument xml = XDocument.Load(Request.InputStream);
            log(xml.ToString(SaveOptions.DisableFormatting));//log
            //xml反序列化为对象
            Message msg = MessageFactory.CreateFromXml(xml);
            //业务处理，根据自己的业务规则进行处理
            if (msg.MsgType == MessageType.Text)
            {
                RTextMessage text = (RTextMessage)msg;
                //测试获取access_token接口
                if (text.Content == "t1")
                {
                    string AccessToken = WeChatHelper.GetAccessToken();
                    log("AccessToken:" + AccessToken);
                    return new WeChatTextResult
                    {
                        FromUserName = text.ToUserName,
                        ToUserName = text.FromUserName,
                        CreateTime = DateTime.Now,
                        Content = text.Content + AccessToken
                    };
                }
                //测试图片上传接口
                if (text.Content == "t2")
                {
                    string AccessToken = WeChatHelper.GetAccessToken();//实际开发时，请勿过多请求AccessToken，保存后未过期则沿用
                    //正常结果：{"access_token":"ACCESS_TOKEN","expires_in":7200}
                    //异常结果：{"errcode":40013,"errmsg":"invalid appid"}
                    var tokenObj = new { access_token = "", expires_in = 0 };
                    var tokenRes = JsonConvert.DeserializeAnonymousType(AccessToken, tokenObj);

                    string res = WeChatHelper.UpLoadMediaFile(tokenRes.access_token, UpLoadMediaType.Image, Server.MapPath("~/mind.jpg"));
                    var rightDef = new { type = "", media_id = "", created_at = 0 };//{"type":"TYPE","media_id":"MEDIA_ID","created_at":123456789}

                    var resObj = JsonConvert.DeserializeAnonymousType(res, rightDef);
                    return new WeChatImageResult
                    {
                        CreateTime = DateTime.Now,
                        FromUserName = text.ToUserName,
                        ToUserName = text.FromUserName,
                        MediaId = resObj.media_id
                    };

                }

                //被动响应消息封装的类继承于ActionResult
                return new WeChatTextResult
                {
                    FromUserName = text.ToUserName,
                    ToUserName = text.FromUserName,
                    CreateTime = DateTime.Now,
                    Content = text.Content
                };
            }
            else
            {
                return Content("");
            }
        }
        /// <summary>
        /// 简单日志，调试用
        /// </summary>
        /// <param name="str"></param>
        private void log(string str)
        {
            using (StreamWriter sw = new StreamWriter(Server.MapPath("~/" + DateTime.Now.ToString("yyyyMMdd") + ".log"), true))
            {
                sw.WriteLine("{0}\t :{1}", DateTime.Now, str);
            }
        }
    }
}
