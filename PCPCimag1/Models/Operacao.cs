using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPCimag1.Models
{
    public class Operacao
    {
        public int Id { get; set; }
        public required string Descricao { get; set; }
        public required TipoDeOperacao TipoDeOperacao{ get; set; }
        public List<Apontamento>? Apontamentos{ get; }
        public List<PecaOperacao>? PecaOperacaoes { get; }
    }
}