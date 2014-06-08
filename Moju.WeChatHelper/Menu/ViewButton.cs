using Newtonsoft.Json.Linq;
namespace Moju.WeChatHelper
{
    public class ViewButton : Button
    {
        private string Type { get; set; }
        public string Url { get; set; }
        public ViewButton()
        {
            this.Type = ButtonType.View;
        }
        public override JObject GetJson()
        {
            return new JObject(
                new JProperty("type",Type),
                new JProperty("name",Name),
                new JProperty("url",Url));
        }
    }
}
