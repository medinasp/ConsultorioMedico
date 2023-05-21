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
    public interface ICadMedicosRepository
    {

        Task<IEnumerable<CadMedicos>> GetAllAsync();

        Task<IEnumerable> GetByIdAsync(int id);

        Task<IEnumerable<CadMedicos>> GetByNomeAsync(string nome);

        Task<IEnumerable<CadMedicos>> GetByCPFAsync(string cpf);

        Task<IEnumerable<CadMedicos>> GetByEspecialidadeAsync(string especialidade);

        Task AddAsync(CadMedicos cadMedico);

        Task UpdateAsync(CadMedicos cadMedico);

        Task DeleteAsync(int id);

    }
}
