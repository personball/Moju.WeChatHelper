using System.Xml.Linq;

namespace Moju.WeChatHelper
{
    public class WeChatTextResult : WeChatResult
    {
        public string Content { get; set; }

        public WeChatTextResult()
        {
            this.MsgType = SMessageType.Text;
        }
        protected override void SubXml(XElement xml)
        {
            xml.Add(new XElement("Content", new XCData(Content)));
        }
    }
}
