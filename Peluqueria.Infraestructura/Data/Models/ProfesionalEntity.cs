using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Peluqueria.Infraestructura.Data.Models
{
    [Table("Profesional")]
    public partial class ProfesionalEntity
    {//clase profesionalEntity de la capa infraestructura la cual interactua con Profesional de la capa Dominio
        public ProfesionalEntity()
        {
            Reservas = new HashSet<ReservaEntity>();
        }

        [Key]
        public int IdProfesional { get; set; }
        [StringLength(100)]
        public string Nombre { get; set; } = null!;
        [StringLength(100)]
        public string Apellido { get; set; } = null!;
        [StringLength(150)]
        public string? Especialidad { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string Telefono { get; set; } = null!;
        [Required]
        public bool? Visible { get; set; }

        [InverseProperty("IdProfesionalNavigation")]
        public virtual ICollection<ReservaEntity> Reservas { get; set; }
    }
}
