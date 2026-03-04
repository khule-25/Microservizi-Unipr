using Anagrafiche.Shared;

namespace Anagrafiche.ClientHttp.Abstraction;

public interface IClientHttp
{
    Task<string?> CreateSoggettoAsync(SoggettoDto soggetto, CancellationToken cancellationToken = default);
    Task<SoggettoDto?> ReadSoggettoAsync(int idAnagrafica, CancellationToken cancellationToken = default);
    Task<SoggettoDto?> GetFromDemograficoAsync(string codiceFiscale, CancellationToken cancellationToken = default);
}
