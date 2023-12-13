using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group7_FinalProject.Data
{
    public class Drink : Food
    {
        private string type;

        public Drink(int foodNum, string foodName, int price, string type) : base(foodNum, foodName, price)
        {
            this.Type = type;
        }

        public string Type { get => type; set => type = value; }

        public override string ToString()
        {
            return
                $"{base.ToString()},{Type}\n";
        }
    }
}
