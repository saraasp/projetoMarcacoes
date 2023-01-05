using System.ComponentModel.DataAnnotations;

namespace projetoMarcacoes.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Introduza o seu nome")]
        public string? Nome { get; set; }

        //[Required(ErrorMessage = "Introduza o seu contacto")]
        //public string? Contacto { get; set; }

        //[Required(ErrorMessage = "Introduza o seu email")]
        //[RegularExpression(".+\\@.+\\..+", ErrorMessage = "Introduza um email válido...")]
        //public string? Email { get; set; }

        //[Required(ErrorMessage = "Introduza uma password")]
        //[DataType(DataType.Password)]
        //[StringLength(10, MinimumLength = 4)]
        //public string? Password { get; set; }


        //cada cliente pode ter uma coleção de marcaçoes:
        public virtual ICollection<Marcacao>? Marcacoes { get; set; }
    }
}
