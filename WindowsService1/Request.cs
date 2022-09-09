using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    class Request
    {
        private string type;
        private string id;
        private DateTime rqTime;
        private List<Customer> customerList = new List<Customer>();
        public string Type 
        {
            get { return type; }
            set { type = value; }
        }

        public string Id
        { 
            get { return id; }
            set { id = value; }
        }
        
        public DateTime RqTime
        {
            get { return rqTime; }
            set { rqTime = value;}
        }

        public List<Customer> CustomerList
        { get { return customerList; } }

        public void AddCustomer(Customer customer)
        {
            customerList.Add(customer);
        }

        public Request(string type, string id, string rqTime)
        {
            this.type = type;
            this.id = id;
            this.rqTime = Convert.ToDateTime(rqTime);
        }

    }
}
