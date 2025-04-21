using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

// Load config
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddJsonFile("appsettings.Development.json", optional: true)
    .Build();

var smsSettings = config.GetSection("SmsSettings");
var token = smsSettings["Token"];
var sender = smsSettings["Sender"];

if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(sender))
{
    Console.WriteLine("❌ Please set your SMS token and sender name in appsettings.json.");
    return;
}

// Prompt user for dynamic input
Console.Write("Enter recipient phone number (e.g. +9665XXXXXXXX): ");
var recipient = Console.ReadLine();

Console.Write("Enter message to send: ");
var message = Console.ReadLine();

if (string.IsNullOrWhiteSpace(recipient) || string.IsNullOrWhiteSpace(message))
{
    Console.WriteLine("❌ Recipient and message cannot be empty.");
    return;
}

var smsRequest = new
{
    recipients = new[] { recipient },
    body = message,
    sender = sender,
    scheduled = (string?)null,
    tag = "test"
};

var json = JsonSerializer.Serialize(smsRequest);
using var client = new HttpClient();

client.BaseAddress = new Uri("https://api.taqnyat.sa/v1/");
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

Console.WriteLine("📤 Sending SMS...");

try
{
    var response = await client.PostAsync("messages", new StringContent(json, Encoding.UTF8, "application/json"));
    var responseContent = await response.Content.ReadAsStringAsync();

    Console.WriteLine($"✅ Status Code: {response.StatusCode}");
    Console.WriteLine("📩 Response:");
    Console.WriteLine(responseContent);
}
catch (Exception ex)
{
    Console.WriteLine("❌ Error occurred:");
    Console.WriteLine(ex.Message);
}
