using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Peluqueria.Infraestructura.Data.Models
{
    [Table("Cliente")]
    public partial class ClienteEntity
    {//clase ClienteEntity de la capa infraestructura la cual interactua con Cliente de la capa Dominio
        public ClienteEntity()
        {
            Reservas = new HashSet<ReservaEntity>();
        }

        [Key]
        public int IdCliente { get; set; }
        [StringLength(100)]
        public string Nombre { get; set; } = null!;
        [StringLength(100)]
        public string Apellido { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime? FechaRegistro { get; set; }
        [Required]
        public bool? Visible { get; set; }

        [InverseProperty("IdClienteNavigation")]
        public virtual ICollection<ReservaEntity> Reservas { get; set; }
    }
}
