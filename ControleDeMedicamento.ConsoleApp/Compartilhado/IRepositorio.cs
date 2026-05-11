using System;

namespace ControleDeMedicamento.ConsoleApp.Compartilhado;

public interface IRepositorio<T>
{
    void Cadastrar(T entidade);
    bool Editar(string idSelecionado, T entidade);
    bool Excluir(T registro);
    T? SelecionarPorId(string idSelecionado);
    List<T> SelecionarTodos();

}
