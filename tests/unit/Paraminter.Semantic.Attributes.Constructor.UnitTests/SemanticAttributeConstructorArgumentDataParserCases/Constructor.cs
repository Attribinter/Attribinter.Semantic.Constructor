namespace Paraminter.Semantic.SemanticAttributeConstructorArgumentDataParserCases;

using Moq;

using Paraminter.Parameters;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullParameterFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!, Mock.Of<ISemanticAttributeConstructorArgumentDataFactory>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullArgumentDataFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(Mock.Of<IMethodParameterFactory>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsParser()
    {
        var result = Target(Mock.Of<IMethodParameterFactory>(), Mock.Of<ISemanticAttributeConstructorArgumentDataFactory>());

        Assert.NotNull(result);
    }

    private static SemanticAttributeConstructorArgumentDataParser Target(IMethodParameterFactory parameterFactory, ISemanticAttributeConstructorArgumentDataFactory argumentDataFactory) => new(parameterFactory, argumentDataFactory);
}
