using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Peluqueria.Infraestructura.Data.Models
{
    [Table("Reserva")]
    public partial class ReservaEntity
    {//clase ReservaEntity de la capa infraestructura la cual interactua con Reserva de la capa Dominio

        [Key]
        public int IdReserva { get; set; }
        public int IdCliente { get; set; }
        public int IdServicio { get; set; }
        public int IdProfesional { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaReserva { get; set; }
        public TimeSpan HoraReserva { get; set; }
        public int IdEstado { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaCreacion { get; set; }
        [Required]
        public bool? Visible { get; set; }

        [ForeignKey("IdCliente")]
        [InverseProperty("Reservas")]
        public virtual ClienteEntity IdClienteNavigation { get; set; } = null!;
        [ForeignKey("IdEstado")]
        [InverseProperty("Reservas")]
        public virtual EstadoReservaEntity IdEstadoNavigation { get; set; } = null!;
        [ForeignKey("IdProfesional")]
        [InverseProperty("Reservas")]
        public virtual ProfesionalEntity IdProfesionalNavigation { get; set; } = null!;
        [ForeignKey("IdServicio")]
        [InverseProperty("Reservas")]
        public virtual ServicioEntity IdServicioNavigation { get; set; } = null!;
    }
}
