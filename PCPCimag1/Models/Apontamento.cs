using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPCimag1.Models
{
    public class Apontamento
    {
        public int Id { get; set; }
        public required OrdemDeProducao OrdemDeProducao{ get; set; }
        public  List<Operador>? operador { get; }
        public required Operacao operacao { get; set; }
        public int Quantidade { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime? Fim { get; set; }

    }
}