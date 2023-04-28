using ApiExamenPersonajesSSG.Models;
using ApiExamenPersonajesSSG.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiExamenPersonajesSSG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonajes repo;

        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> Get()
        {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personaje>> FindPersonaje(int id)
        {
            return await this.repo.FindPersonajeAsync(id);
        }


        [HttpPost]
        public async Task<ActionResult>
            InsertPersonaje(Personaje personaje)
        {
            await this.repo.InsertPersonajeAsync(personaje.Nombre
                , personaje.Imagen, personaje.IdSerie);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult>
            UpdatePersonaje(Personaje personaje)
        {
            await this.repo.UpdatePersonajeAsync( personaje.IdPersonaje ,personaje.Nombre
                , personaje.Imagen, personaje.IdSerie);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePersonaje(int id)
        {
            await this.repo.DeletePersonajeAsync(id);
            return Ok();
        }


        [HttpGet("[action]/{idserie}")]
        public async Task<ActionResult<List<Personaje>>> PersonajesSerie(int idserie)
        {
            return await this.repo.GetPersonajesSerieAsync(idserie);
        }

        [HttpPut("[action]/{idpersonaje}/{idserie}")]
        public async Task<ActionResult> UpdatePersonajeSerie(int idpersonaje, int idserie)
        {
           await this.repo.UpdatePersonajeSerieAsync(idpersonaje,idserie);
            return Ok();
        }
    }
}
