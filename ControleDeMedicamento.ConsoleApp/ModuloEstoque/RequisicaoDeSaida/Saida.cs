using System;
using System.Diagnostics.Contracts;
using ControleDeMedicamento.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamento.ConsoleApp.ModuloPacientes;
using ListaDeCompra.ConsoleApp.Compartilhado;

namespace ControleDeMedicamento.ConsoleApp.ModuloEstoque.RequisiçãoDeSaida;

public class Saida : EntidadeBase
{
    public DateTime Data { get; set; } = DateTime.Now;
    public Paciente Paciente { get; set; } = null!;
    public Medicamento? Medicamentos { get; set; } = null!;
    public int QuantidadeSaida { get; set; }

    public Saida()
    {
    }

    public Saida(Paciente paciente, Medicamento? medicamentos, Requisicao tipoRequisicao, int quantidadeSaida)
    {
        Data = DateTime.Now;
        Paciente = paciente;
        Medicamentos = medicamentos;
        TipoRequisicao = tipoRequisicao;
        QuantidadeSaida = quantidadeSaida;
    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (Paciente == null)
            erros += "o campo Paciente deve ser preenchido;";

        if (Medicamentos == null)
            erros += "O cmapo Medicamento deve ser preenchido;";

        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        throw new NotImplementedException();
    }
}
