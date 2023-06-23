namespace Prontuarios.Domain.Entities
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
            Ativo = true;
        }

        public Guid Id { get; protected set; }
        public DateTime DataCriacao { get; private set; }
        public bool Ativo { get; protected set; }
    }
}