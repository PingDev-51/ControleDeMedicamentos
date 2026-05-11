using System;
using ControleDeMedicamento.ConsoleApp.Compartilhado;
using ControleDeMedicamento.ConsoleApp.ModuloPacientes;
using ListaDeCompra.ConsoleApp.Compartilhado;

namespace ControleDeMedicamento.ConsoleApp.ModuloEstoque.RequisiçãoDeSaida;

public class TelaSaida : ITelaOpcoes
{
    private TelaPaciente telaPaciente;
    private RepositorioSaida repositorioSaida;
    private IRepositorio<Paciente> repositorioPacientes;

    public TelaSaida(
        RepositorioSaida repositorioSaida,
        TelaPaciente telaPaciente,
        IRepositorio<Paciente> repositorioPacientes)
    {
        this.repositorioSaida = repositorioSaida;
        this.telaPaciente = telaPaciente;
        this.repositorioPacientes = repositorioPacientes;
    }

    public string? ObterOpcaoMenu()
    {

        Console.Clear();
        Console.WriteLine("==============================================");
        Console.WriteLine($"Gestão de Estoque (Saída)");
        Console.WriteLine("==============================================");
        Console.ResetColor();
        Console.WriteLine($"1 - Registrar Saída");
        Console.WriteLine($"2 - Visualizar Saídas");
        Console.WriteLine("S - Voltar para o início");
        Console.WriteLine("==============================================");
        Console.Write(">> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }

    public void Registrar()
    {
        Console.Clear();
        ExibirCabecalho($"Registro de Saída");

        try
        {
            Saida novaSaida = ObterDadosCadastrais();

            repositorioSaida.Registrar(novaSaida);

            ExibirMensagem("Saída registrada com sucesso!");

        }
        catch (FormatException)
        {
            Console.WriteLine("O formato do valor de um dos campos está inválido.");
            Console.WriteLine("Pressione ENTER para continuar..");
            Console.ReadLine();
            Registrar();
        }
        catch (Exception)
        {
            Console.WriteLine("Ocorreu um erro inesperado. Tente novamente");
            Console.WriteLine("Pressione ENTER para continuar..");
            Console.ReadLine();
            Registrar();
            return;
        }
    }

    public void VisualizarTodos()
    {
        ExibirCabecalho("Visualização de Saídas");

        Console.WriteLine(
                   "{0, -15} | {1, -20} | {2, -20}",
                    "Data", "Paciente", "Medicamento"
               );

        List<Saida> saidas = repositorioSaida.SelecionarTodos();

        foreach (Saida s in saidas)
        {
            Console.WriteLine(
              "{0, -15} | {1, -20} ", //" {2, -20}",
              s.Data.ToShortDateString(), s.Paciente.Nome //, s.Medicamento.Nome
          );
        }
        Console.WriteLine("==============================================");
        Console.Write("Digite ENTER para continuar...");
        Console.ReadLine();
    }


    public Saida ObterDadosCadastrais()
    {
        Console.Write("Digite a Data da Saída: ");
        DateTime data = Convert.ToDateTime(Console.ReadLine());

        telaPaciente.VisualizarTodos(deveExibirCabecalho: false);

        Console.Write("Digite o Id do Paciente: ");

        string idSelecionado = Console.ReadLine() ?? string.Empty;
        Paciente? paciente = repositorioPacientes.SelecionarPorId(idSelecionado);

        if (paciente == null)
        {
            Console.WriteLine("Paciente não encontrado.");
            Console.WriteLine("===============================");
            Console.Write("Aperte ENTER para voltar");
            Console.ReadLine();

            return ObterDadosCadastrais();
        }

        // telaMedicamentos.VisualizarTodos(deveExibirCabecalho: false);
        // Console.Write("Digite o Id do Medicamento: ");
        // string idSelecionado = Console.ReadLine() ?? string.Empty;
        // Medicamento? medicamentos = repositorioMedicamentos.SelecionarPorId(idSelecionado);

        return new Saida(data, paciente);
    }

    protected void ExibirCabecalho(string titulo)
    {
        Console.Clear();
        Console.WriteLine("==============================================");
        Console.WriteLine($"Gestão de Saídas");
        Console.WriteLine("==============================================");
        Console.WriteLine(titulo);
        Console.WriteLine("==============================================");
    }

    protected void ExibirMensagem(string mensagem)
    {
        Console.WriteLine("==============================================");
        Console.WriteLine(mensagem);
        Console.WriteLine("==============================================");
        Console.Write("Digite ENTER para continuar...");
        Console.ReadLine();
    }
}
