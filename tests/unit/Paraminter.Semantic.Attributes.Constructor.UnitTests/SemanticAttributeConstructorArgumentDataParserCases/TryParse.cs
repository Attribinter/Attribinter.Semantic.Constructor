﻿namespace Paraminter.Semantic.SemanticAttributeConstructorArgumentDataParserCases;

using Microsoft.CodeAnalysis;

using Moq;

using Paraminter.Parameters;

using System;

using Xunit;

public sealed class TryParse
{
    [Fact]
    public void NullRecorder_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!, Mock.Of<ISemanticAttributeConstructorInvocationData>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullInvocationData_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(Mock.Of<IArgumentDataRecorder<IConstructorParameter, ISemanticAttributeConstructorArgumentData>>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void MoreParametersThanArguments_ReturnsFalse()
    {
        var parameter = Mock.Of<IParameterSymbol>();

        Mock<ISemanticAttributeConstructorInvocationData> invocationDataMock = new();

        invocationDataMock.Setup(static (invocationData) => invocationData.Parameters).Returns([parameter]);
        invocationDataMock.Setup(static (invocationData) => invocationData.Arguments).Returns([]);

        Mock<IArgumentDataRecorder<IConstructorParameter, ISemanticAttributeConstructorArgumentData>> recorderMock = new();

        var result = Target(recorderMock.Object, invocationDataMock.Object);

        Assert.False(result);

        recorderMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void MoreArgumentsThanParameters_ReturnsFalse()
    {
        var argument = TypedConstantStore.GetNext();

        Mock<ISemanticAttributeConstructorInvocationData> invocationDataMock = new();

        invocationDataMock.Setup(static (invocationData) => invocationData.Parameters).Returns([]);
        invocationDataMock.Setup(static (invocationData) => invocationData.Arguments).Returns([argument]);

        Mock<IArgumentDataRecorder<IConstructorParameter, ISemanticAttributeConstructorArgumentData>> recorderMock = new();

        var result = Target(recorderMock.Object, invocationDataMock.Object);

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

        var argumentValue1 = TypedConstantStore.GetNext();
        var argumentValue2 = TypedConstantStore.GetNext();
        var argumentValue3 = TypedConstantStore.GetNext();

        var argumentData1 = Mock.Of<ISemanticAttributeConstructorArgumentData>();
        var argumentData2 = Mock.Of<ISemanticAttributeConstructorArgumentData>();

        Fixture.ParameterFactoryMock.Setup((factory) => factory.Create(parameterSymbol1)).Returns(parameter1);
        Fixture.ParameterFactoryMock.Setup((factory) => factory.Create(parameterSymbol2)).Returns(parameter2);

        Fixture.ArgumentDataFactoryMock.Setup((factory) => factory.Create(argumentValue1)).Returns(argumentData1);
        Fixture.ArgumentDataFactoryMock.Setup((factory) => factory.Create(argumentValue2)).Returns(argumentData2);

        Mock<ISemanticAttributeConstructorInvocationData> invocationDataMock = new();

        invocationDataMock.Setup(static (invocationData) => invocationData.Parameters).Returns([parameterSymbol1, parameterSymbol2, parameterSymbol3]);
        invocationDataMock.Setup(static (invocationData) => invocationData.Arguments).Returns([argumentValue1, argumentValue2, argumentValue3]);

        Mock<IArgumentDataRecorder<IConstructorParameter, ISemanticAttributeConstructorArgumentData>> recorderMock = new();

        recorderMock.Setup((recorder) => recorder.TryRecordData(parameter1, argumentData1)).Returns(true);
        recorderMock.Setup((recorder) => recorder.TryRecordData(parameter2, argumentData2)).Returns(false);

        var result = Target(recorderMock.Object, invocationDataMock.Object);

        Assert.False(result);

        recorderMock.Verify((recorder) => recorder.TryRecordData(parameter1, argumentData1), Times.Once());
        recorderMock.Verify((recorder) => recorder.TryRecordData(parameter2, argumentData2), Times.Once());

        recorderMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void TrueReturningRecorder_RecordsAllArguments_ReturnsTrue()
    {
        var parameterSymbol1 = Mock.Of<IParameterSymbol>();
        var parameterSymbol2 = Mock.Of<IParameterSymbol>();

        var parameter1 = Mock.Of<IConstructorParameter>();
        var parameter2 = Mock.Of<IConstructorParameter>();

        var argumentValue1 = TypedConstantStore.GetNext();
        var argumentValue2 = TypedConstantStore.GetNext();

        var argumentData1 = Mock.Of<ISemanticAttributeConstructorArgumentData>();
        var argumentData2 = Mock.Of<ISemanticAttributeConstructorArgumentData>();

        Fixture.ParameterFactoryMock.Setup((factory) => factory.Create(parameterSymbol1)).Returns(parameter1);
        Fixture.ParameterFactoryMock.Setup((factory) => factory.Create(parameterSymbol2)).Returns(parameter2);

        Fixture.ArgumentDataFactoryMock.Setup((factory) => factory.Create(argumentValue1)).Returns(argumentData1);
        Fixture.ArgumentDataFactoryMock.Setup((factory) => factory.Create(argumentValue2)).Returns(argumentData2);

        Mock<ISemanticAttributeConstructorInvocationData> invocationDataMock = new();

        invocationDataMock.Setup(static (invocationData) => invocationData.Parameters).Returns([parameterSymbol1, parameterSymbol2]);
        invocationDataMock.Setup(static (invocationData) => invocationData.Arguments).Returns([argumentValue1, argumentValue2]);

        Mock<IArgumentDataRecorder<IConstructorParameter, ISemanticAttributeConstructorArgumentData>> recorderMock = new();

        recorderMock.Setup((recorder) => recorder.TryRecordData(parameter1, argumentData1)).Returns(true);
        recorderMock.Setup((recorder) => recorder.TryRecordData(parameter2, argumentData2)).Returns(true);

        var result = Target(recorderMock.Object, invocationDataMock.Object);

        Assert.True(result);

        recorderMock.Verify((recorder) => recorder.TryRecordData(parameter1, argumentData1), Times.Once());
        recorderMock.Verify((recorder) => recorder.TryRecordData(parameter2, argumentData2), Times.Once());

        recorderMock.VerifyNoOtherCalls();
    }

    private bool Target(IArgumentDataRecorder<IConstructorParameter, ISemanticAttributeConstructorArgumentData> recorder, ISemanticAttributeConstructorInvocationData invocationData) => Fixture.Sut.TryParse(recorder, invocationData);

    private readonly IParserFixture Fixture = ParserFixtureFactory.Create();
}
