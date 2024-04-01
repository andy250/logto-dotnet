using andy250.LogToDotnet;

using Microsoft.Extensions.Configuration;

IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile("appsettings.private.json", optional: true)
    .Build();

var logToConfig = config.GetSection("LogTo");

var c = new LogToClient(new LogToConfig
{
    AppId = logToConfig.GetValue<string>("AppId")!,
    AppSecret = logToConfig.GetValue<string>("AppSecret")!,
    ManagementApi = logToConfig.GetValue<string>("ManagementApi")!,
    ManagementApiScope = logToConfig.GetValue<string>("ManagementApiScope"),
    BaseUrl = logToConfig.GetValue<string>("BaseUrl")!
});

var user = await c.GetUserById(logToConfig.GetValue<string>("FetchUserId")!);