using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moju.WeChatHelper;
using System.Xml.Linq;

namespace Demo.Tests
{
    [TestClass]
    public class RMessageTests
    {
        [TestMethod]
        public void Xml2RTextMessage()
        {
            XDocument xml = XDocument.Parse(@"<xml>
 <ToUserName><![CDATA[toUser]]></ToUserName>
 <FromUserName><![CDATA[fromUser]]></FromUserName> 
 <CreateTime>1348831860</CreateTime>
 <MsgType><![CDATA[text]]></MsgType>
 <Content><![CDATA[this is a test]]></Content>
 <MsgId>1234567890123456</MsgId>
 </xml>");
            RMessage msg = RMessageFactory.CreateFromXml(xml);

            Assert.IsInstanceOfType(msg, typeof(RTextMessage));
            RTextMessage text = (RTextMessage)msg;
            Assert.AreEqual("toUser", text.ToUserName);
            Assert.AreEqual("fromUser", text.FromUserName);
            Assert.AreEqual(1348831860, text.CreateTime);
            Assert.AreEqual("text", text.MsgType);
            Assert.AreEqual("this is a test", text.Content);
            Assert.AreEqual("1234567890123456", text.MsgId);
        }
        [TestMethod]
        public void Xml2RImageMessage()
        {
            XDocument xml = XDocument.Parse(@"<xml>
 <ToUserName><![CDATA[toUser]]></ToUserName>
 <FromUserName><![CDATA[fromUser]]></FromUserName>
 <CreateTime>1348831860</CreateTime>
 <MsgType><![CDATA[image]]></MsgType>
 <PicUrl><![CDATA[this is a url]]></PicUrl>
 <MediaId><![CDATA[media_id]]></MediaId>
 <MsgId>1234567890123456</MsgId>
 </xml>");
            RMessage msg = RMessageFactory.CreateFromXml(xml);

            Assert.IsInstanceOfType(msg, typeof(RImageMessage));
            RImageMessage img = (RImageMessage)msg;
            Assert.AreEqual("toUser", img.ToUserName);
            Assert.AreEqual("fromUser", img.FromUserName);
            Assert.AreEqual(1348831860, img.CreateTime);
            Assert.AreEqual("image", img.MsgType);

            Assert.AreEqual("this is a url", img.PicUrl);
            Assert.AreEqual("media_id", img.MediaId);

            Assert.AreEqual("1234567890123456", img.MsgId);
        }
        [TestMethod]
        public void Xml2RVoiceMessage()
        {
            XDocument xml = XDocument.Parse(@"<xml>
<ToUserName><![CDATA[toUser]]></ToUserName>
<FromUserName><![CDATA[fromUser]]></FromUserName>
<CreateTime>1357290913</CreateTime>
<MsgType><![CDATA[voice]]></MsgType>
<MediaId><![CDATA[media_id]]></MediaId>
<Format><![CDATA[Format]]></Format>
<MsgId>1234567890123456</MsgId>
</xml>");
            RMessage msg = RMessageFactory.CreateFromXml(xml);

            Assert.IsInstanceOfType(msg, typeof(RVoiceMessage));
            RVoiceMessage img = (RVoiceMessage)msg;
            Assert.AreEqual("toUser", img.ToUserName);
            Assert.AreEqual("fromUser", img.FromUserName);
            Assert.AreEqual(1357290913, img.CreateTime);
            Assert.AreEqual("voice", img.MsgType);

            Assert.AreEqual("media_id", img.MediaId);
            Assert.AreEqual("Format", img.Format);

            Assert.AreEqual("1234567890123456", img.MsgId);
        }
        [TestMethod]
        public void Xml2RVideoMessage()
        {
            XDocument xml = XDocument.Parse(@"<xml>
<ToUserName><![CDATA[toUser]]></ToUserName>
<FromUserName><![CDATA[fromUser]]></FromUserName>
<CreateTime>1357290913</CreateTime>
<MsgType><![CDATA[video]]></MsgType>
<MediaId><![CDATA[media_id]]></MediaId>
<ThumbMediaId><![CDATA[thumb_media_id]]></ThumbMediaId>
<MsgId>1234567890123456</MsgId>
</xml>");
            RMessage msg = RMessageFactory.CreateFromXml(xml);

            Assert.IsInstanceOfType(msg, typeof(RVideoMessage));
            RVideoMessage img = (RVideoMessage)msg;
            Assert.AreEqual("toUser", img.ToUserName);
            Assert.AreEqual("fromUser", img.FromUserName);
            Assert.AreEqual(1357290913, img.CreateTime);
            Assert.AreEqual("video", img.MsgType);

            Assert.AreEqual("media_id", img.MediaId);
            Assert.AreEqual("thumb_media_id", img.ThumbMediaId);

            Assert.AreEqual("1234567890123456", img.MsgId);
        }
        [TestMethod]
        public void Xml2RLocationMessage()
        {
            XDocument xml = XDocument.Parse(@"<xml>
<ToUserName><![CDATA[toUser]]></ToUserName>
<FromUserName><![CDATA[fromUser]]></FromUserName>
<CreateTime>1351776360</CreateTime>
<MsgType><![CDATA[location]]></MsgType>
<Location_X>23.134521</Location_X>
<Location_Y>113.358803</Location_Y>
<Scale>20</Scale>
<Label><![CDATA[位置信息]]></Label>
<MsgId>1234567890123456</MsgId>
</xml>");
            RMessage msg = RMessageFactory.CreateFromXml(xml);

            Assert.IsInstanceOfType(msg, typeof(RLocationMessage));
            RLocationMessage img = (RLocationMessage)msg;
            Assert.AreEqual("toUser", img.ToUserName);
            Assert.AreEqual("fromUser", img.FromUserName);
            Assert.AreEqual(1351776360, img.CreateTime);
            Assert.AreEqual("location", img.MsgType);

            Assert.AreEqual("23.134521", img.Location_X);
            Assert.AreEqual("113.358803", img.Location_Y);
            Assert.AreEqual(20, img.Scale);
            Assert.AreEqual("位置信息", img.Label);

            Assert.AreEqual("1234567890123456", img.MsgId);
        }
        [TestMethod]
        public void Xml2RLinkMessage()
        {
            XDocument xml = XDocument.Parse(@"<xml>
           <ToUserName><![CDATA[toUser]]></ToUserName>
           <FromUserName><![CDATA[fromUser]]></FromUserName>
           <CreateTime>1351776360</CreateTime>
           <MsgType><![CDATA[link]]></MsgType>
           <Title><![CDATA[公众平台官网链接]]></Title>
           <Description><![CDATA[公众平台官网链接]]></Description>
           <Url><![CDATA[url]]></Url>
           <MsgId>1234567890123456</MsgId>
           </xml>");
            RMessage msg = RMessageFactory.CreateFromXml(xml);

            Assert.IsInstanceOfType(msg, typeof(RLinkMessage));
            RLinkMessage img = (RLinkMessage)msg;
            Assert.AreEqual("toUser", img.ToUserName);
            Assert.AreEqual("fromUser", img.FromUserName);
            Assert.AreEqual(1351776360, img.CreateTime);
            Assert.AreEqual("link", img.MsgType);

            Assert.AreEqual("公众平台官网链接", img.Title);
            Assert.AreEqual("公众平台官网链接", img.Description);
            Assert.AreEqual("url", img.Url);

            Assert.AreEqual("1234567890123456", img.MsgId);
        }
    }
}
