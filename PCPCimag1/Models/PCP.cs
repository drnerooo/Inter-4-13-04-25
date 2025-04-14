using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPCimag1.Models
{
    public class PCP
    {
        public int Id { get; set; }
        public required Funcionario Funcionario{ get; set; }
        public List<OrdemDeProducao>? ODP{ get; }
    }
}