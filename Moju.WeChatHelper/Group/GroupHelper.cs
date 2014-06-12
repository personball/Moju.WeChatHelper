using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Moju.WeChatHelper
{
    /// <summary>
    /// 分组管理
    /// </summary>
    public class GroupHelper
    {
        /// <summary>
        /// 创建分组
        /// </summary>
        /// <param name="AccessToken">凭证</param>
        /// <param name="GroupName">新分组组名</param>
        /// <returns>
        /// 正常返回：{"group": {"id": 107, "name": "test"}}
        /// 异常返回：{"errcode":40013,"errmsg":"invalid appid"}
        /// </returns>
        public static int Create(string AccessToken, string GroupName)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/groups/create?access_token={0}", AccessToken);
            string postData = (new JObject(
                new JProperty("group",
                    new JObject(
                        new JProperty("name", GroupName))))).ToString();// "{\"group\":{\"name\":\"" + GroupName + "\"}}";
            string res = Utils.RequestPost(url, postData);
            try
            {
                var retDef = new { group = new { id = 0, name = "" } };
                var retObj = JsonConvert.DeserializeAnonymousType(res, retDef);
                return retObj.group.id;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 查询所有分组
        /// </summary>
        /// <param name="AccessToken">凭证</param>
        /// <returns></returns>
        public static IEnumerable<Group> Get(string AccessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/groups/get?access_token={0}", AccessToken);
            string res = Utils.RequestGet(url);
            JObject Jobj = JObject.Parse(res);
            if (Jobj["groups"] != null)
            {
                return from g in (JArray)Jobj["groups"]
                       select g.ToObject<Group>();
            }
            else
            {
                throw new Exception("查询出错：" + res);
            }
        }
        /// <summary>
        /// 查询用户所在组编号
        /// </summary>
        /// <param name="AccessToken">凭证</param>
        /// <param name="OpenID">用户OpenID</param>
        /// <returns>组编号</returns>
        public static int GetGroupID(string AccessToken, string OpenID)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/groups/getid?access_token={0}", AccessToken);
            string postData = (new JObject(
                new JProperty("openid", OpenID)
                )).ToString();
            string res = Utils.RequestPost(url, postData);
            try
            {
                var rightDef = new { groupid = 0 };//{"groupid": 102}
                var group = JsonConvert.DeserializeAnonymousType(res, rightDef);
                return group.groupid;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 修改分组名
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <param name="GroupID"></param>
        /// <param name="GroupName"></param>
        /// <returns></returns>
        public static bool Update(string AccessToken, int GroupID, string GroupName)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/groups/update?access_token={0}", AccessToken);
            string postData = (
                new JObject(
                    new JProperty("group",
                        new JObject(
                            new JProperty("id", GroupID),
                            new JProperty("name", GroupName)
                            )))).ToString();//"{\"group\":{\"id\":108,\"name\":\"test2_modify2\"}}";
            string res = Utils.RequestPost(url, postData);
            var retDef = new { errcode = 0, errmsg = "" };//{"errcode": 0, "errmsg": "ok"}
            var resObj = JsonConvert.DeserializeAnonymousType(res, retDef);
            return resObj.errcode == 0;
        }
        /// <summary>
        /// 移动用户分组
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <param name="OpenID"></param>
        /// <param name="ToGroupID"></param>
        /// <returns></returns>
        public static bool MemberUpdate(string AccessToken, string OpenID, int ToGroupID)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/groups/members/update?access_token={0}", AccessToken);
            string postData = (new JObject(
                new JProperty("openid", OpenID),
                new JProperty("to_groupid", ToGroupID)
                )).ToString();//{"openid":"oDF3iYx0ro3_7jD4HFRDfrjdCM58","to_groupid":108}
            string res = Utils.RequestPost(url, postData);
            var retDef = new { errcode = 0, errmsg = "" };//{"errcode": 0, "errmsg": "ok"}
            var resObj = JsonConvert.DeserializeAnonymousType(res, retDef);
            return resObj.errcode == 0;
        }
    }
}
