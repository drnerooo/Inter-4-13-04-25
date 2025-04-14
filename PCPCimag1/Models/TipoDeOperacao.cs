using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPCimag1.Models
{
    public class TipoDeOperacao
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public List<Operacao>? Operacoes { get; }
    }
}