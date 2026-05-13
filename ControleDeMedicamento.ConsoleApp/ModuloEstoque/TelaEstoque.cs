using System;
using ControleDeMedicamento.ConsoleApp.Compartilhado;
using ControleDeMedicamento.ConsoleApp.ModuloEstoque.RequisiçãoDeSaida;
using ControleDeMedicamento.ConsoleApp.ModuloEstoque.RequisicaoDeSaida;
using ControleDeMedicamento.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamento.ConsoleApp.ModuloPacientes;
using ListaDeCompra.ConsoleApp.Compartilhado;

namespace ControleDeMedicamento.ConsoleApp.ModuloEstoque;


public class TelaEstoque : ITelaOpcoes
{

    private readonly IRepositorio<Saida> repositorioSaida;
    private readonly IRepositorio<Paciente> repositorioPaciente;
    private readonly IRepositorio<Medicamento> repositorioMedicamento;
    public TelaEstoque
    (
        IRepositorio<Saida> repositorioSaida,
        IRepositorio<Paciente> repositorioPaciente,
        IRepositorio<Medicamento> repositorioMedicamento
    )
    {
        this.repositorioSaida = repositorioSaida;
        this.repositorioPaciente = repositorioPaciente;
        this.repositorioMedicamento = repositorioMedicamento;
    }
    public string? ObterOpcaoMenu()
    {
        //Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gerenciamento De Estoque");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Gerenciar Entrada");
        Console.WriteLine("2 - Gerenciar Saída");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write(">> ");
        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        // if (opcaoMenuPrincipal == "1")
        // return null;
        // else if (opcaoMenuPrincipal == "2")
        // return new TelaSaida("Saida", repositorioSaida, repositorioPaciente, repositorioMedicamento);

        return opcaoMenuPrincipal;
    }
}
