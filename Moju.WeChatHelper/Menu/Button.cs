using Newtonsoft.Json.Linq;
using System.Collections.Generic;
namespace Moju.WeChatHelper
{
    public abstract class Button
    {
        public string Name { get; set; }

        public virtual JObject GetJson()
        {
            return new JObject(
                new JProperty("name",Name));
        }
    }
}
