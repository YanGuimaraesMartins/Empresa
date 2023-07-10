using Empresa.Data.Map;
using Empresa.Models;
using Microsoft.EntityFrameworkCore;

namespace Empresa.Data
{
    public class SistemaTarefasDBcontex : DbContext
    {
        public SistemaTarefasDBcontex(DbContextOptions<SistemaTarefasDBcontex> options)
        : base(options)
        {
        }
        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
  