using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace ai.scratchpad.UseCases.TroubleShoot
{
    internal interface IPromptExecutionSettingsFactory
    {
        OpenAIPromptExecutionSettings Create();
    }
}
