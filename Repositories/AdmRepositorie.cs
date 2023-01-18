using Microsoft.EntityFrameworkCore;
using Autenticacao_JWT.Repositories.Context;
using Autenticacao_JWT.Repositories.Interfaces;
using Autenticacao_JWT.Models;

namespace Autenticacao_JWT.Repositories;

public class AdmRepositorie : IService<Adm>
{
    private Contexto contexto;
    public AdmRepositorie()
    {
        contexto = new Contexto();
    }

    public async Task<List<Adm>> TodosAsync()
    {
        return await contexto.Adim.ToListAsync();
    }

    public async Task IncluirAsync(Adm adm)
    {
        contexto.Adim.Add(adm);
        await contexto.SaveChangesAsync();
    }

    public async Task<Adm> AtualizarAsync(Adm adm)
    {
        contexto.Entry(adm).State = EntityState.Modified;
        await contexto.SaveChangesAsync();

        return adm;
    }

    public async Task ApagarAsync(Adm adm)
    {
        var obj = await contexto.Adim.FindAsync(adm.Id);
        if (obj is null) throw new Exception("Não encontrado.");
        contexto.Adim.Remove(obj);
        await contexto.SaveChangesAsync();
    }
}