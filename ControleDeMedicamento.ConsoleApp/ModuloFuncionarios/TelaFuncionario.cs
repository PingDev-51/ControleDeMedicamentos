using System;
using ListaDeCompra.ConsoleApp.Compartilhado;

namespace ControleDeMedicamento.ConsoleApp.ModuloFuncionarios;

public class TelaFuncionario : TelaBase<Funcionario>, ITelaCrud, ITelaOpcoes
{
    public TelaFuncionario(string nomeEntidade, RepositorioFuncionarios repositorio) : base(nomeEntidade, repositorio)
    {
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {

        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Funcionários");

        Console.WriteLine(
                   "{0, -7} | {1, -20} | {2, -15} | {3, -11}",
                   "Id", "Nome", "Telefone", "CPF"
               );

        List<Funcionario> funcionarios = repositorio.SelecionarTodos();

        foreach (Funcionario p in funcionarios)
        {
            Console.WriteLine(
              "{0, -7} | {1, -20} | {2, -15} | {3, -11}",
              p.Id, p.Nome, p.Telefone, p.Cpf
          );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override Funcionario ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do funcionario: ");
        string? Nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o telefone do funcionario: ");
        string? Telefone = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o CPF do funcionario: ");
        string? Cpf = Console.ReadLine() ?? string.Empty;

        return new Funcionario(Nome, Telefone, Cpf);
    }

    protected override List<string> ValidarRegistroDuplicado(Funcionario? novaEntidade = null, string? idIgnorado = null)
    {
        List<string> erros = new List<string>();

        if (novaEntidade == null)
            return erros;

        List<Funcionario> funcionarios = repositorio.SelecionarTodos();

        foreach (Funcionario f in funcionarios)
        {
            if (f.Id != idIgnorado && f.Cpf == novaEntidade.Cpf)
            {
                erros.Add("Já existe um funcionário com esse CPF");
                break;
            }
        }

        return erros;
    }
}
