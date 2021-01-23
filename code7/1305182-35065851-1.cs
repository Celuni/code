    [MarkupExtensionReturnType(typeof(Length))]
    public class LengthExtension : MarkupExtension
    {
        public LengthExtension(string value)
        {
            this.Value = Length.Parse(value, CultureInfo.InvariantCulture);
        }
        public Length Value { get; private set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
