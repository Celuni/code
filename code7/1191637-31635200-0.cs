    // numeric character references
    static readonly Regex ncrRegex = new Regex("&#(?:x|X)?[A-Fa-f0-9]+;");
    static string ReplaceInvalidXmlCharacterReferences(string input)
    {
        if (input.IndexOf('&') == -1)   // optimization
            return input;
        return ncrRegex.Replace(input, match =>
        {
            string ncr = match.Value;            
            uint num;
            var frmt = NumberFormatInfo.InvariantInfo;
            bool isParsed =
                ncr[2] == 'x' || ncr[0] == 'X' ?
                uint.TryParse(ncr.Substring(3, ncr.Length - 4), NumberStyles.AllowHexSpecifier, frmt, out num) :
                uint.TryParse(ncr.Substring(2, ncr.Length - 3), NumberStyles.Integer, frmt, out num);
            return isParsed && !XmlConvert.IsXmlChar((char)num) ? "�" : ncr;
        });
    }
