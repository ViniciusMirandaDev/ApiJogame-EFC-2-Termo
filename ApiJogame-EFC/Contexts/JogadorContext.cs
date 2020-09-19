using ApiJogame_EFC.Domains;
using Microsoft.EntityFrameworkCore;

namespace ApiJogame_EFC.Contexts
{
    public class JogadorContext : DbContext
    {
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<JogosJogadores> JogosJogadores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=LAB107201\SQLEXPRESS2;Initial Catalog = ApiJogame-EFC ;user id = sa;password = sa132");
            }
            base.OnConfiguring(optionsBuilder);
        }

    }
}
