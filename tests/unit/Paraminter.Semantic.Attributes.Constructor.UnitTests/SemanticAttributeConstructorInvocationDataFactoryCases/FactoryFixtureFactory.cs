namespace Paraminter.Semantic.SemanticAttributeConstructorInvocationDataFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        SemanticAttributeConstructorInvocationDataFactory sut = new();

        return new FactoryFixture(sut);
    }

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly ISemanticAttributeConstructorInvocationDataFactory Sut;

        public FactoryFixture(ISemanticAttributeConstructorInvocationDataFactory sut)
        {
            Sut = sut;
        }

        ISemanticAttributeConstructorInvocationDataFactory IFactoryFixture.Sut => Sut;
    }
}
