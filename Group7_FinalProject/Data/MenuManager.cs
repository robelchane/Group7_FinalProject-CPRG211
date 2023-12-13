using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group7_FinalProject.Data
{
    public class MenuManager
    {

        public static List<Food> food = new List<Food>();

        public static List<Food> GetMenu()
        {
            return food;
        }
        public MenuManager()
        {
            GetDataFromDB();
        }

        public static void GetDataFromDB()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FinalProject_DB_Group7;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            string sql = "Select * from MenuItem";
            using (SqlCommand command = new(sql, sqlConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.GetValue(0).ToString().StartsWith("1"))
                        {
                            food.Add(new Pizza(int.Parse(reader.GetValue(0).ToString()), reader.GetString(1), int.Parse(reader.GetValue(2).ToString()), reader.GetString(4)));
                        }
                        else if (reader.GetValue(0).ToString().StartsWith("2"))
                        {
                            food.Add(new Drink(int.Parse(reader.GetValue(0).ToString()), reader.GetString(1), int.Parse(reader.GetValue(2).ToString()), reader.GetString(3)));
                        }


                    }


                }
            }

        }

    }
}
