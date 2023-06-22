using CadFunc.Application.InputModels;
using CadFunc.Application.ViewModels;
using CadFunc.Domain.Entities;

namespace CadFunc.Application.Services
{
    public interface ICadMedicosService
    {
        Task<CadMedicosViewModel> Add(CadMedicosInputModel model);
        Task<CadMedicosViewModel> GetByCode(string code);
        Task<List<CadMedicosViewModel>> GetByName(string name);
        Task<IEnumerable<CadMedicosViewModel>> GetAll();
        Task<bool> Update(string id, CadMedicosInputModel model);
        Task<IEnumerable<CadMedicosViewModel>> GetActives();
        Task<bool> SoftDelete(string id);
        Task<bool> HardDelete(string id);
    }
}
