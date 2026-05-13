using System.Text.Json;
using ControleDeMedicamento.ConsoleApp.Compartilhado;
using ControleDeMedicamento.ConsoleApp.ModuloEstoque;
using ControleDeMedicamento.ConsoleApp.ModuloEstoque.RequisicaoDeEntrada;
using ControleDeMedicamento.ConsoleApp.ModuloEstoque.RequisicaoDeEntrada.Arquivo;
using ControleDeMedicamento.ConsoleApp.ModuloEstoque.RequisiçãoDeSaida;
using ControleDeMedicamento.ConsoleApp.ModuloEstoque.RequisicaoDeSaida;
using ControleDeMedicamento.ConsoleApp.ModuloFornecedores;
using ControleDeMedicamento.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamento.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamento.ConsoleApp.ModuloMedicamento.Arquivo;
using ControleDeMedicamento.ConsoleApp.ModuloPacientes;
using ListaDeCompra.ConsoleApp.Compartilhado;
using ListaDeCompra.ConsoleApp.Compartilhado.Arquivos;

ContextoJson contexto = new ContextoJson();
try
{
    contexto.Carregar();
}
catch (JsonException)
{
    Console.WriteLine("O arquivo de armazenamento esta corrompido, contate a administração.");
    Console.WriteLine("Pressione ENTER para continuar..");
    Console.ReadLine();
}


IRepositorio<Fornecedor> repositorioFornecedor = new RepositorioFornecedoresEmArquivo(contexto);
IRepositorio<Paciente> repositorioPaciente = new RepositorioPaciente(contexto);
IRepositorio<Medicamento> repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contexto);
IRepositorio<Funcionario> repositorioFuncionario = new RepositorioFuncionarios(contexto);
IRepositorio<Saida> repositorioSaida = new RepositorioSaida(contexto);
IRepositorio<Entrada> repositorioEntrada = new RepositorioEntradaEmArquivo(contexto);

TelaPrincipal telaPrincipal = new TelaPrincipal(repositorioFornecedor, repositorioPaciente, repositorioMedicamento, repositorioFuncionario, repositorioSaida);

while (true)
{
    ITelaOpcoes? telaSelecionada = telaPrincipal.ApresentarMenuOpcoesPrincipal();
    if (telaSelecionada == null)
    {
        //Console.Clear();
        break;
    }

    while (true)
    {
        string? opcaoSubMenu = telaSelecionada.ObterOpcaoMenu();

        if (opcaoSubMenu == "S")
            break;
        if (telaSelecionada is TelaEstoque telaEstoque)
        {
            if (opcaoSubMenu == "1")
                telaSelecionada = new TelaEntrada("Entrada", repositorioEntrada, repositorioMedicamento, repositorioFuncionario);

            if (opcaoSubMenu == "2")
                telaSelecionada = new TelaSaida("Saida", repositorioSaida, repositorioPaciente, repositorioMedicamento);

            continue;
        }

        if (telaSelecionada is TelaSaida telaSaida)
        {
            if (opcaoSubMenu == "1")
                telaSaida.Cadastrar();

            else if (opcaoSubMenu == "2")
                telaSaida.VisualizarTodos(deveExibirCabecalho: false);

            continue;
        }

        if (telaSelecionada is TelaEntrada telaEntrada)
        {
            if (opcaoSubMenu == "1")
                telaEntrada.Cadastrar();

            else if (opcaoSubMenu == "2")
                telaEntrada.VisualizarTodos(deveExibirCabecalho: false);

            continue;
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
