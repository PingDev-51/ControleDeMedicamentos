using System;
using ListaDeCompra.ConsoleApp.Compartilhado;

namespace ControleDeMedicamento.ConsoleApp.ModuloFornecedores;

public class Fornecedor : EntidadeBase
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;

    public Fornecedor()
    {

    }

    public Fornecedor(string nome, string telefone, string cnpj)
    {
        Nome = nome;
        Telefone = telefone;
        Cnpj = cnpj;
    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo nome deve ser preenchido;";
        else if (Nome.Length < 3 || Nome.Length > 100)
            erros += "O campo nome deve conter entre 3 a 100 caracteres;";

        if (string.IsNullOrWhiteSpace(Telefone))
            erros += "O Campo \"Telefone\" é obrigatório.;";
        else if (Telefone.Length != 14 && Telefone.Length != 15)
            erros += "O Campo \"Telefone\" deve estar no formato (##) ####-#### ou (##) #####-####.;";

        else if (Telefone[0] != '(' || Telefone[3] != ')' || Telefone[4] != ' ')
            erros += "O Campo \"Telefone\" deve estar no formato (##) ####-#### ou (##) #####-####.;";

        else if (Telefone.Length == 14 && Telefone[9] != '-')
            erros += "O Campo \"Telefone\" deve estar no formato (##) ####-#### ou (##) #####-####.;";

        else if (Telefone.Length == 15 && Telefone[10] != '-')
            erros += "O Campo \"Telefone\" deve estar no formato (##) ####-#### ou (##) #####-####.;";

        if (string.IsNullOrWhiteSpace(Cnpj))
            erros += "O campo CNPJ deve ser preenchido;";
        else if (Cnpj.Length < 14)
            erros += "O campo CNPJ deve conter 14 caracteres;";

        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Fornecedor fornecedorAtualizado = (Fornecedor)entidadeAtualizada;

        Nome = fornecedorAtualizado.Nome;
        Telefone = fornecedorAtualizado.Telefone;
        Cnpj = fornecedorAtualizado.Cnpj;
    }
}
