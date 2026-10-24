using System.Reflection.Metadata.Ecma335;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Controllers; 

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    [HttpPost("guardar")]
    public async Task<ActionResult> agregarCliente([FromBody] CompraRequest request)
    {
        return Ok(new {mensaje = "Operacion correcta"}); 
    }
}