namespace Paraminter.Semantic.SemanticAttributeConstructorInvocationDataFactoryCases.SemanticAttributeConstructorInvocationDataCases;

using Microsoft.CodeAnalysis;

using System.Collections.Generic;

using Xunit;

public sealed class Arguments
{
    private readonly IInvocationDataFixture Fixture = InvocationDataFixtureFactory.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.ArgumentsMock.Object, result);
    }

    private IReadOnlyList<TypedConstant> Target() => Fixture.Sut.Arguments;
}
