using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KingsLeague.Models
{
    [Table("RM99585_TB_Jogadores")]
    public class Jogadores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JogadorId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Data de Nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public double Salario { get; set; }

        [Required(ErrorMessage = "A Nacionalidade é obrigatória.")]
        public string Nacionalidade { get; set; }

        [Required(ErrorMessage = "A Posicao é obrigatória.")]
        public string Posicao { get; set; }

        [Required(ErrorMessage = "A Especialidade é obrigatória.")]
        public string Especialidade { get; set; }

        [Required(ErrorMessage = "O Status é obrigatório.")]
        public string Status { get; set; }

        //1..N
        public int TimeId { get; set; }
        public Times? Times { get; set; }

    }
}
