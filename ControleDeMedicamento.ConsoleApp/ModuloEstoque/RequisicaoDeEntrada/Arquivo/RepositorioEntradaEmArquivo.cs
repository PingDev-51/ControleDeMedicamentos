using System;
using ControleDeMedicamento.ConsoleApp.Compartilhado;
using ListaDeCompra.ConsoleApp.Compartilhado.Arquivos;

namespace ControleDeMedicamento.ConsoleApp.ModuloEstoque.RequisicaoDeEntrada.Arquivo;

public class RepositorioEntradaEmArquivo : RepositorioBaseEmArquivo<Entrada>, IRepositorio<Entrada>
{
    public RepositorioEntradaEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Entrada> CarregarRegistros()
    {
        return contexto.Entradas;
    }
}
