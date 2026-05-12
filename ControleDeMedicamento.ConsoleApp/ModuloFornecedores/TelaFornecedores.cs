using System;
using ControleDeMedicamento.ConsoleApp.Compartilhado;
using ListaDeCompra.ConsoleApp.Compartilhado;

namespace ControleDeMedicamento.ConsoleApp.ModuloFornecedores;

public class TelaFornecedores : TelaBase<Fornecedor>, ITelaOpcoes, ITelaCrud
{
    public TelaFornecedores(string nomeEntidade, IRepositorio<Fornecedor> repositorio) : base(nomeEntidade, repositorio)
    {
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Pacientes");

        Console.WriteLine
            (
                "{0, -7} | {1, -20} | {2, -15} | {3, -15}",
                "Id", "Nome", "Telefone", "CNPJ"
            );

        List<Fornecedor> fornecedores = repositorio.SelecionarTodos();

        foreach (Fornecedor f in fornecedores)
        {
            Console.WriteLine(
              "{0, -7} | {1, -20} | {2, -15} | {3, -15}",
              f.Id, f.Nome, f.Telefone, f.Cnpj
          );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override Fornecedor ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do fornecedor: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o telefone do fornecedor: ");
        string telefone = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o CNPJ do fornecedor: ");
        string cnpj = Console.ReadLine() ?? string.Empty;

        return new Fornecedor(nome, telefone, cnpj);
    }

    protected override List<string> ValidarRegistroDuplicado(Fornecedor? novaEntidade = null, string? idIgnorado = null)
    {
        List<string> erros = new List<string>();

        if (nomeEntidade == null)
            return erros;
        List<Fornecedor> Fornecedores = repositorio.SelecionarTodos();

        foreach (Fornecedor f in Fornecedores)
        {
            if (f.Id != idIgnorado && f.Cnpj == novaEntidade?.Cnpj)
            {
                erros.Add("Já existe um fornecedor com esse CNPJ");
                break;
            }
        }
        return erros;
    }
}