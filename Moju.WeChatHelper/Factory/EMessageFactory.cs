using System.Xml.Linq;

namespace Moju.WeChatHelper
{
    public class EMessageFactory
    {
        public static EMessage CreateFromXml(XDocument xml)
        {
            string msg_type = xml.Root.Element("MsgType").Value;
            if (msg_type == MessageType.Event)
            {
                string _event = xml.Root.Element("Event").Value;
                switch (_event)
                {
                    case EventType.CLICK: return Utils.Xml2Obj<EClickMessage>(xml);
                    case EventType.LOCATION: return Utils.Xml2Obj<ELocationMessage>(xml);
                    case EventType.SCAN: return Utils.Xml2Obj<EScanMessage>(xml);
                    case EventType.Subscribe:
                        {
                            if (xml.Root.Element("EventKey") != null)
                            {
                                return Utils.Xml2Obj<EScanSubscribeMessage>(xml);
                            }
                            else
                            {
                                return Utils.Xml2Obj<ESubscribeMessage>(xml);
                            }
                        }
                    case EventType.UnSubscribe: return Utils.Xml2Obj<EUnSubscribeMessage>(xml);
                    case EventType.VIEW: return Utils.Xml2Obj<EViewMessage>(xml);
                    default: return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
