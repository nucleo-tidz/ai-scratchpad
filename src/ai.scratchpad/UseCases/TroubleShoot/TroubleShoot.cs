using Microsoft.SemanticKernel;

namespace ai.scratchpad.UseCases.TroubleShoot
{
    internal class TroubleShoot(Kernel kernel, IPromptExecutionSettingsFactory promptExecutionSettingsFactory) : ITroubleShoot
    {

        public async Task Start(string prompt)
        {

            IAsyncEnumerable<StreamingKernelContent> results = kernel.InvokePromptStreamingAsync(prompt, new(promptExecutionSettingsFactory.Create()));
            await foreach (StreamingKernelContent result in results)
            {
                Console.Write(result);
            }
        }
    }
}
