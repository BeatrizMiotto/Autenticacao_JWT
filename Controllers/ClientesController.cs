using Autenticacao_JWT.Models;
using Autenticacao_JWT.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacao_JWT.Controllers;

[Route("clientes")]
public class ClientesController : ControllerBase
{
    private IService<Cliente> _service;

    public ClientesController(IService<Cliente> service)
    {
        _service = service;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var clientes = await _service.TodosAsync();
        return StatusCode(200, clientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        var cliente = (await _service.TodosAsync()).Find(c => c.Id == id);

        return StatusCode(200, cliente);
    }

    [HttpPost("")]
    public async Task<IActionResult> Create([FromBody] Cliente cliente)
    {
        await _service.IncluirAsync(cliente);
        return StatusCode(201, cliente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Cliente cliente)
    {
        if (id != cliente.Id)
        {
            return StatusCode(400, new
            {
                Mensagem = "O Id do cliente precisa bater com o id da URL"
            });
        }

        var clienteDb = await _service.AtualizarAsync(cliente);

        return StatusCode(200, clienteDb);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var clienteDb = (await _service.TodosAsync()).Find(c => c.Id == id);
        if (clienteDb is null)
        {
            return StatusCode(404, new
            {
                Mensagem = "O cliente informado não existe"
            });
        }

        await _service.ApagarAsync(clienteDb);

        return StatusCode(204);
    }
    
}