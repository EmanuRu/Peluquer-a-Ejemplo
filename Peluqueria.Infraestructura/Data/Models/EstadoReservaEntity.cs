using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Peluqueria.Infraestructura.Data.Models
{
    [Table("EstadoReserva")]
    public partial class EstadoReservaEntity
    {//clase EstadoReservaEntity de la capa infraestructura la cual interactua con EstadoReserva de la capa Dominio
        public EstadoReservaEntity()
        {
            Reservas = new HashSet<ReservaEntity>();
        }

        [Key]
        public int IdEstado { get; set; }
        [StringLength(50)]
        public string NombreEstado { get; set; } = null!;
        [Required]
        public bool? Visible { get; set; }

        [InverseProperty("IdEstadoNavigation")]
        public virtual ICollection<ReservaEntity> Reservas { get; set; }
    }
}
