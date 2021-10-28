using System;

namespace TransportEnterprise.Models.Exceptions
{
    public class TemperatureNotInRangeException : Exception
    {
        private readonly string _message;
        private readonly TemperatureRule _expected;
        private readonly TemperatureRule _actual;

        public TemperatureNotInRangeException(string message, TemperatureRule expected, TemperatureRule actual)
        {
            _message = message;
            _expected = expected;
            _actual = actual;
        }
        public override string Message => string.Format("{0}. Expected: {1}. Actual: {2}", _message, _expected, _actual);
    }
}
