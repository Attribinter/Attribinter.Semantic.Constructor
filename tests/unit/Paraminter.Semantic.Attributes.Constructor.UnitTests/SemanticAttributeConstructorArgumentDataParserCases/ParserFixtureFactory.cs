namespace Paraminter.Semantic.SemanticAttributeConstructorArgumentDataParserCases;

using Moq;

using Paraminter.Parameters;

internal static class ParserFixtureFactory
{
    public static IParserFixture Create()
    {
        Mock<INormalParameterFactory> parameterFactoryMock = new();
        Mock<ISemanticAttributeConstructorArgumentDataFactory> argumentDataFactoryMock = new();

        SemanticAttributeConstructorArgumentDataParser sut = new(parameterFactoryMock.Object, argumentDataFactoryMock.Object);

        return new ParserFixture(sut, parameterFactoryMock, argumentDataFactoryMock);
    }

    private sealed class ParserFixture : IParserFixture
    {
        private readonly IArgumentDataParser<INormalParameter, ISemanticAttributeConstructorArgumentData, ISemanticAttributeConstructorInvocationData> Sut;

        private readonly Mock<INormalParameterFactory> ParameterFactoryMock;
        private readonly Mock<ISemanticAttributeConstructorArgumentDataFactory> ArgumentDataFactoryMock;

        public ParserFixture(IArgumentDataParser<INormalParameter, ISemanticAttributeConstructorArgumentData, ISemanticAttributeConstructorInvocationData> sut, Mock<INormalParameterFactory> parameterFactoryMock, Mock<ISemanticAttributeConstructorArgumentDataFactory> argumentDataFactoryMock)
        {
            Sut = sut;

            ParameterFactoryMock = parameterFactoryMock;
            ArgumentDataFactoryMock = argumentDataFactoryMock;
        }

        IArgumentDataParser<INormalParameter, ISemanticAttributeConstructorArgumentData, ISemanticAttributeConstructorInvocationData> IParserFixture.Sut => Sut;

        Mock<INormalParameterFactory> IParserFixture.ParameterFactoryMock => ParameterFactoryMock;
        Mock<ISemanticAttributeConstructorArgumentDataFactory> IParserFixture.ArgumentDataFactoryMock => ArgumentDataFactoryMock;
    }
}
