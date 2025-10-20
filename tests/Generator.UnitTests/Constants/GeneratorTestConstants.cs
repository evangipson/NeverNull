namespace NeverNull.Generator.UnitTests.Constants;

internal static class GeneratorTestConstants
{
    internal const string NeverNullAttributeDefinition = """
using System;

namespace NeverNull.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false)]
    public sealed class NeverNullAttribute : Attribute
    {
    }
}
""";

    internal const string SimpleClassName = "SimpleClass";

    internal const string SimpleClassEmptySource = """
using NeverNull.Attributes;

namespace MyNamespace;

public partial class SimpleClass;
""";
}
