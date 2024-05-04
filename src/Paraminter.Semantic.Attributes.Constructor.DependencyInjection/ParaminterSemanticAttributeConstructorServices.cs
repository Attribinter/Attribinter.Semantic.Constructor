namespace Paraminter.Semantic;

using Microsoft.Extensions.DependencyInjection;

using Paraminter.Parameters;

using System;

/// <summary>Allows the services provided by <i>Paraminter.Semantic.Attributes.Constructor</i> to be registered with <see cref="IServiceCollection"/>.</summary>
public static class ParaminterSemanticAttributeConstructorServices
{
    /// <summary>Registers the services provided by <i>Paraminter.Semantic.Attributes.Constructor</i> with the provided <see cref="IServiceCollection"/>.</summary>
    /// <param name="services">The <see cref="IServiceCollection"/> with which services are registered.</param>
    /// <returns>The provided <see cref="IServiceCollection"/>, so that calls can be chained.</returns>
    public static IServiceCollection AddParaminterSemanticAttributeConstructor(this IServiceCollection services)
    {
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.AddParaminterConstructorParameters();

        services.AddTransient<IArgumentDataParser<IConstructorParameter, ISemanticAttributeConstructorArgumentData, ISemanticAttributeConstructorInvocationData>, SemanticAttributeConstructorArgumentDataParser>();

        services.AddTransient<ISemanticAttributeConstructorArgumentDataFactory, SemanticAttributeConstructorArgumentDataFactory>();
        services.AddTransient<ISemanticAttributeConstructorInvocationDataFactory, SemanticAttributeConstructorInvocationDataFactory>();

        return services;
    }
}
