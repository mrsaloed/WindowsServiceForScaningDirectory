using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    class Customer
    {
        private int id { get; set; }
        //фамилия
        private string f { get; set; }
        //имя
        private string i { get; set; }
        //отчество
        private string o { get; set; }
        
        private List<Animal> animals { get; set; }

        public Customer(int id, string f, string i, string o)
        {
            this.id = id;
            this.f = f;
            this.i = i;
            this.o = o;
        }

        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
        }
    }
}
