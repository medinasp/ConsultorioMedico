using CadFunc.Application.InputModels;
using CadFunc.Application.ViewModels;
using CadFunc.Domain.Entities;

namespace CadFunc.Application.InterfacesServices
{
    public interface ICadMedicosService
    {
        Task<CadMedicosViewModel> Add(CadMedicosInputModels model);
        Task<CadMedicosViewModel> GetByCode(string trackingCode);
        //Task<IEnumerable<CadMedicos>> GetAllAsync();
    }
}
