namespace ai.scratchpad.UseCases.Classification
{
    public enum PromptType
    {
        Specific,
    }

    public class PromptTemplate
    {
       public Dictionary<PromptType, string> prompts = new Dictionary<PromptType, string>
        {

            { PromptType.Specific, @"Classify the following text as one of the following: Valid, Invalid reason when an order to reposition empty container is modified, 
               give response in json with two properties Type and summary where type can have values like Valid and summary will have a brief summary text ,
               json string should be serializable in C# and should not contain any special character text: {{$request}}" }, 
            
        };
    }

}
