using CadFunc.Application.InputModels;
using CadFunc.Application.InterfacesServices;
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
    }
}
