namespace Paraminter.Semantic.SemanticAttributeConstructorArgumentDataFactoryCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class Create
{
    private readonly IFactoryFixture Fixture = FactoryFixtureFactory.Create();

    [Fact]
    public void ReturnsArgumentData()
    {
        var value = TypedConstantStore.GetNext();

        var result = Target(value);

        Assert.NotNull(result);
    }

    private ISemanticAttributeConstructorArgumentData Target(TypedConstant value) => Fixture.Sut.Create(value);
}
