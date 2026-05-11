using System;
using ControleDeMedicamento.ConsoleApp.Compartilhado;
using ListaDeCompra.ConsoleApp.Compartilhado.Arquivos;

namespace ControleDeMedicamento.ConsoleApp.ModuloPacientes;

public class RepositorioPaciente : RepositorioBaseEmArquivo<Paciente>, IRepositorio<Paciente>
{
    public RepositorioPaciente(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Paciente> CarregarRegistros()
    {
        return contexto.Pacientes;
    }
}