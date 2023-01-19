using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Autenticacao_JWT.ModelViews;
using Microsoft.IdentityModel.Tokens;

namespace Autenticacao_JWT.Service.Autenticacao;

public class TokenJWT
{
    public readonly static string Key = "Jasmine_Gata_Linda"; 
    public static string Builder(Logado logado)
    {
        var key = Encoding.ASCII.GetBytes(TokenJWT.Key);
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[]{
                new Claim(ClaimTypes.Name, logado.Nome),
                new Claim(ClaimTypes.Role, logado.Permissao),
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

}