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

        [HttpPost("criar-prontuario-por-id")]
        public async Task<IActionResult> CriarProntuarioId([FromBody] ProntuariosInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _prontuariosService.CriarProntuarioPorId(model);
                return Ok("Sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao criar o prontuário: " + ex.Message);
            }
        }

        [HttpPost("criar-prontuario-por-nome")]
        public async Task<IActionResult> CriarProntuarioNome([FromBody] ProntuariosInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _prontuariosService.CriarProntuarioPorNome(model);
                return Ok("Sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao criar o prontuário: " + ex.Message);
            }
        }
    }
}

