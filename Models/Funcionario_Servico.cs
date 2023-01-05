namespace projetoMarcacoes.Models
{
    public class Funcionario_Servico
    {
        public int Id { get; set; }

        public int FuncionarioId { get; set; }

        public int ServicoId { get; set; }

        public virtual Funcionario? Funcionario { get; set; }

        public virtual Servico? Servico { get; set; }
    }
}
