using ApiExamenPersonajesSSG.Models;
using ApiExamenPersonajesSSG.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiExamenPersonajesSSG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private RepositoryPersonajes repo;

        public SeriesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Serie>>> Get()
        {
            return await this.repo.GetSeriesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Serie>> FindSerie(int id)
        {
            return await this.repo.FindSerieAsync(id);
        }
        
    }
}
