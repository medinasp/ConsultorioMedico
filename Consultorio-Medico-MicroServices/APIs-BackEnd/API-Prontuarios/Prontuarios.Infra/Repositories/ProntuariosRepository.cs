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

        public async Task<Prontuario> GetById(string code)
        {
            if (!Guid.TryParse(code, out var guid))
                return null;

            var prontuario = await _context.Prontuarios.FindAsync(guid);

            return prontuario;
        }

        public async Task<IEnumerable<Prontuario>> GetAllActives()
        {
            return await _context.Prontuarios.Where(c => c.Ativo).ToListAsync();
        }

        public async Task<List<Prontuario>> Add(Prontuario prontuario)
        {
            await _context.Prontuarios.AddAsync(prontuario);
            await _context.SaveChangesAsync();

            var cadProntuario = _context.Prontuarios.Where(c => c.MedicoNome == prontuario.MedicoNome).ToList();

            return cadProntuario;
        }

        private bool ProntuarioExists(string medicoId, string pacienteId)
        {
            //return _context.Prontuarios.Any(p => p.ProntuarioExists(medicoId, pacienteId));
            return _context.Prontuarios.Any(p => p.MedicoId == medicoId && p.PacienteId == pacienteId);
        }

        public async Task Update(Prontuario prontuario)
        {
            _context.Prontuarios.Update(prontuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SoftDelete(Prontuario prontuario)
        {
            if (prontuario == null)
                throw new ArgumentNullException(nameof(prontuario));

            prontuario.Excluir();

            _context.Prontuarios.Update(prontuario);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task HardDelete(Prontuario prontuario)
        {
            _context.Prontuarios.Remove(prontuario);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Prontuario>> GetByNomeMedico(string name)
        {
            var prontuario = await _context.Prontuarios.Where(c => EF.Functions.Like(c.MedicoNome, $"%{name}%")).ToListAsync();
            return prontuario;
        }

        public async Task<List<Prontuario>> GetByNomePaciente(string name)
        {
            var prontuario = await _context.Prontuarios.Where(c => EF.Functions.Like(c.PacienteNome, $"%{name}%")).ToListAsync();
            return prontuario;
        }
    }
}
