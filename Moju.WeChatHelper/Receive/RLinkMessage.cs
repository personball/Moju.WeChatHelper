using System.Xml.Serialization;
namespace Moju.WeChatHelper
{
    [XmlRoot("xml")]
    public class RLinkMessage:RMessage
    {
        public string Title{get;set;}
        public string Description{get;set;}
        public string Url{get;set;}
        public RLinkMessage()
        {
            this.MsgType = MessageType.Link;
        }
    }
}
