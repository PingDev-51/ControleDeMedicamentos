using System;
using ControleDeMedicamento.ConsoleApp.Compartilhado;
using ListaDeCompra.ConsoleApp.Compartilhado.Arquivos;
using System.Collections.Generic;

namespace ControleDeMedicamento.ConsoleApp.ModuloEstoque.RequisiçãoDeSaida;

public class RepositorioSaida : RepositorioBaseEmArquivo<Saida>, IRepositorio<Saida>
{
    public RepositorioSaida(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Saida> CarregarRegistros()
    {
        return contexto.Saidas;
    }
}