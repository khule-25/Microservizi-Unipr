using Anagrafiche.Business.Abstraction;
using Anagrafiche.Repository.Abstraction;
using Anagrafiche.Shared;
using Microsoft.Extensions.Logging;

namespace Anagrafiche.Business;

public class Business(IRepository repository, ILogger<Business> logger) : IBusiness
{
    public async Task CreateSoggettoAsync(SoggettoDto soggetto, CancellationToken cancellationToken = default)
    {
        await repository.CreateSoggettoAsync(soggetto.Nome, soggetto.Cognome, soggetto.CodiceFiscale, soggetto.DataDiNascita, cancellationToken);

        await repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<SoggettoDto?> ReadSoggettoAsync(int idAnagrafica, CancellationToken cancellationToken = default)
    {
        var soggetto = await repository.ReadSoggettoAsync(idAnagrafica, cancellationToken);

        if (soggetto is null)
            return null;

        return new SoggettoDto
        {
            Nome = soggetto.Nome,
            Cognome = soggetto.Cognome,
            CodiceFiscale = soggetto.CodiceFiscale,
            DataDiNascita = soggetto.DataDiNascita,
        };
    }

    public async Task<SoggettoDto> GetFromDemograficoAsync(string codiceFiscale, CancellationToken cancellationToken = default)
    {
        // qui chiamaremo il nostro demografico
        // demograficoClient.GetSoggetto(codiceFiscale, cancellationToken);
        return await Task.FromResult<SoggettoDto>(new SoggettoDto());
    }
}
