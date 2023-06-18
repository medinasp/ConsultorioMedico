using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prontuarios.Domain.Entities;
using Prontuarios.Infra.Configuration;

namespace Prontuarios.Infra.Repositories
{
    public class ProntuariosRepository : IProntuariosRepository
    {
        private readonly ContextBase _context;

        public ProntuariosRepository(ContextBase context)
        {
            _context = context;
        }

        public async Task<Prontuario> GetById(Guid id)
        {
            return await _context.Prontuarios.FindAsync(id);
        }

        public async Task<IEnumerable<Prontuario>> GetAll()
        {
            return await _context.Prontuarios.ToListAsync();
        }

        public async Task Add(Prontuario prontuario)
        {
            await _context.Prontuarios.AddAsync(prontuario);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Prontuario prontuario)
        {
            _context.Prontuarios.Update(prontuario);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var prontuario = await _context.Prontuarios.FindAsync(id);
            if (prontuario != null)
            {
                _context.Prontuarios.Remove(prontuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
