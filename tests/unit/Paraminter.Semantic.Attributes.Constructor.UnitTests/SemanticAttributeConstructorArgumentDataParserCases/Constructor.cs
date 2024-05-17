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
        var result = Record.Exception(() => Target(Mock.Of<INormalParameterFactory>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsParser()
    {
        var result = Target(Mock.Of<INormalParameterFactory>(), Mock.Of<ISemanticAttributeConstructorArgumentDataFactory>());

        Assert.NotNull(result);
    }

    private static SemanticAttributeConstructorArgumentDataParser Target(INormalParameterFactory parameterFactory, ISemanticAttributeConstructorArgumentDataFactory argumentDataFactory) => new(parameterFactory, argumentDataFactory);
}
