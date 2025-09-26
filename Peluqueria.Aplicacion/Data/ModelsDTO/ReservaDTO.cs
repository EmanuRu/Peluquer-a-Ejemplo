using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.Data.ModelsDTO
{//clase ReservaDTO de la capa Aplicación la cual interactua con Reserva de la capa Dominio y la capa de presentación Controller y componentes razor
    public class ReservaDTO
    {
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

        public ClienteDTO? reservaClienteDTO { get; set; } = null!;
        public EstadoReservaDTO? reservaEstadoReservaDTO { get; set; } = null!;
        public ProfesionalDTO? reservaProfecionalDTO { get; set; } = null!;
        public ServicioDTO? reservaServicioDTO { get; set; }=null!;
    }
}
