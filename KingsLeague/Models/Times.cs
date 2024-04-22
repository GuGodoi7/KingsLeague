using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KingsLeague.Models
{

    [Table("RM99585_TB_TIMES")]
    public class Times
    {
        [Key]
        public int TimeId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Data de Fundacao é obrigatório.")]
        public DateTime DataFundacao { get; set; }

        [Required(ErrorMessage = "A Presidencia é obrigatório.")]
        public string Presidencia { get; set; }

        [Required(ErrorMessage = "O Estadio é obrigatório.")]
        public string Estadio { get; set; }

        //1..1
        public int? TecnicoId { get; set; }
        public Tecnicos? Tecnicos { get; set; }

        //1..N
        public virtual IEnumerable<Jogadores>? Jogadores { get; set; }

        //1..N
        public virtual IEnumerable<Patrocinios>? Patrocinios { get; set; }

    }
}