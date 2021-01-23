    using System;
    using System.Collections.Generic;
    using System.IO;
    
    namespace RedirectToFile
    {
        class Program
        {
            static void Main(string[] args)
            {
                var buffer = new char[100];
                var outputs = new List<TextWriter>();
    
                foreach (var file in args)
                    outputs.Add(new StreamWriter(file));
    
                outputs.Add(Console.Out);
    
                int bytesRead;
                do
                {
                    bytesRead = Console.In.ReadBlock(buffer, 0, buffer.Length);
                    outputs.ForEach(o => o.Write(buffer, 0, bytesRead));
                } while (bytesRead == buffer.Length);
    
                outputs.ForEach(o => o.Close());
            }
        }
    }
