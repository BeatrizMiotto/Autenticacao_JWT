namespace Autenticacao_JWT.Models;

public record Cliente
{
    public int Id {get; set;} = default!;
    public string Nome {get; set;} = default!;
    public string Email {get; set;} = default!;
    
}