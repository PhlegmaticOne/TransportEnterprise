using System;

namespace TransportEnterprise.Models.Exceptions
{
    /// <summary>
    /// Represents exception if temperature range of product was outside of specified temperature range
    /// </summary>
    public class TemperatureNotInRangeException : Exception
    {
        private readonly string _message;
        private readonly TemperatureRule _expected;
        private readonly TemperatureRule _actual;
        /// <summary>
        /// Initializes new TemperatureNotInRangeException instance
        /// </summary>
        /// <param name="message">Specified message</param>
        /// <param name="expected">Expected temperature</param>
        /// <param name="actual">Actual temperature</param>
        public TemperatureNotInRangeException(string message, TemperatureRule expected, TemperatureRule actual)
        {
            _message = message;
            _expected = expected;
            _actual = actual;
        }
        /// <summary>
        /// Gets exception message
        /// </summary>
        public override string Message => string.Format("{0}. Expected: {1}. Actual: {2}", _message, _expected, _actual);
    }
}
