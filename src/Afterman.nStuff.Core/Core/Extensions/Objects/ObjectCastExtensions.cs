namespace Afterman.nStuff.Core.Core.Extensions.Objects
{
    using System;
    using Reflection;

    /// <summary>
    /// Extensions on <see cref="Object"/> to assist with everyday typecasting operations
    /// </summary>
    public static class ObjectCastExtensions
    {
        /// <summary>
        /// Performs an "as" cast on the source object
        /// </summary>
        /// <typeparam name="TDesired">Target type to cast to</typeparam>
        /// <param name="source">object to cast to type TDesired</param>
        /// <returns>Object "as" TDesired type.  may return null</returns>
        public static TDesired CastAs<TDesired>(this Object source)
            where TDesired : class
        {
            return source as TDesired;
        }

        /// <summary>
        /// Performs a "hard" cast on the source object
        /// </summary>
        /// <typeparam name="TDesired">Target type to cast to</typeparam>
        /// <param name="source">object to cast to type TDesired</param>
        /// <exception cref="InvalidCastException">Will throw an invalid cast exception if source cannot be cast to TDesired</exception>
        /// <returns>Object cast to TDesired type.</returns>
        public static TDesired UnsafeCast<TDesired>(this Object source)
        {
            return (TDesired)source;
        }

        /// <summary>
        /// Converts an object to its given type, respecting Nullables
        /// </summary>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TTarget ConvertTo<TTarget>(this Object value)
        {
            if (String.IsNullOrEmpty(value?.ToString()))
                return default(TTarget);
            return (TTarget)Convert.ChangeType(value, typeof(TTarget).GetTypeOrUnderlyingNullableType());
        }
    }
}
