using Autenticacao_JWT.Models;
using Microsoft.EntityFrameworkCore;

namespace Autenticacao_JWT.Repositories.Context;

public class Contexto : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conexao = Environment.GetEnvironmentVariable("DATABASE_URL_BM");
        if (conexao is null) conexao = "Server=localhost;Database=estoque;Uid=root;Pwd='';";
        optionsBuilder.UseMySql(conexao, ServerVersion.AutoDetect(conexao));
    }

    public DbSet<Cadastro> cadastro { get; set; } = default!;
    public DbSet<Cliente> cliente { get; set; } = default!;
   
}
