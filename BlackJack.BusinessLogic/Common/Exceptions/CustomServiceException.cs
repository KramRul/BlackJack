using System;

namespace BlackJack.BusinessLogic.Common.Exceptions
{
    public class CustomServiceException : Exception
    {
        public string Property { get; protected set; }
        public CustomServiceException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
