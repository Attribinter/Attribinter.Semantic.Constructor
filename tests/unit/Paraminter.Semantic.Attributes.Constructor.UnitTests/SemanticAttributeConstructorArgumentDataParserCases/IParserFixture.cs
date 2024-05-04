namespace Paraminter.Semantic.SemanticAttributeConstructorArgumentDataParserCases;

using Moq;

using Paraminter.Parameters;

internal interface IParserFixture
{
    public abstract IArgumentDataParser<IConstructorParameter, ISemanticAttributeConstructorArgumentData, ISemanticAttributeConstructorInvocationData> Sut { get; }

    public abstract Mock<IConstructorParameterFactory> ParameterFactoryMock { get; }
    public abstract Mock<ISemanticAttributeConstructorArgumentDataFactory> ArgumentDataFactoryMock { get; }
}
