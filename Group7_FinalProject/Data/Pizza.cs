using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group7_FinalProject.Data
{
    public class Pizza : Food
    {
        private string topping;

        public Pizza(int foodNum, string foodName, int price, string topping) : base(foodNum, foodName, price)
        {
            this.Topping = topping;
        }

        public string Topping { get => topping; set => topping = value; }

        public override string ToString()
        {
            return
                $"{base.ToString()},{Topping}\n";
        }
    }
}
