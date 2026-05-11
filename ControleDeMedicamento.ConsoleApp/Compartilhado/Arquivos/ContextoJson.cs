using System.Text.Json;
using System.Text.Json.Serialization;
using ControleDeMedicamento.ConsoleApp.ModuloFornecedores;
using ControleDeMedicamento.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamento.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamento.ConsoleApp.ModuloPacientes;

namespace ListaDeCompra.ConsoleApp.Compartilhado.Arquivos;

public class ContextoJson
{
    public List<Fornecedor> Fornecedor { get; set; } = new List<Fornecedor>();
    public List<Paciente> Pacientes { get; set; } = new List<Paciente>();
    public List<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
    public List<Medicamento> Medicamento { get; set; } = new List<Medicamento>();
    private readonly string caminhoArquivo;
    public ContextoJson()
    {
        string caminhoAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); //Leva ate  apasta AppData
        string caminhoDiretorio = Path.Combine(caminhoAppData, "PastaDados.json");

        Directory.CreateDirectory(caminhoDiretorio);

        caminhoArquivo = Path.Combine(caminhoDiretorio, "dados.json");
    }


    public void Salvar()
    {
        JsonSerializerOptions opcoesJson = new JsonSerializerOptions();
        opcoesJson.WriteIndented = true;
        opcoesJson.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        opcoesJson.ReferenceHandler = ReferenceHandler.Preserve;

        string jsonString = JsonSerializer.Serialize(this, opcoesJson);

        File.WriteAllText(caminhoArquivo, jsonString);
    }

    public void Carregar()
    {
        if (!File.Exists(caminhoArquivo))
            return;

        string jsonString = File.ReadAllText(caminhoArquivo);

        JsonSerializerOptions opcoesJson = new JsonSerializerOptions();
        opcoesJson.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        opcoesJson.ReferenceHandler = ReferenceHandler.Preserve;

        ContextoJson? contextoSalvo = JsonSerializer.Deserialize<ContextoJson>(jsonString, opcoesJson);

        if (contextoSalvo == null)
            return;

        this.Fornecedor = contextoSalvo.Fornecedor;
        this.Pacientes = contextoSalvo.Pacientes;
        this.Medicamento = contextoSalvo.Medicamento;
        this.Funcionarios = contextoSalvo.Funcionarios;
    }
}
