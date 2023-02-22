using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolutionV1.Utilities.Exceptions
{
    public class EShopSolutionException : Exception
    {
        public EShopSolutionException()
        {
        }

        public EShopSolutionException(string message)
            : base(message)
        {
        }

        public EShopSolutionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
