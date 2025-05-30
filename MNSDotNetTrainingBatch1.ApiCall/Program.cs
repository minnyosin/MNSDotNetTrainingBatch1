// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("Hello, World!");
Console.Write("Enter Id: ");
int id = Convert.ToInt32(Console.ReadLine())!;

HttpClient client = new HttpClient();
var response = await client.GetAsync($"https://localhost:7250/api/Product/{id}");
if (response.IsSuccessStatusCode)
{
    string jsonStr = await response.Content.ReadAsStringAsync();
    Console.WriteLine(jsonStr);
}

//Console.Write("Enter Mobile No: ");
//string mobileNo = Console.ReadLine()!;

//Console.Write("Enter Amount: ");
//decimal amount = Convert.ToDecimal(Console.ReadLine())!;

//ProductRequestModel product = new ProductRequestModel()
//{
//    Id = id
//};

//string JsonStr = JsonConvert.SerializeObject(product);
//var content = new StringContent(id.ToString(), Encoding.UTF8, Application.Json);

//var response = await client.PostAsync("https://localhost:7250/api/Product", content);
//if (response.IsSuccessStatusCode)
//{
//    string result = await response.Content.ReadAsStringAsync();
//    Console.WriteLine(result);
//}

Console.ReadLine();

public class ProductRequestModel
{
    public int Id { get; set; }
}
