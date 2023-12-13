using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group7_FinalProject.Data
{
    internal class InvalidQtyException : Exception
    {
        public InvalidQtyException() : base("ERROR: Enter Quantity > 0 to add item.")
        {

        }
    }
}
