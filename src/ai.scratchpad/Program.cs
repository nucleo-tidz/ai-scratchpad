using ai.scratchpad.UseCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.SemanticKernel;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((config, services) =>
    {
        services.AddTransient<Kernel>(serviceProvider =>
        {
            var kernelBuilder = Kernel.CreateBuilder();
            kernelBuilder.Services.AddAzureOpenAIChatCompletion("gpt-35-turbo",
                config.Configuration["AzureOpenAI:Endpoint"],
                config.Configuration["AzureOpenAI:AuthKey"]);
            var kernel = kernelBuilder.Build();
            return kernel;
        });
        services.AddTransient<ITroubleShoot, TroubleShoot>();
    }).Build();



var troubleShootService = host.Services.GetRequiredService<ITroubleShoot>();
while (true)
{
    troubleShootService.Start(Console.ReadLine()).Wait();
}
