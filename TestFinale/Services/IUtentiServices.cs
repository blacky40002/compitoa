using TestFinale.DTO;
using TestFinale.Entities;

namespace TestFinale.Services
{
    public interface IUtentiServices
    {
        Task<List<UtentiDTO>> ReadTuttiUtenti();
        Task<bool> CreateUtente(CreateUtenteDTO u);
        Task<UtentiDTO> ReadUtente(int id);
        Task<bool> RemoveUtente(int id);

    }
}
