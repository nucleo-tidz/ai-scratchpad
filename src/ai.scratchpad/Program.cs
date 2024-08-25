using ai.scratchpad;
using ai.scratchpad.UseCases.Classification;
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
             kernelBuilder.Services.AddAzureOpenAIChatCompletion("gpt-4o",
                config.Configuration["AzureOpenAI:Endpoint"],
                config.Configuration["AzureOpenAI:AuthKey"]);
            Kernel kernel = kernelBuilder.Build();
            return kernel;
        }).AddTransient<IPromptExecutionSettingsFactory, PromptExecutionSettingsFactory>()
          .AddTransient<ITroubleShoot, TroubleShoot>()
        .AddTransient<IClassifier, Classifier>();
    }).Build();

IClassifier aiservice = host.Services.GetRequiredService<IClassifier>();
while (true)
{
    Console.WriteLine("Enter text to classify:");
    aiservice.Classify(Console.ReadLine()).Wait();
}
