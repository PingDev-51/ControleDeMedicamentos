using System;
using ListaDeCompra.ConsoleApp.Compartilhado.Arquivos;

namespace ControleDeMedicamento.ConsoleApp.ModuloEstoque.RequisiçãoDeSaida;

public class RepositorioSaida
{
    protected List<Saida> registrosSaida = new();
    
    // protected ContextoJson contexto;

    // public RepositorioBaseEmArquivo(ContextoJson contexto)
    //   {
    //   this.contexto = contexto;
    //   this.registros = CarregarRegistros();
    //  }

    // protected abstract List<T> CarregarRegistros();

    public void Registrar(Saida saida)
    {
        registrosSaida.Add(saida);
    }

    public List<Saida> SelecionarTodos()
    {
        return registrosSaida;
    }
}
