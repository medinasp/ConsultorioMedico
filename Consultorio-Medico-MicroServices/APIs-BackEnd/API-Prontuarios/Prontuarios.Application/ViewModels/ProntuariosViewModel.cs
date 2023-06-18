using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prontuarios.Application.ViewModels
{
    public class ProntuariosViewModel
    {
        public Guid Id { get; set; }
        public Guid IdPaciente { get; set; }
        public string NomePaciente { get; set; }
        public string CPFPaciente { get; set; }
        public string DataCriacaoPaciente { get; set; }
        public Guid IdMedico { get; set; }
        public string NomeMedico { get; set; }
        public string CPFMedico { get; set; }
        public string EspecialidadeMedico { get; set; }
        public string TextoProntuario { get; set; }
    }
}
