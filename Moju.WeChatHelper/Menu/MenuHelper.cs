using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moju.WeChatHelper
{
    /// <summary>
    /// 自定义菜单
    /// </summary>
    public class MenuHelper
    {
        /// <summary>
        /// 创建自定义菜单
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <returns></returns>
        public static string Create(string AccessToken, Menu menu)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", AccessToken);
            return Utils.RequestPost(url, menu.GetJson().ToString());
        }
        /// <summary>
        /// 查询菜单
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <returns></returns>
        public static string Get(string AccessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", AccessToken);
            return Utils.RequestGet(url);
        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <returns></returns>
        public static string Delete(string AccessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}", AccessToken);
            return Utils.RequestGet(url);
        }
    }
}
