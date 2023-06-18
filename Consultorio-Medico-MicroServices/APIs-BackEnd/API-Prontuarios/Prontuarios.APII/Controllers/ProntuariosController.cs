using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prontuarios.Application.InputModels;
using Prontuarios.Application.InterfaceServices;

namespace Prontuarios.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProntuariosController : ControllerBase
    {
        private readonly IProntuariosService _prontuariosService;

        public ProntuariosController(IProntuariosService prontuariosService)
        {
            _prontuariosService = prontuariosService;
        }

        [HttpPost("criar-prontuario")]
        public async Task<IActionResult> CriarProntuario([FromBody] ProntuariosInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prontuarioViewModel = await _prontuariosService.CriarProntuarioPorId(model);

            if (prontuarioViewModel == null)
            {
                return NotFound();
            }

            return Ok(prontuarioViewModel);
        }

        // Outros métodos do controller...

    }
}

