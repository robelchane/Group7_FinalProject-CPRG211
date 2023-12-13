using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group7_FinalProject.Data
{
    internal class InvalidDeleteException : Exception
    {
        public InvalidDeleteException() : base("ERROR: Cannot delete item not in order.")
        {

        }
    }
}
