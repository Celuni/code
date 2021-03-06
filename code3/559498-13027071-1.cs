    public static class QuestionTypeExtension
    {
        public static IEnumerable<Reference> Reference()
        {
            return Enum.GetValues(typeof(QuestionType)).OfType<QuestionType>().
                Select(qt=>new Reference(){ PartitionKey = "00", RowKey = (int)qt, Value = qt.ToString()});
        }
    } 
