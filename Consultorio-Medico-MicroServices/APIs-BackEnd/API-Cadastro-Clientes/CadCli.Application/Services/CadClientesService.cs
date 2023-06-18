using CadCli.Application.InputModels;
using CadCli.Application.ViewModels;
using CadCli.Infra.Repositories;

namespace CadCli.Application.Services
{
    public class CadClientesService : ICadClientesService
    {
        private readonly ICadClientesRepository _repository;
        //private static readonly List<CadCliente> _cadClientesList = new List<CadCliente>();

        public CadClientesService(ICadClientesRepository repository)
        {
            _repository = repository;
        }

        public async Task<CadClientesViewModel> Add(CadClientesInputModel model)
        {
            var cadCliente = model.ToEntity();
            await _repository.Add(cadCliente);

            var viewModel = new CadClientesViewModel
            {
                Id = cadCliente.Id,
                Nome = cadCliente.Nome,
                CPF = cadCliente.CPF,
                DataCriacao = cadCliente.DataCriacao,
                Ativo = cadCliente.Ativo
            };
            return viewModel;
        }

        //public async Task<CadClientesViewModel> Add(CadClientesInputModel model)
        //{
        //    var cadClientes = model.ToEntity();
        //    _cadClientesList.Add(cadClientes);

        //    var viewModel = new CadClientesViewModel
        //    {
        //        Id = cadClientes.Id,
        //        Nome = cadClientes.Nome,
        //        CPF = cadClientes.CPF
        //    };
        //    return await Task.FromResult(viewModel);

        //}

        public async Task<CadClientesViewModel> GetByCode(string code)
        {
            if (!Guid.TryParse(code, out var guid))
                return null;

            var cadClientes = await _repository.GetByCode(guid.ToString());
            if (cadClientes == null)
                return null;

            var cadClientesViewModel = new CadClientesViewModel
            {
                Id = cadClientes.Id,
                Nome = cadClientes.Nome,
                CPF = cadClientes.CPF
            };

            return cadClientesViewModel;
        }

        //public async Task<CadClientesViewModel> GetByCode(string code)
        //{
        //    if (!Guid.TryParse(code, out var guid))
        //        return null;

        //    var cadClientes = _cadClientesList.FirstOrDefault(m => m.Id == guid);
        //    if (cadClientes == null)
        //        return null;

        //    var cadClientesViewModel = new CadClientesViewModel
        //    {
        //        Id = cadClientes.Id,
        //        Nome = cadClientes.Nome,
        //        CPF = cadClientes.CPF
        //    };

        //    return await Task.FromResult(cadClientesViewModel);
        //}

        public async Task<IEnumerable<CadClientesViewModel>> GetAll()
        {
            var getAllCadClientes = await _repository.GetAll();
            var viewModels = getAllCadClientes.Select(m => new CadClientesViewModel
            {
                Id = m.Id,
                Nome = m.Nome,
                CPF = m.CPF,
                Ativo = m.Ativo
            });

            return viewModels;
        }

        //public async Task<IEnumerable<CadClientesViewModel>> GetAll()
        //{
        //    var viewModels = _cadClientesList.Select(m => new CadClientesViewModel
        //    {
        //        Id = m.Id,
        //        Nome = m.Nome,
        //        CPF = m.CPF
        //    });

        //    return await Task.FromResult(viewModels);
        //}

        public async Task<bool> Update(string id, CadClientesInputModel model)
        {
            if (!Guid.TryParse(id, out var guid))
                return false;

            var cadCliente = await _repository.GetByCode(guid.ToString());

            if (cadCliente == null)
                return false;

            //cadCliente.Update(model.Nome, model.CPF);

            await _repository.Update(cadCliente);

            return true;
        }

        //public async Task<bool> Update(string id, CadClientesInputModel model)
        //{
        //    if (!Guid.TryParse(id, out var guid))
        //        return false;

        //    var cadClientes = _cadClientesList.FirstOrDefault(m => m.Id.ToString() == id);

        //    if (cadClientes == null)
        //        return false;

        //    cadClientes.Update(model.Nome, model.CPF);
        //    return true;
        //}

        public async Task<IEnumerable<CadClientesViewModel>> GetActives()
        {
            var activeCadClientes = await _repository.GetActives();
            var viewModels = activeCadClientes.Select(m => new CadClientesViewModel
            {
                Id = m.Id,
                Nome = m.Nome,
                CPF = m.CPF,
                Ativo = m.Ativo
            });

            return viewModels;
        }

        //public async Task<IEnumerable<CadClientesViewModel>> GetActives()
        //{
        //    var activeCadClientes = _cadClientesList.Where(m => m.Ativo);
        //    var viewModels = activeCadClientes.Select(m => new CadClientesViewModel
        //    {
        //        Id = m.Id,
        //        Nome = m.Nome,
        //        CPF = m.CPF
        //    });

        //    return await Task.FromResult(viewModels);
        //}

        public async Task<bool> SoftDelete(string id)
        {
            if (!Guid.TryParse(id, out var guid))
                return false;

            var cadCliente = await _repository.GetByCode(guid.ToString());

            if (cadCliente == null || !cadCliente.Ativo)
                return false;

            await _repository.SoftDelete(cadCliente);

            return true;
        }

        //public async Task<bool> SoftDelete(string id)
        //{
        //    if (!Guid.TryParse(id, out var guid))
        //        return false;

        //    var cadClientes = _cadClientesList.FirstOrDefault(m => m.Id == guid && m.Ativo);
        //    if (cadClientes == null)
        //        return false;

        //    cadClientes.Excluir();

        //    return true;
        //}

        public async Task<bool> HardDelete(string id)
        {
            if (!Guid.TryParse(id, out var guid))
                return false;

            var cadCliente = await _repository.GetByCode(guid.ToString());

            if (cadCliente == null)
                return false;

            await _repository.HardDelete(cadCliente);

            return true;
        }

        //public async Task<bool> HardDelete(string id)
        //{
        //    if (!Guid.TryParse(id, out var guid))
        //        return false;

        //    var cadClientes = _cadClientesList.FirstOrDefault(m => m.Id.ToString() == id);

        //    if (cadClientes == null)
        //        return false;

        //    _cadClientesList.Remove(cadClientes);

        //    return true;

        //}

    }
}
