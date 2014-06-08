using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;

namespace Moju.WeChatHelper
{
    public class WeChatHelper
    {
        private static WeChatHelperSection config = (WeChatHelperSection)ConfigurationManager.GetSection("WeChatHelperSection");
        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <param name="APPID"></param>
        /// <param name="APPSECRET"></param>
        /// <returns></returns>
        public static string GetAccessToken()
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", config.WeChatAppID, config.WeChatAppSecret);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "GET";
            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
            {
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    using (StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                    {
                        //正常结果：{"access_token":"ACCESS_TOKEN","expires_in":7200}
                        //异常结果：{"errcode":40013,"errmsg":"invalid appid"}
                        return sr.ReadToEnd();
                    }
                }
                else
                {
                    throw new Exception("微信AccessToken接口调用失败!");
                }
            }
        }
        /// <summary>
        /// 上传本地文件
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <param name="UpLoadMediaType"></param>
        /// <param name="FilePath"></param>
        public static string UpLoadMediaFile(string AccessToken, string UpLoadMediaType, string FilePath)
        {
            //上传本地文件，用户上传的文件必须先保存在服务器中，再上传至微信接口（微信的文件保存仅3天）

            //TODO 本地不想保留文件时，如何直接将用户上传的文件中转给微信？
            //TODO 文件限制
            /*
             * 上传的多媒体文件有格式和大小限制，如下：
             * 图片（image）: 256K，支持JPG格式
             * 语音（voice）：256K，播放长度不超过60s，支持AMR\MP3格式
             * 视频（video）：1MB，支持MP4格式
             * 缩略图（thumb）：64KB，支持JPG格式
             */
            string url = string.Format("http://file.api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}", AccessToken, UpLoadMediaType);//接口地址及参数
            WebClient client = new WebClient();
            client.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                byte[] res = client.UploadFile(url, FilePath);
                //正常结果：{"type":"TYPE","media_id":"MEDIA_ID","created_at":123456789}
                //异常结果：{"errcode":40004,"errmsg":"invalid media type"}
                return Encoding.Default.GetString(res, 0, res.Length);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// 下载多媒体文件
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <param name="MediaID"></param>
        /// <param name="SavePath"></param>
        /// <returns>文件保存路径</returns>
        public static string DownLoadMediaFile(string AccessToken, string MediaID, string SavePath)
        {
            string url = string.Format("http://file.api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}", AccessToken, MediaID);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "GET";

            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
            {
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    if (resp.ContentType.ToLower().IndexOf("text/plain") > -1)
                    {
                        //异常结果：响应为文本，json数据
                        using (StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                    else
                    {
                        //正常结果：内容为多媒体文件，调用下载
                        WebClient mywebclient = new WebClient();
                        try
                        {
                            //TODO 语音文件的mime类型？视频文件不可下载
                            string FileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
                            mywebclient.DownloadFile(resp.ResponseUri.ToString(), SavePath + FileName);//注意保存路径的写入权限
                            return FileName;
                        }
                        catch (Exception ex)
                        {
                            return ex.StackTrace;
                        }
                    }
                }
                else
                {
                    return "微信下载接口调用失败!";
                }
            }
        }
        /// <summary>
        /// 创建自定义菜单
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <returns></returns>
        public static string MenuCreate(string AccessToken, Menu menu)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", AccessToken);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "POST";
            string postData = menu.GetJson().ToString();
            byte[] data = Encoding.UTF8.GetBytes(postData);
            req.ContentLength = data.Length;
            using (Stream sw = req.GetRequestStream())
            {
                sw.Write(data, 0, data.Length);
                sw.Flush();
                using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
                {
                    if (resp.StatusCode == HttpStatusCode.OK)
                    {
                        using (StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                    else
                    {
                        return "接口调用异常";
                    }
                }
            }
        }
        public static string MenuGet()
        {
            return null;
        }
        public static string MenuDelete()
        {
            return null;
        }
    }
}
