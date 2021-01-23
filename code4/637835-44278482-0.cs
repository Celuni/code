    <#@ template debug="false" hostspecific="true" language="C#" #>
    <#@ assembly name="System.Core" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.Text" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ import namespace="System.IO" #>
    <#@ output extension=".cs" #>
    
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    
    <#
   	if (File.Exists(Host.ResolvePath("git_version.txt")))
   	{
   		Write("[assembly: AssemblyInformationalVersion(\""+ File.ReadAllText(Host.ResolvePath("git_version.txt")).Trim() + "\")]");
   	}else{
   		Write("// version file not found in " + Host.ResolvePath("git_version.txt"));
   	}
   
    #>
