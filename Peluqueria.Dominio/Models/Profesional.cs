using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Dominio.Models
{
    public class Profesional
    {//clase Profesional de la capa Dominio la cual interactua con ProfesionalDTO de la capa Aplicación y la capa de infraestructura
        public int IdProfesional { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string? Especialidad { get; set; }
        public string Telefono { get; set; } = null!;
        public bool? Visible { get; set; } = true;
        public List<Reserva> reservasProfesional { get; set; }= new List<Reserva>();
    }
}
