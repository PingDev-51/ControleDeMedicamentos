using System;
using System.Security.Cryptography;
using ControleDeMedicamento.ConsoleApp.ModuloEstoque;

namespace ListaDeCompra.ConsoleApp.Compartilhado;

public abstract class EntidadeBase : Object
{
    public string Id { get; set; } = string.Empty;
    public Requisicao TipoRequisicao { get; set; }

    public EntidadeBase()
    {
        Id = Convert
                .ToHexString(RandomNumberGenerator.GetBytes(20))
                .ToLower()
                .Substring(0, 7);
    }

    public abstract string[] Validar();
    public abstract void AtualizarDados(EntidadeBase entidadeAtualizada);
}
