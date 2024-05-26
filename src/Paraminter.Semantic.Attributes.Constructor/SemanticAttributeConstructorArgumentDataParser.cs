namespace Paraminter.Semantic;

using Microsoft.CodeAnalysis;

using Paraminter.Parameters;

using System;

/// <summary>Parses attribute constructor arguments.</summary>
public sealed class SemanticAttributeConstructorArgumentDataParser : IArgumentDataParser<IMethodParameter, ISemanticAttributeConstructorArgumentData, ISemanticAttributeConstructorInvocationData>
{
    private readonly IMethodParameterFactory ParameterFactory;
    private readonly ISemanticAttributeConstructorArgumentDataFactory ArgumentDataFactory;

    /// <summary>Instantiates a <see cref="SemanticAttributeConstructorArgumentDataParser"/>, parsing attribute constructor arguments.</summary>
    /// <param name="parameterFactory">Handles creation of <see cref="IMethodParameter"/>.</param>
    /// <param name="argumentDataFactory">Handles creation of <see cref="ISemanticAttributeConstructorArgumentData"/>.</param>
    public SemanticAttributeConstructorArgumentDataParser(IMethodParameterFactory parameterFactory, ISemanticAttributeConstructorArgumentDataFactory argumentDataFactory)
    {
        ParameterFactory = parameterFactory ?? throw new ArgumentNullException(nameof(parameterFactory));
        ArgumentDataFactory = argumentDataFactory ?? throw new ArgumentNullException(nameof(argumentDataFactory));
    }

    bool IArgumentDataParser<IMethodParameter, ISemanticAttributeConstructorArgumentData, ISemanticAttributeConstructorInvocationData>.TryParse(IArgumentDataRecorder<IMethodParameter, ISemanticAttributeConstructorArgumentData> recorder, ISemanticAttributeConstructorInvocationData invocationData)
    {
        if (recorder is null)
        {
            throw new ArgumentNullException(nameof(recorder));
        }

        if (invocationData is null)
        {
            throw new ArgumentNullException(nameof(invocationData));
        }

        if (invocationData.Parameters.Count != invocationData.Arguments.Count)
        {
            return false;
        }

        for (var i = 0; i < invocationData.Parameters.Count; i++)
        {
            if (TryRecordArgument(recorder, invocationData.Parameters[i], invocationData.Arguments[i]) is false)
            {
                return false;
            }
        }

        return true;
    }

    private bool TryRecordArgument(IArgumentDataRecorder<IMethodParameter, ISemanticAttributeConstructorArgumentData> recorder, IParameterSymbol parameterSymbol, TypedConstant argumentValue)
    {
        var parameter = ParameterFactory.Create(parameterSymbol);
        var argumentData = ArgumentDataFactory.Create(argumentValue);

        return recorder.TryRecordData(parameter, argumentData);
    }
}
