namespace Paraminter.Semantic.SemanticAttributeConstructorArgumentDataFactoryCases.SemanticAttributeConstructorArgumentDataCases;

using Microsoft.CodeAnalysis;

internal interface IArgumentDataFixture
{
    public abstract ISemanticAttributeConstructorArgumentData Sut { get; }

    public abstract TypedConstant Value { get; }
}
