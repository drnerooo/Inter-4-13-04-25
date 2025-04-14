using System;

namespace PCPCimag1.Models;

public class PecaOperacao
{
    public required Peca Peca { get; set; }
    public required Operacao Operacao { get; set; }
    public int etapa;
}
