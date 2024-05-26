namespace Paraminter.Semantic.SemanticAttributeConstructorInvocationDataFactoryCases.SemanticAttributeConstructorInvocationDataCases;

using Microsoft.CodeAnalysis;

using System.Collections.Generic;

using Xunit;

public sealed class Parameters
{
    private readonly IInvocationDataFixture Fixture = InvocationDataFixtureFactory.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.ParametersMock.Object, result);
    }

    private IReadOnlyList<IParameterSymbol> Target() => Fixture.Sut.Parameters;
}
