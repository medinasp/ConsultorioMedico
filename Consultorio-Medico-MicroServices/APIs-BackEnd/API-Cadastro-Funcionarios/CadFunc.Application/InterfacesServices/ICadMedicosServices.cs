using CadFunc.Application.InputModels;
using CadFunc.Domain.Entities;

namespace CadFunc.Application.InterfacesServices
{
    public interface ICadMedicosServices
    {
        Task<string> Add(CadMedicosInputModels model);
        Task<CadMedicos> GetByCode(string trackingCode);
        //Task<IEnumerable<CadMedicos>> GetAllAsync();
    }
}
