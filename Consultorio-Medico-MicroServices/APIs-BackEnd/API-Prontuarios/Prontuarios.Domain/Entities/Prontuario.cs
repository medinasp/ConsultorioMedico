namespace Prontuarios.Domain.Entities
{
    public class Prontuario : EntityBase
    {
        public string MedicoId { get; set; }
        public string PacienteId { get; set; }
        public string TextoProntuario { get; set; }

        private Prontuario()
        {
        }

         public Prontuario(string medicoId, string pacienteId, string textoProntuario)
        {
            MedicoId = medicoId;
            PacienteId = pacienteId;
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