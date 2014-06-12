using Demo.Models;
using Moju.WeChatHelper;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;
using System.Xml.Linq;
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
            Tools.Log(xml.ToString(SaveOptions.DisableFormatting));//log
            //xml反序列化为对象
            Message msg = MessageFactory.CreateFromXml(xml);
            //业务处理，根据自己的业务规则进行处理
            if (msg.MsgType == MessageType.Text)
            {
                RTextMessage text = (RTextMessage)msg;
                //测试获取access_token接口
                if (text.Content == "t1")
                {
                    string AccessToken = BaseHelper.GetAccessToken();
                    Tools.Log("AccessToken:" + AccessToken);
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
                    string res = BaseHelper.UpLoadMediaFile(Tools.GetToken(), UpLoadMediaType.Image, Server.MapPath("~/mind.jpg"));
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
                    string FilePath = BaseHelper.DownLoadMediaFile(Tools.GetToken(), img.MediaId, Server.MapPath("~/files/"));

                    Tools.Log("download:" + FilePath);

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
    }
}
