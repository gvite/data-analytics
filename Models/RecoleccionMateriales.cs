using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntosVerdes.Models
{
    public class RecoleccionMateriales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Anio { get; set; }
        [Required]
        public string Mes { get; set; }
        [Required]
        public float Pesaje { get; set; }
        [Required]
        public int PuntoVerdeId { get; set; }
        public virtual PuntoVerde PuntoVerde { get; set; }
        [Required]
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }
    }
}
