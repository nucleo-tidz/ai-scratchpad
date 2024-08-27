using Microsoft.SemanticKernel;
using System.Text.Json;

namespace ai.scratchpad.UseCases.Classification
{
    public class Classifier(Kernel kernel) : IClassifier
    {
        public async Task Classify(string input)
        {
            var prompt = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "UseCases", "Classification", "Prompts", "OrdertoRepos.yaml"));
            var function = kernel.CreateFunctionFromPromptYaml(prompt);       
            KernelArguments args = new KernelArguments() { { "request", input } };
            FunctionResult result = await kernel.InvokeAsync(function, args);
            Response response = JsonSerializer.Deserialize<Response>(result.GetValue<string>());
            Console.WriteLine(result.GetValue<string>());
        }
    }
}
