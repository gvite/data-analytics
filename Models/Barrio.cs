using System;
using System.ComponentModel.DataAnnotations;

namespace PuntosVerdes.Models
{
    public class Barrio
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

    }
}
