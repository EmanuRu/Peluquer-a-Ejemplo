using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.Data.ModelsDTO
{//clase ServicioDTO de la capa Aplicación la cual interactua con Servicio de la capa Dominio y la capa de presentación Controller y componentes razor
    public class ServicioDTO
    {
        public int IdServicio { get; set; }
        [Required(ErrorMessage = "El nombre del servicio es obligatorio")]
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "La duración del servicio obligatoria")]
        public int DuracionMinutos { get; set; }
        public bool? Visible { get; set; } = true;
        public List<ReservaDTO> servicioReservasDTO { get; set; } = new List<ReservaDTO>();
        //public virtual ICollection<ReservaEntity> Reservas { get; set; }
    }
}
