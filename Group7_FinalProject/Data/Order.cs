using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group7_FinalProject.Data
{
    public class Order
    {
        private int orderNum;
        private int orderFoodNum;
        private int quantity;
        private DateTime orderDateTime;
        private string orderStatus;
        private int totalPrice;

        public Order() 
        { 

        }
        public Order(int orderNum, DateTime orderDateTime, string orderStatus)
        {
            this.OrderNum = orderNum;
            this.OrderDateTime = orderDateTime;
            this.OrderStatus = orderStatus;

        }

        public Order(int orderNum, int orderFoodNum, int quantity, DateTime orderDateTime, string orderStatus, int totalPrice)
        {
            this.OrderNum = orderNum;
            this.OrderFoodNum = orderFoodNum;
            this.Quantity = quantity;
            this.OrderDateTime = orderDateTime;
            this.OrderStatus = orderStatus;
            this.TotalPrice = totalPrice;
        }

        public int OrderNum { get => orderNum; set => orderNum = value; }
        public int OrderFoodNum { get => orderFoodNum; set => orderFoodNum = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public DateTime OrderDateTime { get => orderDateTime; set => orderDateTime = value; }
        public string OrderStatus { get => orderStatus; set => orderStatus = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
