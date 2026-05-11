
using System.Collections;
using System.Net;
using System.Runtime.CompilerServices;
using ControleDeMedicamento.ConsoleApp.Compartilhado;
using ControleDeMedicamento.ConsoleApp.ModuloFornecedores;
using ControleDeMedicamento.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamento.ConsoleApp.ModuloPacientes;
using ListaDeCompra.ConsoleApp.Compartilhado;
class TelaPrincipal
{
    //instaciar o repositorio de fornecedores aqui em baixo

    private readonly IRepositorio<Fornecedor> repositorioFornecedor;
    private readonly IRepositorio<Paciente> repositorioPaciente;
    private readonly IRepositorio<Funcionario> repositorioFuncionario;

    public TelaPrincipal(IRepositorio<Fornecedor> repositorioFornecedor, IRepositorio<Paciente> repositorioPaciente, IRepositorio<Funcionario> repositorioFuncionario)
    {
        this.repositorioFornecedor = repositorioFornecedor;
        this.repositorioPaciente = repositorioPaciente;
        //medicamentos
        this.repositorioFuncionario = repositorioFuncionario;
    }

    public ITelaOpcoes? ApresentarMenuOpcoesPrincipal()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Controle De Medicamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Gerenciar Fornecedores");
        Console.WriteLine("2 - Gerenciar Pacientes");
        Console.WriteLine("3 - Gerenciar Medicamentos");
        Console.WriteLine("4 - Gerenciar Funcionários");
        Console.WriteLine("5 - Gerenciar Estoque");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write(">> ");
        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        if (opcaoMenuPrincipal == "1")
            return new TelaFornecedores("Fornecedores", repositorioFornecedor);

        if (opcaoMenuPrincipal == "2")
            return new TelaPaciente("Pacientes", repositorioPaciente);

        if (opcaoMenuPrincipal == "3")
            return null; // passar modulo de pacientes aqui

        if (opcaoMenuPrincipal == "4")
            return new TelaFuncionario("Funcinarios", repositorioFuncionario);

        return null;
    }
}
