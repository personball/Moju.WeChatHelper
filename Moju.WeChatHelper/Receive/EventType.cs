namespace Moju.WeChatHelper
{
    /// <summary>
    /// 事件推送之事件类型
    /// </summary>
    public static class EventType
    {
        /// <summary>
        /// 订阅（关注）
        /// </summary>
        public const string Subscribe = "subscribe";
        /// <summary>
        /// 取消订阅（取消关注）
        /// </summary>
        public const string UnSubscribe = "unsubscribe";
        /// <summary>
        /// 扫描带参数二维码事件
        /// </summary>
        public const string SCAN = "SCAN";
        /// <summary>
        /// 上报地理位置事件
        /// </summary>
        public const string LOCATION = "LOCATION";
        /// <summary>
        /// 点击菜单拉取消息时的事件推送
        /// </summary>
        public const string CLICK = "CLICK";
        /// <summary>
        /// 点击菜单跳转链接时的事件推送
        /// </summary>
        public const string VIEW = "VIEW";
    }
}
