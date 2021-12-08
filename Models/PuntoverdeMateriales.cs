using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntosVerdes.Models
{
    public class PuntoverdeMateriales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PuntoVerdeId { get; set; }
        public virtual PuntoVerde PuntoVerde { get; set; }
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }
    }
}
