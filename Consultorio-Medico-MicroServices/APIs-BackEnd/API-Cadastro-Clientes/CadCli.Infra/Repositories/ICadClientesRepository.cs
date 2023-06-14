using CadCli.Domain.Entities;

namespace CadCli.Infra.Repositories
{
    public interface ICadClientesRepository
    {
        Task Add(CadCliente cadCliente);
        Task<CadCliente> GetByCode(string code);
        Task<IEnumerable<CadCliente>> GetAll();
        Task Update(CadCliente cadCliente);
        Task<bool> SoftDelete(string id);
        Task<IEnumerable<CadCliente>> GetActives();
        Task HardDelete(CadCliente cadCliente);
    }
}
