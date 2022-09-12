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
        private readonly string _connectionString = "Data Source = F:\\Temp\\clinic.db";

        private readonly string insertCustomer = "INSERT INTO " +
                                                 "Customer (id, f, i, o) " +
                                                 "VALUES (@id, @f, @i, @o)";
        private readonly string insertAnimal = "INSERT INTO Animal (id, customerId, type, Name, BirthDate) " +
                                               "VALUES (@id, @customerId, @type, @Name, @BirthDate)";
        private readonly string updateCustomerString = "UPDATE Customer " +
                                                       "SET f=@f, i=@i, o=@o " +
                                                       "WHERE id=@id";
        private readonly string updateAnimalString = "UPDATE Animal " +
                                                     "SET customerId=@customerId, type=@type, Name=@Name, BirthDate=@BirthDate " +
                                                     "WHERE id=@id";
        private readonly string countCustomer = "SELECT COUNT(*) " +
                                                "FROM [Customer] " +
                                                "WHERE id = @id";
        private readonly string countAnimal = "SELECT COUNT(*) " +
                                              "FROM [Animal] " +
                                              "WHERE id = @id";


        public DbConnection()
        {

        }

        public void AddRequest(Request request)
        {

            try
            {
                using (SqliteConnection connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();

                    foreach (Customer customer in request.CustomerList)
                    {
                        SqliteCommand checkCustomer = new SqliteCommand(countCustomer, connection);
                        SqliteParameter customerIdParam = new SqliteParameter("@id", customer.Id);
                        SqliteParameter customerFParam = new SqliteParameter("@f", customer.F);
                        SqliteParameter customerIParam = new SqliteParameter("@i", customer.I);
                        SqliteParameter customerOParam = new SqliteParameter("@o", customer.O);
                        checkCustomer.Parameters.Add(customerIdParam);
                        object transactionResult = checkCustomer.ExecuteScalar();
                        if (Convert.ToInt32(transactionResult) == 0)
                        {
                            SqliteCommand addCustomer = new SqliteCommand(insertCustomer, connection);
                            addCustomer.Parameters.Add(customerIdParam);
                            addCustomer.Parameters.Add(customerFParam);
                            addCustomer.Parameters.Add(customerIParam);
                            addCustomer.Parameters.Add(customerOParam);
                            addCustomer.ExecuteNonQuery();
                        }
                        else
                        {
                            SqliteCommand updateCustomer = new SqliteCommand(updateCustomerString, connection);
                            updateCustomer.Parameters.Add(customerIdParam);
                            updateCustomer.Parameters.Add(customerFParam);
                            updateCustomer.Parameters.Add(customerIParam);
                            updateCustomer.Parameters.Add(customerOParam);
                            updateCustomer.ExecuteNonQuery();
                        }

                        foreach (Animal animal in customer.AnimalList)
                        {
                            SqliteCommand checkAnimal = new SqliteCommand(countAnimal, connection);
                            SqliteParameter animalIdParam = new SqliteParameter("@id", animal.Id);
                            SqliteParameter animalCustomerId = new SqliteParameter("@customerId", customer.Id);
                            SqliteParameter animalType = new SqliteParameter("@type", animal.Type);
                            SqliteParameter animalNameParam = new SqliteParameter("@Name", animal.Name);
                            SqliteParameter animalBirthDate = new SqliteParameter("@BirthDate", animal.BirthDate);
                            checkAnimal.Parameters.Add(animalIdParam);
                            transactionResult = checkAnimal.ExecuteScalar();
                            if(Convert.ToInt32(transactionResult) == 0 )
                            {
                                SqliteCommand addAnimal = new SqliteCommand(insertAnimal, connection);
                                addAnimal.Parameters.Add(animalIdParam);
                                addAnimal.Parameters.Add(animalCustomerId);
                                addAnimal.Parameters.Add(animalType);
                                addAnimal.Parameters.Add(animalNameParam);
                                addAnimal.Parameters.Add(animalBirthDate);
                                addAnimal.ExecuteNonQuery();
                            }
                            else
                            {
                                SqliteCommand updateAnimal = new SqliteCommand(updateAnimalString, connection);
                                updateAnimal.Parameters.Add(animalIdParam);
                                updateAnimal.Parameters.Add(animalCustomerId);
                                updateAnimal.Parameters.Add(animalType);
                                updateAnimal.Parameters.Add(animalNameParam);
                                updateAnimal.Parameters.Add(animalBirthDate);
                                updateAnimal.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (SqliteException ex)
            {
                throw new SqliteException(ex.Message, ex.SqliteErrorCode, ex.SqliteExtendedErrorCode);
            }
        }
    }
}
