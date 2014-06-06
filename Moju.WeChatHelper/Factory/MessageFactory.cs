using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Moju.WeChatHelper
{
    public class MessageFactory
    {
        public static Message CreateFromXml(XDocument xml)
        {
            string msg_type = xml.Root.Element("MsgType").Value;
            if (msg_type == MessageType.Event)
            {
                return EMessageFactory.CreateFromXml(xml);
            }
            else
            {
                return RMessageFactory.CreateFromXml(xml);
            }
        }
    }
}
