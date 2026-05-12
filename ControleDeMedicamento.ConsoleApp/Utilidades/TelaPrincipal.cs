
using System.Collections;
using System.Net;
using System.Runtime.CompilerServices;
using ControleDeMedicamento.ConsoleApp.Compartilhado;
using ControleDeMedicamento.ConsoleApp.ModuloFornecedores;
using ControleDeMedicamento.ConsoleApp.ModuloEstoque;
using ControleDeMedicamento.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamento.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamento.ConsoleApp.ModuloPacientes;
using ListaDeCompra.ConsoleApp.Compartilhado;

class TelaPrincipal
{
    //instaciar o repositorio de fornecedores aqui em baixo
    private readonly IRepositorio<Fornecedor> repositorioFornecedor;
    private readonly IRepositorio<Paciente> repositorioPaciente;
    private readonly IRepositorio<Medicamento> repositorioMedicamento;
    private readonly IRepositorio<Funcionario> repositorioFuncionario;
    private readonly TelaEstoque telaEstoque;

    public TelaPrincipal
    (
        IRepositorio<Fornecedor> repositorioFornecedor,
        IRepositorio<Paciente> repositorioPaciente,
        IRepositorio<Medicamento> repositorioMedicamento,
        IRepositorio<Funcionario> repositorioFuncionario,
        TelaEstoque telaEstoque
    )
    {
        this.repositorioFornecedor = repositorioFornecedor;
        this.repositorioPaciente = repositorioPaciente;
        this.repositorioMedicamento = repositorioMedicamento;
        this.repositorioFuncionario = repositorioFuncionario;
        this.telaEstoque = telaEstoque;
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
            return new TelaMedicamento("Medicamento", repositorioMedicamento, repositorioFornecedor);

        if (opcaoMenuPrincipal == "4")
            return new TelaFuncionario("Funcionarios", repositorioFuncionario);

        if (opcaoMenuPrincipal == "5")
            return telaEstoque;

        return null;
    }
}
