using TestFinale.DTO;
using TestFinale.Entities;
using TestFinale.Repository;

namespace TestFinale.Services
{
    public class UtentiServices : IUtentiServices
    {
    IUtentiRepository _repository;
        public UtentiServices(IUtentiRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> CreateUtente(CreateUtenteDTO u)
        {
            try
            {

                Utente utente = new Utente()
                {
                   
                    Password = u.Password,
                    Username = u.Username,
                    NomeUtente = u.NomeUtente,

                };

                return await _repository.PostUtente(utente);
            }
            catch (Exception ex) { throw; }
        }

        public async Task<List<UtentiDTO>> ReadTuttiUtenti()
        {

            try
            {

                var listaUtentiDto = from u in await _repository.GetTuttiUtenti()
                                     select new UtentiDTO()
                                     {
                                         UtenteId = u.UtenteId,
                                         Password = u.Password,
                                         Username = u.Username,
                                         NomeUtente = u.NomeUtente,
                                     };


                return listaUtentiDto.ToList();
            }
            catch { throw; }
        }

        public async Task<UtentiDTO> ReadUtente(int id)
        {
            try
            {
                var u = await _repository.GetUtente(id);
                var utentedto  = new UtentiDTO()
                {
                    UtenteId = u.UtenteId,
                    Password = u.Password,
                    Username = u.Username,
                    NomeUtente = u.NomeUtente,
                };


                return utentedto;
            }
            catch { throw; }
        }

        public async Task<bool> RemoveUtente(int id)
        {
            try
            {
                return await _repository.DeleteUtente(id);
            }
            catch { throw; }
        }
    }
}
