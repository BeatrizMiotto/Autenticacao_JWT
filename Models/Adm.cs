namespace Autenticacao_JWT.Models;

public record Adm
{
    public int Id {get; set;} = default!;
    public string Nome {get; set;} = default!;
    public string Email {get; set;} = default!;
    public string Senha {get; set;} = default!;
    public string Permissao {get; set;} = default!;
    
}