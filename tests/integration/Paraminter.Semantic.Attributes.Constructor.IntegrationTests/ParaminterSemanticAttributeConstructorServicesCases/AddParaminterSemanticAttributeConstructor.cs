namespace Paraminter.Semantic.ParaminterSemanticConstructorServicesCases;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Paraminter.Parameters;

using Xunit;

public sealed class AddParaminterSemanticAttributeConstructor
{
    [Fact]
    public void IArgumentDataParser_ServiceCanBeResolved() => ServiceCanBeResolved<IArgumentDataParser<IMethodParameter, ISemanticAttributeConstructorArgumentData, ISemanticAttributeConstructorInvocationData>>();

    [Fact]
    public void ISemanticAttributeConstructorArgumentDataFactory_ServiceCanBeResolved() => ServiceCanBeResolved<ISemanticAttributeConstructorArgumentDataFactory>();

    [Fact]
    public void ISemanticAttributeConstructorInvocationDataFactory_ServiceCanBeResolved() => ServiceCanBeResolved<ISemanticAttributeConstructorInvocationDataFactory>();

    private static void Target(IServiceCollection services) => ParaminterSemanticAttributeConstructorServices.AddParaminterSemanticAttributeConstructor(services);

    [AssertionMethod]
    private static void ServiceCanBeResolved<TService>()
        where TService : notnull
    {
        HostBuilder host = new();

        host.ConfigureServices(static (services) => Target(services));

        var serviceProvider = host.Build().Services;

        var result = serviceProvider.GetRequiredService<TService>();

        Assert.NotNull(result);
    }
}
