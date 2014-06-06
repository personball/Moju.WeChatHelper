using System.Xml.Serialization;
namespace Moju.WeChatHelper
{
    [XmlRoot("xml")]
    public class EClickMessage : EMessage
    {
        /// <summary>
        /// 事件KEY值，与自定义菜单接口中KEY值对应
        /// </summary>
        public string EventKey { get; set; }

        public EClickMessage()
            : base()
        {
            this.Event = EventType.CLICK;
        }
    }
}
