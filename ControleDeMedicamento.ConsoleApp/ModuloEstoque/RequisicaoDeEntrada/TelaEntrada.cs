using System;
using ControleDeMedicamento.ConsoleApp.Compartilhado;
using ListaDeCompra.ConsoleApp.Compartilhado;

namespace ControleDeMedicamento.ConsoleApp.ModuloEstoque.RequisicaoDeEntrada;

public class TelaEntrada : TelaBase<Entrada>, ITelaCrud, ITelaOpcoes
{
    public TelaEntrada(string nomeEntidade, IRepositorio<Entrada> repositorio) : base(nomeEntidade, repositorio)
    {
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        throw new NotImplementedException();
    }

    protected override Entrada ObterDadosCadastrais()
    {
        throw new NotImplementedException();
    }
}
