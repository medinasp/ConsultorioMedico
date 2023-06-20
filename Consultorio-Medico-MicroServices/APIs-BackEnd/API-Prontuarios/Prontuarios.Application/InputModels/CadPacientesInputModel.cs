using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prontuarios.Application.InputModels
{
    public class CadPacientesInputModel
    {
        public string id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public bool ativo { get; set; }
        public DateTime dataCriacao { get; set; }
    }
}
