using System;

namespace PCPCimag1.Models;

public class Subprodutos
{
    public Peca? Subproduto { get; set; }
    public Peca Pecaref { get; set; }
    public double Quantidade { get; set; }

    public Subprodutos(Peca sub, Peca pecaref, double qtd)
    {
        Subproduto = sub;
        Pecaref = pecaref;
        Quantidade = qtd;
    }
}
