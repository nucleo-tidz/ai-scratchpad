using Microsoft.SemanticKernel;
using System.Text.Json;

namespace ai.scratchpad.UseCases.Classification
{
    public class Classifier(Kernel kernel) : IClassifier
    {
        public async Task Classify(string text)
        {
            PromptTemplate template = new();
            KernelArguments args = new KernelArguments() { { "request", text } };
            PromptType selectedPrompt = PromptType.Specific;
            FunctionResult result = await kernel.InvokePromptAsync(template.prompts[selectedPrompt], args);
            //Response response = JsonSerializer.Deserialize<Response>(result.GetValue<string>());
            Console.WriteLine(result.GetValue<string>());
        }
    }
}
