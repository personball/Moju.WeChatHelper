using System;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
namespace Moju.WeChatHelper
{
    public class WeChatResult : ActionResult
    {
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public DateTime CreateTime { get; set; }
        protected string MsgType { get; set; }
        /// <summary>
        /// 由具体子类实现
        /// </summary>
        /// <param name="xml"></param>
        protected virtual void SubXml(XElement xml)
        {

        }
        /// <summary>
        /// 便于单元测试
        /// </summary>
        /// <returns></returns>
        public string GetXml()
        {
            XElement xml = new XElement("xml",
                           new XElement("ToUserName", new XCData(ToUserName)),
                           new XElement("FromUserName", new XCData(FromUserName)),
                           new XElement("CreateTime", CreateTime.Ticks.ToString()),
                           new XElement("MsgType", new XCData(MsgType))
                           );
            SubXml(xml);
            return xml.ToString(SaveOptions.DisableFormatting);
        }
        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;
            response.Write(GetXml());
        }

    }
}
