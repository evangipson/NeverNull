using Microsoft.CodeAnalysis;

namespace NeverNull.Generator.Extensions
{
    /// <summary>
    /// A <see langword="static"/> collection of methods to extend <see cref="AttributeData"/> functionality.
    /// </summary>
    internal static class AttributeDataExtensions
    {
        private const string _neverNullAttributeFullName = "NeverNull.Attributes.NeverNullAttribute";
        private const string _neverNullAttributeName = "NeverNullAttribute";
        private const string _neverNullAttributeSimpleName = "NeverNull";

        /// <summary>
        /// A predicate that makes sure <paramref name="attributeData"/> matches the <c>[NeverNull]</c>
        /// attribute name.
        /// </summary>
        /// <param name="attributeData">The <see cref="AttributeData"/> to check.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="attributeData"/> matches the <c>[NeverNull]</c>
        /// attribute name, <see langword="false"/> otherwise.
        /// </returns>
        internal static bool AttributeNameMatchesNeverNull(this AttributeData attributeData)
            => attributeData.AttributeClass?.ToDisplayString() == _neverNullAttributeFullName
                || attributeData.AttributeClass?.Name == _neverNullAttributeSimpleName
                || attributeData.AttributeClass?.GetType().Name == _neverNullAttributeName;
    }
}