using CadCli.Application.InputModels;
using CadCli.Application.ViewModels;

namespace CadCli.Application.Services
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
