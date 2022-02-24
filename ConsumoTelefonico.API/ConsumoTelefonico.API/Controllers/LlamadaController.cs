using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Negocio.Repositorio.IRepositorio;
using System.Security.Claims;

namespace ConsumoTelefonico.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LlamadaController : ControllerBase
    {
        private readonly ILlamadaRepositorio _llamadaRepositorio;

        public LlamadaController(ILlamadaRepositorio llamadaRepositorio)
        {
            _llamadaRepositorio = llamadaRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerLlamadas()
        {
            return Ok(await _llamadaRepositorio.VerRegistroLlamadas());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Crear(RegistroLlamadaDTO registroLlamadaDTO)
        {
            var idUsuario = (HttpContext.User.Identity as ClaimsIdentity)?
                                .FindFirst("Id")?.Value;

            if (idUsuario != registroLlamadaDTO.UserId && !User.IsInRole(Roles.Administrador))
                return Unauthorized("No tiene permisos para realizar esta operacion");

            registroLlamadaDTO.FechaLlamada = DateTime.Now;
            var resultado = await _llamadaRepositorio.RegistrarLlamada(registroLlamadaDTO);
            return Ok(resultado);
        }

        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> ObtenerLlamadas(string idUsuario)
        {
            return Ok(await _llamadaRepositorio.VerRegistroLlamadas(idUsuario));
        }
    }
}
