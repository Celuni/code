        // prefix to the relative Uri for resource (xaml file)
        string _prefix = String.Concat(typeof(App).Namespace, ";component/");
        // clear all ResourceDictionaries
        this.Resources.MergedDictionaries.Clear();
        // add ResourceDictionary
        this.Resources.MergedDictionaries.Add
        (
            new ResourceDictionary { Source = new Uri(String.Concat(_prefix + "Languages/English.xaml", UriKind.Relative) }
        );
