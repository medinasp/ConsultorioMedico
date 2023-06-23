using Newtonsoft.Json;
using Prontuarios.Application.InputModels;
using Prontuarios.Application.InterfaceServices;
using Prontuarios.Application.ViewModels;
using Prontuarios.Domain.Entities;
using Prontuarios.Infra.Repositories;

namespace Prontuarios.Application.Services
{
    public class ProntuariosService : IProntuariosService
    {
        private readonly HttpClient _httpClient;
        private readonly IProntuariosRepository _prontuariosRepository;

        public ProntuariosService(HttpClient httpClient, IProntuariosRepository prontuariosRepository)
        {
            _httpClient = httpClient;
            _prontuariosRepository = prontuariosRepository;
        }

        public async Task <ProntuariosViewModel> ConsultaPorCodigo(string code)
        {
            if (!Guid.TryParse(code, out var guid))
                return null;

            var prontuarios = await _prontuariosRepository.GetById(guid.ToString());
            if (prontuarios == null)
                return null;

            var prontuariosViewModelList = new ProntuariosViewModel
            {
                Id = prontuarios.Id,
                IdPaciente = Guid.Parse(prontuarios.PacienteId),
                NomePaciente = prontuarios.PacienteNome,
                IdMedico = Guid.Parse(prontuarios.MedicoId),
                NomeMedico = prontuarios.MedicoNome,
                EspecialidadeMedico = prontuarios.MedicoEspecialidade,
                TextoProntuario = prontuarios.TextoProntuario
            };

            return prontuariosViewModelList;
        }

        public async Task<List<ProntuariosViewModel>> ConsultarProntuarioPorNomeMedico(string nomeMedico)
        {
            var prontuariosList = await _prontuariosRepository.GetByNomeMedico(nomeMedico);
            if (prontuariosList == null)
                return null;

            var prontuariosViewModelList = prontuariosList.Select(m => new ProntuariosViewModel
            {
                Id = m.Id,
                IdPaciente = Guid.Parse(m.PacienteId),
                NomePaciente = m.PacienteNome,
                IdMedico = Guid.Parse(m.MedicoId),
                NomeMedico = m.MedicoNome,
                EspecialidadeMedico = m.MedicoEspecialidade,
                TextoProntuario = m.TextoProntuario
            }).ToList();

            return prontuariosViewModelList;
        }

        public async Task<List<ProntuariosViewModel>> ConsultarProntuarioPorNomePaciente(string nomePaciente)
        {
            var prontuariosList = await _prontuariosRepository.GetByNomePaciente(nomePaciente);
            if (prontuariosList == null)
                return null;

            var prontuariosViewModelList = prontuariosList.Select(m => new ProntuariosViewModel
            {
                Id = m.Id,
                IdPaciente = Guid.Parse(m.PacienteId),
                NomePaciente = m.PacienteNome,
                IdMedico = Guid.Parse(m.MedicoId),
                NomeMedico = m.MedicoNome,
                EspecialidadeMedico = m.MedicoEspecialidade,
                TextoProntuario = m.TextoProntuario
            }).ToList();

            return prontuariosViewModelList;
        }

        public async Task<List<ProntuariosViewModel>> CriarProntuarioPorId(ProntuariosInputModel model)
        {
            // Obter dados do médico da API externa
            var medicoResponse = await _httpClient.GetAsync($"https://localhost:7176/api/CadMedicos/{model.MedicoId}");
            if (!medicoResponse.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao obter os dados do médico");
            }

            var medicoContent = await medicoResponse.Content.ReadAsStringAsync();
            var deserealizadoMedico = JsonConvert.DeserializeObject<ExternalApiInputModel>(medicoContent);

            // Obter dados do paciente da API externa
            var pacienteResponse = await _httpClient.GetAsync($"https://localhost:7099/api/CadClientes/{model.PacienteId}");
            if (!pacienteResponse.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao obter os dados do paciente");
            }

            var pacienteContent = await pacienteResponse.Content.ReadAsStringAsync();
            var deserealizadoPaciente = JsonConvert.DeserializeObject<ExternalApiInputModel>(pacienteContent);

            var prontuario = new Prontuario(deserealizadoMedico.Id, deserealizadoMedico.nome, deserealizadoMedico.especialidade, deserealizadoPaciente.Id, deserealizadoPaciente.nome, model.TextoProntuario);

            // Persistir o prontuário no banco de dados
            var cadProntList = await _prontuariosRepository.Add(prontuario);
            if (cadProntList == null)
                return null;

            var viewModel = cadProntList.Select(c => new ProntuariosViewModel
            {
                Id = c.Id,
                IdPaciente = Guid.Parse(c.PacienteId),
                NomePaciente = c.PacienteNome,
                IdMedico = Guid.Parse(c.MedicoId),
                NomeMedico = c.MedicoNome,
                EspecialidadeMedico = c.MedicoEspecialidade,
                TextoProntuario = c.TextoProntuario
            }).ToList();

            return viewModel;

        }

        public async Task<bool> EditarProntuario(string id, ProntuariosInputModel model)
        {
            if (!Guid.TryParse(id, out var guid)) return false;

            var prontuario = await _prontuariosRepository.GetById(guid.ToString());

            if (prontuario == null) return false;

            prontuario.Update(model.TextoProntuario);

            await _prontuariosRepository.Update(prontuario);

            return true;
        }

        public async Task<IEnumerable<ProntuariosViewModel>> GetAll()
        {
            var getAllProntuarios = await _prontuariosRepository.GetAllActives();

            var viewModels = getAllProntuarios.Select(m => new ProntuariosViewModel
            {
                Id = m.Id,
                IdPaciente = Guid.Parse(m.PacienteId),
                NomePaciente = m.PacienteNome,
                IdMedico = Guid.Parse(m.MedicoId),
                NomeMedico = m.MedicoNome,
                EspecialidadeMedico = m.MedicoEspecialidade,
                TextoProntuario = m.TextoProntuario
            });

            return viewModels;
        }

        public async Task<bool> RemoverProntuarioHard(string id)
        {
            if (!Guid.TryParse(id, out var guid))
                return false;

            var prontuarios = await _prontuariosRepository.GetById(guid.ToString());

            if (prontuarios == null)
                return false;

            await _prontuariosRepository.HardDelete(prontuarios);

            return true;
        }

        public async Task<bool> RemoverProntuarioSoft(string id)
        {
            if (!Guid.TryParse(id, out var guid))
                return false;

            var prontuarios = await _prontuariosRepository.GetById(guid.ToString());

            if (prontuarios == null || !prontuarios.Ativo)
                return false;

            await _prontuariosRepository.SoftDelete(prontuarios);

            return true;
        }
    }
}
