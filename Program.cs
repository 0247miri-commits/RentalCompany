using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RentalCompany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
                "Data Source=DESKTOP-4G5A9E;Initial Catalog=Rental Company;Integrated Security=True;TrustServerCertificate=True;"; DatabaseManager databaseManager = new DatabaseManager();
            databaseManager.InsertDataIntoProducts(connectionString);
            databaseManager.readDataFromProducts(connectionString);

            databaseManager.InsertDataIntoCategories(connectionString);
            databaseManager.readDataFromCategories(connectionString);

        }
    }
}
