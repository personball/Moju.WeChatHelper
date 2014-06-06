namespace Moju.WeChatHelper
{
    /// <summary>
    /// 事件消息
    /// </summary>
    public abstract class EMessage : Message
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        public string Event { get; set; }

        public EMessage()
        {
            this.MsgType = MessageType.Event;
        }
    }
}
