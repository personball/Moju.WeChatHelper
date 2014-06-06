using System.Xml.Serialization;
namespace Moju.WeChatHelper
{
    [XmlRoot("xml")]
    public class EUnSubscribeMessage : EMessage
    {
        public EUnSubscribeMessage()
            : base()
        {
            this.Event = EventType.UnSubscribe;
        }
    }
}
