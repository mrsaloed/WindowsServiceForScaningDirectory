using System;

namespace WindowsService1
{
    class Animal
    {
        private int id;
        private string type;
        private string name;
        private DateTime birthDate;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Type
        {
           get { return type; }
           set
            {
                type = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                birthDate = value;
            }
        }

        public Animal(string id, string type, string name, string birthDate)
        {
            this.id = Convert.ToInt32(id);
            this.type = type;
            this.name = name;
            this.birthDate = Convert.ToDateTime(birthDate);
        }
    }
}
