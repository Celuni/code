    class Program
      {
        public static void Main(string[] args)
		{
			RemoveDiacritics("foobar");
		}
        
            static String RemoveDiacritics(String s)
            {
                String normalizedString = s.Normalize(NormalizationForm.FormD);
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < normalizedString.Length; i++)
                {
                    Char c = normalizedString[i];
                    if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                        stringBuilder.Append(c);
                }
                return stringBuilder.ToString();
            }
        
     }
