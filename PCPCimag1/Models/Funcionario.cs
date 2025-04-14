using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPCimag1.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public List<PCP>? PCPs { get; }
        public List<Operador>? Operadores { get; }
        public required string Login { get; set; }
        public required string Senha { get; set; }
    }
}