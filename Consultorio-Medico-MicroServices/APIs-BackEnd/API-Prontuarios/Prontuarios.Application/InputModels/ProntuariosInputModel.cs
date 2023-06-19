using Prontuarios.Domain.Entities;

namespace Prontuarios.Application.InputModels
{
    //public class ProntuariosInputModel
    //{
    //    public CadMedicos Medico { get; set; }
    //    public CadClientes Cliente { get; set; }
    //    public string TextoProntuario { get; set; }

    //    public Prontuario ToEntity()
    //        => new(Medico, Cliente, TextoProntuario);

    //}

    public class ProntuariosInputModel
    {
        public string TextoProntuario { get; set; }
        public string MedicoId { get; set; }
        public string PacienteId { get; set; }

        public Prontuario ToEntity()
        {
            return new Prontuario(MedicoId, PacienteId, TextoProntuario);
        }
    }

}