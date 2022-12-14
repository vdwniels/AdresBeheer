using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerDL.Exceptions
{
    public class StraatRepositoryADOException : Exception
    {
        public StraatRepositoryADOException(string? message) : base(message)
        {
        }

        public StraatRepositoryADOException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
