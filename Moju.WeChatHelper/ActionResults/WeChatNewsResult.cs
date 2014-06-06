using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Moju.WeChatHelper
{
    public class WeChatNewsResult : WeChatResult
    {
        public List<Article> Articles { get; set; }
        public WeChatNewsResult()
        {
            this.Articles = new List<Article>();
            this.MsgType = SMessageType.News;
        }
        protected override void SubXml(XElement xml)
        {
            if (Articles == null || Articles.Count == 0)
            {
                throw new Exception(message: "没有图文内容！");
            }
            xml.Add(new XElement("ArticleCount", Articles.Count));
            XElement Items = new XElement("Articles");
            foreach (var item in Articles)
            {
                Items.Add(
                    new XElement("item",
                        new XElement("Title", new XCData(item.Title)),
                        new XElement("Description", new XCData(item.Description)),
                        new XElement("PicUrl", new XCData(item.PicUrl)),
                        new XElement("Url", new XCData(item.Url))
                        ));
            }
            xml.Add(Items);
        }
    }
}
