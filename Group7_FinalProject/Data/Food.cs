using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group7_FinalProject.Data
{
    public class Food
    {
        private int foodNum;
        private string foodName;
        private int price;

        public Food(int foodNum, string foodName, int price)
        {
            this.FoodNum = foodNum;
            this.FoodName = foodName;
            this.Price = price;
        }

        public int FoodNum { get => foodNum; set => foodNum = value; }
        public string FoodName { get => foodName; set => foodName = value; }
        public int Price { get => price; set => price = value; }

        public override string ToString()
        {
            return $"{FoodNum},{FoodName},{Price}";
        }

    }
}
