using Autenticacao_JWT.Models;
using Autenticacao_JWT.Repositories.Context;
using Autenticacao_JWT.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Autenticacao_JWT.Repositories;


public class CadastroRepositorie : IServiceCadastro<Cadastro>
{
    private Contexto contexto;
    public CadastroRepositorie()
    {
        contexto = new Contexto();
    }

    public async Task<List<Cadastro>> TodosAsync()
    {
        return await contexto.cadastro.ToListAsync();
    }

    public async Task<Cadastro?> Login(string email, string senha)
    {
        return await contexto.cadastro.Where(c => c.Email == email && c.Senha == senha).FirstOrDefaultAsync();
    }

    public async Task IncluirAsync(Cadastro cadastro)
    {
        contexto.cadastro.Add(cadastro);
        await contexto.SaveChangesAsync();
    }

    public async Task<Cadastro> AtualizarAsync(Cadastro cadastro)
    {
        contexto.Entry(cadastro).State = EntityState.Modified;
        await contexto.SaveChangesAsync();

        return cadastro;
    }

    public async Task ApagarAsync(Cadastro cadastro)
    {
        var obj = await contexto.cadastro.FindAsync(cadastro.Id);
        if(obj is null) throw new Exception("cadastro não encontrado");
        contexto.cadastro.Remove(obj);
        await contexto.SaveChangesAsync();
    }
}