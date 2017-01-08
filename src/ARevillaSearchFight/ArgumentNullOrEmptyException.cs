using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARevillaSearchFight
{
    public sealed class ArgumentNullOrEmptyException : ArgumentException
    {
        public ArgumentNullOrEmptyException(string name) : base(name)
        {
        }

        public ArgumentNullOrEmptyException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}
