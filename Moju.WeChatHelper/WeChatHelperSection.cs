using System;
using System.Configuration;

namespace Moju.WeChatHelper
{
    /// <summary>
    /// 微信配置类
    /// 配置方式（web.config中）
    ///  <configSections>
    ///  <section name="WeChatHelperSection" type="Moju.WeChatHelper.WeChatHelperSection, Moju.WeChatHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" />
    ///  </configSections>
    ///  <WeChatHelperSection WeChatAppID="" WeChatAppSecret="" Token="" />
    /// </summary>
    public class WeChatHelperSection : ConfigurationSection
    {
        public WeChatHelperSection() { }
        [ConfigurationProperty("WeChatAppID", DefaultValue = "")]
        public String WeChatAppID
        {
            get
            {
                return (String)this["WeChatAppID"];
            }
            set
            {
                this["WeChatAppID"] = value;
            }
        }
        [ConfigurationProperty("WeChatAppSecret", DefaultValue = "")]
        public String WeChatAppSecret
        {
            get
            {
                return (String)this["WeChatAppSecret"];
            }
            set
            {
                this["WeChatAppSecret"] = value;
            }
        }
        [ConfigurationProperty("Token", DefaultValue = "")]
        public String Token
        {
            get
            {
                return (String)this["Token"];
            }
            set
            {
                this["Token"] = value;
            }
        }
        
    }
}
