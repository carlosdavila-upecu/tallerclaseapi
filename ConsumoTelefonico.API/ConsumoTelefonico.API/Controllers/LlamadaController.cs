using Microsoft.AspNetCore.Mvc;
using Modelos;
using Negocio.Repositorio.IRepositorio;

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

        [HttpPost]
        public async Task<IActionResult> Crear(RegistroLlamadaDTO registroLlamadaDTO)
        {
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
