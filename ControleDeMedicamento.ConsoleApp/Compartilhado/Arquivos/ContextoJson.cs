using System.Text.Json;
using System.Text.Json.Serialization;

namespace ListaDeCompra.ConsoleApp.Compartilhado.Arquivos;

public class ContextoJson
{
    public ContextoJson()
    {
        string caminhoAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string caminhoDowloads = Path.Combine(caminhoAppData, "ListaDeCompras");
        string caminhoArquivo = Path.Combine(caminhoAppData, "\\Dados.json");

        Directory.CreateDirectory(caminhoDowloads);
    }

    //public List<Categoria> Categoria { get; set; } = new List<Categoria>();
    //public List<Produto> Produto { get; set; } = new List<Produto>();
    //public List<ListaCompra> ListaCompra { get; set; } = new List<ListaCompra>();

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

        //this.Categoria = contextoSalvo.Categoria;
        //this.Produto = contextoSalvo.Produto;
        //this.ListaCompra = contextoSalvo.ListaCompra;

    }
}
