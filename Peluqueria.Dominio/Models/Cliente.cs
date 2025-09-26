using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Dominio.Models
{
    public class Cliente
    {//clase Cliente de la capa Dominio la cual interactua con ClienteDTO de la capa Aplicación y la capa de infraestructura
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public DateTime? FechaRegistro { get; set; }
        public bool? Visible { get; set; } = true;
        public List<Reserva> clienteReserva { get; set; }=new List<Reserva>();
    }
}
