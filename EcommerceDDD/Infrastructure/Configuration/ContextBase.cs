// Importando namespaces necessários para o uso do Entity Framework Core e ASP.NET Identity
using Entities.Entities;  // Importa as entidades do domínio, como Produto e CompraUsuario
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;  // Permite integração do Identity com Entity Framework Core
using Microsoft.EntityFrameworkCore;  // Necessário para usar o Entity Framework Core

namespace Infrastructure.Configuration
{
    // Define a classe ContextBase, que herda de IdentityDbContext<ApplicationUser>
    // O IdentityDbContext já tem configurações prontas para gerenciar autenticação e autorização de usuários.
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        // Construtor que recebe as opções do DbContext e passa para a classe base.
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
        }

        // DbSet é uma coleção de entidades. Aqui, estamos definindo tabelas para Produto, CompraUsuario e ApplicationUser.
        // Produto: Representa a tabela de produtos no banco de dados
        // CompraUsuario: Representa a tabela de compras do usuário
        // ApplicationUser: Representa a tabela de usuários, herdando de IdentityUser
        public DbSet<Produto> Produto { get; set; }
        public DbSet<CompraUsuario> CompraUsuario { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        // Método que configura as opções do DbContext, como a string de conexão
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Verifica se as opções já foram configuradas (evita sobrescrever configurações)
            if (!optionsBuilder.IsConfigured)
            {
                // Configura o DbContext para usar SQL Server com a string de conexão obtida no método GetStringConectionConfig()
                optionsBuilder.UseSqlServer(GetStringConectionConfig());
                // Chama o método base para garantir que o comportamento padrão do DbContext seja mantido
                base.OnConfiguring(optionsBuilder);
            }
        }

        // Método que configura o modelo de dados (como as tabelas e chaves) usando o ModelBuilder
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Personaliza a tabela do Identity para o ApplicationUser.
            // Definindo que a tabela de usuários será chamada "AspNetUsers" e que a chave primária será o campo 'Id'
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            // Chama o método base para garantir que a configuração padrão do Identity seja aplicada
            base.OnModelCreating(builder);
        }

        // Método privado que retorna a string de conexão com o banco de dados
        // Essa string inclui detalhes como o servidor, banco de dados, usuário e senha
        private string GetStringConectionConfig()
        {
            // Retorna a string de conexão com os parâmetros necessários para conectar ao banco
            string strCon = "Data Source=TIMEWARE72;Initial Catalog=DDD_ECOMMERCE;User ID=sa;Password=123456;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True";
            return strCon;
        }
    }
}
