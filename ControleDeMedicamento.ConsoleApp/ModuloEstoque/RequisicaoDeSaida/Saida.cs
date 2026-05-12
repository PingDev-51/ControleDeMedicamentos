using System;
using System.Diagnostics.Contracts;
using ControleDeMedicamento.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamento.ConsoleApp.ModuloPacientes;
using ListaDeCompra.ConsoleApp.Compartilhado;

namespace ControleDeMedicamento.ConsoleApp.ModuloEstoque.RequisiçãoDeSaida;

public class Saida : EntidadeBase
{
    public DateTime Data { get; set; }
    public Paciente Paciente { get; set; }
    public Medicamento? Medicamentos { get; set; }

    public Saida(DateTime data, Paciente paciente, Medicamento? medicamentos)
    {
        Data = data;
        Paciente = paciente;
        Medicamentos = medicamentos;
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
