namespace Paraminter.Semantic;

using Microsoft.CodeAnalysis;

/// <inheritdoc cref="ISemanticAttributeConstructorArgumentDataFactory"/>
public sealed class SemanticAttributeConstructorArgumentDataFactory : ISemanticAttributeConstructorArgumentDataFactory
{
    /// <summary>Instantiates a <see cref="ISemanticAttributeConstructorArgumentDataFactory"/>, handling creation of <see cref="ISemanticAttributeConstructorArgumentData"/>.</summary>
    public SemanticAttributeConstructorArgumentDataFactory() { }

    ISemanticAttributeConstructorArgumentData ISemanticAttributeConstructorArgumentDataFactory.Create(TypedConstant value) => new SemanticAttributeConstructorArgumentData(value);

    private sealed class SemanticAttributeConstructorArgumentData : ISemanticAttributeConstructorArgumentData
    {
        private readonly TypedConstant Value;

        public SemanticAttributeConstructorArgumentData(TypedConstant value)
        {
            Value = value;
        }

        TypedConstant ISemanticAttributeConstructorArgumentData.Value => Value;
    }
}
