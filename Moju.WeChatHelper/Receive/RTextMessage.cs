using System.Xml.Serialization;
namespace Moju.WeChatHelper
{
    [XmlRoot("xml")]
    public class RTextMessage : RMessage
    {
        public string Content { get; set; }

        public RTextMessage()
        {
            this.MsgType = MessageType.Text;
        }
    }
}
