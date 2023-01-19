namespace Autenticacao_JWT.Repositories.Interfaces;

public interface IServiceCadastro<T> : IService<T>
{
    Task<T?> Login(string email, string senha);
}