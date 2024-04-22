using KingsLeague.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingsLeague.Models
{
    [Table("RM99585_TB_JOGOS")]
    public class Jogos
    {
        [Key]
        public int JogoId { get; set; }

        [Required(ErrorMessage = "A Data do Jogo é obrigatório.")]
        public DateTime DataJogo { get; set; }

        [Required(ErrorMessage = "Time Mandante é obrigatório.")]
        public string TimeMandante { get; set; }

        [Required(ErrorMessage = "time Visitante é obrigatório.")]
        public string timeVisitante { get; set; }

        [Required(ErrorMessage = "Tipo Jogo é obrigatório.")]
        public string TipoJogo { get; set; }

        public int Publico { get; set; }
    }
}
