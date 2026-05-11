using System;
using ControleDeMedicamento.ConsoleApp.Compartilhado;
using ControleDeMedicamento.ConsoleApp.ModuloEstoque.RequisiçãoDeSaida;
using ControleDeMedicamento.ConsoleApp.ModuloPacientes;
using ListaDeCompra.ConsoleApp.Compartilhado;

namespace ControleDeMedicamento.ConsoleApp.ModuloEstoque;


public class TelaEstoque : ITelaOpcoes
{
    public TelaSaida telaSaida;

    public TelaEstoque(
        RepositorioSaida repositorioSaida,
        TelaPaciente telaPaciente,
       IRepositorio<Paciente> repositorioPacientes
    )
    {
        telaSaida = new TelaSaida(
            repositorioSaida,
            telaPaciente,
            repositorioPacientes
        );
    }

    public string? ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gerenciamento De Estoque");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Gerenciar Entrada");
        Console.WriteLine("2 - Gerenciar Saída");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write(">> ");
        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        if (opcaoMenuPrincipal == "1")
            return null; //colocar a saída aqui


        if (opcaoMenuPrincipal == "2")
            while (true)
            {
                string? opcao = telaSaida.ObterOpcaoMenu();

                if (opcao == "S")
                {
                    Console.Clear();
                    break;
                }

                switch (opcao)
                {
                    case "1":
                        telaSaida.Registrar();
                        break;

                    case "2":
                        telaSaida.VisualizarTodos();
                        break;
                }
            }

        if (opcaoMenuPrincipal == "S"){ // resolver de voltar para o menu principal
            
        }

        return opcaoMenuPrincipal;
    }
}
