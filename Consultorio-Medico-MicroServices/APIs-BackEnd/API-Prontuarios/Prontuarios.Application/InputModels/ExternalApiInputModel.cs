namespace Prontuarios.Application.InputModels
{
    public class ExternalApiInputModel
    {
        public string Id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string especialidade { get; set; }
        public bool ativo { get; set; }
        public DateTime dataCriacao { get; set; }
    }
}
