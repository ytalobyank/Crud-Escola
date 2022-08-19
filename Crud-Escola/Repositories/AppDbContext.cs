using Crud_Escola.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_Escola.Repositories
{
    public class AppDbContext : DbContext
    {
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Escola> Escolas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared");

    }
}
