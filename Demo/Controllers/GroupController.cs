using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moju.WeChatHelper;
using Demo.Models;
namespace Demo.Controllers
{
    public class GroupController : Controller
    {
        public ActionResult Create(string name)
        {
            string token = Tools.GetToken();
            return Content(GroupHelper.Create(token, name).ToString());
        }

        public ActionResult Get()
        {
            string token = Tools.GetToken();
            List<Group> list = GroupHelper.Get(token).ToList();
            string res = string.Join("<br/>",
                (from l in list
                 select (l.ID + "|" + l.Name + "|" + l.Count)).ToArray<string>());
            return Content(res);
        }
        public ActionResult GetGroupID(string OpenID)
        {
            string token = Tools.GetToken();
            int gid = GroupHelper.GetGroupID(token, OpenID);
            return Content(gid.ToString());
        }
        public ActionResult Update(int ID,string GroupName)
        {
            string token = Tools.GetToken();
            bool x= GroupHelper.Update(token, ID, GroupName);
            return Content(x.ToString());
        }
        public ActionResult MUpdate(string OpenID, int ToGroupID)
        {
            string token = Tools.GetToken();
            bool x = GroupHelper.MemberUpdate(token,OpenID,ToGroupID);
            return Content(x.ToString());
        }
    }
}
