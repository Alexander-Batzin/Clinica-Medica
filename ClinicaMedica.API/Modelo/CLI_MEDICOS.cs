using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.API.Modelo
{
    public class CLI_MEDICOS
    {
        [Key]
        public int MED_id { get; set; }
        public int USR_id { get; set; }
        public string MED_nombre { get; set; }
        public string  MED_apellido { get; set; }
        public string MED_tipo { get; set; }
        public int MED_telefono { get; set; }
        public string MED_correo { get; set; }

    }
}







 