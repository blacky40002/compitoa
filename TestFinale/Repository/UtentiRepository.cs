using Microsoft.EntityFrameworkCore;
using TestFinale.DataSource;
using TestFinale.Entities;

namespace TestFinale.Repository
{
    public class UtentiRepository : IUtentiRepository
    {
        private readonly UtentiContext _context;

        public UtentiRepository(UtentiContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteUtente(int id)
        {
            using (_context)
            {
                try
                {


                    Utente? u = await GetUtente(id);
                    _context.Entry(u).State = EntityState.Deleted;
                    int numeroCancellati = await _context.SaveChangesAsync();
                    if (numeroCancellati != 1)
                    {
                        string messaggioErrore = "Operazione di cancellazione non effettuata";
                        throw new Exception(messaggioErrore);
                    }
                    return true;

                }
                catch (Exception ex) { throw; }

            }

        }

        public async Task<List<Utente>> GetTuttiUtenti()
        {
            using(_context)
            {
                try
                {
                    var listaUtenti = await _context.Utenti.ToListAsync();
                    if (listaUtenti.Count > 0 && listaUtenti != null) { return listaUtenti; }
                    throw new ArgumentNullException("lista utenti vuota");
                }
                catch (Exception)
                {
                    throw;
                }
                
            }   
        }

        public async Task<Utente> GetUtente(int id)
        {
            try
            {
                Utente? utente = await _context.Utenti.FindAsync(id);
                if (utente != null) { return utente; }
                throw new ArgumentNullException("utente non trovate");

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> PostUtente(Utente u)
        {

            try
            {
                Utente? utente = await _context.Utenti.FirstOrDefaultAsync(item => item.Username == u.Username);
                if (utente != null) throw new Exception("utente già presente");
                _context.Entry(u).State = EntityState.Added;
                var numeroInseriti = await _context.SaveChangesAsync();
                if (numeroInseriti < 1)
                {
                    string messaggioErrore = "Operazione di inserimento non effettuata";
                    throw new Exception(messaggioErrore);
                }
                return true;

            }
            catch (Exception ex)
            {
                throw;
            }

        }


    }
}
