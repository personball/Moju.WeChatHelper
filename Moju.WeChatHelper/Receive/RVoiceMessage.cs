using System.Xml.Serialization;
namespace Moju.WeChatHelper
{
    [XmlRoot("xml")]
    public class RVoiceMessage : RMessage
    {
        public string MediaId { get; set; }
        public string Format { get; set; }

        public RVoiceMessage()
        {
            this.MsgType = MessageType.Voice;
        }
    }
}
