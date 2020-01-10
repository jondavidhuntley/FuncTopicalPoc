using System;

namespace FuncAppPoc.Guards
{
    public static class Guard
    {
        /// <summary>
        /// Throws a <see cref="ArgumentNullException"/> if <paramref name="value"/> is null
        /// </summary>
        /// <param name="value">The value to test for null</param>
        /// <param name="paramName">The parameter name</param>
        /// <param name="message">The optional message to include in any exception raised</param>
        public static void AgainstNull(object value, string paramName, string message = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName, message ?? $"The object passed for parameter {paramName} was found to be null");
            }
        }

        /// <summary>
        /// Throws a <see cref="ArgumentNullException"/> if <paramref name="value"/> is null or
        /// a <see cref="ArgumentException"/> if <paramref name="value"/> is empty
        /// </summary>
        /// <param name="value">The value to test for null or empty</param>
        /// <param name="paramName">The parameter name</param>
        /// <param name="message">The optional message to include in any exception raised</param>
        public static void AgainstNullOrEmpty(string value, string paramName, string message = null)
        {
            AgainstNull(value, paramName, message);

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(message ?? $"The string passed for parameter {paramName} was found to be empty", paramName);
            }
        }

        /// <summary>
        /// Throws a <see cref="ArgumentNullException"/> if <paramref name="value"/> is null or
        /// a <see cref="ArgumentException"/> if <paramref name="value"/> is empty or whites-space
        /// </summary>
        /// <param name="value">The value to test for null, empty or white-space</param>
        /// <param name="paramName">The parameter name</param>
        /// <param name="message">The optional message to include in any exception raised</param>
        public static void AgainstNullOrWhitespace(string value, string paramName, string message = null)
        {
            AgainstNullOrEmpty(value, paramName, message);

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(message ?? $"The string passed for parameter {paramName} was found to be white-space", paramName);
            }
        }
    }
}