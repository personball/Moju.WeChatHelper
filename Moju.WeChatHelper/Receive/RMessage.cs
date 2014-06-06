namespace Moju.WeChatHelper
{
    /// <summary>
    /// 普通消息
    /// </summary>
    public abstract class RMessage : Message
    {
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public string MsgId { get; set; }
    }
}
