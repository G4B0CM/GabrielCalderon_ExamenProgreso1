using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;

namespace GabrielCalderon_ExamenProgreso1.Models
{
    public class GCalderon
    {
        //Seria como que la clase usuario
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        [AllowNull]
        [DisplayName("Apellido(Opcional)")]
        public string Apellido { get; set; }
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(50)]
        public string Contrasena { get; set; }
        [Required]
        [Phone]
        public string numtelf { get; set; }
        [Required]
        public double Saldo { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public bool EsCliente { get; set; }
        //Relacion de un usuario un celular
        public Celular? Celular { get; set; }
        [ForeignKey("Celular")]
        public int CelularId { get; set; }
    }
}
