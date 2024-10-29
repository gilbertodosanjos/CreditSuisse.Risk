// Program.cs
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using CreditSuisse.Domain.Interfaces;
using CreditSuisse.Domain.Services.Categories;
using CreditSuisse.Domain.Services;
using CreditSuisse.Domain.Entities;
using System.IO;

// Configure services
var serviceProvider = new ServiceCollection()
    .AddSingleton<ITradeCategoryHandler, ExpiredCategoryHandler>()
    .AddSingleton<ITradeCategoryHandler, HighRiskCategoryHandler>()
    .AddSingleton<ITradeCategoryHandler, MediumRiskCategoryHandler>()
     .AddSingleton<ITradeCategoryHandler, PepCategoryHandler>() // Novo manipulador de categoria PEP
    .AddSingleton<TradeCategorizerService>()
    .BuildServiceProvider();

// Resolve the service
var tradeCategorizer = serviceProvider.GetRequiredService<TradeCategorizerService>();

var referenceDate  = DateTime.ParseExact("12/30/2024", "MM/dd/yyyy", CultureInfo.InvariantCulture);

var trades = new List<ITrade>();

var filePath = "trades.txt";

if (File.Exists(filePath))
{
    var lines = File.ReadAllLines(filePath);
    foreach (var line in lines)
    {
        var tradeData = line.Split(' ');

        var value = double.Parse(tradeData[0]);
        var clientSector = tradeData[1];
        var nextPaymentDate = DateTime.ParseExact(tradeData[2], "MM/dd/yyyy", CultureInfo.InvariantCulture);
        var isPoliticallyExposed = bool.Parse(tradeData[3]);
        
        trades.Add(new Trade(value, clientSector, nextPaymentDate, isPoliticallyExposed));
    }
}


// Categorize trades
foreach (var trade in trades)
{
    var category = tradeCategorizer.Categorize(trade, referenceDate);
    Console.WriteLine(category);
}
