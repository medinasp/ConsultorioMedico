using CadCli.Domain.Entities;

namespace CadCli.Application.InputModels
{
    public class CadClientesInputModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }

        public CadCliente ToEntity()
            => new(Nome, CPF);

    }
}
