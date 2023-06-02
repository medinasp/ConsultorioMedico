using CadCli.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadCli.Application.InputModels
{
    public class CadClientesInputModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }

        public CadClientes ToEntity()
            => new(Nome, CPF);

    }
}
