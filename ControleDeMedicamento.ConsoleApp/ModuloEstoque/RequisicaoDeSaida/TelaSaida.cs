using System;
using ControleDeMedicamento.ConsoleApp.Compartilhado;
using ControleDeMedicamento.ConsoleApp.ModuloEstoque.RequisicaoDeSaida;
using ControleDeMedicamento.ConsoleApp.ModuloFornecedores;
using ControleDeMedicamento.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamento.ConsoleApp.ModuloPacientes;
using ListaDeCompra.ConsoleApp.Compartilhado;

namespace ControleDeMedicamento.ConsoleApp.ModuloEstoque.RequisiçãoDeSaida;

public class TelaSaida : TelaBase<Saida>, ITelaCrud, ITelaOpcoes
{
    private IRepositorio<Saida> repositorioSaida;
    private IRepositorio<Paciente> repositorioPacientes;
    private IRepositorio<Medicamento> repositorioMedicamento;

    public TelaSaida(string nomeEntidade, IRepositorio<Saida> repositorio, IRepositorio<Paciente> repositorioPaciente, IRepositorio<Medicamento> repositorioMedicamento) : base(nomeEntidade, repositorio)
    {
        this.repositorioSaida = repositorio;
        this.repositorioPacientes = repositorioPaciente;
        this.repositorioMedicamento = repositorioMedicamento;
    }


    public override string? ObterOpcaoMenu()
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

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        ExibirCabecalho("Visualização de Saídas");

        Console.WriteLine
            (
                "{0, -15} | {1, -20} | {2, -20}",
                "Data", "Paciente", "Medicamento"
            );

        List<Saida> saidas = repositorioSaida.SelecionarTodos();

        foreach (Saida s in saidas)
        {
            Medicamento? m = s.Medicamentos;
            Console.WriteLine
            (
                "{0, -15} | {1, -20}  |  {2, -20}",
                s.Data.ToShortDateString(), s.Paciente.Nome, m?.Nome
            );
        }

        Console.WriteLine("========================================");
        Console.Write("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    protected override Saida ObterDadosCadastrais()
    {
        Console.Write("Digite a Data da Saída: ");
        DateTime data = Convert.ToDateTime(Console.ReadLine());

        string idSelecionadoDoPaciente = SelecionarPaciente();

        Paciente? pacienteSelecionado = (Paciente?)repositorioPacientes.SelecionarPorId(idSelecionadoDoPaciente);

        if (pacienteSelecionado == null)
            throw new NullReferenceException("Não foi possivel selecionar este paciente");

        string idSelecionadoDoMedicamento = SelecionarMedicamento();

        Medicamento? medicamentoSelecionado = (Medicamento?)repositorioMedicamento.SelecionarPorId(idSelecionadoDoMedicamento);

        if (medicamentoSelecionado == null)
            throw new NullReferenceException("Não foi possivel selecionar este medicamento");

        return new Saida(data, pacienteSelecionado, medicamentoSelecionado);
    }

    public string SelecionarPaciente()
    {
        Console.WriteLine
            (
                "{0, -7} | {1, -20} | {2, -15} | {3, -15} | {4, -11}",
                "Id", "Nome", "Telefone", "Cartão do Sus", "CPF"
            );

        List<Paciente> pacientes = repositorioPacientes.SelecionarTodos();

        foreach (Paciente p in pacientes)
        {
            Console.WriteLine(
              "{0, -7} | {1, -20} | {2, -15} | {3, -15} | {4, -11}",
              p.Id, p.Nome, p.Telefone, p.CartaoSus, p.Cpf
          );
        }

        string? idSelecionado;
        do
        {
            Console.Write("Digite o ID da categoria em que deseja guardar o produto: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        return idSelecionado;
    }

    public string SelecionarMedicamento()
    {
        Console.WriteLine
        (
            "{0, -7} | {1, -20} | {2, -15} | {3, -15} | {4, -15}",
            "Id", "Nome", "Descrição", "Quantidade", "Fornecedor"
        );

        List<Medicamento> medicamentos = repositorioMedicamento.SelecionarTodos();

        foreach (Medicamento m in medicamentos)
        {
            Fornecedor? f = m.Fornecedor;

            Console.WriteLine(
              "{0, -7} | {1, -20} | {2, -15} | {3, -15} | {4, -15}",
              m.Id, m.Nome, m.Descricao, m.QuantidadeEmEstoque, f?.Nome
          );
        }

        string? idSelecionado;
        do
        {
            Console.Write("Digite o ID da categoria em que deseja guardar o produto: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        return idSelecionado;
    }
}