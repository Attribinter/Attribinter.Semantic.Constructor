namespace Paraminter.Semantic.SemanticAttributeConstructorArgumentDataFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        SemanticAttributeConstructorArgumentDataFactory sut = new();

        return new FactoryFixture(sut);
    }

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly ISemanticAttributeConstructorArgumentDataFactory Sut;

        public FactoryFixture(ISemanticAttributeConstructorArgumentDataFactory sut)
        {
            Sut = sut;
        }

        ISemanticAttributeConstructorArgumentDataFactory IFactoryFixture.Sut => Sut;
    }
}
