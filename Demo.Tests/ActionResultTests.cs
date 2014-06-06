using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moju.WeChatHelper;
using System.Collections.Generic;

namespace Demo.Tests
{
    [TestClass]
    public class ActionResultTests
    {
        /// <summary>
        /// 文本消息测试
        /// </summary>
        [TestMethod]
        public void ResponseWeChatTextResult()
        {
            string except = @"<xml><ToUserName><![CDATA[toUser]]></ToUserName><FromUserName><![CDATA[fromUser]]></FromUserName><CreateTime>12345678</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[你好]]></Content></xml>";
            WeChatTextResult res = new WeChatTextResult
            {
                Content = "你好",
                CreateTime = new DateTime(12345678),
                FromUserName = "fromUser",
                ToUserName = "toUser"
            };
            Assert.AreEqual(except, res.GetXml());
        }
        [TestMethod]
        public void ResponseWeChatImageResult()
        {
            string except = @"<xml><ToUserName><![CDATA[toUser]]></ToUserName><FromUserName><![CDATA[fromUser]]></FromUserName><CreateTime>12345678</CreateTime><MsgType><![CDATA[image]]></MsgType><Image><MediaId><![CDATA[media_id]]></MediaId></Image></xml>";
            WeChatImageResult res = new WeChatImageResult
            {
                CreateTime = new DateTime(12345678),
                FromUserName = "fromUser",
                ToUserName = "toUser",
                MediaId = "media_id"
            };
            Assert.AreEqual(except, res.GetXml());
        }
        [TestMethod]
        public void ResponseWeChatVoiceResult()
        {
            string except = @"<xml><ToUserName><![CDATA[toUser]]></ToUserName><FromUserName><![CDATA[fromUser]]></FromUserName><CreateTime>12345678</CreateTime><MsgType><![CDATA[voice]]></MsgType><Voice><MediaId><![CDATA[media_id]]></MediaId></Voice></xml>";
            WeChatVoiceResult res = new WeChatVoiceResult
            {
                CreateTime = new DateTime(12345678),
                FromUserName = "fromUser",
                ToUserName = "toUser",
                MediaId = "media_id"
            };
            Assert.AreEqual(except, res.GetXml());
        }
        [TestMethod]
        public void ResponseWeChatVideoResult()
        {
            string except = @"<xml><ToUserName><![CDATA[toUser]]></ToUserName><FromUserName><![CDATA[fromUser]]></FromUserName><CreateTime>12345678</CreateTime><MsgType><![CDATA[video]]></MsgType><Video><MediaId><![CDATA[media_id]]></MediaId><Title><![CDATA[title]]></Title><Description><![CDATA[description]]></Description></Video></xml>";
            WeChatVideoResult res = new WeChatVideoResult
            {
                CreateTime = new DateTime(12345678),
                FromUserName = "fromUser",
                ToUserName = "toUser",
                MediaId = "media_id",
                Description = "description",
                Title = "title"
            };
            Assert.AreEqual(except, res.GetXml());
        }
        [TestMethod]
        public void ResponseWeChatMusicResult()
        {
            string except = @"<xml><ToUserName><![CDATA[toUser]]></ToUserName><FromUserName><![CDATA[fromUser]]></FromUserName><CreateTime>12345678</CreateTime><MsgType><![CDATA[music]]></MsgType><Music><Title><![CDATA[TITLE]]></Title><Description><![CDATA[DESCRIPTION]]></Description><MusicUrl><![CDATA[MUSIC_Url]]></MusicUrl><HQMusicUrl><![CDATA[HQ_MUSIC_Url]]></HQMusicUrl><ThumbMediaId><![CDATA[media_id]]></ThumbMediaId></Music></xml>";
            WeChatMusicResult res = new WeChatMusicResult
            {
                CreateTime = new DateTime(12345678),
                FromUserName = "fromUser",
                ToUserName = "toUser",
                Description = "DESCRIPTION",
                HQMusicUrl = "HQ_MUSIC_Url",
                MusicUrl = "MUSIC_Url",
                ThumbMediaId = "media_id",
                Title = "TITLE"
            };
            Assert.AreEqual(except, res.GetXml());
        }
        [TestMethod]
        public void ResponseWeChatNewsResult()
        {
            string except = @"<xml><ToUserName><![CDATA[toUser]]></ToUserName><FromUserName><![CDATA[fromUser]]></FromUserName><CreateTime>12345678</CreateTime><MsgType><![CDATA[news]]></MsgType><ArticleCount>2</ArticleCount><Articles><item><Title><![CDATA[title1]]></Title><Description><![CDATA[description1]]></Description><PicUrl><![CDATA[picurl]]></PicUrl><Url><![CDATA[url]]></Url></item><item><Title><![CDATA[title]]></Title><Description><![CDATA[description]]></Description><PicUrl><![CDATA[picurl]]></PicUrl><Url><![CDATA[url]]></Url></item></Articles></xml>";
            WeChatNewsResult res = new WeChatNewsResult
            {
                CreateTime = new DateTime(12345678),
                FromUserName = "fromUser",
                ToUserName = "toUser",
            };
            res.Articles = new List<Article>
            {
                new Article{ Title="title1", Description="description1", PicUrl="picurl", Url="url" },
                new Article{ Title="title", Description="description", PicUrl="picurl", Url="url"}
            };
            Assert.AreEqual(except, res.GetXml());
        }
    }
}
