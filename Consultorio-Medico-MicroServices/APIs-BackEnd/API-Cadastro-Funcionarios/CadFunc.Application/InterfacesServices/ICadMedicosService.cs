using CadFunc.Application.InputModels;
using CadFunc.Application.ViewModels;
using CadFunc.Domain.Entities;

namespace CadFunc.Application.InterfacesServices
{
    public interface ICadMedicosService
    {
        Task<CadMedicosViewModel> Add(CadMedicosInputModel model);
        Task<CadMedicosViewModel> GetByCode(string code);
        Task<IEnumerable<CadMedicosViewModel>> GetAll();
        Task<bool> Update(string id, CadMedicosInputModel model);
        Task<bool> SoftDelete(string id);
        Task<IEnumerable<CadMedicosViewModel>> GetActives();
        Task<bool> HardDelete(string id);
    }
}
