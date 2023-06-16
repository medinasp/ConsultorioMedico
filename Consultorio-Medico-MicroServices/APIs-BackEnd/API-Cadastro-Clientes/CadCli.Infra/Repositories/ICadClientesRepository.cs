using CadCli.Domain.Entities;

namespace CadCli.Infra.Repositories
{
    public interface ICadClientesRepository
    {
        Task Add(CadClientes cadCliente);
        Task<CadClientes> GetByCode(string code);
        Task<IEnumerable<CadClientes>> GetAll();
        Task Update(CadClientes cadCliente);
        Task<IEnumerable<CadClientes>> GetActives();
        Task<bool> SoftDelete(CadClientes cadCliente);
        Task HardDelete(CadClientes cadCliente);
    }
}
