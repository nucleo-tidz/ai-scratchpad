using Azure.AI.OpenAI;
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace ai.scratchpad.UseCases
{
    internal class TroubleShoot(Kernel kernel,IConfiguration configuration) : ITroubleShoot
    {
        
        public async Task Start(string prompt)
        {
            AzureSearchChatExtensionConfiguration extension = new AzureSearchChatExtensionConfiguration
            {
                SearchEndpoint = new Uri(configuration["AzureSearchChatExtensionConfiguration:SearchEndpoint"]),
                Authentication = new OnYourDataApiKeyAuthenticationOptions(configuration["AzureSearchChatExtensionConfiguration:AuthKey"]),
                IndexName = "nucelotizindex"
            };
            AzureChatExtensionsOptions azureChatExtensionsOptions = new AzureChatExtensionsOptions { Extensions = { extension } };
            OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new OpenAIPromptExecutionSettings();
#pragma warning disable SKEXP0010 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            openAIPromptExecutionSettings.AzureChatExtensionsOptions = azureChatExtensionsOptions;
#pragma warning restore SKEXP0010 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            var results =  kernel.InvokePromptStreamingAsync(prompt, new(openAIPromptExecutionSettings));
            await foreach (var result in results)
            {
                Console.Write(result);
            }
        }
    }
}
