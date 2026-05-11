using ControleDeMedicamento.ConsoleApp.Compartilhado;
using ControleDeMedicamento.ConsoleApp.ModuloPacientes;
using ListaDeCompra.ConsoleApp.Compartilhado;
using ListaDeCompra.ConsoleApp.Compartilhado.Arquivos;

ContextoJson contexto = new ContextoJson();
contexto.Carregar();

IRepositorio<Paciente> repositorioPaciente = new RepositorioPaciente(contexto);
TelaPrincipal telaPrincipal = new TelaPrincipal(repositorioPaciente);

while (true)
{
    ITelaOpcoes? telaSelecionada = telaPrincipal.ApresentarMenuOpcoesPrincipal();

    if (telaSelecionada == null)
    {
        Console.Clear();


        continue;
    }

    while (true)
    {
        string? opcaoSubMenu = telaSelecionada.ObterOpcaoMenu();
        if (opcaoSubMenu == "S")
        {
            Console.Clear();
            break;
        }
        if (telaSelecionada is ITelaCrud telaCrud)
        {
            if (opcaoSubMenu == "1")
                telaCrud.Cadastrar();

            else if (opcaoSubMenu == "2")
                telaCrud.Editar();

            else if (opcaoSubMenu == "3")
                telaCrud.Excluir();

            else if (opcaoSubMenu == "4")
                telaCrud.VisualizarTodos(deveExibirCabecalho: true);
        }
    }
}