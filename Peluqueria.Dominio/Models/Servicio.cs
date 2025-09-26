using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Dominio.Models
{
    public class Servicio
    {//clase Reserva de la capa Dominio la cual interactua con ReservaDTO de la capa Aplicación y la capa de infraestructura
        public int IdServicio { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int DuracionMinutos { get; set; }
        public bool? Visible { get; set; } = true;
        public List<Reserva> servicioReservas { get; set; } = new List<Reserva>();
    }
}
