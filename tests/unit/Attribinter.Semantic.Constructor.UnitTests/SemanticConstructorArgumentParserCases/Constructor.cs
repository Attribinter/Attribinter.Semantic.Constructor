namespace Attribinter.Semantic.SemanticConstructorArgumentParserCases;

using Attribinter.Parameters;

using Moq;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullParameterFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidParameterFactory_ReturnsParser()
    {
        var result = Target(Mock.Of<IConstructorParameterFactory>());

        Assert.NotNull(result);
    }

    private static SemanticConstructorArgumentParser Target(IConstructorParameterFactory parameterFactory) => new(parameterFactory);
}
