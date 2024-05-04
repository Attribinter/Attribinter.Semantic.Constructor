namespace Paraminter.Semantic;

using Microsoft.CodeAnalysis;

using Paraminter.Parameters;

using System;

/// <summary>Parses the attribute constructor arguments.</summary>
public sealed class SemanticAttributeConstructorArgumentDataParser : IArgumentDataParser<IConstructorParameter, ISemanticAttributeConstructorArgumentData, ISemanticAttributeConstructorInvocationData>
{
    private readonly IConstructorParameterFactory ParameterFactory;
    private readonly ISemanticAttributeConstructorArgumentDataFactory ArgumentDataFactory;

    /// <summary>Instantiates a <see cref="SemanticAttributeConstructorArgumentDataParser"/>, parsing the attribute constructor arguments.</summary>
    /// <param name="parameterFactory">Handles creation of <see cref="IConstructorParameter"/>.</param>
    /// <param name="argumentDataFactory">Handles creation of <see cref="ISemanticAttributeConstructorArgumentData"/>.</param>
    public SemanticAttributeConstructorArgumentDataParser(IConstructorParameterFactory parameterFactory, ISemanticAttributeConstructorArgumentDataFactory argumentDataFactory)
    {
        ParameterFactory = parameterFactory ?? throw new ArgumentNullException(nameof(parameterFactory));
        ArgumentDataFactory = argumentDataFactory ?? throw new ArgumentNullException(nameof(argumentDataFactory));
    }

    bool IArgumentDataParser<IConstructorParameter, ISemanticAttributeConstructorArgumentData, ISemanticAttributeConstructorInvocationData>.TryParse(IArgumentDataRecorder<IConstructorParameter, ISemanticAttributeConstructorArgumentData> recorder, ISemanticAttributeConstructorInvocationData invocationData)
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

    private bool TryRecordArgument(IArgumentDataRecorder<IConstructorParameter, ISemanticAttributeConstructorArgumentData> recorder, IParameterSymbol parameterSymbol, TypedConstant argumentValue)
    {
        var parameter = ParameterFactory.Create(parameterSymbol);
        var argumentData = ArgumentDataFactory.Create(argumentValue);

        return recorder.TryRecordData(parameter, argumentData);
    }
}
