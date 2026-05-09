using System;
using ListaDeCompra.ConsoleApp.Compartilhado;

namespace ControleDeMedicamento.ConsoleApp.ModuloPacientes;

public class Paciente : EntidadeBase
{
    string Nome { get; set; }
    int Telefone { get; set; }
    int CartaoSus { get; set; }
    int Cpf { get; set; }

    public Paciente(string nome, int telefone, int cartaoSus, int cpf)
    {
        Nome = nome;
        Telefone = telefone;
        CartaoSus = cartaoSus;
        Cpf = cpf;
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Paciente pacienteAtualizado = (Paciente)entidadeAtualizada;

        Nome = pacienteAtualizado.Nome;
        Telefone = pacienteAtualizado.Telefone;
        CartaoSus = pacienteAtualizado.CartaoSus;
        Cpf = pacienteAtualizado.Cpf;

    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (Nome.Length == 3 || Nome.Length > 100)
            erros += "O Campo \"Nome\" deve conter no entre 3 e 100 caracteres.;";
        string telefone = Telefone.ToString();

        if (string.IsNullOrWhiteSpace(telefone))
            erros += "O Campo \"Telefone\" é obrigatório.;";

        else if (telefone.Length != 14 && telefone.Length != 15)
            erros += "O Campo \"Telefone\" deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.;";

        else if (telefone[0] != '(' || telefone[3] != ')' || telefone[4] != ' ')
            erros += "O Campo \"Telefone\" deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.;";

        else if (telefone.Length == 14 && telefone[9] != '-')
            erros += "O Campo \"Telefone\" deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.;";
            
        else if (telefone.Length == 15 && telefone[10] != '-')
            erros += "O Campo \"Telefone\" deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.;";

        if (CartaoSus.ToString().Length > 15)
            erros += "O Campo \"Cartão Do SUS\" deve conter 15 digitos;";

        if (Cpf.ToString().Length > 11)
            erros += "O Campo \"CPF\" deve conter 11 digitos;";

        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }
}
