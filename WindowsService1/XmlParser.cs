using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WindowsService1
{
    class XmlParser
    {
        XDocument xdoc;
        XmlParser(string file) 
        {
            xdoc = XDocument.Load(file);
        }

        public Request ParseRequest()
        {
            Request request = null;
            XElement requestElement = xdoc.Element("request");
            if (requestElement != null) 
            {
                XAttribute type = requestElement.Attribute("type");
                XAttribute id = requestElement.Attribute("id");
                XAttribute rqTime = requestElement.Attribute("rq-time");
                request = new Request(type.Value, id.Value, rqTime.Value);
                
            }
            
            return request;
        }
    }
}
