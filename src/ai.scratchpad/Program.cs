using ai.scratchpad;
using ai.scratchpad.UseCases.Classification;
using ai.scratchpad.UseCases.TroubleShoot;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.Google;
IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((config, services) =>
    {
        services.Configure<AzureSearchChatExtensionOptions>(config.Configuration.GetSection("AzureSearchChatExtensionOptions"))
        .AddTransient<Kernel>(serviceProvider =>
        {
            IKernelBuilder kernelBuilder = Kernel.CreateBuilder();

            #region Geoogle Gemini
#pragma warning disable SKEXP0070 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
             kernelBuilder.Services.AddGoogleAIGeminiChatCompletion("gemini-1.0-pro", config.Configuration["GoogleApiKey"],serviceId: "gpt-4-turbo");
#pragma warning restore SKEXP0070 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            #endregion

            #region Azure OpenAI
            //kernelBuilder.Services.AddAzureOpenAIChatCompletion("gpt-4o",
            //   config.Configuration["AzureOpenAI:Endpoint"],
            //   config.Configuration["AzureOpenAI:AuthKey"],
            //   "gpt-4-turbo",
            //   "gpt-4-turbo");
            #endregion

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
