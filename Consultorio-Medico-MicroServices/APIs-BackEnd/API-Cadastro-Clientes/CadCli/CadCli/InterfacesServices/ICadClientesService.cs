using CadCli.Application.ViewModels;
using CadCli.Application.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadCli.Application.InterfacesServices
{
    public interface ICadClientesService
    {
        Task<CadClientesViewModel> Add(CadClientesInputModel model);
        Task<CadClientesViewModel> GetByCode(string code);
        Task<IEnumerable<CadClientesViewModel>> GetAll();
        Task<bool> Update(string id, CadClientesInputModel model);
        Task<bool> SoftDelete(string id);
        Task<IEnumerable<CadClientesViewModel>> GetActives();
        Task<bool> HardDelete(string id);
    }
}
