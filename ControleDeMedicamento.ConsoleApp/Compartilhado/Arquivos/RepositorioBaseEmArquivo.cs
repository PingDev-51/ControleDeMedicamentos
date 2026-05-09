using System;

namespace ListaDeCompra.ConsoleApp.Compartilhado.Arquivos;

public abstract class RepositorioBaseEmArquivo<T> where T : EntidadeBase
{
    //protected T?[] registros = new T[100];
    protected List<T> registros;

    protected ContextoJson contexto;

    public RepositorioBaseEmArquivo(ContextoJson contexto)
    {
        this.contexto = contexto;

        this.registros = CarregarRegistros();
    }

    protected abstract List<T> CarregarRegistros();

    public void Cadastrar(T entidade)
    {
        registros.Add(entidade);

        contexto.Salvar();

        // quem fica responsavel por tudo agr é o Add.

        // for (int i = 0; i < registros.Count; i++) // count atualiza de acordo com os espaços oculados na memoria, nao conta espaços null
        // {
        //     if (registros[i] == null)
        //     {
        //         registros[i] = entidade;
        //         break;
        //     }
        // }
    }

    public bool Editar(string idSelecionado, T entidade)
    {
        T? entidadeSelecionada = SelecionarPorId(idSelecionado);

        if (entidadeSelecionada == null)
            return false;

        entidadeSelecionada.AtualizarDados(entidade);

        contexto.Salvar();

        return true;
    }

    public bool Excluir(string idSelecionado)
    {
        T? registroSelecionado = SelecionarPorId(idSelecionado);

        if (registroSelecionado == null)
            return false;

        registros.Remove(registroSelecionado);
        contexto.Salvar();

        // for (int i = 0; i < registros.Length; i++)
        // {
        //     T? c = registros[i];

        //     if (c == null)
        //         continue;

        //     if (c.Id == idSelecionado)
        //     {
        //         registros[i] = null;
        //         return true;
        //     }
        // }

        return true;
    }

    public T? SelecionarPorId(string idSelecionado)
    {
        //versao 1 foeach
        foreach (T registro in registros)
        {
            if (registro.Id == idSelecionado)
                return registro;
        }

        return null;

        //versao 2 com for
        // for (int i = 0; i < registros.Count; i++)
        // {
        //     T? c = (T?)registros[i];

        //     if (c == null)
        //         continue;

        //     if (c.Id == idSelecionado)
        //     {
        //         entidadeSelecionada = c;
        //         break;
        //     }
        // }

        //return entidadeSelecionada;
    }

    public List<T> SelecionarTodos()
    {
        return registros;
    }
}
