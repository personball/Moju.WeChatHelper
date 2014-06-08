using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Moju.WeChatHelper
{
    public class HasSubButton:Button
    {
        public List<Button> SubButton { get; set; }
        public override JObject GetJson()
        {
            return new JObject(
                new JProperty("name",Name),
                new JProperty("sub_button",
                    new JArray(
                        from sub in SubButton
                        select sub.GetJson()
                        )));
        }
    }
}
