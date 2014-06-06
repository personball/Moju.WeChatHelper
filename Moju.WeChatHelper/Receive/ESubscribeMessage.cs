using System.Xml.Serialization;
namespace Moju.WeChatHelper
{
    [XmlRoot("xml")]
    public class ESubscribeMessage : EMessage
    {
        public ESubscribeMessage()
            : base()
        {
            this.Event = EventType.Subscribe;
        }
    }
}
