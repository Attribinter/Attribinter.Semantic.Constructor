namespace Attribinter.Semantic;

using Attribinter.Parameters;

using Microsoft.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;

using System;

/// <summary>Allows the services provided by <i>Attribinter.Semantic.Constructor</i> to be registered with <see cref="IServiceCollection"/>.</summary>
public static class AttribinterSemanticConstructorServices
{
    /// <summary>Registers the services provided by <i>Attribinter.Semantic.Constructor</i> with the provided <see cref="IServiceCollection"/>.</summary>
    /// <param name="services">The <see cref="IServiceCollection"/> with which services are registered.</param>
    /// <returns>The provided <see cref="IServiceCollection"/>, so that calls can be chained.</returns>
    public static IServiceCollection AddAttribinterSemanticConstructor(this IServiceCollection services)
    {
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.AddAttribinterConstructorParameters();

        services.AddTransient<IArgumentParser<IConstructorParameter, TypedConstant, AttributeData>, SemanticConstructorArgumentParser>();

        return services;
    }
}
