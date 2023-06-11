using CadCli.Application.InputModels;
using CadCli.Application.InterfacesServices;
using CadCli.Application.ViewModels;
using CadCli.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadCli.Application.Services
{
    public class CadClientesService : ICadClientesService
    {
        private static readonly List<CadCliente> _cadClientesList = new List<CadCliente>();

        public async Task<CadClientesViewModel> Add(CadClientesInputModel model)
        {
            var cadClientes = model.ToEntity();
            _cadClientesList.Add(cadClientes);

            var viewModel = new CadClientesViewModel
            {
                Id = cadClientes.Id,
                Nome = cadClientes.Nome,
                CPF = cadClientes.CPF
            };
            return await Task.FromResult(viewModel);

        }

        public async Task<IEnumerable<CadClientesViewModel>> GetActives()
        {
            var activeCadClientes = _cadClientesList.Where(m => m.Ativo);
            var viewModels = activeCadClientes.Select(m => new CadClientesViewModel
            {
                Id = m.Id,
                Nome = m.Nome,
                CPF = m.CPF
            });

            return await Task.FromResult(viewModels);
        }

        public async Task<IEnumerable<CadClientesViewModel>> GetAll()
        {
            var viewModels = _cadClientesList.Select(m => new CadClientesViewModel
            {
                Id = m.Id,
                Nome = m.Nome,
                CPF = m.CPF
            });

            return await Task.FromResult(viewModels);
        }

        public async Task<CadClientesViewModel> GetByCode(string code)
        {
            if (!Guid.TryParse(code, out var guid))
                return null;

            var cadClientes = _cadClientesList.FirstOrDefault(m => m.Id == guid);
            if (cadClientes == null)
                return null;

            var cadClientesViewModel = new CadClientesViewModel
            {
                Id = cadClientes.Id,
                Nome = cadClientes.Nome,
                CPF = cadClientes.CPF
            };

            return await Task.FromResult(cadClientesViewModel);
        }

        public async Task<bool> HardDelete(string id)
        {
            if (!Guid.TryParse(id, out var guid))
                return false;

            var cadClientes = _cadClientesList.FirstOrDefault(m => m.Id.ToString() == id);

            if (cadClientes == null)
                return false;

            _cadClientesList.Remove(cadClientes);

            return true;

        }

        public async Task<bool> SoftDelete(string id)
        {
            if (!Guid.TryParse(id, out var guid))
                return false;

            var cadClientes = _cadClientesList.FirstOrDefault(m => m.Id == guid && m.Ativo);
            if (cadClientes == null)
                return false;

            cadClientes.Excluir();

            return true;
        }

        public async Task<bool> Update(string id, CadClientesInputModel model)
        {
            if (!Guid.TryParse(id, out var guid))
                return false;

            var cadClientes = _cadClientesList.FirstOrDefault(m => m.Id.ToString() == id);

            if (cadClientes == null)
                return false;

            cadClientes.Update(model.Nome, model.CPF);
            return true;
        }
    }
}
