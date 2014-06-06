using System.Xml.Linq;

namespace Moju.WeChatHelper
{
    public class WeChatMusicResult:WeChatResult
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string MusicUrl { get; set; }
        public string HQMusicUrl { get; set; }
        public string ThumbMediaId { get; set; }

        public WeChatMusicResult()
        {
            this.MsgType = SMessageType.Music;
        }
        protected override void SubXml(XElement xml)
        {
            xml.Add(new XElement("Music",
                new XElement("Title",new XCData(Title)),
                new XElement("Description",new XCData(Description)),
                new XElement("MusicUrl",new XCData(MusicUrl)),
                new XElement("HQMusicUrl", new XCData(HQMusicUrl)),
                new XElement("ThumbMediaId", new XCData(ThumbMediaId))
                ));
        }
    }
}
