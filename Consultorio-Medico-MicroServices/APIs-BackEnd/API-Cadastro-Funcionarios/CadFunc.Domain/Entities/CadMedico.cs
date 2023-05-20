namespace CadFunc.Domain.Entities
{
    public class CadMedico : EntityBase
    {
        public CadMedico(string nome, string cpf, string especialidade)
        {
            Nome = nome;
            CPF = cpf;
            Especialidade = especialidade;
            DataCriacao = DateTime.Now;
            Ativo = true;
        }

        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Especialidade { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public bool Ativo { get; private set; }

        public void Excluir()
        {
            Ativo = false;
        }
    }
}
