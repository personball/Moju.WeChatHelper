using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Moju.WeChatHelper;
using System.Collections.Generic;
namespace Demo.Tests
{
    [TestClass]
    public class MenuTests
    {
        [TestMethod]
        public void CreateMenuIntoJson()
        {
            string except = @"{'button':[
     {	
          'type':'click',
          'name':'今日歌曲',
          'key':'V1001_TODAY_MUSIC'
      },
      {
           'type':'click',
           'name':'歌手简介',
           'key':'V1001_TODAY_SINGER'
      },
      {
           'name':'菜单',
           'sub_button':[
           {	
               'type':'view',
               'name':'搜索',
               'url':'http://www.soso.com/'
            },
            {
               'type':'view',
               'name':'视频',
               'url':'http://v.qq.com/'
            },
            {
               'type':'click',
               'name':'赞一下我们',
               'key':'V1001_GOOD'
            }]
       }]
 }".Replace("\r\n", "").Replace("\t", "").Replace(" ", "").Replace("'","\"");

            Menu menu = new Menu();
            menu.button = new List<Button>();
            menu.button.Add(new ClickButton { Key = "V1001_TODAY_MUSIC", Name = "今日歌曲" });
            menu.button.Add(new ClickButton { Key = "V1001_TODAY_SINGER", Name = "歌手简介" });
            HasSubButton sub = new HasSubButton();
            sub.Name = "菜单";
            sub.SubButton = new List<Button>();
            sub.SubButton.Add(new ViewButton { Name = "搜索", Url = "http://www.soso.com/" });
            sub.SubButton.Add(new ViewButton { Name = "视频", Url = "http://v.qq.com/" });
            sub.SubButton.Add(new ClickButton { Name = "赞一下我们", Key = "V1001_GOOD" });
            menu.button.Add(sub);

            string ret = menu.GetJson().ToString().Replace("\r\n", "").Replace("\t", "").Replace(" ", "");
            Assert.AreEqual(except, ret);
        }
    }
}
