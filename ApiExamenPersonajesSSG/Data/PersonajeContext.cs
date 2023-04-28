using ApiExamenPersonajesSSG.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExamenPersonajesSSG.Data
{
    public class PersonajeContext : DbContext
    {
        public PersonajeContext(DbContextOptions<PersonajeContext> options) : base(options) { }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Personaje> Personajes { get; set; }
    }
}
