using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBookManagement.Services.Exceptions
{
    public class ExceptionMemoryCache : Exception
    {
        public ExceptionMemoryCache(string message) : base(message)
        {
            
        }
    }
}
