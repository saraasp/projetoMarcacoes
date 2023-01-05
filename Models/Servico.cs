using System.ComponentModel.DataAnnotations;

namespace projetoMarcacoes.Models
{
    public class Servico
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public double Custo { get; set; }

        [Required]
        [Display(Name ="Duração Hora")]
        public double DuracaoHora { get; set; }

        //cada serviço pode ter uma coleção de marcaçoes:
        public virtual ICollection<Funcionario_Servico>? Funcionario_Servicos { get; set; }
        
    }
}
