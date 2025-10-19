using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using NeverNull.Generator.UnitTests.Constants;
using NeverNull.Generator.UnitTests.Factories;

namespace NeverNull.Generator.UnitTests;

public class NeverNullGeneratorTests : CSharpSourceGeneratorTest<NeverNullGenerator, DefaultVerifier>
{
    [Theory]
    [InlineData("int", "Number")]
    [InlineData("System.DateTime", "Time")]
    [InlineData("System.Guid", "Id")]
    public async Task PublicValueTypeField_DoesNotGenerateNeverNullSource(string memberType, string memberName)
    {
        // Arrange
        var source = GeneratorTestFactory.CreateSimpleClassSourceWithNeverNullField(memberType, memberName);

        // Act
        TestState.Sources.Add(GeneratorTestConstants.NeverNullAttributeDefinition);
        TestState.Sources.Add(source);

        // Assert
        await RunAsync();
    }

    [Theory]
    [InlineData("string", "String")]
    [InlineData("object", "Object")]
    public async Task PublicPrimitiveField_GeneratesNeverNullSource(string memberType, string memberName)
    {
        // Arrange
        var source = GeneratorTestFactory.CreateSimpleClassSourceWithNeverNullField(memberType, memberName);
        var expected = GeneratorTestFactory.GetExpectedGeneratedSimpleClassSource(memberType, memberName);
        var generatedSourceName = GeneratorTestFactory.GetGeneratedSourceName(memberName);

        // Act
        TestState.Sources.Add(GeneratorTestConstants.NeverNullAttributeDefinition);
        TestState.Sources.Add(source);
        TestState.GeneratedSources.Add((typeof(NeverNullGenerator), generatedSourceName, expected));

        // Assert
        await RunAsync();
    }

    [Theory]
    [InlineData("List<string>", "Strings")]
    [InlineData("List<int>", "Numbers")]
    [InlineData("List<object>", "Objects")]
    public async Task PublicListField_GeneratesNeverNullSource(string listType, string memberName)
    {
        // Arrange
        var source = GeneratorTestFactory.CreateSimpleClassSourceWithNeverNullField(listType, memberName, "public", ["System.Collections.Generic"]);
        var expected = GeneratorTestFactory.GetExpectedGeneratedSimpleClassSource($"System.Collections.Generic.{listType}", memberName);
        var generatedSourceName = GeneratorTestFactory.GetGeneratedSourceName(memberName);

        // Act
        TestState.Sources.Add(GeneratorTestConstants.NeverNullAttributeDefinition);
        TestState.Sources.Add(source);
        TestState.GeneratedSources.Add((typeof(NeverNullGenerator), generatedSourceName, expected));

        // Assert
        await RunAsync();
    }
}