using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moju.WeChatHelper;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
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
 }".Replace("\r\n", "").Replace("\t", "").Replace(" ", "").Replace("'", "\"");

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
        [TestMethod]
        public void Json2Menu()
        {
            string jsonData = @"
{
    'menu': {
        'button': [
            {
                'type': 'click',
                'name': '今日歌曲',
                'key': 'V1001_TODAY_MUSIC',
                'sub_button': []
            },
            {
                'type': 'click',
                'name': '歌手简介',
                'key': 'V1001_TODAY_SINGER',
                'sub_button': []
            },
            {
                'name': '菜单',
                'sub_button': [
                    {
                        'type': 'view',
                        'name': '搜索',
                        'url': 'http://www.soso.com/',
                        'sub_button': []
                    },
                    {
                        'type': 'view',
                        'name': '视频',
                        'url': 'http://v.qq.com/',
                        'sub_button': []
                    },
                    {
                        'type': 'click',
                        'name': '赞一下我们',
                        'key': 'V1001_GOOD',
                        'sub_button': []
                    }
                ]
            }
        ]
    }
}";
            JObject Jobj = JObject.Parse(jsonData);
            Menu menu = new Menu();
            menu.button = ((JArray)Jobj["menu"]["button"]).ToWeChatMenuButtonList().ToList();

            Assert.IsInstanceOfType(menu.button[0], typeof(ClickButton));
            Assert.IsInstanceOfType(menu.button[1], typeof(ClickButton));
            Assert.IsInstanceOfType(menu.button[2], typeof(HasSubButton));
            HasSubButton sub = (HasSubButton)menu.button[2];
            Assert.IsInstanceOfType(sub.SubButton[0], typeof(ViewButton));
            Assert.IsInstanceOfType(sub.SubButton[1], typeof(ViewButton));
            Assert.IsInstanceOfType(sub.SubButton[2], typeof(ClickButton));
        }
    }
}
