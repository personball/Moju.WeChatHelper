using Moju.WeChatHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
                    string res = WeChatHelper.UpLoadMediaFile(GetToken(), UpLoadMediaType.Image, Server.MapPath("~/mind.jpg"));
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
                if (msg.MsgType == MessageType.Image)
                {
                    RImageMessage img = (RImageMessage)msg;
                    //下载图片
                    string FilePath = WeChatHelper.DownLoadMediaFile(GetToken(), img.MediaId, Server.MapPath("~/files/"));

                    log("download:" + FilePath);

                    return new WeChatTextResult
                    {
                        FromUserName = img.ToUserName,
                        ToUserName = img.FromUserName,
                        Content = "图片已存，文件名：" + FilePath,
                        CreateTime = DateTime.Now
                    };
                }


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

        public ActionResult SetMenu()
        {
            string token = GetToken();

            Menu menu = new Menu();
            menu.button = new List<Button>();
            menu.button.Add(new ClickButton { Key = "K001", Name = "测试菜单1" });
            menu.button.Add(new ClickButton { Key = "K002", Name = "测试菜单2" });
            menu.button.Add(new ClickButton { Key = "K003", Name = "测试菜单3" });

            string res = WeChatHelper.MenuCreate(token, menu);
            return Content("done:" + res);
        }

        public ActionResult GetMenu()
        {
            string token = GetToken();
            string res = WeChatHelper.MenuGet(token);
            Menu menu = new Menu();
            if (res!="error")
            {
                JObject Jobj = JObject.Parse(res);   
                menu.button = ((JArray)Jobj["menu"]["button"]).ToWeChatMenuButtonList().ToList();
            }
            return Content(res+"<br/>"+menu.GetJson().ToString());
        }


        private string GetToken()
        {
            string AccessToken = WeChatHelper.GetAccessToken();//实际开发时，请勿过多请求AccessToken，保存后未过期则沿用
            //正常结果：{"access_token":"ACCESS_TOKEN","expires_in":7200}
            //异常结果：{"errcode":40013,"errmsg":"invalid appid"}
            var tokenObj = new { access_token = "", expires_in = 0 };
            var tokenRes = JsonConvert.DeserializeAnonymousType(AccessToken, tokenObj);
            return tokenRes.access_token;
        }
    }
}
