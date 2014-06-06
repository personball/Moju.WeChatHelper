using System.Xml.Linq;
namespace Moju.WeChatHelper
{
    public class RMessageFactory
    {
        public static RMessage CreateFromXml(XDocument xml)
        {
            string msg_type = xml.Root.Element("MsgType").Value;
            switch (msg_type)
            {
                case MessageType.Text: return Utils.Xml2Obj<RTextMessage>(xml);
                case MessageType.Image: return Utils.Xml2Obj<RImageMessage>(xml);
                case MessageType.Voice: return Utils.Xml2Obj<RVoiceMessage>(xml);
                case MessageType.Video: return Utils.Xml2Obj<RVideoMessage>(xml);
                case MessageType.Location: return Utils.Xml2Obj<RLocationMessage>(xml);
                case MessageType.Link: return Utils.Xml2Obj<RLinkMessage>(xml);
                default: return null;
            }
        }
       
    }
}
