namespace Prontuarios.Domain.Entities
{
    public class Prontuario : EntityBase
    {
        public string MedicoId { get; set; }
        public string MedicoNome { get; set; }
        public string MedicoEspecialidade { get; set; }
        public string PacienteId { get; set; }
        public string PacienteNome { get; set; }
        public string TextoProntuario { get; set; }

        private Prontuario()
        {
        }

         public Prontuario(string medicoId, string medicoNome, string medicoEspecialidade, string pacienteId, string pacienteNome, string textoProntuario)
        {
            MedicoId = medicoId;
            MedicoNome = medicoNome;
            MedicoEspecialidade = medicoEspecialidade;
            PacienteId = pacienteId;
            PacienteNome = pacienteNome;
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

        public bool ProntuarioExists(string medicoId, string pacienteId)
        {
            return MedicoId == medicoId && PacienteId == pacienteId;
        }
    }
}