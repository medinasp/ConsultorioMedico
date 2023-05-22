using CadFunc.Application.InputModels;
using CadFunc.Application.InterfacesServices;
using CadFunc.Application.ViewModels;
using CadFunc.Domain.Entities;
using System.Text.Json;

namespace CadFunc.Application.Services
{
    public class CadMedicosService : ICadMedicosService
    {
        private static readonly List<CadMedicos> _cadMedicosList = new List<CadMedicos>();

        public async Task<string> Add(CadMedicosInputModels model)
        {
            var cadMedicos = model.ToEntity();
            _cadMedicosList.Add(cadMedicos);
            Console.WriteLine(JsonSerializer.Serialize(cadMedicos));
            return await Task.FromResult(cadMedicos.Id.ToString());
        }

        public async Task<CadMedicosViewModel> GetByCode(string trackingCode)
        {
            if (!Guid.TryParse(trackingCode, out var guid))
                return null;

            var cadMedicos = _cadMedicosList.FirstOrDefault(m => m.Id == guid);
            if (cadMedicos == null)
                return null;

            var cadMedicosViewModel = new CadMedicosViewModel
            {
                Id = cadMedicos.Id,
                Nome = cadMedicos.Nome,
                CPF = cadMedicos.CPF,
                Especialidade = cadMedicos.Especialidade,
                DataCriacao = cadMedicos.DataCriacao,
                Ativo = cadMedicos.Ativo
            };

            return await Task.FromResult(cadMedicosViewModel);
        }

    }
}
