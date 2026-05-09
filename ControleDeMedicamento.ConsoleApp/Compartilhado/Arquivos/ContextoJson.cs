using System.Text.Json;
using System.Text.Json.Serialization;
using ControleDeMedicamento.ConsoleApp.ModuloPacientes;

namespace ListaDeCompra.ConsoleApp.Compartilhado.Arquivos;

public class ContextoJson
{
    public List<Paciente> Pacientes { get; set; } = new List<Paciente>();

    public ContextoJson()
    {
        string caminhoAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); // 
        string caminhoArquivo = Path.Combine(caminhoAppData, "Dados.json");

        Directory.CreateDirectory(caminhoArquivo);
    }

    public void Salvar()
    {
        string caminhoAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string caminhoArquivo = caminhoAppData + "\\Dados.json";

        JsonSerializerOptions opcoesJson = new JsonSerializerOptions();
        opcoesJson.WriteIndented = true;
        opcoesJson.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        opcoesJson.ReferenceHandler = ReferenceHandler.Preserve;

        string jsonString = JsonSerializer.Serialize(this, opcoesJson);

        File.WriteAllText(caminhoArquivo, jsonString);
    }

    public void Carregar()
    {

        string caminhoAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string caminhoArquivo = caminhoAppData + "\\Dados.json";

        if (!File.Exists(caminhoArquivo))
            Console.WriteLine("A parta não existe");

        JsonSerializerOptions opcoesJson = new JsonSerializerOptions();
        opcoesJson.ReferenceHandler = ReferenceHandler.Preserve;

        string jsonString = File.ReadAllText(caminhoArquivo);

        ContextoJson? contextoSalvo = JsonSerializer.Deserialize<ContextoJson>(jsonString, opcoesJson);

        if (contextoSalvo == null)
            return;

        this.Pacientes = contextoSalvo.Pacientes;
    }
}
