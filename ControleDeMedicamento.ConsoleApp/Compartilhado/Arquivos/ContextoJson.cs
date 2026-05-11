using System.Text.Json;
using System.Text.Json.Serialization;
using ControleDeMedicamento.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamento.ConsoleApp.ModuloPacientes;

namespace ListaDeCompra.ConsoleApp.Compartilhado.Arquivos;

public class ContextoJson
{
    public ContextoJson()
    {
        string caminhoAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string caminhoDowloads = Path.Combine(caminhoAppData, "ListaDeCompras");
        string caminhoArquivo = Path.Combine(caminhoAppData, "Dados.json");

        Directory.CreateDirectory(caminhoDowloads);
    }

    
    public List<Paciente> Pacientes { get; set; } = new List<Paciente>();
    //public List<ListaCompra> ListaCompra { get; set; } = new List<ListaCompra>();
    public List<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
  

    public void Salvar()
    {
        string caminhoDowloads = "C:\\Users\\kauan\\Downloads";
        string caminhoArquivo = caminhoDowloads + "\\Dados.json";

        JsonSerializerOptions opcoesJson = new JsonSerializerOptions();

        opcoesJson.WriteIndented = true;
        opcoesJson.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        opcoesJson.ReferenceHandler = ReferenceHandler.Preserve;

        string jsonString = JsonSerializer.Serialize(this, opcoesJson);

        File.WriteAllText(caminhoArquivo, jsonString);
    }

    public void Carregar()
    {

        string caminhoDowloads = "C:\\Users\\kauan\\Downloads";
        string caminhoArquivo = caminhoDowloads + "\\Dados.json";

        if (!File.Exists(caminhoArquivo))
            Console.WriteLine("A parta não existe");

        JsonSerializerOptions opcoesJson = new JsonSerializerOptions();
        opcoesJson.ReferenceHandler = ReferenceHandler.Preserve;

        string jsonString = File.ReadAllText(caminhoArquivo);

        ContextoJson? contextoSalvo = JsonSerializer.Deserialize<ContextoJson>(jsonString, opcoesJson);

        if (contextoSalvo == null)
            return;

        this.Pacientes = contextoSalvo.Pacientes;
        this.Funcionarios = contextoSalvo.Funcionarios;
        //this.ListaCompra = contextoSalvo.ListaCompra;
    }
}
