using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    class Request
    {
        private string type { get; set; }
        private string id { get; set; }
        private DateTime rqTime { get; set; }

        private List<Customer> customerList { get; set; }

        public Request(string type, string id, string rqTime)
        {
            this.type = type;
            this.id = id;
            this.rqTime = Convert.ToDateTime(rqTime);
        }

        public void AddCustomer(Customer customer)
        {
            customerList.Add(customer); 
        }
    }
}
