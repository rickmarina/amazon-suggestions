#nullable disable
    public class SuggestionsResponseModel
    {
        public string alias { get; set; }
        public string prefix { get; set; }
        public string suffix { get; set; }
        public List<Suggestion> suggestions { get; set; }
        public object suggestionTitleId { get; set; }
        public string responseId { get; set; }
        public bool shuffled { get; set; }
    }

    public class Suggestion
    {
        public string suggType { get; set; }
        public string type { get; set; }
        public string value { get; set; }
        public string refTag { get; set; }
        public string candidateSources { get; set; }
        public string strategyId { get; set; }
        public string strategyApiType { get; set; }
        public double prior { get; set; }
        public bool ghost { get; set; }
        public bool help { get; set; }
    }

