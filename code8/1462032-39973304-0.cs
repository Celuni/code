    using (ZipArchive archive = ZipFile.OpenRead(zipPath))
    {
         foreach (ZipArchiveEntry entry in archive.Entries)
         {
                 if (entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                 {
                      entry.ExtractToFile(Path.Combine(extractPath, entry.FullName));
                 }
         }
     } 
