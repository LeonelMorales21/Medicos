using Medico.Data;
using Medico.Models;
using Microsoft.EntityFrameworkCore;

namespace Medico.Services
{
    public class CitasService (ApplicationDbContext context) : ICitas
    {
        public async Task<List<Cita>> ObtenerCitasHoy()
        {
            List<Cita> citas = new List<Cita>();
            //Mira como usamos el include para consultar otras tablas diciendo
            //Que nos traiga todo de la tabla paciente de ese registro.
            citas = await context.Citas.Include(p => p.Paciente)
                .OrderByDescending(f => f.Fecha).ToListAsync();
            //await Task.Delay(3000);
            return citas;
        }
    }
}
