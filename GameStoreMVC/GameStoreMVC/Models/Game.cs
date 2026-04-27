using System.ComponentModel.DataAnnotations;

namespace GameStoreMVC.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        [StringLength(150, ErrorMessage = "O título deve ter no máximo 150 caracteres")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O gênero é obrigatório")]
        public string Genero { get; set; } = string.Empty;

        [Required(ErrorMessage = "A plataforma é obrigatória")]
        public string Plataforma { get; set; } = string.Empty;

        [Required(ErrorMessage = "O preço é obrigatório")]
        [Range(0.01, 99999.99, ErrorMessage = "O preço deve ser maior que zero")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        [StringLength(500)]
        public string? Descricao { get; set; }

        public string? ImagemUrl { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}