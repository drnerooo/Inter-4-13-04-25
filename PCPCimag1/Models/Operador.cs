using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPCimag1.Models
{
    public class Operador
    {
        public int Id { get; set; }
        public required Funcionario Funcionario{ get; set; }
        public List<Apontamento>? Apontamentos { get; set; }
    }
}