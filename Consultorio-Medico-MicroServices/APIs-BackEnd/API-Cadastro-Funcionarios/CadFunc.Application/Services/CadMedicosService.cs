using CadFunc.Application.InputModels;
using CadFunc.Application.InterfacesServices;
using CadFunc.Domain.Entities;

namespace CadFunc.Application.Services
{
    public class CadMedicosService : ICadMedicosService
    {
        private readonly List<CadMedicos> _cadMedicosList;

        public CadMedicosService()
        {
            _cadMedicosList = new List<CadMedicos>();
        }

        public async Task<string> Add(CadMedicosInputModels model)
        {
            var cadMedicos = model.ToEntity();
            _cadMedicosList.Add(cadMedicos);
            Console.WriteLine(JsonSerializer.Serialize(cadMedicos));
            return await Task.FromResult(cadMedicos.Id.ToString());
        }

        public async Task<CadMedicos> GetByCode(string trackingCode)
        {
            return await Task.FromResult(_cadMedicosList.Find(m => m.Nome.ToString() == trackingCode));
        }
    }
}
