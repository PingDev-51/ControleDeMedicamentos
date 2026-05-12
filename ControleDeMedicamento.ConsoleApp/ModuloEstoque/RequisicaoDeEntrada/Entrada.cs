using System;
using ControleDeMedicamento.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamento.ConsoleApp.ModuloMedicamento;
using ListaDeCompra.ConsoleApp.Compartilhado;

namespace ControleDeMedicamento.ConsoleApp.ModuloEstoque.RequisicaoDeEntrada;

public class Entrada : EntidadeBase
{

    public DateTime DataDeEntrada { get; set; }
    public Medicamento Medicamento { get; set; } = null!;
    public Funcionario Funcionario { get; set; } = null!;
    public int Quantidade { get; set; }

    public Entrada()
    {

    }

    public Entrada(DateTime dataDeEntrada, Medicamento medicamento, Funcionario funcionario, int quantidade)
    {
        DataDeEntrada = dataDeEntrada;
        Medicamento = medicamento;
        Funcionario = funcionario;
        Quantidade = quantidade;
    }

    public override string[] Validar()
    {
        throw new NotImplementedException();
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        throw new NotImplementedException();
    }
}
