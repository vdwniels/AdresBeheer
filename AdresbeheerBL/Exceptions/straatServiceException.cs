using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerBL.Exceptions
{
    public class straatServiceException : Exception
    {
        public straatServiceException(string? message) : base(message)
        {
        }

        public straatServiceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
