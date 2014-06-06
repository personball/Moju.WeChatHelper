using System.Xml.Serialization;
namespace Moju.WeChatHelper
{
    [XmlRoot("xml")]
    public class EViewMessage : EMessage
    {
        /// <summary>
        /// 事件KEY值，设置的跳转URL
        /// </summary>
        public string EventKey { get; set; }
        public EViewMessage()
            : base()
        {
            this.Event = EventType.VIEW;
        }
    }
}
