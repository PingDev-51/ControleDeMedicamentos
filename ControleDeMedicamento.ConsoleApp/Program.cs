using System.Text.Json;
using ControleDeMedicamento.ConsoleApp.Compartilhado;
using ControleDeMedicamento.ConsoleApp.ModuloEstoque;
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
RepositorioSaida repositorioSaida = new RepositorioSaida(contexto);


TelaPrincipal telaPrincipal = new TelaPrincipal(repositorioFornecedor, repositorioPaciente, repositorioMedicamento, repositorioFuncionario, repositorioSaida);
TelaEstoque telaEstoque = new TelaEstoque(repositorioSaida, repositorioPaciente, repositorioMedicamento);

while (true)
{
    ITelaOpcoes? telaSelecionada = telaPrincipal.ApresentarMenuOpcoesPrincipal();
    if (telaSelecionada == null)
    {
        Console.Clear();
        break;
    }

    while (true)
    {
        string? opcaoSubMenu = telaSelecionada.ObterOpcaoMenu();

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
            if (opcaoSubMenu == "S")
                break;
        }
        //else
       // {
        //    telaEstoque.ApresentarMenuEstoque();
        //}
    }
}