using Autenticacao_JWT.Models;
using Autenticacao_JWT.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacao_JWT.Controllers;

[Route("adim")]
public class AdmController : ControllerBase
{
    private IService<Adm> _service;

    public AdmController(IService<Adm> service)
    {
        _service = service;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var adims = await _service.TodosAsync();
        return StatusCode(200, adims);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        var adm = (await _service.TodosAsync()).Find(c => c.Id == id);

        return StatusCode(200, adm);
    }

    [HttpPost("")]
    public async Task<IActionResult> Create([FromBody] Adm adm)
    {
        await _service.IncluirAsync(adm);
        return StatusCode(201, adm);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Adm adm)
    {
        if (id != adm.Id)
        {
            return StatusCode(400, new
            {
                Mensagem = "O Id precisa bater com o id da URL"
            });
        }

        var admDb = await _service.AtualizarAsync(adm);

        return StatusCode(200, admDb);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var admDb = (await _service.TodosAsync()).Find(c => c.Id == id);
        if (admDb is null)
        {
            return StatusCode(404, new
            {
                Mensagem = "O adiministrador informado não existe"
            });
        }

        await _service.ApagarAsync(admDb);

        return StatusCode(204);
    }
    
}