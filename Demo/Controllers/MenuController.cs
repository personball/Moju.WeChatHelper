using Demo.Models;
using Moju.WeChatHelper;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class MenuController : Controller
    {
        public ActionResult Set()
        {
            string token = Tools.GetToken();

            Menu menu = new Menu();
            menu.button = new List<Button>();
            menu.button.Add(new ClickButton { Key = "K001", Name = "测试菜单1" });
            menu.button.Add(new ClickButton { Key = "K002", Name = "测试菜单2" });
            menu.button.Add(new ClickButton { Key = "K003", Name = "测试菜单3" });

            string res = MenuHelper.Create(token, menu);
            return Content("done:" + res);
        }

        public ActionResult Get()
        {
            string token = Tools.GetToken();
            string res = MenuHelper.Get(token);
            Menu menu = new Menu();
            if (res != "error")
            {
                JObject Jobj = JObject.Parse(res);
                menu.button = ((JArray)Jobj["menu"]["button"]).ToWeChatMenuButtonList().ToList();
            }
            return Content(res + "<br/>" + menu.GetJson().ToString());
        }
        public ActionResult Del()
        {
            string token = Tools.GetToken();
            string res = MenuHelper.Delete(token);
            return Content(res);
        }
    }
}
