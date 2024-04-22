using KingsLeague.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingsLeague.Models
{
    [Table("RM99585_TB_PATROCINIOS")]
    public class Patrocinios
    {

        [Key]
        public int PatrocinioId { get; set; }

        [Required(ErrorMessage = "A Marca é obrigatório.")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "A verba é obrigatório.")]
        public double Verba { get; set; }

        [Required(ErrorMessage = "O Prazo Contrato é obrigatório.")]
        public DateTime PrazoContrato { get; set; }

        [Required(ErrorMessage = "O Tipo Contrato é obrigatório.")]
        public string TipoContrato { get; set; }


        //1..N
        public int TimeId { get; set; }
        public Times? Times { get; set; }

    }
}