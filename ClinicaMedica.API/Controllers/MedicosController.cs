using ClinicaMedica.API.Context;
using ClinicaMedica.API.Modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaMedica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly AppDbContext medico;

        public MedicosController(AppDbContext medico)
        {
            this.medico = medico;
        }

        [HttpGet]
        public async Task<List<CLI_MEDICOS>> Listar()
        {
            return await medico.CLI_MEDICOS.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CLI_MEDICOS>> BuscarPorId(decimal Id)
        {
            var resultado = await medico.CLI_MEDICOS.FirstOrDefaultAsync(x => x.MED_id == Id);
            if (resultado != null)
            {
                return resultado;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<CLI_MEDICOS>> Insertar(CLI_MEDICOS m)
        {
            try
            {
                await medico.CLI_MEDICOS.AddAsync(m);
                await medico.SaveChangesAsync();
                m.MED_id = await medico.CLI_MEDICOS.MaxAsync(x => x.MED_id);

                return m;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
