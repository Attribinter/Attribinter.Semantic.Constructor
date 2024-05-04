namespace Paraminter.Semantic.SemanticAttributeConstructorInvocationDataFactoryCases;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void ReturnsFactory()
    {
        var result = Target();

        Assert.NotNull(result);
    }

    private static SemanticAttributeConstructorInvocationDataFactory Target() => new();
}
