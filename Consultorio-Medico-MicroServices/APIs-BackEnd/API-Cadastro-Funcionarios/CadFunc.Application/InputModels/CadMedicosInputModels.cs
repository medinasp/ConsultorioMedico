using CadFunc.Domain.Entities;

namespace CadFunc.Application.InputModels
{
    public class CadMedicosInputModels
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Especialidade { get; set; }

        public CadMedicos ToEntity()
            => new(Nome, CPF, Especialidade);
    }
}
