using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace WindowsService1
{
    class DbConnection
    {
        string _connectionString = "Data Source = F:\\Temp\\clinic.db";
        string insertCustomer = "INSERT INTO Customer (id, f, i, o) VALUES (@id, @f, @i, @o)";
        string insertAnimal = "INSERT INTO Animal (id, customerId, type, Name, BirthDate) " +
"                               VALUES (@id, @customerId, @type, @Name, @BirthDate)";
        string updateCustomer;
        string updateAnimal;
        string countCustomer = "SELECT COUNT(*) FROM [Customer] WHERE Id = @Id";


        public DbConnection(){
            
        }

        public int AddRequest(Request request) 
        {
            int returnValue;

            try
            {
                      
                    foreach (Customer customer in request.CustomerList)
                    {
                        
                        AddCustomer(customer);

                        foreach (Animal animal in customer.AnimalList)
                        {
                            AddAnimal(animal);
                        }
                    }

                
                returnValue = 1;
            }
            catch (SqliteException ex)
            {
                throw new SqliteException(ex.Message, ex.SqliteErrorCode, ex.SqliteExtendedErrorCode);
            }

            return returnValue;
        }

        private void AddCustomer(Customer customer)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                SqliteCommand addCustomer = new SqliteCommand(insertCustomer, connection);
                SqliteParameter customerIdParam = new SqliteParameter("@id", customer.Id);
                SqliteParameter customerFParam = new SqliteParameter("@f", customer.F);
                SqliteParameter customerIParam = new SqliteParameter("@i", customer.I);
                SqliteParameter customerOParam = new SqliteParameter("@o", customer.O);
                addCustomer.Parameters.Add(customerIdParam);
                addCustomer.Parameters.Add(customerFParam);
                addCustomer.Parameters.Add(customerIParam);
                addCustomer.Parameters.Add(customerOParam);
                addCustomer.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void AddAnimal(Animal animal)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                SqliteCommand addAnimal = new SqliteCommand(insertAnimal, connection);
                SqliteParameter animalIdParam = new SqliteParameter("@id", animal.Id);
                SqliteParameter animalCustomerId = new SqliteParameter("@customerId", customer.Id);
                SqliteParameter animalType = new SqliteParameter("@type", animal.Type);
                SqliteParameter animalNameParam = new SqliteParameter("@Name", animal.Name);
                SqliteParameter animalBirthDate = new SqliteParameter("@BirthDate", animal.BirthDate);
                addAnimal.Parameters.Add(animalIdParam);
                addAnimal.Parameters.Add(animalCustomerId);
                addAnimal.Parameters.Add(animalType);
                addAnimal.Parameters.Add(animalNameParam);
                addAnimal.Parameters.Add(animalBirthDate);
                addAnimal.ExecuteNonQuery();
                connection.Close();
            }
        }

        private bool CustomerExists (Customer customer)
        {
            using(SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                SqliteCommand checkCustomer = new SqliteCommand(countCustomer, connection);
                
            }
    }   
}
