using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
namespace Moju.WeChatHelper
{
    public class Menu
    {
        public List<Button> button { get; set; }
        public JObject GetJson()
        {
            if (button!=null&&button.Count>0)
            {
                return new JObject(
                    new JProperty("button",
                        new JArray(
                            from b in button
                            select b.GetJson()
                            )));
            }
            else
            {
                return new JObject();
            }
        }
    }
}
