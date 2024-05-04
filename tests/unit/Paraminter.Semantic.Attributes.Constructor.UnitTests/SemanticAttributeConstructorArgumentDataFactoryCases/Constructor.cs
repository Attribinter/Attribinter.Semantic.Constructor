namespace Paraminter.Semantic.SemanticAttributeConstructorArgumentDataFactoryCases;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void ReturnsFactory()
    {
        var result = Target();

        Assert.NotNull(result);
    }

    private static SemanticAttributeConstructorArgumentDataFactory Target() => new();
}
