using System;
using ControleDeMedicamento.ConsoleApp.Compartilhado;
using ListaDeCompra.ConsoleApp.Compartilhado.Arquivos;

namespace ControleDeMedicamento.ConsoleApp.ModuloFornecedores;

public class RepositorioFornecedoresEmArquivo : RepositorioBaseEmArquivo<Fornecedor>, IRepositorio<Fornecedor>
{
    public RepositorioFornecedoresEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Fornecedor> CarregarRegistros()
    {
        return contexto.Fornecedor;
    }
}
