using System.Xml.Serialization;
namespace Moju.WeChatHelper
{
    [XmlRoot("xml")]
    public class RLocationMessage:RMessage
    {
        public string Location_X{get;set;}
        public string Location_Y{get;set;}
        public int Scale{get;set;}
        public string Label{get;set;}

        public RLocationMessage()
        {
            this.MsgType = MessageType.Location;
        }
    }
}
