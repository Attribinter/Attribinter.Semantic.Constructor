namespace Paraminter.Semantic.SemanticAttributeConstructorInvocationDataFactoryCases.SemanticAttributeConstructorInvocationDataCases;

using Microsoft.CodeAnalysis;

using Moq;

using System.Collections.Generic;

internal static class InvocationDataFixtureFactory
{
    public static IInvocationDataFixture Create()
    {
        Mock<IReadOnlyList<IParameterSymbol>> parametersMock = new();
        Mock<IReadOnlyList<TypedConstant>> argumentsMock = new();

        ISemanticAttributeConstructorInvocationDataFactory factory = new SemanticAttributeConstructorInvocationDataFactory();

        var sut = factory.Create(parametersMock.Object, argumentsMock.Object);

        return new InvocationDataFixture(sut, parametersMock, argumentsMock);
    }

    private sealed class InvocationDataFixture : IInvocationDataFixture
    {
        private readonly ISemanticAttributeConstructorInvocationData Sut;

        private readonly Mock<IReadOnlyList<IParameterSymbol>> ParametersMock;
        private readonly Mock<IReadOnlyList<TypedConstant>> ArgumentsMock;

        public InvocationDataFixture(ISemanticAttributeConstructorInvocationData sut, Mock<IReadOnlyList<IParameterSymbol>> parametersMock, Mock<IReadOnlyList<TypedConstant>> argumentsMock)
        {
            Sut = sut;

            ParametersMock = parametersMock;
            ArgumentsMock = argumentsMock;
        }

        ISemanticAttributeConstructorInvocationData IInvocationDataFixture.Sut => Sut;

        Mock<IReadOnlyList<IParameterSymbol>> IInvocationDataFixture.ParametersMock => ParametersMock;
        Mock<IReadOnlyList<TypedConstant>> IInvocationDataFixture.ArgumentsMock => ArgumentsMock;
    }
}
