/*using Autenticacao_JWT.Models;
using Autenticacao_JWT.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacao_JWT.Controllers;

[Route("cadastros")]
[ApiController]
[AllowAnonymous]

public class CadastrosController : ControllerBase
{
    private IService<Cadastro> _service;

    public CadastrosController(IService<Cadastro> service)
    {
        _service = service;
    }

  
    [HttpGet("")]
    
    public async Task<IActionResult> Index()
    {
        var cadastros = await _service.TodosAsync();
        return StatusCode(200, cadastros);
    }

    [HttpGet("{id}")]
   
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        var cadastro = (await _service.TodosAsync()).Find(c => c.Id == id);

        return StatusCode(200, cadastro);
    }

    [HttpPost("")]
  
    public async Task<IActionResult> Create([FromBody] Cadastro cadastro)
    {
        await _service.IncluirAsync(cadastro);
        return StatusCode(201, cadastro);
    }

    [HttpPut("{id}")]
  
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Cadastro cadastro)
    {
        if (id != cadastro.Id)
        {
            return StatusCode(400, new
            {
                Mensagem = "O Id do cadastro precisa bater com o id da URL"
            });
        }

        var cadastroDb = await _service.AtualizarAsync(cadastro);

        return StatusCode(200, cadastroDb);
    }

    [HttpDelete("{id}")]
  
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var cadastroDb = (await _service.TodosAsync()).Find(c => c.Id == id);
        if (cadastroDb is null)
        {
            return StatusCode(404, new
            {
                Mensagem = "O cadastro informado não existe"
            });
        }

        await _service.ApagarAsync(cadastroDb);

        return StatusCode(204);
    }
    
}*/