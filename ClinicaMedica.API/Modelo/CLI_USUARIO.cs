using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.API.Modelo
{
    public class CLI_USUARIO
    {
        [Key]
        public int USR_id { get; set; }
        public string USR_usuario { get; set; }
        public string USR_contrasena { get; set; }
    }
}
