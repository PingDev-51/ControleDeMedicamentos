using System;
using ListaDeCompra.ConsoleApp.Compartilhado.Arquivos;

namespace ControleDeMedicamento.ConsoleApp.ModuloPacientes;

public class RepositorioPaciente : RepositorioBaseEmArquivo<Paciente>
{
    public RepositorioPaciente(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Paciente> CarregarRegistros()
    {
        return contexto.Pacientes;
    }
}