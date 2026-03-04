using Anagrafiche.Repository.Model;

namespace Anagrafiche.Repository.Abstraction;

public interface IRepository
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task CreateSoggettoAsync(string nome, string cognome, string codiceFiscale, DateTime dataDiNascita, CancellationToken cancellationToken = default);
    Task<Soggetto?> ReadSoggettoAsync(int idAnagrafica, CancellationToken cancellationToken = default);
}
