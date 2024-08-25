namespace ai.scratchpad.UseCases.Classification
{
    public enum PromptType
    {
        Simple,
        Specific,
    }

    public class PromptTemplate
    {
       public Dictionary<PromptType, string> prompts = new Dictionary<PromptType, string>
        {
            { PromptType.Simple, "Classify the following give one word answer like Obscene  text: {{$request}} " },
            { PromptType.Specific, "Classify the following text as one of the following: Obscene, Decent give one word answer like Obscene  text: {{$request}}" }, 
            
        };
    }

}
