namespace ai.scratchpad
{
    public class AzureSearchChatExtensionOptions
    {
        public required string SearchEndpoint { get; init; }
        public required string AuthKey { get; init; }
        public required string IndexName { get; init; }
    }
}
