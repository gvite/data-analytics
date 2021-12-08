using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntosVerdes.Models
{
    public class PuntoVerde
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        [Required]
        public double Latitud { get; set; }
        [Required]
        public double Longitud { get; set; }
        public string Calle { get; set; }
        public string Calle2 { get; set; }
        [Required]
        public int BarrioId { get; set; }
        public virtual Barrio Barrio { get; set; }
        [Required]
        public int CooperativaId { get; set; }
        public virtual Cooperativa Cooperativa { get; set; }
        public int ComunaId { get; set; }
        public virtual Comuna Comuna { get; set; }
    }
}
