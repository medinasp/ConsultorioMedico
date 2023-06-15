using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadCli.Domain.Entities
{
    public class CadCliente : EntityBase
    {
        //o método abaixo é exigido somente para poder rodar as migrations com sucesso
        private CadCliente() : base("", "")
        {
        }

        public CadCliente(string nome, string cpf) : base(nome, cpf)
        {
        }

        public void Excluir()
        {
            Ativo = false;
        }

        public void Update(string nome, string cpf)
        {
            Nome = nome;
            CPF = cpf;
        }
    }
}
