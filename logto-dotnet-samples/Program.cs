using andy250.LogToDotnet;

using Microsoft.Extensions.Configuration;

IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile("appsettings.private.json", optional: true)
    .Build();

var logToConfig = new LogToConfig();
config.GetSection("LogTo").Bind(logToConfig);

var c = new LogToClient(logToConfig);

var user = await c.GetUserById(config["FetchUserId"]!);
Console.WriteLine($"id={user?.Id} email={user?.PrimaryEmail}");
Console.ReadLine();