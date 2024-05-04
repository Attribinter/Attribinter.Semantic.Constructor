namespace Paraminter.Semantic;

using Microsoft.CodeAnalysis;

using System;
using System.Collections.Generic;

/// <inheritdoc cref="ISemanticAttributeConstructorInvocationDataFactory"/>
public sealed class SemanticAttributeConstructorInvocationDataFactory : ISemanticAttributeConstructorInvocationDataFactory
{
    /// <summary>Instantiates a <see cref="SemanticAttributeConstructorInvocationDataFactory"/>, handling creation of <see cref="ISemanticAttributeConstructorInvocationData"/>.</summary>
    public SemanticAttributeConstructorInvocationDataFactory() { }

    ISemanticAttributeConstructorInvocationData ISemanticAttributeConstructorInvocationDataFactory.Create(IReadOnlyList<IParameterSymbol> parameters, IReadOnlyList<TypedConstant> arguments)
    {
        if (parameters is null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        if (arguments is null)
        {
            throw new ArgumentNullException(nameof(arguments));
        }

        return new SemanticAttributeConstructorInvocationData(parameters, arguments);
    }

    private sealed class SemanticAttributeConstructorInvocationData : ISemanticAttributeConstructorInvocationData
    {
        private readonly IReadOnlyList<IParameterSymbol> Parameters;
        private readonly IReadOnlyList<TypedConstant> Arguments;

        public SemanticAttributeConstructorInvocationData(IReadOnlyList<IParameterSymbol> parameters, IReadOnlyList<TypedConstant> arguments)
        {
            Parameters = parameters;
            Arguments = arguments;
        }

        IReadOnlyList<IParameterSymbol> ISemanticAttributeConstructorInvocationData.Parameters => Parameters;
        IReadOnlyList<TypedConstant> ISemanticAttributeConstructorInvocationData.Arguments => Arguments;
    }
}
