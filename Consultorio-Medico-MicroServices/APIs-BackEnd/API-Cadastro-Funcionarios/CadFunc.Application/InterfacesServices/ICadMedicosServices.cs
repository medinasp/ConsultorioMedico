using CadFunc.Domain.Entities;

namespace CadFunc.Application.InterfacesServices
{
    public interface ICadMedicosServices
    {
        Task<IEnumerable<CadMedicos>> GetAllAsync();
    }
}
