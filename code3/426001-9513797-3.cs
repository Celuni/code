    using System;
    using System.IO; 
    using System.MarshalByRefObject;
    class DoStuff 
    {
       char driveLetter;
       ...
       
       void Initialize()
       {
          try
          {
             Directory.SetCurrentDirectory( string(driveLetter)+string(@":\"); 
          }
          catch(FileNotFoundException e)
          { 
             //Just in case...
             Console.WriteLine(e.ToString()); 
             string[] str=Directory.GetLogicalDrives();
             Console.WriteLine( "Using C# Directory Class ,Available drives are:");
             for(int i=0;i< str.Length;i++)
             Console.WriteLine(str[i]);
             //If fatal
             //Environment.Exit(1)
          } 
          Process.Start("cmd.exe");
          //Do whatever else you need to do in C:/ ...
    } 
