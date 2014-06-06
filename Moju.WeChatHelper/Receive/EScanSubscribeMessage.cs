using System.Xml.Serialization;
namespace Moju.WeChatHelper
{
    [XmlRoot("xml")]
    public class EScanSubscribeMessage : EMessage
    {
        /// <summary>
        /// 事件KEY值，qrscene_为前缀，后面为二维码的参数值
        /// </summary>
        public string EventKey { get; set; }
        /// <summary>
        /// 二维码的ticket，可用来换取二维码图片
        /// </summary>
        public string Ticket { get; set; }
        public EScanSubscribeMessage()
            : base()
        {
            this.Event = EventType.Subscribe;
        }
    }
}
