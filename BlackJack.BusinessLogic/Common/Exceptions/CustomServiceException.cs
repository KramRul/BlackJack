using System;

namespace BlackJack.BusinessLogic.Common.Exceptions
{
    public class CustomServiceException : Exception
    {
        public CustomServiceException(string message) : base(message)
        {
        }
    }
}
