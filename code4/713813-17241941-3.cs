    public class LangPackDescriptor : ILangPackDescriptor { 
        public static string LangPackName = "Italian";
        public string string CultureString = "it-IT";
        ...
    }
    public class ItItLangPackInit : ILangPackInit{ 
        public void Init() {
            StringLib.MainFormTitle = "Il Nome Del Mio Applicazione"
            ...
        }
    }
