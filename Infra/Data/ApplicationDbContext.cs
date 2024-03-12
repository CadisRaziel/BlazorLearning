using BlazorLearning.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorLearning.Infra.Data
{
    //Usando Sqlite -> igualzin o SqlServer
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Todo> Todos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().Property(e => e.Title).IsRequired();
            modelBuilder.Entity<Todo>().Property(e => e.Description).IsRequired();

            modelBuilder.Entity<Category>().Property(e => e.Description).IsRequired();


            //Criando dados iniciais na tabela (quando a tabela for criada ela terá esses itens)
            modelBuilder.Entity<Category>().HasData(
                               new Category { Id = 1, Description = "Trabalho" },
                               new Category { Id = 2, Description = "Pessoal" },
                               new Category { Id = 3, Description = "Outro" }
                               );
        }
    }
}
