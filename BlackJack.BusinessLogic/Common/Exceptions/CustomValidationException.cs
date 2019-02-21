using System;

namespace BlackJack.BusinessLogic.Common.Exceptions
{
    public class CustomValidationException : Exception
    {
        public string Property { get; protected set; }
        public CustomValidationException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
