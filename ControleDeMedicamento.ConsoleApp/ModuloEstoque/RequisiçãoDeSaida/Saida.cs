using System;
using System.Diagnostics.Contracts;
using ControleDeMedicamento.ConsoleApp.ModuloPacientes;

namespace ControleDeMedicamento.ConsoleApp.ModuloEstoque.RequisiçãoDeSaida;

public class Saida
{
    public DateTime Data { get; set; }
    public Paciente Paciente { get; set; }
    // public Medicamentos Medicamentos {get; set;}

    public Saida(DateTime data, Paciente paciente) //, Medicamentos medicamento
    {
        Data = data;
        Paciente = paciente;
        // Medicamentos = medicamentos;
    }
}
