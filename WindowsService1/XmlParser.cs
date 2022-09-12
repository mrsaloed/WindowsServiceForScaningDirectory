using System.Xml.Linq;

namespace WindowsService1
{
    class XmlParser
    {
        string filePath;
        public XmlParser(string file) 
        {
            this.filePath = file;
        }

        public Request ParseRequest()
        {
            XDocument xdoc = XDocument.Load(filePath);
            Request request = null;
            XElement requestElement = xdoc.Element("request");
            if (requestElement != null) 
            {
                XAttribute requstType = requestElement.Attribute("type");
                XAttribute requestId = requestElement.Attribute("id");
                XAttribute rqTime = requestElement.Attribute("rq-time");
                request = new Request(requstType.Value, requestId.Value, rqTime.Value);
                foreach (XElement customerElement in requestElement.Elements("customer"))
                {
                    XAttribute customerId = customerElement.Attribute("id");
                    XAttribute f = customerElement.Attribute("f");
                    XAttribute i = customerElement.Attribute("i");
                    XAttribute o = customerElement.Attribute("o");
                    Customer customer = new Customer(customerId.Value, f.Value, i.Value, o.Value);
                    
                    foreach (XElement animalElement in customerElement.Elements("animal"))
                    {
                        XAttribute animalId = animalElement.Attribute("id");
                        XAttribute animalType = animalElement.Attribute("type");
                        XAttribute name = animalElement.Attribute("Name");
                        XAttribute birthDate = animalElement.Attribute("BithDate");
                        customer.AddAnimal(new Animal(animalId.Value, animalType.Value, name.Value, birthDate.Value));
                    }

                    request.AddCustomer(customer);
                    
                }
            }
            
            return request;
        }
    }
}
