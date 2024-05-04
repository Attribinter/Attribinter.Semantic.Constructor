namespace Paraminter.Semantic.SemanticAttributeConstructorArgumentDataParserCases;

using Moq;

using Paraminter.Parameters;

internal static class ParserFixtureFactory
{
    public static IParserFixture Create()
    {
        Mock<IConstructorParameterFactory> parameterFactoryMock = new();
        Mock<ISemanticAttributeConstructorArgumentDataFactory> argumentDataFactoryMock = new();

        SemanticAttributeConstructorArgumentDataParser sut = new(parameterFactoryMock.Object, argumentDataFactoryMock.Object);

        return new ParserFixture(sut, parameterFactoryMock, argumentDataFactoryMock);
    }

    private sealed class ParserFixture : IParserFixture
    {
        private readonly IArgumentDataParser<IConstructorParameter, ISemanticAttributeConstructorArgumentData, ISemanticAttributeConstructorInvocationData> Sut;

        private readonly Mock<IConstructorParameterFactory> ParameterFactoryMock;
        private readonly Mock<ISemanticAttributeConstructorArgumentDataFactory> ArgumentDataFactoryMock;

        public ParserFixture(IArgumentDataParser<IConstructorParameter, ISemanticAttributeConstructorArgumentData, ISemanticAttributeConstructorInvocationData> sut, Mock<IConstructorParameterFactory> parameterFactoryMock, Mock<ISemanticAttributeConstructorArgumentDataFactory> argumentDataFactoryMock)
        {
            Sut = sut;

            ParameterFactoryMock = parameterFactoryMock;
            ArgumentDataFactoryMock = argumentDataFactoryMock;
        }

        IArgumentDataParser<IConstructorParameter, ISemanticAttributeConstructorArgumentData, ISemanticAttributeConstructorInvocationData> IParserFixture.Sut => Sut;

        Mock<IConstructorParameterFactory> IParserFixture.ParameterFactoryMock => ParameterFactoryMock;
        Mock<ISemanticAttributeConstructorArgumentDataFactory> IParserFixture.ArgumentDataFactoryMock => ArgumentDataFactoryMock;
    }
}
