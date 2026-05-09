using System;
using ListaDeCompra.ConsoleApp.Compartilhado;

namespace ControleDeMedicamento.ConsoleApp.ModuloPacientes;

public class Paciente : EntidadeBase
{
   public string Nome { get; set; }
    public string Telefone { get; set; }
    public string CartaoSus { get; set; }
    public string Cpf { get; set; }

    public Paciente(string nome, string telefone, string cartaoSus, string cpf)
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

        if (CartaoSus.Length > 15)
            erros += "O Campo \"Cartão Do SUS\" deve conter 15 digitos;";

        if (Cpf.Length > 11)
            erros += "O Campo \"CPF\" deve conter 11 digitos;";

        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }
}
