namespace Attribinter.Semantic.SemanticConstructorArgumentParserCases;

using Attribinter.Parameters;

using Microsoft.CodeAnalysis;

using Moq;

internal interface IParserFixture
{
    public abstract IArgumentParser<IConstructorParameter, TypedConstant, AttributeData> Sut { get; }

    public abstract Mock<IConstructorParameterFactory> ParameterFactoryMock { get; }
}
