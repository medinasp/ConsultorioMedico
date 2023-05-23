namespace CadFunc.Domain.Entities
{
    public class CadMedicos : EntityBase
    {
        public CadMedicos(string nome, string cpf, string especialidade) : base(nome, cpf)
        {
            Especialidade = especialidade;
        }

        public string Especialidade { get; private set; }

        public void Excluir()
        {
            Ativo = false;
        }
    }
}
