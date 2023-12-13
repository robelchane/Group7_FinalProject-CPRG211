using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group7_FinalProject.Data
{
    public class InvalidOutstandingBalanceException : Exception
    {
        public InvalidOutstandingBalanceException() : base("Order cannot be completed. Please try again")
        { 
        }
    }
}
