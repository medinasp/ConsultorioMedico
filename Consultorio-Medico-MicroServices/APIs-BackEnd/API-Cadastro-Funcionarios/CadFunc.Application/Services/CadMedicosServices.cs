using CadFunc.Application.InputModels;
using CadFunc.Application.InterfacesServices;
using CadFunc.Domain.Entities;

namespace CadFunc.Application.Services
{
    public class CadMedicosServices : ICadMedicosServices
    {
        private readonly List<CadMedicos> _cadMedicosList;

        public CadMedicosServices()
        {
            _cadMedicosList = new List<CadMedicos>();
        }

        public async Task<string> Add(CadMedicosInputModels model)
        {
            var cadMedicos = model.ToEntity();
            _cadMedicosList.Add(cadMedicos);
            return await Task.FromResult(cadMedicos.Id.ToString());
        }

        public async Task<CadMedicos> GetByCode(string trackingCode)
        {
            return await Task.FromResult(_cadMedicosList.Find(m => m.Id.ToString() == trackingCode));
        }
    }
}
