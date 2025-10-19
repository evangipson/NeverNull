# NeverNull
An attribute and source generator to ensure reference type fields are never null, unless explicitly marked nullable.

Any classes that leverage the `[NeverNull]` attribute **must be partial** due to how the source generator works.

## Getting Started
Download this NuGet package, then mark any field with the `[NeverNull]` attribute to use the source generator to ensure that field will never be null:
```csharp
namespace MyNamspace;

// MUST be a partial class for source generation
public partial class MyClass
{
    // String is now guaranteed to never be null.
    [NeverNull]
    public string String;

    // Strings is now guaranteed to never be null.
    [NeverNull]
    public List<string> Strings;

    // Object will not have any source generation,
    // as it is explicitly marked nullable.
    [NeverNull]
    public object? Object;

    // Numbers will not have any source generation,
    // as int is a value type and cannot be null.
    [NeverNull]
    public List<int> Numbers;
}
```