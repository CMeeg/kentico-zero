namespace KenticoZero.Eng.Infrastructure
{
    internal class ResourceNameArgs
    {
        public string ProjectShortName { get; set; } = default!;
        public string ServiceShortName { get; set; } = default!;
        public string Environment { get; set; } = default!;
        public string ResourceShortName { get; set; } = default!;
        public string Delimiter { get; set; } = default!;
    }
}
