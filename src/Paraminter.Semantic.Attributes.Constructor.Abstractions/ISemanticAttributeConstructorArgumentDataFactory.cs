namespace Paraminter.Semantic;

using Microsoft.CodeAnalysis;

/// <summary>Handles creation of <see cref="ISemanticAttributeConstructorArgumentData"/>.</summary>
public interface ISemanticAttributeConstructorArgumentDataFactory
{
    /// <summary>Creates a <see cref="ISemanticAttributeConstructorArgumentData"/>, representing an attribute constructor argument.</summary>
    /// <param name="value">The value of the argument.</param>
    /// <returns>The created <see cref="ISemanticAttributeConstructorArgumentData"/>.</returns>
    public abstract ISemanticAttributeConstructorArgumentData Create(TypedConstant value);
}
