using System.Xml.Serialization;
namespace Moju.WeChatHelper
{
    [XmlRoot("xml")]
    public class RImageMessage:RMessage
    {
        public string PicUrl { get; set; }
        public string MediaId { get; set; }
        public RImageMessage()
        {
            this.MsgType = MessageType.Image;
        }
    }
}
