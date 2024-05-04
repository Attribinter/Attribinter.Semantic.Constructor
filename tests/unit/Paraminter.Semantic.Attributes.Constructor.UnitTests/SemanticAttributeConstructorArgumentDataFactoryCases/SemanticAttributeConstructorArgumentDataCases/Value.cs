namespace Paraminter.Semantic.SemanticAttributeConstructorArgumentDataFactoryCases.SemanticAttributeConstructorArgumentDataCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class Value
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Equal(Fixture.Value, result);
    }

    private TypedConstant Target() => Fixture.Sut.Value;

    private readonly IArgumentDataFixture Fixture = ArgumentDataFixtureFactory.Create();
}
