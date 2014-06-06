using System.Collections.Generic;
using System.IO;
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
            string hashRes = SHA1(str);
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
        /// SHA1加密
        /// </summary>
        private static string SHA1(string ToEncrypt)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(ToEncrypt, "SHA1").ToLower();
            // 
            /*
             *  var sha1 = new SHA1CryptoServiceProvider();
            return BitConverter.ToString(sha1.ComputeHash(Encoding.Default.GetBytes(result))).Replace("-", "").ToLower();
             */
            //byte[] StrRes = Encoding.Default.GetBytes(ToEncrypt);
            //HashAlgorithm iSHA = new SHA1CryptoServiceProvider();
            //StrRes = iSHA.ComputeHash(StrRes);
            //StringBuilder EnText = new StringBuilder();
            //foreach (byte iByte in StrRes)
            //{
            //    EnText.AppendFormat("{0:x2}", iByte);
            //}
            //return EnText.ToString();
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
    }
}
