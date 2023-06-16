using CadCli.Domain.Entities;
using CadCli.Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using System;

namespace CadCli.Infra.Repositories
{
    public class CadClientesRepository : ICadClientesRepository
    {
        private readonly ContextBase _context;

        public CadClientesRepository(ContextBase context)
        {
            _context = context;
        }

        public async Task Add(CadClientes cadCliente)
        {
            await _context.CadClientes.AddAsync(cadCliente);
            await _context.SaveChangesAsync();
        }

        public async Task<CadClientes> GetByCode(string code)
        {
            if (!Guid.TryParse(code, out var guid))
                return null;

            var cadCliente = await _context.CadClientes.FindAsync(guid);

            return cadCliente;
        }

        public async Task<IEnumerable<CadClientes>> GetAll()
        {
            return await _context.CadClientes.ToListAsync();
        }

        public async Task Update(CadClientes cadCliente)
        {
            _context.CadClientes.Update(cadCliente);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CadClientes>> GetActives()
        {
            return await _context.CadClientes.Where(c => c.Ativo).ToListAsync();
        }

        public async Task<bool> SoftDelete(CadClientes cadCliente)
        {
            if (cadCliente == null)
                throw new ArgumentNullException(nameof(cadCliente));

            cadCliente.Excluir();

            _context.CadClientes.Update(cadCliente);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task HardDelete(CadClientes cadCliente)
        {
            _context.CadClientes.Remove(cadCliente);
            await _context.SaveChangesAsync();
        }


    }
}

