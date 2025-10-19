using System.Linq;
using Microsoft.CodeAnalysis;

namespace NeverNull.Generator.Extensions
{
    /// <summary>
    /// A <see langword="static"/> collection of methods to extend <see cref="ISymbol"/> functionality.
    /// </summary>
    internal static class SymbolExtensions
    {
        /// <summary>
        /// A predicate that will make sure the containing type is not explicitly nullable,
        /// and then check for the <c>[NeverNull]</c> attribute.
        /// </summary>
        /// <param name="symbol">The <see cref="ISymbol"/> to check.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="symbol"/> has the <c>[NeverNull]</c>
        /// attribute and is not explicitly marked nullable, <see langword="false"/> otherwise.
        /// </returns>
        internal static bool HasNeverNullAttribute(this ISymbol? symbol) => symbol != null
            && symbol.ContainingType.NullableAnnotation != NullableAnnotation.Annotated
            && symbol.GetAttributes().Any(x => x.AttributeNameMatchesNeverNull());
    }
}