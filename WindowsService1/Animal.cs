using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    class Animal
    {
        private int id { get; set; }
        private string type { get; set; }
        private string name { get; set; }
        private DateTime birthDate { get; set; }

        public Animal(int id, string type, string name, DateTime birthDate)
        {
            this.id = id;
            this.type = type;
            this.name = name;
            this.birthDate = birthDate;
        }
    }
}
