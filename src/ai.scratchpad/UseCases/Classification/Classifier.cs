using Microsoft.SemanticKernel;

namespace ai.scratchpad.UseCases.Classification
{
    public class Classifier(Kernel kernel) : IClassifier
    {
        public async Task Classify(string text)
        {
            PromptTemplate template = new();
            KernelArguments args = new KernelArguments() { { "request", text } };
            PromptType selectedPrompt = PromptType.Simple;
            FunctionResult result = await kernel.InvokePromptAsync(template.prompts[selectedPrompt], args);
            Console.WriteLine(result.GetValue<string>());
        }
    }
}
