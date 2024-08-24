using Azure.AI.OpenAI;
using Microsoft.Extensions.Options;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace ai.scratchpad.UseCases.TroubleShoot
{
    public class PromptExecutionSettingsFactory(IOptions<AzureSearchChatExtensionOptions> options) : IPromptExecutionSettingsFactory
    {
        public OpenAIPromptExecutionSettings Create()
        {
            AzureSearchChatExtensionConfiguration extension = new()
            {
                SearchEndpoint = new Uri(options.Value.SearchEndpoint),
                Authentication = new OnYourDataApiKeyAuthenticationOptions(options.Value.AuthKey),
                IndexName = options.Value.IndexName
            };

            AzureChatExtensionsOptions azureChatExtensionsOptions = new();
            azureChatExtensionsOptions.Extensions.Add(extension);

            OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new()
            {
#pragma warning disable SKEXP0010 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
                AzureChatExtensionsOptions = azureChatExtensionsOptions
            };
#pragma warning restore SKEXP0010 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

            return openAIPromptExecutionSettings;
        }
    }
}
