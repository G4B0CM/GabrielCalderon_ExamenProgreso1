using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GabrielCalderon_ExamenProgreso1.Models
{
    public class Celular
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Modelo { get; set; }
        [Range(2010, 2025)]
        [AllowNull]
        public int año { get; set; }
        [Required]
        public double precio { get; set; 
    }
}
