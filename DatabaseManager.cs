using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RentalCompany
{
    public class DatabaseManager
    {

        public int InsertDataIntoProducts(string connectionString)
        {
            string productName, description,imageName;
            int categoryId;
            decimal price;
            Console.WriteLine("Insert Product Name ");
            productName = Console.ReadLine();

            Console.WriteLine("Insert category Id");
            categoryId = int.Parse(Console.ReadLine());

            Console.WriteLine("Insert Price");
            price = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Insert Description");
            description = Console.ReadLine();

            Console.WriteLine("Insert Image Name");
            imageName = Console.ReadLine();

            //define INSERT query with parameters
            string query = "INSERT INTO Products(Product_Name, Category_Id, Price, Description,Image_Name)"+
                "VALUES (@productName, @categoryId, @price, @description, @imageName)";

            // Create connection and command
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                //Define parameters and their values:
                cmd.Parameters.Add("@productName", SqlDbType.NChar, 30).Value = productName;
                cmd.Parameters.Add("@categoryId", SqlDbType.Int).Value = categoryId;
                cmd.Parameters.Add("@price", SqlDbType.Money).Value = price;
                cmd.Parameters.Add("@description", SqlDbType.NChar,100).Value = description;
                cmd.Parameters.Add("@imageName", SqlDbType.NChar,20).Value = imageName;

                //Open connection, Execute INSERT, Close connection
                cn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                cn.Close();

                return rowsAffected;
            }

        }
        public int InsertDataIntoCategories(string connectionString)
        {
            string categoryName;
            Console.WriteLine("Insert Category Name ");
            categoryName = Console.ReadLine();

          
            //define INSERT query with parameters
            string query = "INSERT INTO Categories(Category_Name)" +
                "VALUES (@categoryName)";

            // Create connection and command
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                //Define parameters and their values:
                cmd.Parameters.Add("@categoryName", SqlDbType.NChar, 20).Value = categoryName;
                

                //Open connection, Execute INSERT, Close connection
                cn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                cn.Close();

                return rowsAffected;
            }

        }
        internal void readDataFromProducts(string connectionString)
        {
            string queryString = "select * from Products";
            using(SqlConnection connection = 
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                            reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                    }
                    reader.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }

        }

        internal void readDataFromCategories(string connectionString)
        {
            string queryString = "select * from Categories";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}",
                            reader[0], reader[1]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }

        }













    }
}
