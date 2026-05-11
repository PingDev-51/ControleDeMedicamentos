using System;
using ControleDeMedicamento.ConsoleApp.ModuloFornecedores;
using ListaDeCompra.ConsoleApp.Compartilhado;

namespace ControleDeMedicamento.ConsoleApp.ModuloMedicamento;

public class Medicamento : EntidadeBase
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int QuantidadeEmEstoque { get; set; }
    public Fornecedor? Fornecedor { get; set; }

    public Medicamento()
    {

    }

    public Medicamento(string nome, string descricao, int quantidadeEmEstoque, Fornecedor fornecedor)
    {
        Nome = nome;
        Descricao = descricao;
        QuantidadeEmEstoque = quantidadeEmEstoque;
        Fornecedor = fornecedor;
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Medicamento medicamentoAtualizado = (Medicamento)entidadeAtualizada;

        Nome = medicamentoAtualizado.Nome;
        Descricao = medicamentoAtualizado.Descricao;
        QuantidadeEmEstoque = medicamentoAtualizado.QuantidadeEmEstoque;
        Fornecedor = medicamentoAtualizado.Fornecedor;
    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo Nome deve ser preenchido;";
        else if (Nome.Length < 3 || Nome.Length > 100)
            erros += "O campo Nome deve conter entre 3 a 100 caracteres;";

        if (string.IsNullOrWhiteSpace(Descricao))
            erros += "O campo Descrição deve ser preenchido;";
        else if (Descricao.Length < 5 || Descricao.Length > 255)
            erros += "O campo Descrição deve conter entre 5 a 255 caracteres;";

        if (QuantidadeEmEstoque < 0)
            erros += "O campo quantidade nao pode ser um numero neativo;";

        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }
}
