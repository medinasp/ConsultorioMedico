using Prontuarios.Domain.Entities.External;

namespace Prontuarios.Domain.Entities
{
    public class Prontuario : EntityBase
    {
        public string TextoProntuario { get; private set; }
        public CadMedicos? Medico { get; private set; }
        public CadClientes? Cliente { get; private set; }


        public Prontuario()
        {}

        public Prontuario(CadMedicos medico, CadClientes cliente, string textoProntuario)
        {
            Medico = medico;
            Cliente = cliente;
            TextoProntuario = textoProntuario;
        }

        public void Excluir()
        {
            Ativo = false;
        }

        public void Update(string textoProntuario)
        {
            TextoProntuario = textoProntuario;
        }
    }
}