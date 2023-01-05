using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projetoMarcacoes.Models
{
    public class Marcacao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime Hora { get; set; }


        [Display(Name="Cliente")]
        public int ClienteId { get; set; }

        
        [Display(Name = "Funcionario_Serviço")]
        public int Funcionario_ServicoId { get; set; }

        

        public virtual Cliente? Cliente { get; set; }
        public virtual Funcionario_Servico? Funcionario_Servico { get; set; }
        

    }
}
