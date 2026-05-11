using System;
using ControleDeMedicamento.ConsoleApp.ModuloPacientes;
using ListaDeCompra.ConsoleApp.Compartilhado;

namespace ControleDeMedicamento.ConsoleApp.ModuloFuncionarios;

public class Funcionario : EntidadeBase
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;

    public Funcionario()
    {

    }

    public Funcionario(string nome, string telefone, string cpf)
    {
        Nome = nome;
        Telefone = telefone;
        Cpf = cpf;
    }
    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Funcionario funcionarioAtualizado = (Funcionario)entidadeAtualizada;

        Nome = funcionarioAtualizado.Nome;
        Telefone = funcionarioAtualizado.Telefone;
        Cpf = funcionarioAtualizado.Cpf;

    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (Nome.Length < 3 || Nome.Length > 100)
            erros += "O Campo \"Nome\" deve conter no entre 3 e 100 caracteres.;";

        if (string.IsNullOrWhiteSpace(Telefone))
            erros += "O Campo \"Telefone\" é obrigatório.;";

        else if (Telefone.Length != 14 && Telefone.Length != 15)
            erros += "O Campo \"Telefone\" deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.;";

        else if (Telefone[0] != '(' || Telefone[3] != ')' || Telefone[4] != ' ')
            erros += "O Campo \"Telefone\" deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.;";

        else if (Telefone.Length == 14 && Telefone[9] != '-')
            erros += "O Campo \"Telefone\" deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.;";

        else if (Telefone.Length == 15 && Telefone[10] != '-')
            erros += "O Campo \"Telefone\" deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.;";

        if (Cpf.Length > 11)
            erros += "O Campo \"CPF\" deve conter 11 digitos;";

        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }
}
