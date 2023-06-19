using Prontuarios.Application.InputModels;
using Prontuarios.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prontuarios.Application.InterfaceServices
{
    public interface IProntuariosService
    {
        Task<ProntuariosViewModel> CriarProntuarioPorId(ProntuariosInputModel model);
        Task CriarProntuario2(ProntuariosInputModel model);
        //Task<ProntuariosViewModel> CriarProntuarioPorNome(ProntuariosInputModel model);
        //Task<ProntuariosViewModel> ConsultarProntuarioPorNomeMedico(string nomeMedico);
        //Task<ProntuariosViewModel> ConsultarProntuarioPorNomeMedicoAtivos(string nomeMedico);
        //Task<ProntuariosViewModel> ConsultarProntuarioPorNomePaciente(string nomePaciente);
        //Task<ProntuariosViewModel> ConsultarProntuarioPorNomePacienteAtivos(string nomePaciente);
        //Task<bool> EditarProntuario(string id, ProntuariosInputModel model);
        //Task<bool> RemoverProntuarioSoft(string id);
        //Task<bool> RemoverProntuarioHard(string id);

    }
}
