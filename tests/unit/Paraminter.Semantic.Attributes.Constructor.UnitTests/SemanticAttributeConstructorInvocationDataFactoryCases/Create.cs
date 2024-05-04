namespace Paraminter.Semantic.SemanticAttributeConstructorInvocationDataFactoryCases;

using Microsoft.CodeAnalysis;

using Moq;

using System;
using System.Collections.Generic;

using Xunit;

public sealed class Create
{
    [Fact]
    public void NullParameters_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!, Mock.Of<IReadOnlyList<TypedConstant>>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullArguments_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(Mock.Of<IReadOnlyList<IParameterSymbol>>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsArgumentData()
    {
        var result = Target(Mock.Of<IReadOnlyList<IParameterSymbol>>(), Mock.Of<IReadOnlyList<TypedConstant>>());

        Assert.NotNull(result);
    }

    private ISemanticAttributeConstructorInvocationData Target(IReadOnlyList<IParameterSymbol> parameters, IReadOnlyList<TypedConstant> arguments) => Fixture.Sut.Create(parameters, arguments);

    private readonly IFactoryFixture Fixture = FactoryFixtureFactory.Create();
}
