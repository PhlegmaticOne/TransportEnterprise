using System;

namespace TransportEnterprise.Models.Exceptions
{
    public class SemitrailerOverloadingException : Exception
    {
        /// <summary>
        /// Message for an exception
        /// </summary>
        private readonly string _message;
        private readonly decimal _loadCapacity;
        private readonly decimal _newWeight;

        /// <summary>
        /// Initializes new exception instance when weight is wrong
        /// </summary>
        /// <param name="message">Message for an exception</param>
        /// <param name="specifiedWrongWeight">Actual weight that was wrong</param>
        public SemitrailerOverloadingException(string message, decimal loadCapacity, decimal newWeight)
        {
            _message = message;
            _loadCapacity = loadCapacity;
            _newWeight = newWeight;
        }
        /// <summary>
        /// Message that describes reasons of throwing it
        /// </summary>
        public override string Message => string.Format("{0}. Max capacity of semitrailer: {1:f4}. New: {2:f4}", _message, _loadCapacity, _newWeight);
    }
}
