
namespace Autenticacao_JWT.Repositories.Interfaces;

public interface IService<T>
{
    Task<List<T>> TodosAsync();
    Task IncluirAsync(T obj);
    Task<T> AtualizarAsync(T obj);
    Task ApagarAsync(T obj);
}

