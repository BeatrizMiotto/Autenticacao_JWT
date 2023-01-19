using Autenticacao_JWT.ModelViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacao_JWT.Controllers;

[ApiController]
[AllowAnonymous]
public class HomeController : ControllerBase
{
    [Route("/")]
    [HttpGet]
    public ActionResult Index()
    {
        return StatusCode(200, new Home{
            Mensagem = "Bem vindo a minha API"
        });
    }
}