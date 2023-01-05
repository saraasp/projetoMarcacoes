using System.ComponentModel.DataAnnotations;

namespace projetoMarcacoes.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        public string? Contacto { get; set; }

        //cada funcionario pode ter uma coleção de marcaçoes:
        public virtual ICollection<Funcionario_Servico>? Funcionario_Servicos { get; set; }
        
    }
}
