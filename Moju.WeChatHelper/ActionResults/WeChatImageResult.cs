using System.Xml.Linq;

namespace Moju.WeChatHelper
{
   public class WeChatImageResult:WeChatResult
    {
       public string MediaId { get; set; }
       public WeChatImageResult()
       {
           this.MsgType = SMessageType.Image;
       }
       protected override void SubXml(XElement xml)
       {
           xml.Add(new XElement("Image", 
               new XElement("MediaId", 
                   new XCData(MediaId))));
       }
    }
}
