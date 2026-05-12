using System;
using ListaDeCompra.ConsoleApp.Compartilhado;

namespace ControleDeMedicamento.ConsoleApp.ModuloEstoque.RequisicaoDeSaida;

public interface ITelaOpcoesEstoque : ITelaOpcoes
{
    public string? ObterOpcaoMenuEstoque();
}
