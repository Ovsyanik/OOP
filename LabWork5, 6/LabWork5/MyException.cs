using System;

namespace LabWork5
{
    class LessThanZeroException : Exception
    {
        public LessThanZeroException(string message) : base(message) 
        { }
    }
}
