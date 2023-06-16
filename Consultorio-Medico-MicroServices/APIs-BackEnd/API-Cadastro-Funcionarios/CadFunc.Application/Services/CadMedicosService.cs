using CadFunc.Application.InputModels;
using CadFunc.Application.ViewModels;
using CadFunc.Infra.Repositories;

namespace CadFunc.Application.Services
{
    public class CadMedicosService : ICadMedicosService
    {
        private readonly ICadMedicosRepository _repository;
        //private static readonly List<CadMedico> _cadMedicosList = new List<CadMedico>();

        public CadMedicosService(ICadMedicosRepository repository)
        {
            _repository = repository;
        }

        public async Task<CadMedicosViewModel> Add(CadMedicosInputModel model)
        {
            var cadMedico = model.ToEntity();
            await _repository.Add(cadMedico);

            var viewModel = new CadMedicosViewModel
            {
                Id = cadMedico.Id,
                Nome = cadMedico.Nome,
                CPF = cadMedico.CPF,
                Especialidade = cadMedico.Especialidade
            };
            return viewModel;
        }

        public async Task<CadMedicosViewModel> GetByCode(string code)
        {
            if (!Guid.TryParse(code, out var guid))
                return null;

            var cadMedicos = await _repository.GetByCode(guid.ToString());
            if (cadMedicos == null)
                return null;

            var cadMedicosViewModel = new CadMedicosViewModel
            {
                Id = cadMedicos.Id,
                Nome = cadMedicos.Nome,
                CPF = cadMedicos.CPF,
                Especialidade = cadMedicos.Especialidade,
            };

            return cadMedicosViewModel;
        }

        public async Task<IEnumerable<CadMedicosViewModel>> GetAll()
        {
            var getAllCadMedicos = await _repository.GetAll();

            var viewModels = getAllCadMedicos.Select(m => new CadMedicosViewModel
            {
                Id = m.Id,
                Nome = m.Nome,
                CPF = m.CPF,
                Especialidade = m.Especialidade,
                Ativo = m.Ativo
    });

            return viewModels;
        }

        public async Task<bool> Update(string id, CadMedicosInputModel model)
        {
            if (!Guid.TryParse(id, out var guid))
                return false;

            var cadMedico = await _repository.GetByCode(guid.ToString());
            
            if (cadMedico == null)
                return false;

            cadMedico.Update(model.Nome, model.CPF, model.Especialidade);

            await _repository.Update(cadMedico);

            return true;
        }

        public async Task<IEnumerable<CadMedicosViewModel>> GetActives()
        {
            var activeCadMedicos = await _repository.GetActives();
            var viewModels = activeCadMedicos.Select(m => new CadMedicosViewModel
            {
                Id = m.Id,
                Nome = m.Nome,
                CPF = m.CPF,
                Especialidade = m.Especialidade,
                Ativo = m.Ativo
            });

            return viewModels;
        }

        public async Task<bool> SoftDelete(string id)
        {
            if (!Guid.TryParse(id, out var guid))
                return false;

            var cadMedico = await _repository.GetByCode(guid.ToString());

            if (cadMedico == null || !cadMedico.Ativo)
                return false;

            await _repository.SoftDelete(cadMedico);

            return true;
        }

        public async Task<bool> HardDelete(string id)
        {
            if (!Guid.TryParse(id, out var guid))
                return false;

            var cadMedicos = await _repository.GetByCode(guid.ToString());

            if (cadMedicos == null)
                return false;

            await _repository.HardDelete(cadMedicos);

            return true;
        }

    }
}
