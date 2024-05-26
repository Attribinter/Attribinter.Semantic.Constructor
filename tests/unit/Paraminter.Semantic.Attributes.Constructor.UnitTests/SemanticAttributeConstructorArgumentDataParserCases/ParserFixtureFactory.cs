namespace Paraminter.Semantic.SemanticAttributeConstructorArgumentDataParserCases;

using Moq;

using Paraminter.Parameters;

internal static class ParserFixtureFactory
{
    public static IParserFixture Create()
    {
        Mock<IMethodParameterFactory> parameterFactoryMock = new();
        Mock<ISemanticAttributeConstructorArgumentDataFactory> argumentDataFactoryMock = new();

        SemanticAttributeConstructorArgumentDataParser sut = new(parameterFactoryMock.Object, argumentDataFactoryMock.Object);

        return new ParserFixture(sut, parameterFactoryMock, argumentDataFactoryMock);
    }

    private sealed class ParserFixture : IParserFixture
    {
        private readonly IArgumentDataParser<IMethodParameter, ISemanticAttributeConstructorArgumentData, ISemanticAttributeConstructorInvocationData> Sut;

        private readonly Mock<IMethodParameterFactory> ParameterFactoryMock;
        private readonly Mock<ISemanticAttributeConstructorArgumentDataFactory> ArgumentDataFactoryMock;

        public ParserFixture(IArgumentDataParser<IMethodParameter, ISemanticAttributeConstructorArgumentData, ISemanticAttributeConstructorInvocationData> sut, Mock<IMethodParameterFactory> parameterFactoryMock, Mock<ISemanticAttributeConstructorArgumentDataFactory> argumentDataFactoryMock)
        {
            Sut = sut;

            ParameterFactoryMock = parameterFactoryMock;
            ArgumentDataFactoryMock = argumentDataFactoryMock;
        }

        IArgumentDataParser<IMethodParameter, ISemanticAttributeConstructorArgumentData, ISemanticAttributeConstructorInvocationData> IParserFixture.Sut => Sut;

        Mock<IMethodParameterFactory> IParserFixture.ParameterFactoryMock => ParameterFactoryMock;
        Mock<ISemanticAttributeConstructorArgumentDataFactory> IParserFixture.ArgumentDataFactoryMock => ArgumentDataFactoryMock;
    }
}
