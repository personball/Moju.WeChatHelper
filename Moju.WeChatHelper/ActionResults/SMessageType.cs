using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moju.WeChatHelper
{
    /// <summary>
    /// 被动响应消息的消息类型定义
    /// </summary>
    public static class SMessageType
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
        /// 音乐消息
        /// </summary>
        public const string Music = "music";
        /// <summary>
        /// 图文消息
        /// </summary>
        public const string News = "news";
    }
}
