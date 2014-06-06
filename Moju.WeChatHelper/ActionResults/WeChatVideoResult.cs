using System.Xml.Linq;

namespace Moju.WeChatHelper
{
    public class WeChatVideoResult : WeChatResult
    {
        public string MediaId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public WeChatVideoResult()
        {
            this.MsgType = SMessageType.Video;
        }
        protected override void SubXml(XElement xml)
        {
            xml.Add(new XElement("Video",
                new XElement("MediaId", new XCData(MediaId)),
                new XElement("Title", new XCData(Title)),
                new XElement("Description", new XCData(Description))));
        }
    }
}
