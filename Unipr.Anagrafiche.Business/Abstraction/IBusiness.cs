using Anagrafiche.Shared;

namespace Anagrafiche.Business.Abstraction;

public interface IBusiness
{
    Task CreateSoggettoAsync(SoggettoDto soggetto, CancellationToken cancellationToken = default);
    Task<SoggettoDto?> ReadSoggettoAsync(int idAnagrafica, CancellationToken cancellationToken = default);
    Task<SoggettoDto> GetFromDemograficoAsync(string codiceFiscale, CancellationToken cancellationToken = default);
}
