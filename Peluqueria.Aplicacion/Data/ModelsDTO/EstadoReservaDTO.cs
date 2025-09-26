using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.Data.ModelsDTO
{
    public class EstadoReservaDTO
    {//clase EstadoReservaDTO de la capa Aplicación la cual interactua con EstadoReserva de la capa Dominio y la capa de presentación Controller y componentes razor
        public int IdEstado { get; set; }
        [Required(ErrorMessage = "La descripción del estado es obligatoria")]
        public string NombreEstado { get; set; } = null!;
        public bool? Visible { get; set; } = true;
        public List<ReservaDTO> EstadoReservasDTO { get; set; }= new List<ReservaDTO>();
        //public virtual ICollection<ReservaEntity> Reservas { get; set; }
    }
}
