using System;
using ControleDeMedicamento.ConsoleApp.Compartilhado;
using ControleDeMedicamento.ConsoleApp.ModuloFornecedores;
using ControleDeMedicamento.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamento.ConsoleApp.ModuloMedicamento;
using ListaDeCompra.ConsoleApp.Compartilhado;

namespace ControleDeMedicamento.ConsoleApp.ModuloEstoque.RequisicaoDeEntrada;

public class TelaEntrada : TelaBase<Entrada>, ITelaCrud, ITelaOpcoes
{
    private IRepositorio<Medicamento> repositorioMedicamento;
    private IRepositorio<Funcionario> repositorioFuncionario;

    public TelaEntrada
    (
        string nomeEntidade,
        IRepositorio<Entrada> repositorio,
        IRepositorio<Medicamento> repositorioMedicamento,
        IRepositorio<Funcionario> repositorioFuncionario

    ) : base(nomeEntidade, repositorio)
    {
        this.repositorioMedicamento = repositorioMedicamento;
        this.repositorioFuncionario = repositorioFuncionario;
    }

    public override string? ObterOpcaoMenu()
    {

        Console.Clear();
        Console.WriteLine("==============================================");
        Console.WriteLine($"Gestão de Estoque (Entrada)");
        Console.WriteLine("==============================================");
        Console.ResetColor();
        Console.WriteLine($"1 - Registrar Entrada");
        Console.WriteLine($"2 - Visualizar Entrada");
        Console.WriteLine("S - Voltar para o início");
        Console.WriteLine("==============================================");
        Console.Write(">> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        Console.WriteLine
        (
            "{0, -15} | {1, -20} | {2, -20} | {3, -15}",
            "Data", "Medicamentos", "Funcionarios", "Quantidade"
        );

        List<Entrada> entradas = repositorio.SelecionarTodos();

        foreach (Entrada e in entradas)
        {
            Medicamento? m = e.Medicamento;
            Funcionario? f = e.Funcionario;

            Console.WriteLine
            (
                "{0, -15} | {1, -20} | {2, -20} | {3, -20}",
                e.DataDeEntrada.ToShortDateString(), m.Nome, f.Nome, e.Quantidade
            );
        }

        Console.WriteLine("========================================");
        Console.Write("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    protected override Entrada ObterDadosCadastrais()
    {
        string idSelecionadoDoMedicamento = SelecionarMedicamento();
        Medicamento? medicamentoSelecionado = repositorioMedicamento.SelecionarPorId(idSelecionadoDoMedicamento);

        if (medicamentoSelecionado == null)
            throw new NullReferenceException("Não foi possivel selecionar este medicamento..");

        Console.Write("Digite a quantidade de medicamentos: ");
        int quantidade = Convert.ToInt32(Console.ReadLine());

        string idSelecionadoDoFuncionario = SelecionarFuncionario();
        Funcionario? funcionarioSelecionado = repositorioFuncionario.SelecionarPorId(idSelecionadoDoFuncionario);

        if (funcionarioSelecionado == null)
            throw new NullReferenceException("Não foi possivel selecionar este funcionario..");

        medicamentoSelecionado.QuantidadeEmEstoque += quantidade;

        return new Entrada(medicamentoSelecionado, funcionarioSelecionado, quantidade);
    }

    public string SelecionarMedicamento()
    {
        Console.WriteLine
        (
            "{0, -7} | {1, -20} | {2, -15} | {3, -15} | {4, -15} | {5, -15}",
            "Id", "Nome", "Descrição", "Quantidade", "Fornecedor", "Quantidade"
        );

        List<Medicamento> medicamentos = repositorioMedicamento.SelecionarTodos();

        foreach (Medicamento m in medicamentos)
        {
            Fornecedor? f = m.Fornecedor;

            Console.WriteLine
            (
                "{0, -7} | {1, -20} | {2, -15} | {3, -15} | {4, -15} | {5, -15}",
                m.Id, m.Nome, m.Descricao, m.QuantidadeEmEstoque, f?.Nome, m.QuantidadeEmEstoque
            );
        }

        Console.WriteLine("Escolha o medicamento que deseja.");

        string? idSelecionado;
        do
        {
            Console.Write("Digite o ID do Medicamento: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        return idSelecionado;
    }

    public string SelecionarFuncionario()
    {
        Console.WriteLine
        (
            "{0, -7} | {1, -20} | {2, -15} | {3, -11}",
            "Id", "Nome", "Telefone", "CPF"
        );

        List<Funcionario> funcionarios = repositorioFuncionario.SelecionarTodos();

        foreach (Funcionario p in funcionarios)
        {
            Console.WriteLine
            (
                "{0, -7} | {1, -20} | {2, -15} | {3, -11}",
                p.Id, p.Nome, p.Telefone, p.Cpf
            );
        }

        Console.WriteLine("Qual o funcionario que está efetuando esta requisição: ");

        string? idSelecionado;
        do
        {
            Console.Write("Digite o ID do Funcionario: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        return idSelecionado;
    }

}
