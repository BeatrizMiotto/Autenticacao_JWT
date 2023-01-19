using Autenticacao_JWT.DTOs;
using Autenticacao_JWT.Models;
using Autenticacao_JWT.ModelViews;
using Autenticacao_JWT.Repositories.Interfaces;
using Autenticacao_JWT.Service.Autenticacao;
using Microsoft.AspNetCore.Mvc;
using Autenticacao_JWT.Service;
using Microsoft.AspNetCore.Authorization;

namespace Autenticacao_JWT.Controllers;

public class LoginController : ControllerBase
{
    private IServiceCadastro<Cadastro> _service;
    public LoginController(IServiceCadastro<Cadastro> service)
    {
        _service = service;
    }
    // GET: Clientes
    [HttpPost("/login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] CadastroDTO cadastroDTO)
    {
        if(string.IsNullOrEmpty(cadastroDTO.Email) || string.IsNullOrEmpty(cadastroDTO.Senha))
            return StatusCode(400, new {
                Mensagem = "Preencha o email e a senha"
            });

        var administrador = await _service.Login(cadastroDTO.Email, cadastroDTO.Senha);
        if(administrador is null)
            return StatusCode(404, new {
                Mensagem = "Usuario ou senha não encontrado em nossa base de dados"
            });

        var admLogado = BuilderService<Logado>.Builder(administrador);
        admLogado.Token = TokenJWT.Builder(admLogado);

        return StatusCode(200, admLogado);
    }
}