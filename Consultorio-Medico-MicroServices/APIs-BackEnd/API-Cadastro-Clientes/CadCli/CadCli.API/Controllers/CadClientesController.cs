using CadCli.Application.InputModels;
using CadCli.Application.InterfacesServices;
using Microsoft.AspNetCore.Mvc;

namespace CadCli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadClientesController : ControllerBase
    {
        private readonly ICadClientesService _cadClientesServices;

        public CadClientesController(ICadClientesService cadClientesServices)
        {
            _cadClientesServices = cadClientesServices;
        }

        /// <summary>
        /// Cadastrar um novo cliente
        /// </summary>
        /// <remarks>
        /// {"nome": "string", "cpf": "string"}
        /// </remarks>
        /// <param name="model"></param>
        /// <returns>Objeto criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="400">Requisição Inválida</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CadClientesInputModel model)
        {
            if (ModelState.IsValid)
            {
                var id = await _cadClientesServices.Add(model);
                return CreatedAtRoute("GetById", new { id }, id);
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Obter um cadastro específico pelo id
        /// </summary>
        /// <param name="id">Identificador do cadastro de um cliente específico</param>
        /// <returns>Dados do cadastro específico do cliente</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("{id}", Name = "GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(string id)
        {
            var cadClientesViewModel = await _cadClientesServices.GetByCode(id);

            if (cadClientesViewModel == null)
                return NotFound();

            return Ok(cadClientesViewModel);
        }

        /// <summary>
        /// Obter todos cadastros de clientes em memória
        /// </summary>
        /// <returns>Clientes Cadastrados</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var cadClientesViewModels = await _cadClientesServices.GetAll();
            return Ok(cadClientesViewModels);
        }

        /// <summary>
        /// Atualizar cadastro de um cliente específico
        /// </summary>
        /// <remarks>
        /// {"nome": "string", "cpf": "string"}
        /// </remarks>
        /// <param name="id">Identificador do cadastro de um cliente específico</param>
        /// <param name="model">Dados do cadastro específico do cliente</param>
        /// <returns>Ok</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult>Update(string id, CadClientesInputModel model)
        {
            var updated = await _cadClientesServices.Update(id, model);

            if (updated)
                return Ok();

            return NotFound();
        }

        /// <summary>
        /// Obter somente cadastros de clientes com status "ativo"
        /// </summary>
        /// <returns>Clientes Cadastrados</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet("actives")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetActives()
        {
            var activeCadClientes = await _cadClientesServices.GetActives();
            return Ok(activeCadClientes);   
        }

        /// <summary>
        /// Soft Delete - Desativa registro
        /// </summary>
        /// <param name="id">Identificador do cadastro de um cliente específico</param>
        /// <returns>Nada</returns>
        /// <response code="404">Não encontrado</response>
        /// <response code="200">Sucesso</response>
        [HttpDelete("soft/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SoftDelete(string id)
        {
            var success = await _cadClientesServices.SoftDelete(id);

            if (!success)
                return NotFound();

            return Ok("SoftDelete Ok");
        }

        /// <summary>
        /// Hard Delete - Remove um cadastro do banco em memória
        /// </summary>
        /// <param name="id">Identificador do cadastro de um cliente específico</param>
        /// <returns>Nada</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response> 
        [HttpDelete("hard/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> HardDelete(string id)
        {
            var result = await _cadClientesServices.HardDelete(id);
            if (result)
                return Ok("HardRemove Ok");

            return NotFound();
        }


    }
}
