using Microsoft.AspNetCore.Mvc;
using TestFinale.DTO;
using TestFinale.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestFinale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtentiController : ControllerBase
    {
      private IUtentiServices _services;

        public UtentiController(IUtentiServices services)
        {
            _services = services;
        }


        [HttpGet]
        public async Task<ActionResult<List<UtentiDTO>>> Get()
        {
            try
            {
                var utenti = await _services.ReadTuttiUtenti();
                return utenti == null ? NotFound() : Ok(utenti);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET api/<UtentiController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UtentiDTO>> GetAsync(int id)
        {
            if (id < 1) return BadRequest("id non valido");
            try
            {
                var utente = await _services.ReadUtente(id);
                return utente == null ? NotFound() : Ok(utente);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<UtentiController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateUtenteDTO utenti)
        {
            try
            {
                await  _services.CreateUtente(utenti);
                return Ok("utente creato");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/<UtentiController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id < 1) return BadRequest("id non valido");
            try
            {
                await _services.RemoveUtente(id);
                return Ok("utente cancellato");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

