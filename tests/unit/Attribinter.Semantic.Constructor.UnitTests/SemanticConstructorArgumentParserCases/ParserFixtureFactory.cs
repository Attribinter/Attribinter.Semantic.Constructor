namespace Attribinter.Semantic.SemanticConstructorArgumentParserCases;

using Attribinter.Parameters;

using Microsoft.CodeAnalysis;

using Moq;

internal static class ParserFixtureFactory
{
    public static IParserFixture Create()
    {
        Mock<IConstructorParameterFactory> parameterFactoryMock = new();

        SemanticConstructorArgumentParser sut = new(parameterFactoryMock.Object);

        return new ParserFixture(sut, parameterFactoryMock);
    }

    private sealed class ParserFixture : IParserFixture
    {
        private readonly IArgumentParser<IConstructorParameter, TypedConstant, AttributeData> Sut;

        private readonly Mock<IConstructorParameterFactory> ParameterFactoryMock;

        public ParserFixture(IArgumentParser<IConstructorParameter, TypedConstant, AttributeData> sut, Mock<IConstructorParameterFactory> parameterFactoryMock)
        {
            Sut = sut;

            ParameterFactoryMock = parameterFactoryMock;
        }

        IArgumentParser<IConstructorParameter, TypedConstant, AttributeData> IParserFixture.Sut => Sut;

        Mock<IConstructorParameterFactory> IParserFixture.ParameterFactoryMock => ParameterFactoryMock;
    }
}
