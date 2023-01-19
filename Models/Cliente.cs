using System.ComponentModel.DataAnnotations.Schema;

namespace Autenticacao_JWT.Models;

[Table("cliente")]
public record Cliente
{
    public int Id {get; set;} = default!;
    public string Nome {get; set;} = default!;
    public string? Email {get; set;}
    
}