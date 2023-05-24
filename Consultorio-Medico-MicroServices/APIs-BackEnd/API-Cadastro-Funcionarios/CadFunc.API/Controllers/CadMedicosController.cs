using CadFunc.Application.InputModels;
using CadFunc.Application.InterfacesServices;
using CadFunc.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadFunc.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CadMedicosController : ControllerBase
    {
        private readonly ICadMedicosService _cadMedicosServices;

        public CadMedicosController(ICadMedicosService cadMedicosServices)
        {
            _cadMedicosServices = cadMedicosServices;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CadMedicosInputModels model)
        {
            if (ModelState.IsValid)
            {
                var id = await _cadMedicosServices.Add(model);
                return CreatedAtRoute("GetById", new { id }, id);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            var cadMedicosViewModel = await _cadMedicosServices.GetByCode(id);

            if (cadMedicosViewModel == null)
                return NotFound();

            return Ok(cadMedicosViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cadMedicosViewModels = await _cadMedicosServices.GetAll();

            return Ok(cadMedicosViewModels);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, CadMedicosInputModels model)
        {
            var updated = await _cadMedicosServices.Update(id, model);

            if (updated)
                return Ok();

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete(string id)
        {
            var success = await _cadMedicosServices.SoftDelete(id);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpGet("actives")]
        public async Task<IActionResult> GetActives()
        {
            var activeCadMedicos = await _cadMedicosServices.GetActives();
            return Ok(activeCadMedicos);
        }

        [HttpDelete("hard/{id}")]
        public async Task<IActionResult> HardDelete(string id)
        {
            var result = await _cadMedicosServices.HardDelete(id);
            if (result)
                return NoContent();

            return NotFound();
        }
    }
}
