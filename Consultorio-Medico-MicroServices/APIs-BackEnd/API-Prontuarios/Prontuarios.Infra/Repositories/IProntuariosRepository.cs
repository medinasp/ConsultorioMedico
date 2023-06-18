using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prontuarios.Domain.Entities;

namespace Prontuarios.Infra.Repositories
{
    public interface IProntuariosRepository
    {
        Task<Prontuario> GetById(Guid id);
        Task<IEnumerable<Prontuario>> GetAll();
        Task Add(Prontuario prontuario);
        Task Update(Prontuario prontuario);
        Task Delete(Guid id);
    }
}
