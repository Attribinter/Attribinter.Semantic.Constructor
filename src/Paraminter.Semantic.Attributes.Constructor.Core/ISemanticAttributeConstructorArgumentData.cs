namespace Paraminter.Semantic;

using Microsoft.CodeAnalysis;

/// <summary>Represents an attribute constructor argument.</summary>
public interface ISemanticAttributeConstructorArgumentData
{
    /// <summary>The value of the argument.</summary>
    public abstract TypedConstant Value { get; }
}
