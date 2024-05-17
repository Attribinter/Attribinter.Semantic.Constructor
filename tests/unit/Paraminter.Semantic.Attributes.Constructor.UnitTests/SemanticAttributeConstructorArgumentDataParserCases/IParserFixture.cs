namespace Paraminter.Semantic.SemanticAttributeConstructorArgumentDataParserCases;

using Moq;

using Paraminter.Parameters;

internal interface IParserFixture
{
    public abstract IArgumentDataParser<INormalParameter, ISemanticAttributeConstructorArgumentData, ISemanticAttributeConstructorInvocationData> Sut { get; }

    public abstract Mock<INormalParameterFactory> ParameterFactoryMock { get; }
    public abstract Mock<ISemanticAttributeConstructorArgumentDataFactory> ArgumentDataFactoryMock { get; }
}
