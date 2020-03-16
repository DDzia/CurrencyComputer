using CurrencyComputer.Core;
using CurrencyComputer.Engine.Antlr;

using Microsoft.Extensions.Logging;

using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;

using Serilog.Events;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace CurrencyComputer
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: add logging!!!
            ILogger logger = null;
            Log.Logger = new LoggerConfiguration()
	            .MinimumLevel.Information()
	            .WriteTo.Console()
                .WriteTo.File("logs\\ConversionResult.txt", rollingInterval: RollingInterval.Day)
                
	            .CreateLogger();

            var computer = CreateComputer(logger);
            while (true)
            {
                try
                {
                    var input = Console.ReadLine()?.Trim();
                    var result = computer.Compute(input);
                    // TODO: what with result???
                    Log.Information("{Input} = {Result}", input, result);
                }
                catch (Exception e)
                {
	                Log.Error(e, "Incorrect input data");
                }
            }
        }

        private static IConversionComputer CreateComputer(ILogger logger)
        {
            var costs = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, decimal>>>(File.ReadAllText("conversion-costs.json"));
            var conventions = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("conversion-to-currency.convention.json"));

            return new Computer(costs, conventions, logger);
        }
    }
}
