// See https://aka.ms/new-console-template for more information
using System.Text;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("Hello, World!");


Console.Write("Enter Code: ");
string request = Console.ReadLine()!;

HttpClient client = new HttpClient();


//var result = await client.GetAsync($"https://localhost:7071/api/ProductCategory/{request}");
//if (result.IsSuccessStatusCode)
//{
//    string response = await result.Content.ReadAsStringAsync();
//    Console.WriteLine(response);
//}

RequestModel requestModel = new RequestModel
{
    code = request
};
string jsonStr = JsonConvert.SerializeObject(requestModel);
var content = new StringContent(jsonStr, Encoding.UTF8, Application.Json);
var result = await client.PostAsync("https://localhost:7071/api/ProductCategory", content);
if (result.IsSuccessStatusCode)
{
    string response = await result.Content.ReadAsStringAsync();
    Console.WriteLine(response);
}

Console.ReadLine();

public class RequestModel
{
    public string? code { get; set; }
}