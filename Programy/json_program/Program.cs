using System.Text.Json;

namespace json_program
{
  class Program
  {
    static void Main(string[] args)
    {
      string filePath = "C:/Users/uih05153/Desktop/Programy/json_program/RepoData.json";
      string jsonData = File.ReadAllText(filePath);

      Repo r1 = JsonSerializer.Deserialize<Repo>(jsonData);
      Console.WriteLine($"id: {r1.id}");
      Console.WriteLine($"name: {r1.name}");
      Console.WriteLine($"owner login: {r1.owner.login}");
      Console.WriteLine($"owner type: {r1.owner.type}");
      
      var testRepo = new Repo(){
        id = 123456789,
        name = "Jon",
        owner = new owner(){
          login = "test",
          type = "test2"
        }
      };

      var options = new JsonSerializerOptions {WriteIndented = true};
      string jsonString = JsonSerializer.Serialize(testRepo, options);
      System.Console.WriteLine(jsonString);
      File.AppendAllText(filePath, jsonString);
    }
  }
}
