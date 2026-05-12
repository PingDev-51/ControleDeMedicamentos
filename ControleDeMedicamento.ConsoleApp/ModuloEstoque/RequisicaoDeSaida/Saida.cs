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
        string erros = string.Empty;

        if (Data > DateTime.Now.Date)
            erros += "A data deve conter informações validas;";

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
