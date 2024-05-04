namespace Paraminter.Semantic.SemanticAttributeConstructorInvocationDataFactoryCases.SemanticAttributeConstructorInvocationDataCases;

using Microsoft.CodeAnalysis;

using Moq;

using System.Collections.Generic;

internal interface IInvocationDataFixture
{
    public abstract ISemanticAttributeConstructorInvocationData Sut { get; }

    public abstract Mock<IReadOnlyList<IParameterSymbol>> ParametersMock { get; }
    public abstract Mock<IReadOnlyList<TypedConstant>> ArgumentsMock { get; }
}
