using ClinicaMedica.API.Context;
using ClinicaMedica.API.Modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaMedica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext usuario;

        public UsuarioController(AppDbContext usuario)
        {
            this.usuario = usuario;
        }

        [HttpGet]
        public async Task<List<CLI_USUARIO>> Listar()
        {
            return await usuario.CLI_USUARIO.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CLI_USUARIO>> BuscarPorId(decimal Id)
        {
            var resultado = await usuario.CLI_USUARIO.FirstOrDefaultAsync(x => x.USR_id == Id);
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
        public async Task<ActionResult<CLI_USUARIO>> Insertar(CLI_USUARIO u)
        {
            try
            {
                await usuario.CLI_USUARIO.AddAsync(u);
                await usuario.SaveChangesAsync();
                u.USR_id = await usuario.CLI_USUARIO.MaxAsync(x => x.USR_id);

                return u;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CLI_USUARIO>> Actualizar(CLI_USUARIO u)
        {
            if(u == null || u.USR_id == 0)
               return BadRequest("No Contiene Datos");
            CLI_USUARIO temp = await usuario.CLI_USUARIO.FirstOrDefaultAsync(x => x.USR_id == u.USR_id);
            if(temp == null)
                return NotFound();
            try
            {
                temp.USR_usuario = u.USR_usuario;
                temp.USR_contrasena = u.USR_contrasena;
                usuario.CLI_USUARIO.Update(temp);
                await usuario.SaveChangesAsync();

                return temp;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(decimal Id)
        {
            CLI_USUARIO temp = await usuario.CLI_USUARIO.FirstOrDefaultAsync(x => x.USR_id == Id);
            if(temp == null)
                return NotFound();
            try
            {
                usuario.CLI_USUARIO.Remove(temp);
                await usuario.SaveChangesAsync();
                return true;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
