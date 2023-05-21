using CadFunc.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CadFunc.Domain.Interfaces
{
    public interface ICadMedicoRepository
    {

        Task<IEnumerable<CadMedico>> GetAllAsync();

        Task<IEnumerable> GetByIdAsync(int id);

        Task<IEnumerable<CadMedico>> GetByNomeAsync(string nome);

        Task<IEnumerable<CadMedico>> GetByCPFAsync(string cpf);

        Task<IEnumerable<CadMedico>> GetByEspecialidadeAsync(string especialidade);

        Task AddAsync(CadMedico cadMedico);

        Task UpdateAsync(CadMedico cadMedico);

        Task DeleteAsync(int id);

    }
}
