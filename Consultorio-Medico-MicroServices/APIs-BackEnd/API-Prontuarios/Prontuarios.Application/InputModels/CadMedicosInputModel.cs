﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prontuarios.Application.InputModels
{
    public class CadMedicosInputModel
    {
        public string Id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string especialidade { get; set; }
        public bool ativo { get; set; }
        public DateTime dataCriacao { get; set; }
    }
}
