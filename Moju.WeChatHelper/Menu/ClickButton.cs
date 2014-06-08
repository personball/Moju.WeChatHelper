
using Newtonsoft.Json.Linq;
namespace Moju.WeChatHelper
{
    public class ClickButton:Button
    {
        private string Type { get; set; }
        public string Key { get; set; }
        public ClickButton()
        {
            this.Type = ButtonType.Click;
        }
        public override JObject GetJson()
        {
            return new JObject(
                new JProperty("type",Type),
                new JProperty("name",Name),
                new JProperty("key",Key));
        }
    }
}
