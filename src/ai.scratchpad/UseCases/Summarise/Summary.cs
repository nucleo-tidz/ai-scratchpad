using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace ai.scratchpad.UseCases.Summarise
{
    public class Summary(IChatCompletionService chatCompletionService) : ISummary
    {

        public async Task Summarise(string text)
        {
            ChatHistory chatHistory = new($""" Please summarize the the following text in 20 words or less:{text}""");
            var response = await chatCompletionService.GetChatMessageContentsAsync(chatHistory);
            throw new NotImplementedException();
        }
    }

    public class SummaryKernel(Kernel kernel) : ISummary
    {
        public async Task Summarise(string text)
        {
            var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
            ChatHistory chatHistory = new($""" Please summarize the the following text in 20 words or less:{text}""");
            var response = await chatCompletionService.GetChatMessageContentsAsync(chatHistory);
            throw new NotImplementedException();
        }
    }
}
