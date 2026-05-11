using System;
using ListaDeCompra.ConsoleApp.Compartilhado.Arquivos;

namespace ControleDeMedicamento.ConsoleApp.ModuloFuncionarios;

public class RepositorioFuncionarios : RepositorioBaseEmArquivo<Funcionario>
{
    public RepositorioFuncionarios(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Funcionario> CarregarRegistros()
    {
        return contexto.Funcionarios;
    }
}
