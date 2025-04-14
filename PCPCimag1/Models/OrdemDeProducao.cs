        using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPCimag1.Models
{
    public class OrdemDeProducao
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public required DateTime DataEmissao { get; set; }
        public required Peca peca{ get; set; }
        public List <PCP>? PCPEmissor { get; }
        public required Apontamento Apontamentos{ get; set; }

    }
}