namespace Paraminter.Semantic;

using Microsoft.CodeAnalysis;

using System.Collections.Generic;

/// <summary>Handles creation of <see cref="ISemanticAttributeConstructorInvocationData"/>.</summary>
public interface ISemanticAttributeConstructorInvocationDataFactory
{
    /// <summary>Creates a <see cref="ISemanticAttributeConstructorInvocationData"/>, representing the constructor parameters and constructor arguments of an attribute invocation.</summary>
    /// <param name="parameters">The constructor parameters of the invocation.</param>
    /// <param name="arguments">The constructor arguments of the invocation.</param>
    /// <returns>The created <see cref="ISemanticAttributeConstructorInvocationData"/>.</returns>
    public abstract ISemanticAttributeConstructorInvocationData Create(IReadOnlyList<IParameterSymbol> parameters, IReadOnlyList<TypedConstant> arguments);
}
