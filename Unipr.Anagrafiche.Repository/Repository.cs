using Anagrafiche.Repository.Abstraction;
using Anagrafiche.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace Anagrafiche.Repository;

public class Repository(AnagraficheDbContext anagraficheDbContext) : IRepository
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await anagraficheDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task CreateSoggettoAsync(string nome, string cognome, string codiceFiscale, DateTime dataDiNascita, CancellationToken cancellationToken = default)
    {
        Soggetto soggetto = new Soggetto();
        soggetto.Nome = nome;
        soggetto.Cognome = cognome;
        soggetto.CodiceFiscale = codiceFiscale;
        soggetto.DataDiNascita = dataDiNascita;

        await anagraficheDbContext.Soggetti.AddAsync(soggetto, cancellationToken);
    }

    public async Task<Soggetto?> ReadSoggettoAsync(int idAnagrafica, CancellationToken cancellationToken = default)
    {
        return await anagraficheDbContext.Soggetti.Where(p => p.Id == idAnagrafica).FirstOrDefaultAsync(cancellationToken);
    }
}
