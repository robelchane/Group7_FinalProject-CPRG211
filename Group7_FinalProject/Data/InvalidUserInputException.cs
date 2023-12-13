using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group7_FinalProject.Data
{
    public class InvalidUserInputException : Exception
    {
        public InvalidUserInputException() : base("Please enter a valid amount.") { }
    }
}
