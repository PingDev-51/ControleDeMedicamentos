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
    public uint Quantidade { get; set; }

    public Entrada()
    {

    }

    public Entrada(Medicamento medicamento, Funcionario funcionario, uint quantidade)
    {
        DataDeEntrada = DateTime.Now;
        Medicamento = medicamento;
        Funcionario = funcionario;
        Quantidade = quantidade;
    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (Medicamento == null)
            erros += "O campo Medicamentos precisa ser preenchido;";
        if (Funcionario == null)
            erros += "O campo Funcionario precisa ser preenchido;";
        if (Quantidade < 0)
            erros += "O campo Quantidade  não pode ser um valor negativo;";

        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        throw new NotImplementedException();
    }
}
