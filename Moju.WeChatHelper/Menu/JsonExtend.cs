using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
namespace Moju.WeChatHelper
{
    public static class JsonExtend
    {
        public static Button ToWeChatMenuButton(this JObject JObj)
        {
            if (JObj["type"] == null)
            {
                return new HasSubButton
                {
                    Name = JObj["name"].ToString(),
                    SubButton = ((JArray)JObj["sub_button"]).ToWeChatMenuButtonList().ToList()
                };
            }
            else
            {
                switch (JObj["type"].ToString())
                {
                    case "click":
                        {
                            return JObj.ToObject<ClickButton>();
                        }
                    case "view":
                        {
                            return JObj.ToObject<ViewButton>();
                        }
                    default:
                        {
                            return null;
                        }
                }
            }

        }
        public static IEnumerable<Button> ToWeChatMenuButtonList(this JArray JArr)
        {
            return from obj in JArr
                   select ((JObject)obj).ToWeChatMenuButton();
        }
    }
}
