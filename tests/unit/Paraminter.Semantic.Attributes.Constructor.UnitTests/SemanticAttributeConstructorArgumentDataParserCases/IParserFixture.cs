namespace Paraminter.Semantic.SemanticAttributeConstructorArgumentDataParserCases;

using Moq;

using Paraminter.Parameters;

internal interface IParserFixture
{
    public abstract IArgumentDataParser<IMethodParameter, ISemanticAttributeConstructorArgumentData, ISemanticAttributeConstructorInvocationData> Sut { get; }

    public abstract Mock<IMethodParameterFactory> ParameterFactoryMock { get; }
    public abstract Mock<ISemanticAttributeConstructorArgumentDataFactory> ArgumentDataFactoryMock { get; }
}
