using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Peluqueria.Infraestructura.Data.Models
{
    [Table("Servicio")]
    public partial class ServicioEntity
    {//clase ServicioEntity de la capa infraestructura la cual interactua con Servicio de la capa Dominio
        public ServicioEntity()
        {
            Reservas = new HashSet<ReservaEntity>();
        }

        [Key]
        public int IdServicio { get; set; }
        [StringLength(100)]
        public string Nombre { get; set; } = null!;
        [StringLength(255)]
        public string? Descripcion { get; set; }
        public int DuracionMinutos { get; set; }
        [Required]
        public bool? Visible { get; set; }

        [InverseProperty("IdServicioNavigation")]
        public virtual ICollection<ReservaEntity> Reservas { get; set; }
    }
}
