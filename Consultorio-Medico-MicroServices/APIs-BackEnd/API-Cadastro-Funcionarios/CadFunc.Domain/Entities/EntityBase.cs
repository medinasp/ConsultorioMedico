namespace CadFunc.Domain.Entities
{
    public abstract class EntityBase
    {
        public EntityBase(string nome, string cpf) 
        {
            Id = Guid.NewGuid();
            Nome = nome;
            CPF = cpf;
            DataCriacao = DateTime.Now;
            Ativo = true;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public bool Ativo { get; protected set; }
    }
}
