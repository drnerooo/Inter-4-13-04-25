using System;

namespace PCPCimag1.Models;

public class Superprodutos
{
    public Peca? Superproduto { get; set; }
    public Peca Pecaref { get; set; }
    public double Quantidade { get; set; }

    public Superprodutos(Peca super, Peca pecaref, double qtd)
    {
        Superproduto = super;
        Pecaref = pecaref;
        Quantidade = qtd;
    }
}
