using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntosVerdes.Models
{
    public class Poblacion
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public long Cantidad { get; set; }
        public int Anio { get; set; }
        public int ComunaId { get; set; }
        public virtual Comuna Comuna { get; set; }
    }
}
