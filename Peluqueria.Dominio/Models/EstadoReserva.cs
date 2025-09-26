using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Dominio.Models
{
    public class EstadoReserva
    {//clase EstadoReserva de la capa Dominio la cual interactua con EstadoReservaDTO de la capa Aplicación y la capa de infraestructura
        public int IdEstado { get; set; }
        public string NombreEstado { get; set; } = null!;
        public bool? Visible { get; set; } = true;
        public List<Reserva> reservas { get; set; }= new List<Reserva>();
        //public virtual ICollection<ReservaEntity> Reservas { get; set; }
    }
}
