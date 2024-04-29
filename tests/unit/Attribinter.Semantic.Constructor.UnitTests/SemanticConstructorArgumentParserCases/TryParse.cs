namespace Attribinter.Semantic.SemanticConstructorArgumentParserCases;

using Attribinter.Parameters;

using Microsoft.CodeAnalysis;

using Moq;

using System;

using Xunit;

public sealed class TryParse
{
    [Fact]
    public void NullRecorder_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!, Mock.Of<AttributeData>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullAttributeData_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(Mock.Of<IArgumentRecorder<IConstructorParameter, TypedConstant>>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullAttributeConstructor_ReturnsFalse()
    {
        CustomAttributeData attributeData = new();

        Mock<IArgumentRecorder<IConstructorParameter, TypedConstant>> recorderMock = new();

        var result = Target(recorderMock.Object, attributeData);

        Assert.False(result);

        recorderMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void MoreParametersThanArguments_ReturnsFalse()
    {
        var parameter = Mock.Of<IParameterSymbol>();

        Mock<IMethodSymbol> attributeConstructorMock = new();

        attributeConstructorMock.Setup(static (method) => method.Parameters).Returns([parameter]);

        CustomAttributeData attributeData = new() { AttributeConstructor = attributeConstructorMock.Object, ConstructorArguments = [] };

        Mock<IArgumentRecorder<IConstructorParameter, TypedConstant>> recorderMock = new();

        var result = Target(recorderMock.Object, attributeData);

        Assert.False(result);

        recorderMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void MoreArgumentsThanParameters_ReturnsFalse()
    {
        var argument = TypedConstantStore.GetNext();

        Mock<IMethodSymbol> attributeConstructorMock = new();

        attributeConstructorMock.Setup(static (method) => method.Parameters).Returns([]);

        CustomAttributeData attributeData = new() { AttributeConstructor = attributeConstructorMock.Object, ConstructorArguments = [argument] };

        Mock<IArgumentRecorder<IConstructorParameter, TypedConstant>> recorderMock = new();

        var result = Target(recorderMock.Object, attributeData);

        Assert.False(result);

        recorderMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void FalseReturningRecorder_ReturnsFalse()
    {
        var parameterSymbol1 = Mock.Of<IParameterSymbol>();
        var parameterSymbol2 = Mock.Of<IParameterSymbol>();
        var parameterSymbol3 = Mock.Of<IParameterSymbol>();

        var parameter1 = Mock.Of<IConstructorParameter>();
        var parameter2 = Mock.Of<IConstructorParameter>();
        var parameter3 = Mock.Of<IConstructorParameter>();

        var argument1 = TypedConstantStore.GetNext();
        var argument2 = TypedConstantStore.GetNext();
        var argument3 = TypedConstantStore.GetNext();

        Fixture.ParameterFactoryMock.Setup((factory) => factory.Create(parameterSymbol1)).Returns(parameter1);
        Fixture.ParameterFactoryMock.Setup((factory) => factory.Create(parameterSymbol2)).Returns(parameter2);
        Fixture.ParameterFactoryMock.Setup((factory) => factory.Create(parameterSymbol3)).Returns(parameter3);

        Mock<IMethodSymbol> attributeConstructorMock = new();

        attributeConstructorMock.Setup(static (method) => method.Parameters).Returns([parameterSymbol1, parameterSymbol2, parameterSymbol3]);

        CustomAttributeData attributeData = new() { AttributeConstructor = attributeConstructorMock.Object, ConstructorArguments = [argument1, argument2, argument3] };

        Mock<IArgumentRecorder<IConstructorParameter, TypedConstant>> recorderMock = new();

        recorderMock.Setup((recorder) => recorder.TryRecordData(parameter1, argument1)).Returns(true);
        recorderMock.Setup((recorder) => recorder.TryRecordData(parameter2, argument2)).Returns(true);
        recorderMock.Setup((recorder) => recorder.TryRecordData(parameter3, argument3)).Returns(true);
        recorderMock.Setup((recorder) => recorder.TryRecordData(parameter2, argument2)).Returns(false);

        var result = Target(recorderMock.Object, attributeData);

        Assert.False(result);

        recorderMock.Verify((recorder) => recorder.TryRecordData(parameter1, argument1), Times.Once());
        recorderMock.Verify((recorder) => recorder.TryRecordData(parameter2, argument2), Times.Once());

        recorderMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void TrueReturningRecorder_RecordsAllArguments_ReturnsTrue()
    {
        var parameterSymbol1 = Mock.Of<IParameterSymbol>();
        var parameterSymbol2 = Mock.Of<IParameterSymbol>();

        var parameter1 = Mock.Of<IConstructorParameter>();
        var parameter2 = Mock.Of<IConstructorParameter>();

        var argument1 = TypedConstantStore.GetNext();
        var argument2 = TypedConstantStore.GetNext();

        Fixture.ParameterFactoryMock.Setup((factory) => factory.Create(parameterSymbol1)).Returns(parameter1);
        Fixture.ParameterFactoryMock.Setup((factory) => factory.Create(parameterSymbol2)).Returns(parameter2);

        Mock<IMethodSymbol> attributeConstructorMock = new();

        attributeConstructorMock.Setup(static (method) => method.Parameters).Returns([parameterSymbol1, parameterSymbol2]);

        CustomAttributeData attributeData = new() { AttributeConstructor = attributeConstructorMock.Object, ConstructorArguments = [argument1, argument2] };

        Mock<IArgumentRecorder<IConstructorParameter, TypedConstant>> recorderMock = new();

        recorderMock.Setup((recorder) => recorder.TryRecordData(parameter1, argument1)).Returns(true);
        recorderMock.Setup((recorder) => recorder.TryRecordData(parameter2, argument2)).Returns(true);

        var result = Target(recorderMock.Object, attributeData);

        Assert.True(result);

        recorderMock.Verify((recorder) => recorder.TryRecordData(parameter1, argument1), Times.Once());
        recorderMock.Verify((recorder) => recorder.TryRecordData(parameter2, argument2), Times.Once());

        recorderMock.VerifyNoOtherCalls();
    }

    private bool Target(IArgumentRecorder<IConstructorParameter, TypedConstant> recorder, AttributeData attributeData) => Fixture.Sut.TryParse(recorder, attributeData);

    private readonly IParserFixture Fixture = ParserFixtureFactory.Create();
}
