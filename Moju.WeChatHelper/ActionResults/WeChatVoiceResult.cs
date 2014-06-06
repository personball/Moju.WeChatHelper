using System.Xml.Linq;

namespace Moju.WeChatHelper
{
    public class WeChatVoiceResult : WeChatResult
    {
        public string MediaId { get; set; }
        public WeChatVoiceResult()
        {
            this.MsgType = SMessageType.Voice;
        }
        protected override void SubXml(XElement xml)
        {
            xml.Add(new XElement("Voice",
                new XElement("MediaId",new XCData(MediaId))));
        }
    }
}
