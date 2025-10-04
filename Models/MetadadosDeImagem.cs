using System.ComponentModel.DataAnnotations;

namespace ChallengeAPI.Models
{
    public class MetadadosDeImagem {
        [Key]
        [Required]
        public string? NomeDoArquivo { get; set; }
        [Required]
        [MaxLength(6)]
        [MinLength(3)]
        public string? TipoDoArquivo { get; set; }
        [Required]
        public int? Altura { get; set; }
        [Required]
        public int? Comprimento { get; set; }

        public string? Proporcao { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime? DataDeCriacao { get; set; }
    }
}
