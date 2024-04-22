using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KingsLeague.Models
{
    [Table("RM99585_TB_TECNICOS")]
    public class Tecnicos
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TecnicoId { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "A Data de Nascimento é obrigatória.")]
    public DateTime DataNascimento { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    public double Salario { get; set; }

    [Required(ErrorMessage = "A Nacionalidade é obrigatória.")]
    public string Nacionalidade { get; set; }

    [Required(ErrorMessage = "O AnosExperiencia é obrigatório.")]
    public int TempoCarreira { get; set; }

    [Required(ErrorMessage = "O Estrategia é obrigatório.")]
    public string Estrategia { get; set; }
}
}
