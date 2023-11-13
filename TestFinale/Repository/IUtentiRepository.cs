using TestFinale.Entities;

namespace TestFinale.Repository
{
    public interface IUtentiRepository
    {
        Task<List<Utente>> GetTuttiUtenti();
        Task<bool> PostUtente(Utente u);
        Task<Utente> GetUtente(int id);
        Task<bool> DeleteUtente(int id);
    }
}
