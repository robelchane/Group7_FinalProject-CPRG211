using Group7_FinalProject.Pages;
using Microsoft.Data.SqlClient;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Group7_FinalProject.Data
{
    public class OrderManager
    {
        // Lists to store order-related data
        public static List<Order> distinctOrders = new List<Order>();
        public static List<Order> Orders = new List<Order>();
        public static List<Food> OrderedFood = new List<Food>();


        // Getters for the lists
        public static List<Order> GetOrders()
        {
            return Orders;
        }
        public static List<Order> GetDistinctOrder()
        {
            return distinctOrders;
        }
        public static List<Food> GetFoodByOrderFoodNum()
        {
            return OrderedFood;
        }

        // Constructor to initialize data from the database
        public OrderManager()
        {
            GetOrderFromDB();
            GetFoodByOrderFoodNum();
        }

        // Retrieves limited order details (OrderNum, OrderDateTime, OrderStatus) from OrderTable
        // Stores the retrieved details in a list of Order objects
        public static List<Order> GetOrderFromDB()
        {
            List<Order> orders = new List<Order>();
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FinalProject_DB_Group7;Integrated Security=True";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                string sql = "SELECT DISTINCT OrderNum, OrderDateTime, OrderStatus FROM OrderTable ORDER BY OrderDateTime";
                using (SqlCommand command = new SqlCommand(sql, sqlConnection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var order = new Order(
                                Convert.ToInt32(reader["OrderNum"]),
                                Convert.ToDateTime(reader["OrderDateTime"]),
                                reader["OrderStatus"].ToString()
                            );

                            orders.Add(order);
                        }
                    }
                }

            }

            return orders;
        }
        // Update the 'OrderStatus' of a specific order in the 'OrderTable'
        // Uses a SQL UPDATE statement to modify the order status
        // Returns a boolean indicating the success of the update

        public static bool UpdateOrderStatus(int orderNum, string newStatus)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FinalProject_DB_Group7;Integrated Security=True";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                string sql = "UPDATE [OrderTable] SET OrderStatus = @NewStatus WHERE OrderNum = @OrderNum";
                using (SqlCommand command = new SqlCommand(sql, sqlConnection))
                {
                    command.Parameters.AddWithValue("@NewStatus", newStatus);
                    command.Parameters.AddWithValue("@OrderNum", orderNum);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }



        // Retrieves food details based on a specific food number from the 'MenuItem' table
        // Converts database fields into a Food object and returns it

        public static Food GetFoodByOrderFoodNum(int orderFoodNum)
        {
            Food orderedFood = null;

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FinalProject_DB_Group7;Integrated Security=True";
            string query = "SELECT * FROM MenuItem WHERE FoodNum = @FoodNum";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FoodNum", orderFoodNum);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int foodNum = Convert.ToInt32(reader["FoodNum"]);
                    string foodName = reader["FoodName"].ToString();
                    int price = Convert.ToInt32(reader["Price"]);

                    orderedFood = new Food(foodNum, foodName, price);
                }

                reader.Close();
            }

            return orderedFood;
        }

        // Retrieves distinct orders (based on OrderNum, OrderDateTime, OrderStatus) from OrderTable
        // Filters orders based on a specific status ('Paid')
        // Stores the retrieved orders in a list of Order objects

        public static List<Order> GetDistinctOrders()
        {
            List<Order> distinctOrders = new List<Order>();

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FinalProject_DB_Group7;Integrated Security=True";
            string query = "SELECT DISTINCT OrderNum, OrderDateTime, OrderStatus FROM OrderTable WHERE OrderStatus = 'Paid' ORDER BY OrderDateTime";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int orderNum = Convert.ToInt32(reader["OrderNum"]);
                    DateTime orderDateTime = Convert.ToDateTime(reader["OrderDateTime"]);
                    string orderStatus = reader["OrderStatus"].ToString();

                    distinctOrders.Add(new Order(orderNum, orderDateTime, orderStatus));
                }

                reader.Close();
            }

            return distinctOrders;
        }

        // Retrieves food numbers related to a specific order number from OrderTable
        // Retrieves detailed food information for each food number using GetFoodByOrderFoodNum method
        // Stores the retrieved food items in a list of Food objects

        public static List<Food> GetFoodsByOrderNum(int orderNum)
        {
            List<Food> orderedFoods = new List<Food>();

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FinalProject_DB_Group7;Integrated Security=True";
            string query = "SELECT FoodNum FROM OrderTable WHERE OrderNum = @OrderNum";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@OrderNum", orderNum);

                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int foodNum = Convert.ToInt32(reader["FoodNum"]);

                    // Assuming you have a method to retrieve food details by FoodNum
                    Food orderedFood = GetFoodByOrderFoodNum(foodNum);
                    if (orderedFood != null)
                    {
                        orderedFoods.Add(orderedFood);
                    }
                }

                reader.Close();
            }

            return orderedFoods;
        }

    }

}