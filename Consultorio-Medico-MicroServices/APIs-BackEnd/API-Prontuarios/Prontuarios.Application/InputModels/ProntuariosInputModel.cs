using Prontuarios.Domain.Entities;
using Prontuarios.Domain.Entities.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prontuarios.Application.InputModels
{
    public class ProntuariosInputModel
    {
        public CadMedicos Medico { get; set; }
        public CadClientes Cliente { get; set; }
        public string TextoProntuario { get; set; }

        public Prontuario ToEntity()
            => new(Medico, Cliente, TextoProntuario);

    }
}
