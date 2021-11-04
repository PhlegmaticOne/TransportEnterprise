using System;

namespace TransportEnterprise.Models.Exceptions
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
        private readonly decimal _maxWeight;
        private readonly decimal _actualWeight;
        /// <summary>
        /// Initializes new exception instance when weight is wrong
        /// </summary>
        /// <param name="message">Message for an exception</param>
        /// <param name="specifiedWrongWeight">Actual weight that was wrong</param>
        public WeightException(string message, decimal maxWeight, decimal specifiedWrongWeight)
        {
            _message = message;
            _maxWeight = maxWeight;
            _actualWeight = specifiedWrongWeight;
        }
        /// <summary>
        /// Gets exception message
        /// </summary>
        public override string Message => string.Format("{0}. Max weight: {1}. Actual: {2}", _message, _maxWeight, _actualWeight);
    }
}
