using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Moju.WeChatHelper
{
    public class Utils
    {
        public static bool WeChatRequestVerify(string Token, string timestamp, string nonce, string signature)
        {
            if (string.IsNullOrWhiteSpace(Token)
                || string.IsNullOrWhiteSpace(timestamp)
                || string.IsNullOrWhiteSpace(nonce)
                || string.IsNullOrWhiteSpace(signature))
            {
                return false;//参数不可为空
            }

            SortedSet<string> tmp = new SortedSet<string>();
            tmp.Add(Token);
            tmp.Add(timestamp);
            tmp.Add(nonce);
            string str = string.Join("", tmp);
            string hashRes = FormsAuthentication.HashPasswordForStoringInConfigFile(str, "SHA1").ToLower();
            if (!string.IsNullOrWhiteSpace(hashRes) && signature == hashRes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 泛型方法，处理xml反序列化为RMessage子类实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T Xml2Obj<T>(XDocument xml) where T : Message
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader sr = new StringReader(xml.ToString(SaveOptions.DisableFormatting)))
            {
                return (T)serializer.Deserialize(sr);
            }
        }

        /// <summary>
        /// 发送一个GET请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string RequestGet(string url)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "GET";
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
                    return "error";
                }
            }
        }
        /// <summary>
        /// 发送一个POST请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static string RequestPost(string url, string postData)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "POST";
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
                        return "error";
                    }
                }
            }
        }

    }
}
