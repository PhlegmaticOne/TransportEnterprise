using System;

namespace TransportEnterprise.Core.Exceptions
{
    /// <summary>
    /// Represents an exception that must to be throw when weight of a product is wrong
    /// </summary>
    public class WeightException : Exception
    {
        /// <summary>
        /// Message for an exception
        /// </summary>
        private readonly string _message;
        /// <summary>
        /// Initializes new exception instance when weight is wrong
        /// </summary>
        /// <param name="message">Message for an exception</param>
        /// <param name="specifiedWrongWeight">Actual weight that was wrong</param>
        public WeightException(string message, decimal specifiedWrongWeight)
        {
            _message = message;
            ActualWeight = specifiedWrongWeight;
        }
        /// <summary>
        /// Message that describes reasons of throwing it
        /// </summary>
        public override string Message => _message;
        /// <summary>
        /// Weight value that caused an exception
        /// </summary>
        public decimal ActualWeight { get; }
    }
}
