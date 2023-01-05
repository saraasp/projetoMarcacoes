using Microsoft.EntityFrameworkCore;

using projetoMarcacoes.Models;
namespace projetoMarcacoes.Data
{
    public class ApplicationDbContext :DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options )
            : base( options )   
        {
            
        }

        public DbSet<Funcionario> Tfuncionarios { get; set; }
        public DbSet<Servico> Tservicos { get; set; }
        public DbSet<Marcacao> Tmarcacoes { get; set; }
        public DbSet<Cliente> Tclientes { get; set; }
        public DbSet<Funcionario_Servico> Tfuncionario_servico { get; set; }

    }
}

