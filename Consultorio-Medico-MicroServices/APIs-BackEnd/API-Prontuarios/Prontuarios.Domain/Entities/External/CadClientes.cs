using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prontuarios.Domain.Entities.External
{
    public class CadClientes
    {
        public string Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? DataCriacao { get; set; }
        public bool? Ativo { get; set; }

        //o método abaixo é exigido somente para poder rodar as migrations com sucesso
        //private CadClientes()
        //{
        //}

        //public CadCliente(Guid id, string nome, string cpf)
        //{
        //    Id = id;
        //    Nome = nome;
        //    CPF = cpf;
        //}

        //public void Excluir()
        //{
        //    Ativo = false;
        //}

        //public void Update(string nome, string cpf)
        //{
        //    Nome = nome;
        //    CPF = cpf;
        //}
    }
}
