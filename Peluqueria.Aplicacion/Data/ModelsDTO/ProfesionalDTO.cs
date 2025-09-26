using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.Data.ModelsDTO
{
    public class ProfesionalDTO
    {//clase ProfesionalDTO de la capa Aplicación la cual interactua con Profesional de la capa Dominio y la capa de presentación Controller y componentes razor
        public int IdProfesional { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string Apellido { get; set; } = null!;
        public string? Especialidad { get; set; }
        [Required(ErrorMessage = "El telefono es obligatorio")]
        [RegularExpression(@"^[0-9]{7,20}$", ErrorMessage = "El telefono debe contener solo números")]
        public string Telefono { get; set; }= null!;
        public bool? Visible { get; set; } = true;
        public List<ReservaDTO> reservasProfesionalDTO { get; set; }= new List<ReservaDTO>();
    }
}
