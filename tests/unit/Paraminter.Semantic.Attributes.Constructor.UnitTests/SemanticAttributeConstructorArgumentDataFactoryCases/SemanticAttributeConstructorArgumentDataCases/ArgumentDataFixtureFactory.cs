namespace Paraminter.Semantic.SemanticAttributeConstructorArgumentDataFactoryCases.SemanticAttributeConstructorArgumentDataCases;

using Microsoft.CodeAnalysis;

internal static class ArgumentDataFixtureFactory
{
    public static IArgumentDataFixture Create()
    {
        var value = TypedConstantStore.GetNext();

        ISemanticAttributeConstructorArgumentDataFactory factory = new SemanticAttributeConstructorArgumentDataFactory();

        var sut = factory.Create(value);

        return new ArgumentDataFixture(sut, value);
    }

    private sealed class ArgumentDataFixture : IArgumentDataFixture
    {
        private readonly ISemanticAttributeConstructorArgumentData Sut;

        private readonly TypedConstant Value;

        public ArgumentDataFixture(ISemanticAttributeConstructorArgumentData sut, TypedConstant value)
        {
            Sut = sut;

            Value = value;
        }

        ISemanticAttributeConstructorArgumentData IArgumentDataFixture.Sut => Sut;

        TypedConstant IArgumentDataFixture.Value => Value;
    }
}
