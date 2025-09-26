using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.Data.ModelsDTO
{//clase ClienteDTO de la capa Aplicación la cual interactua con Cliente de la capa Dominio y la capa de presentación Controller y componentes razor
    public class ClienteDTO
    {
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string Apellido { get; set; } = null!;
        public DateTime? FechaRegistro { get; set; }
        public bool? Visible { get; set; } = true;
        public List<ReservaDTO> clienteReservaDTO { get; set; }=new List<ReservaDTO>();
    }
}
