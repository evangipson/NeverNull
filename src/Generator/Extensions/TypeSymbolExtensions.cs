using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace NeverNull.Generator.Extensions
{
    /// <summary>
    /// A <see langword="static"/> collection of methods to extend <see cref="ITypeSymbol"/> functionality.
    /// </summary>
    internal static class TypeSymbolExtensions
    {
        private static readonly List<string> _unrecognizedValueTypes = new List<string>()
        {
            "Guid",
            "DateTime"
        };

        /// <summary>
        /// A predicate that checks <paramref name="typeSymbol"/> for known value types.
        /// <para>
        /// Due to a bug in the Rosylyn compiler, <see cref="ITypeSymbol"/> value types aren't
        /// always recognized as such before runtime, so this method will correctly infer value
        /// types before runtime based on known primitive value types.
        /// </para>
        /// </summary>
        /// <param name="typeSymbol">The type symbol to check.</param>
        /// <returns>
        /// <see langword="true"/> if the <paramref name="typeSymbol"/> is a value type,
        /// <see langword="false"/> otherwise.
        /// </returns>
        internal static bool TypeSymbolIsValueType(this ITypeSymbol typeSymbol) => typeSymbol.IsValueType
            || _unrecognizedValueTypes.Contains(typeSymbol.Name);
    }
}