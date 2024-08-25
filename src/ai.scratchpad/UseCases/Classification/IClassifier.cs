namespace ai.scratchpad.UseCases.Classification
{
    public interface IClassifier
    {
        Task Classify(string text);
    }
}
