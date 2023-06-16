namespace CadFunc.Domain.Entities
{
    public class CadMedicos : EntityBase
    {
        public string Especialidade { get; private set; }

        //o método abaixo é exigido somente para poder rodar as migrations com sucesso
        public CadMedicos() : base("", "")
        {
        }

        public CadMedicos(string nome, string cpf, string especialidade) : base(nome, cpf)
        {
            Especialidade = especialidade;
        }

        public void Excluir()
        {
            Ativo = false;
        }

        public void Update(string nome, string cpf, string especialidade)
        {
            Nome = nome;
            CPF = cpf;
            Especialidade = especialidade;
        }
    }
}
