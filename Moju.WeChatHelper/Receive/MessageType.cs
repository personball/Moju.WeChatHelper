namespace Moju.WeChatHelper
{
    /// <summary>
    /// 接收普通消息的消息类型定义
    /// </summary>
    public static class MessageType
    {
        /// <summary>
        /// 文本消息
        /// </summary>
        public const string Text = "text";
        /// <summary>
        /// 图片消息
        /// </summary>
        public const string Image = "image";
        /// <summary>
        /// 语音消息
        /// </summary>
        public const string Voice = "voice";
        /// <summary>
        /// 视频消息
        /// </summary>
        public const string Video = "video";
        /// <summary>
        /// 地理位置消息
        /// </summary>
        public const string Location = "location";
        /// <summary>
        /// 链接消息
        /// </summary>
        public const string Link = "link";
        /// <summary>
        /// 事件推送
        /// </summary>
        public const string Event = "event";
    }
}
