using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryRH
{
    public class Funcionario
    {
        public string codigo { get; set; }
        public string nome { get; set; }
        public DateTime dataNascimento { get; set; }
        public Departamento departamento { get; set; }
    }
}
