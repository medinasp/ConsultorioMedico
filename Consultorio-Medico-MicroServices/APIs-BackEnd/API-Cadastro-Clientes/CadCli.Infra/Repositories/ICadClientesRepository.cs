using CadCli.Domain.Entities;

namespace CadCli.Infra.Repositories
{
    public interface ICadClientesRepository
    {
        Task Add(CadCliente cadCliente);
        Task<CadCliente> GetByCode(string code);
        Task<IEnumerable<CadCliente>> GetAll();
        Task Update(CadCliente cadCliente);
        Task<IEnumerable<CadCliente>> GetActives();
        Task<bool> SoftDelete(CadCliente cadCliente);
        Task HardDelete(CadCliente cadCliente);
    }
}
