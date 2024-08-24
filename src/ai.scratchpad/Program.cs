using ai.scratchpad;
using ai.scratchpad.UseCases.TroubleShoot;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.SemanticKernel;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((config, services) =>
    {
        services.Configure<AzureSearchChatExtensionOptions>(config.Configuration.GetSection("AzureSearchChatExtensionOptions"))
        .AddTransient<Kernel>(serviceProvider =>
        {
            IKernelBuilder kernelBuilder = Kernel.CreateBuilder();
             kernelBuilder.Services.AddAzureOpenAIChatCompletion("gpt-35-turbo",
                config.Configuration["AzureOpenAI:Endpoint"],
                config.Configuration["AzureOpenAI:AuthKey"]);
            Kernel kernel = kernelBuilder.Build();
            return kernel;
        }).AddTransient<IPromptExecutionSettingsFactory, PromptExecutionSettingsFactory>()
          .AddTransient<ITroubleShoot, TroubleShoot>();
    }).Build();

ITroubleShoot troubleShootService = host.Services.GetRequiredService<ITroubleShoot>();
while (true)
{
    troubleShootService.Start(Console.ReadLine()).Wait();
}
