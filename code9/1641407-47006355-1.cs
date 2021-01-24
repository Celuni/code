    <#@ template debug="false" hostspecific="true" language="C#" #>
    <#@ assembly name="System.Core" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.Globalization" #>
    <#@ import namespace="System.Resources" #>
    <#@ import namespace="System.Reflection" #>
    <#@ import namespace="System.Collections" #>
    <#@ import namespace="System.IO" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ output extension=".json" #>
    <# 
    	Langages = new [] { "en-US", "fr-FR", "pt-BR" };
    	Resources = new []{"Resource"};
    #>
    {
     <# var first = true;
     PushIndent("    ");
     foreach (var langage in Langages) {
    	if (!first){
    		WriteLine("},");
    	}
    	first =false;
    	WriteLine($@"""{langage}"":{{");
    	PushIndent("    ");
    	foreach(var resource in Resources){
    		WriteLine($@"""{resource}"":{{");
    		PushIndent("    ");
    		var dic = GetDictionary(resource, langage);
    		DisplayDictionary(dic);
    		PopIndent();
    		WriteLine("}");
    	}
    	PopIndent();
     } 
     WriteLine("}");
     PopIndent();
     #>
    }
    <#+
    private string[] Langages;
    
    private string[] Resources;
    
    private void DisplayDictionary(IDictionary<string,string> dictionary){
    	var first = true;
    	foreach(var entry in dictionary){
    		if (!first){
    			WriteLine(",");
    		}
    		first = false;
    		Write($@"""{entry.Key}"":""{entry.Value}""");
    	}
    	WriteLine("");
    }
    
    private IDictionary<string,string> GetDictionary(string resourceName, string langage){
    	var path = this.Host.ResolveAssemblyReference("$(TargetPath)");
    	var asm = Assembly.LoadFrom(path);
    	var resourceManager = new ResourceManager("Example.Option.CFx.Vue." + resourceName, asm);
    	var rs = resourceManager.GetResourceSet(new CultureInfo(langage), true, true);
    	return rs.Cast<DictionaryEntry>().ToDictionary(dicEntry => (string)dicEntry.Key, dicEntry => (string)dicEntry.Value);            
    }
    #>
