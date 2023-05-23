﻿using CadFunc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadFunc.Application.InputModels
{
    public class CadMedicosInputModels
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Especialidade { get; set; }

        public Domain.Entities.CadMedicos ToEntity()
            => new Domain.Entities.CadMedicos(Nome, CPF, Especialidade);
    }
}