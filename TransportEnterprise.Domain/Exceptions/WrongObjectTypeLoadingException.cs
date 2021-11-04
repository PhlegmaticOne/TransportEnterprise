using System;

namespace TransportEnterprise.Models.Exceptions
{
    /// <summary>
    /// Represents exception if semitrailer cannot load object of specified type
    /// </summary>
    public class WrongObjectTypeLoadingException : Exception
    {
        private readonly string _message;
        private readonly Type _expectedType;
        private readonly Type _realType;
        /// <summary>
        /// Initializes new WrongObjectTypeLoadingException
        /// </summary>
        /// <param name="message">Specified message</param>
        /// <param name="expectedType">Expected type to load</param>
        /// <param name="realType">Real type that cannot be loaded</param>
        public WrongObjectTypeLoadingException(string message, Type expectedType, Type realType)
        {
            _message = message;
            _expectedType = expectedType;
            _realType = realType;
        }
        /// <summary>
        /// Gets exception message
        /// </summary>
        public override string Message => $"{_message}. Expected: {_expectedType.Name}. Actual: {_realType.Name}";
    }
}
