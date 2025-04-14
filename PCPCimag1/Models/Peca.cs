using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPCimag1.Models
{
    public class Peca
    {
        public int Id { get; set; }
        public required string Descricao { get; set; } 
        public DateTime Data_Cadastro { get; set; }
        public double Valor { get; set; }
        public bool Situacao { get; set; }
        public string? Imagem { get; set; }
        public List<OrdemDeProducao>? Ops{ get; }
        public List<PecaOperacao>? PecaOperacoes { get; }
        public List<Subprodutos>? Subprodutos{ get;}
    }
}