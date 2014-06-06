using System.Xml.Serialization;
namespace Moju.WeChatHelper
{
    [XmlRoot("xml")]
    public class RVideoMessage : RMessage
    {
        public string MediaId { get; set; }
        public string ThumbMediaId { get; set; }
        public RVideoMessage()
        {
            this.MsgType = MessageType.Video;
        }
    }
}
