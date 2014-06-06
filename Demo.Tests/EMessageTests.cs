using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moju.WeChatHelper;
using System.Xml.Linq;

namespace Demo.Tests
{
    [TestClass]
    public class EMessageTests
    {
        [TestMethod]
        public void Xml2ESubscribeMessage()
        {
            XDocument xml = XDocument.Parse(@"<xml>
<ToUserName><![CDATA[toUser]]></ToUserName>
<FromUserName><![CDATA[FromUser]]></FromUserName>
<CreateTime>123456789</CreateTime>
<MsgType><![CDATA[event]]></MsgType>
<Event><![CDATA[subscribe]]></Event>
</xml>");
            EMessage msg = EMessageFactory.CreateFromXml(xml);

            Assert.IsInstanceOfType(msg, typeof(ESubscribeMessage));
            ESubscribeMessage sub = (ESubscribeMessage)msg;

            Assert.AreEqual("toUser", sub.ToUserName);
            Assert.AreEqual("FromUser", sub.FromUserName);
            Assert.AreEqual(123456789, sub.CreateTime);
            Assert.AreEqual("event", sub.MsgType);
            Assert.AreEqual("subscribe", sub.Event);

        }
        [TestMethod]
        public void Xml2EUnSubscribeMessage()
        {
            XDocument xml = XDocument.Parse(@"<xml>
<ToUserName><![CDATA[toUser]]></ToUserName>
<FromUserName><![CDATA[FromUser]]></FromUserName>
<CreateTime>123456789</CreateTime>
<MsgType><![CDATA[event]]></MsgType>
<Event><![CDATA[unsubscribe]]></Event>
</xml>");
            EMessage msg = EMessageFactory.CreateFromXml(xml);

            Assert.IsInstanceOfType(msg, typeof(EUnSubscribeMessage));
            EUnSubscribeMessage unsub = (EUnSubscribeMessage)msg;

            Assert.AreEqual("toUser", unsub.ToUserName);
            Assert.AreEqual("FromUser", unsub.FromUserName);
            Assert.AreEqual(123456789, unsub.CreateTime);
            Assert.AreEqual("event", unsub.MsgType);
            Assert.AreEqual("unsubscribe", unsub.Event);

        }
        [TestMethod]
        public void Xml2EScanSubscribeMessage()
        {
            XDocument xml = XDocument.Parse(@"<xml>
<ToUserName><![CDATA[toUser]]></ToUserName>
<FromUserName><![CDATA[FromUser]]></FromUserName>
<CreateTime>123456789</CreateTime>
<MsgType><![CDATA[event]]></MsgType>
<Event><![CDATA[subscribe]]></Event>
<EventKey><![CDATA[qrscene_123123]]></EventKey>
<Ticket><![CDATA[TICKET]]></Ticket>
</xml>");
            EMessage msg = EMessageFactory.CreateFromXml(xml);

            Assert.IsInstanceOfType(msg, typeof(EScanSubscribeMessage));
            EScanSubscribeMessage scansub = (EScanSubscribeMessage)msg;

            Assert.AreEqual("toUser", scansub.ToUserName);
            Assert.AreEqual("FromUser", scansub.FromUserName);
            Assert.AreEqual(123456789, scansub.CreateTime);
            Assert.AreEqual("event", scansub.MsgType);
            Assert.AreEqual("subscribe", scansub.Event);
            Assert.AreEqual("qrscene_123123", scansub.EventKey);
            Assert.AreEqual("TICKET", scansub.Ticket);
        }
        [TestMethod]
        public void Xml2EScanMessage()
        {
            XDocument xml = XDocument.Parse(@"<xml>
<ToUserName><![CDATA[toUser]]></ToUserName>
<FromUserName><![CDATA[FromUser]]></FromUserName>
<CreateTime>123456789</CreateTime>
<MsgType><![CDATA[event]]></MsgType>
<Event><![CDATA[SCAN]]></Event>
<EventKey><![CDATA[SCENE_VALUE]]></EventKey>
<Ticket><![CDATA[TICKET]]></Ticket>
</xml>");
            EMessage msg = EMessageFactory.CreateFromXml(xml);

            Assert.IsInstanceOfType(msg, typeof(EScanMessage));
            EScanMessage scan = (EScanMessage)msg;

            Assert.AreEqual("toUser", scan.ToUserName);
            Assert.AreEqual("FromUser", scan.FromUserName);
            Assert.AreEqual(123456789, scan.CreateTime);
            Assert.AreEqual("event", scan.MsgType);
            Assert.AreEqual("SCAN", scan.Event);
            Assert.AreEqual("SCENE_VALUE", scan.EventKey);
            Assert.AreEqual("TICKET", scan.Ticket);
        }
        [TestMethod]
        public void Xml2ELocationMessage()
        {
            XDocument xml = XDocument.Parse(@"<xml>
<ToUserName><![CDATA[toUser]]></ToUserName>
<FromUserName><![CDATA[fromUser]]></FromUserName>
<CreateTime>123456789</CreateTime>
<MsgType><![CDATA[event]]></MsgType>
<Event><![CDATA[LOCATION]]></Event>
<Latitude>23.137466</Latitude>
<Longitude>113.352425</Longitude>
<Precision>119.385040</Precision>
</xml>");
            EMessage msg = EMessageFactory.CreateFromXml(xml);

            Assert.IsInstanceOfType(msg, typeof(ELocationMessage));
            ELocationMessage locate = (ELocationMessage)msg;

            Assert.AreEqual("toUser", locate.ToUserName);
            Assert.AreEqual("fromUser", locate.FromUserName);
            Assert.AreEqual(123456789, locate.CreateTime);
            Assert.AreEqual("event", locate.MsgType);
            Assert.AreEqual("LOCATION", locate.Event);
            Assert.AreEqual("23.137466", locate.Latitude);
            Assert.AreEqual("113.352425", locate.Longitude);
            Assert.AreEqual("119.385040", locate.Precision);
        }
        [TestMethod]
        public void Xml2EClickMessage()
        {
            XDocument xml = XDocument.Parse(@"<xml>
   <ToUserName><![CDATA[toUser]]></ToUserName>
   <FromUserName><![CDATA[FromUser]]></FromUserName>
   <CreateTime>123456789</CreateTime>
   <MsgType><![CDATA[event]]></MsgType>
   <Event><![CDATA[CLICK]]></Event>
   <EventKey><![CDATA[EVENTKEY]]></EventKey>
   </xml>");
            EMessage msg = EMessageFactory.CreateFromXml(xml);

            Assert.IsInstanceOfType(msg, typeof(EClickMessage));
            EClickMessage click = (EClickMessage)msg;

            Assert.AreEqual("toUser", click.ToUserName);
            Assert.AreEqual("FromUser", click.FromUserName);
            Assert.AreEqual(123456789, click.CreateTime);
            Assert.AreEqual("event", click.MsgType);
            Assert.AreEqual("CLICK", click.Event);
            Assert.AreEqual("EVENTKEY", click.EventKey);
        }
        [TestMethod]
        public void Xml2EViewMessage()
        {
            XDocument xml = XDocument.Parse(@"<xml>
<ToUserName><![CDATA[toUser]]></ToUserName>
<FromUserName><![CDATA[FromUser]]></FromUserName>
<CreateTime>123456789</CreateTime>
<MsgType><![CDATA[event]]></MsgType>
<Event><![CDATA[VIEW]]></Event>
<EventKey><![CDATA[www.qq.com]]></EventKey>
</xml>");
            EMessage msg = EMessageFactory.CreateFromXml(xml);

            Assert.IsInstanceOfType(msg, typeof(EViewMessage));
            EViewMessage view = (EViewMessage)msg;

            Assert.AreEqual("toUser", view.ToUserName);
            Assert.AreEqual("FromUser", view.FromUserName);
            Assert.AreEqual(123456789, view.CreateTime);
            Assert.AreEqual("event", view.MsgType);
            Assert.AreEqual("VIEW", view.Event);
            Assert.AreEqual("www.qq.com", view.EventKey);
        }
    }
}
