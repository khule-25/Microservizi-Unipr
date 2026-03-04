using Anagrafiche.ClientHttp;
using Anagrafiche.ClientHttp.Abstraction;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class UniprAnagraficheClientExtensions {

    public static IServiceCollection AddUniprAnagraficheClient(this IServiceCollection services, IConfiguration configuration) {

        IConfigurationSection confSection = configuration.GetSection(UniprAnagraficheClientOptions.SectionName);
        UniprAnagraficheClientOptions options = confSection.Get<UniprAnagraficheClientOptions>() ?? new();

        services.AddHttpClient<IClientHttp, ClientHttp>(o => {          
            o.BaseAddress = new Uri(options.BaseAddress);
        }).ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
        });

        return services;
    }
}
