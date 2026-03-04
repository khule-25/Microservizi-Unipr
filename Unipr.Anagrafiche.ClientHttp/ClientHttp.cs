using Anagrafiche.ClientHttp.Abstraction;
using Anagrafiche.Shared;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Net.Http.Json;

namespace Anagrafiche.ClientHttp;

public class ClientHttp(HttpClient httpClient) : IClientHttp
{
    public async Task<string?> CreateSoggettoAsync(SoggettoDto soggetto, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsync($"/Soggetto/CreateSoggetto", JsonContent.Create(soggetto), cancellationToken);
        return await response.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<string>(cancellationToken: cancellationToken);
    }

    public async Task<SoggettoDto?> ReadSoggettoAsync(int idAnagrafica, CancellationToken cancellationToken = default)
    {
        var queryString = QueryString.Create(new Dictionary<string, string?>() {
            { "idAnagrafica", idAnagrafica.ToString(CultureInfo.InvariantCulture) }
        });
        var response = await httpClient.GetAsync($"/Soggetto/ReadSoggetto{queryString}", cancellationToken);
        return await response.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<SoggettoDto?>(cancellationToken: cancellationToken);
    }

    public async Task<SoggettoDto?> GetFromDemograficoAsync(string codiceFiscale, CancellationToken cancellationToken = default)
    {
        var queryString = QueryString.Create(new Dictionary<string, string?>() {
            { "codiceFiscale", codiceFiscale.ToString(CultureInfo.InvariantCulture) }
        });
        var response = await httpClient.GetAsync($"/Soggetto/GetFromDemografico{queryString}", cancellationToken);
        return await response.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<SoggettoDto>(cancellationToken: cancellationToken);
    }
}
