using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Dominio.Models
{
    public class Reserva
    {//clase Reserva de la capa Dominio la cual interactua con ReservaDTO de la capa Aplicación y la capa de infraestructura
        public int IdReserva { get; set; }
        public int IdCliente { get; set; }
        public int IdServicio { get; set; }
        public int IdProfesional { get; set; }
        public DateTime FechaReserva { get; set; }
        public TimeSpan HoraReserva { get; set; }
        public int IdEstado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool? Visible { get; set; } = true;
        /////

        public Cliente reservaCliente { get; set; } = null!;
        public EstadoReserva reservaEstadoReserva { get; set; } = null!;
        public Profesional reservaProfecional { get; set; } = null!;
        public Servicio reservaServicio { get; set; }=null!;
    }
}
