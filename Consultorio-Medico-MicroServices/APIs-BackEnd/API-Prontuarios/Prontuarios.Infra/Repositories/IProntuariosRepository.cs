using Prontuarios.Domain.Entities;

namespace Prontuarios.Infra.Repositories
{
    public interface IProntuariosRepository
    {
        Task<Prontuario> GetById(string code);
        Task<IEnumerable<Prontuario>> GetAllActives();
        Task<List<Prontuario>> GetByNomeMedico(string name);
        Task<List<Prontuario>> GetByNomePaciente(string name);
        Task<List<Prontuario>> Add(Prontuario prontuario);
        Task Update(Prontuario prontuario);
        Task<bool> SoftDelete(Prontuario prontuario);
        Task HardDelete(Prontuario prontuario);
    }
}
