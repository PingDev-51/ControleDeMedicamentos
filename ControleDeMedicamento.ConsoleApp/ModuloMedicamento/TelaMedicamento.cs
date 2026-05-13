using System;
using ControleDeMedicamento.ConsoleApp.Compartilhado;
using ControleDeMedicamento.ConsoleApp.ModuloFornecedores;
using ListaDeCompra.ConsoleApp.Compartilhado;

namespace ControleDeMedicamento.ConsoleApp.ModuloMedicamento;

public class TelaMedicamento : TelaBase<Medicamento>, ITelaOpcoes, ITelaCrud
{
    private IRepositorio<Fornecedor> repositorioFornecedor;

    public TelaMedicamento(string nomeEntidade, IRepositorio<Medicamento> repositorio, IRepositorio<Fornecedor> repositorioFornecedor) : base(nomeEntidade, repositorio)
    {
        this.repositorioFornecedor = repositorioFornecedor;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Medicamento");

        Console.WriteLine
        (
            "{0, -7} | {1, -20} | {2, -15} | {3, -15} | {4, -15} | {5, -15}",
            "Id", "Nome", "Descrição", "Quantidade", "Fornecedor", "Quantidade"
        );

        List<Medicamento> medicamentos = repositorio.SelecionarTodos();

        foreach (Medicamento m in medicamentos)
        {
            Fornecedor? f = m.Fornecedor;

            Console.WriteLine
            (
                "{0, -7} | {1, -20} | {2, -15} | {3, -15} | {4, -15} | {5, -15}",
                m.Id, m.Nome, m.Descricao, m.QuantidadeEmEstoque, f?.Nome, m.QuantidadeEmEstoque
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override Medicamento ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do medicamento: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o Descrição do medicamento: ");
        string descricao = Console.ReadLine() ?? string.Empty;

        string idSelecionado = SelecionarFornecedor();

        Fornecedor? fornecedorSelecionado = (Fornecedor?)repositorioFornecedor.SelecionarPorId(idSelecionado);

        if (fornecedorSelecionado == null)
            throw new NullReferenceException("Não foi possivel selecionar este fornecedor.");

        return new Medicamento(nome, descricao, fornecedorSelecionado);
    }

    public string SelecionarFornecedor()
    {

        ExibirCabecalho("Visualização de Pacientes");

        Console.WriteLine
            (
                "{0, -7} | {1, -20} | {2, -15} | {3, -15}",
                "Id", "Nome", "Telefone", "CNPJ"
            );

        List<Fornecedor> fornecedores = repositorioFornecedor.SelecionarTodos();

        foreach (Fornecedor f in fornecedores)
        {
            Console.WriteLine(
              "{0, -7} | {1, -20} | {2, -15} | {3, -15}",
              f.Id, f.Nome, f.Telefone, f.Cnpj
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
