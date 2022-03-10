using System;

namespace RomanNum
{
    public class RomanNumberException:Exception
    {
        public RomanNumberException() { }
        public RomanNumberException(string message):base(message) { }

    }
}
