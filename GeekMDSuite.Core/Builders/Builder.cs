using System;

namespace GeekMDSuite.Core.Builders
{
    /// <summary>
    /// Build complex objects in a fluent and safe manner.
    /// </summary>
    /// <typeparam name="TBuilder"></typeparam>
    /// <typeparam name="TObj"></typeparam>
    public abstract class Builder<TBuilder, TObj> : IBuilder<TObj> where TBuilder : new()
    {
        /// <summary>
        /// Fluent alternative in object creation
        /// </summary>
        /// <returns>TBuilder</returns>
        public static TBuilder Initialize() => new TBuilder();
        /// <summary>
        /// A safe method to construct complex objects. Backing fields for properties
        /// set by mandatory methods will be validated prior to object construction.
        /// <exception cref="MissingMethodException">When a mandatory method is not called.</exception>
        /// </summary>
        /// <returns>TObj</returns>
        public abstract TObj Build();
        /// <summary>
        /// [Unsafe] This is a method useful for testing purposes.
        /// It allows for incomplete construction of complex objects.
        /// Using this method in production code is likely to
        /// result in a number of exceptions being thrown and
        /// other unexpected behavior.
        /// </summary>
        /// <returns>TObj</returns>
        public abstract TObj BuildWithoutModelValidation();
    }
}