using Microsoft.EntityFrameworkCore;
using Autenticacao_JWT.Repositories.Context;
using Autenticacao_JWT.Repositories.Interfaces;
using Autenticacao_JWT.Models;

namespace Autenticacao_JWT.Repositories;

public class ClienteRepositorie : IService<Cliente>
{
    private Contexto contexto;
    public ClienteRepositorie()
    {
        contexto = new Contexto();
    }

    public async Task<List<Cliente>> TodosAsync()
    {
        return await contexto.Clientes.ToListAsync();
    }

    public async Task IncluirAsync(Cliente cliente)
    {
        contexto.Clientes.Add(cliente);
        await contexto.SaveChangesAsync();
    }

    public async Task<Cliente> AtualizarAsync(Cliente cliente)
    {
        contexto.Entry(cliente).State = EntityState.Modified;
        await contexto.SaveChangesAsync();

        return cliente;
    }

    public async Task ApagarAsync(Cliente cliente)
    {
        var obj = await contexto.Clientes.FindAsync(cliente.Id);
        if (obj is null) throw new Exception("Cliente não encontrado.");
        contexto.Clientes.Remove(obj);
        await contexto.SaveChangesAsync();
    }
}