using Prontuarios.Application.InputModels;
using Prontuarios.Application.ViewModels;

namespace Prontuarios.Application.InterfaceServices
{
    public interface IProntuariosService
    {
        Task<IEnumerable<ProntuariosViewModel>> GetAll();
        Task<List<ProntuariosViewModel>> CriarProntuarioPorId(ProntuariosInputModel model);
        Task<ProntuariosViewModel> ConsultaPorCodigo(string code);
        Task<List<ProntuariosViewModel>> ConsultarProntuarioPorNomeMedico(string nomeMedico);
        Task<List<ProntuariosViewModel>> ConsultarProntuarioPorNomePaciente(string nomePaciente);
        Task<bool> EditarProntuario(string id, ProntuariosInputModel model);
        Task<bool> RemoverProntuarioSoft(string id);
        Task<bool> RemoverProntuarioHard(string id);

    }
}