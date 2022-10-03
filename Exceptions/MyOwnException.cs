using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class MyOwnException : Exception
        //можна успадковуватися від будь якого іншого ексепшена
    {
        public MyOwnException() : base("це моя помилка")
        {
            
        }

        public MyOwnException(string? message) : base(message)
        {
        }

        public MyOwnException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
