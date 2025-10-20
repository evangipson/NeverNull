using System;

namespace NeverNull.Attributes
{
    /// <summary>
    /// A decorator for a reference type field which guarantees it will never be <see langword="null"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, Inherited = false)]
    public sealed class NeverNullAttribute : Attribute
    {
    }
}