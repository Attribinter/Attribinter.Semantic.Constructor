namespace Paraminter.Semantic;

using Microsoft.CodeAnalysis;

using System.Collections.Generic;

/// <summary>Represents the constructor parameters and constructor arguments of an attribute invocation.</summary>
public interface ISemanticAttributeConstructorInvocationData
{
    /// <summary>The constructor parameters of the invocation.</summary>
    public abstract IReadOnlyList<IParameterSymbol> Parameters { get; }

    /// <summary>The constructor arguments of the invocation.</summary>
    public abstract IReadOnlyList<TypedConstant> Arguments { get; }
}
