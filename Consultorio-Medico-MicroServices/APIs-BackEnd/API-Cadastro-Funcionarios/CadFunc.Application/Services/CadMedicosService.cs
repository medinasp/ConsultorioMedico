using CadFunc.Application.InputModels;
using CadFunc.Application.InterfacesServices;
using CadFunc.Application.ViewModels;
using CadFunc.Domain.Entities;
using System.Text.Json;

namespace CadFunc.Application.Services
{
    public class CadMedicosService : ICadMedicosService
    {
        private static readonly List<Domain.Entities.CadMedicos> _cadMedicosList = new List<Domain.Entities.CadMedicos>();

        public async Task<CadMedicosViewModel> Add(CadMedicosInputModels model)
        {
            var cadMedicos = model.ToEntity();
            _cadMedicosList.Add(cadMedicos);

            var viewModel = new CadMedicosViewModel
            {
                Id = cadMedicos.Id,
                Nome = cadMedicos.Nome,
                CPF = cadMedicos.CPF,
                Especialidade = cadMedicos.Especialidade
            };
            return await Task.FromResult(viewModel);
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
            };

            return await Task.FromResult(cadMedicosViewModel);
        }

        public async Task<IEnumerable<CadMedicosViewModel>> GetAll()
        {
            var viewModels = _cadMedicosList.Select(m => new CadMedicosViewModel
            {
                Id = m.Id,
                Nome = m.Nome,
                CPF = m.CPF,
                Especialidade = m.Especialidade,
            });

            return await Task.FromResult(viewModels);
        }

        public async Task<bool> Update(string id, CadMedicosInputModels model)
        {
            var cadMedicos = _cadMedicosList.FirstOrDefault(m => m.Id.ToString() == id);

            if (cadMedicos == null)
                return false;

            cadMedicos.Update(model.Nome, model.CPF, model.Especialidade);

            return true;
        }

        public async Task<bool> SoftDelete(string id)
        {
            if (!Guid.TryParse(id, out var guid))
                return false;

            var cadMedicos = _cadMedicosList.FirstOrDefault(m => m.Id == guid && m.Ativo);
            if (cadMedicos == null)
                return false;

            cadMedicos.Excluir();

            return true;
        }

        public async Task<IEnumerable<CadMedicosViewModel>> GetActives()
        {
            var activeCadMedicos = _cadMedicosList.Where(m => m.Ativo);
            var viewModels = activeCadMedicos.Select(m => new CadMedicosViewModel
            {
                Id = m.Id,
                Nome = m.Nome,
                CPF = m.CPF,
                Especialidade = m.Especialidade
            });

            return await Task.FromResult(viewModels);
        }

        public async Task<bool> HardDelete(string id)
        {
            var cadMedicos = _cadMedicosList.FirstOrDefault(m => m.Id.ToString() == id);

            if (cadMedicos == null)
                return false;

            _cadMedicosList.Remove(cadMedicos);

            return true;
        }

    }
}
