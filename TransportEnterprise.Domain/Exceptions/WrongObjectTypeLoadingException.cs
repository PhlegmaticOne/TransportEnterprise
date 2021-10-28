using System;

namespace TransportEnterprise.Models.Exceptions
{
    public class WrongObjectTypeLoadingException : Exception
    {
        private readonly string _message;
        private readonly Type _expectedType;
        private readonly Type _realType;

        public WrongObjectTypeLoadingException(string message, Type expectedType, Type realType)
        {
            _message = message;
            _expectedType = expectedType;
            _realType = realType;
        }
        public override string Message => $"{_message}. Expected: {_expectedType.Name}. Actual: {_realType.Name}";
    }
}
