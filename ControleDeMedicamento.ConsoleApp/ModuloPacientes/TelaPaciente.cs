using System;
using ControleDeMedicamento.ConsoleApp.Compartilhado;
using ListaDeCompra.ConsoleApp.Compartilhado;

namespace ControleDeMedicamento.ConsoleApp.ModuloPacientes;

public class TelaPaciente : TelaBase<Paciente>, ITelaCrud, ITelaOpcoes
{
    public TelaPaciente(string nomeEntidade, IRepositorio<Paciente> repositorio) : base(nomeEntidade, repositorio)
    {
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {

        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Pacientes");

        Console.WriteLine(
                   "{0, -7} | {1, -20} | {2, -15} | {3, -15} | {4, -11}",
                   "Id", "Nome", "Telefone", "Cartão do Sus", "CPF"
               );

        List<Paciente> pacientes = repositorio.SelecionarTodos();

        foreach (Paciente p in pacientes)
        {
            Console.WriteLine(
              "{0, -7} | {1, -20} | {2, -15} | {3, -15} | {4, -11}",
              p.Id, p.Nome, p.Telefone, p.CartaoSus, p.Cpf
          );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
        }

    }

    protected override Paciente ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do paciente: ");
        string? Nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o telefone do paciente: ");
        string? Telefone = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o Cartão Do SUS do paciente: ");
        string? CartaoSus = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o CPF do paciente: ");
        string? Cpf = Console.ReadLine() ?? string.Empty;

        return new Paciente(Nome, Telefone, CartaoSus, Cpf);
    }
}
