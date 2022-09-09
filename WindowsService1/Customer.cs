using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    class Customer
    {
        private int id;
        //фамилия
        private string f;
        //имя
        private string i;
        //отчество
        private string o;
        private List<Animal> animals = new List<Animal>();

        public int Id
        { 
            get { return id; } 
            set { id = value; } 
        }
        public string F 
        {
            get { return f; }
            set { f = value; } 
        }
        public string I 
        { 
            get { return i; } 
            set { i = value; } 
        }
        public string O 
        { 
            get { return o; } 
            set { o = value; } 
        }
        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
        }

        public List<Animal> AnimalList
        { get { return animals; } }

        public Customer(string id, string f, string i, string o)
        {
            this.id = Convert.ToInt32(id); ;
            this.f = f;
            this.i = i;
            this.o = o;
        }

        
    }
}
