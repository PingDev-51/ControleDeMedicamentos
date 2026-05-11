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
        throw new NotImplementedException();
    }
}
