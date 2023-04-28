using ApiExamenPersonajesSSG.Data;
using ApiExamenPersonajesSSG.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExamenPersonajesSSG.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajeContext context;

        public RepositoryPersonajes(PersonajeContext context)
        {
            this.context = context;
        }

        #region SERIES

        public async Task<List<Serie>> GetSeriesAsync()
        {
            return await this.context.Series.ToListAsync();
        }

        public async Task<Serie> FindSerieAsync(int idserie)
        {
            return await this.context.Series.FirstOrDefaultAsync(x => x.IdSerie == idserie);
        }

        #endregion

        #region PERSONAJES

        private async Task<int> GetMaxIdPersonajesAsync()
        {
            if (this.context.Personajes.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await this.context.Personajes.MaxAsync(z => z.IdPersonaje) + 1;
            }
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<List<Personaje>> GetPersonajesSerieAsync(int idserie)
        {
            return await this.context.Personajes.Where(x=> x.IdSerie == idserie).ToListAsync();
        }


        public async Task<Personaje> FindPersonajeAsync(int idpersonaje)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == idpersonaje);
        }

        public async Task InsertPersonajeAsync(string nombre, string imagen, int idserie)
        {
            Personaje personaje = new Personaje();
            personaje.IdPersonaje = await this.GetMaxIdPersonajesAsync();
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.IdSerie = idserie;
            this.context.Personajes.Add(personaje);
            this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonajeAsync(int idpersonaje, string nombre, string imagen, int idserie)
        {
            Personaje personaje = await this.FindPersonajeAsync(idpersonaje);
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.IdSerie = idserie;
            this.context.SaveChangesAsync();
        }


        public async Task UpdatePersonajeSerieAsync(int idpersonaje, int idserie)
        {
            Personaje personaje = await this.FindPersonajeAsync(idpersonaje);
            personaje.IdSerie = idserie;
            this.context.SaveChangesAsync();
        }

        public async Task DeletePersonajeAsync(int idpersonaje)
        {
            Personaje personaje = await this.FindPersonajeAsync(idpersonaje);
            this.context.Personajes.Remove(personaje);
            this.context.SaveChangesAsync();
        }

        #endregion

    }
}
