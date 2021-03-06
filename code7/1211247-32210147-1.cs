        /// <summary>
        /// Create zip archive from root directory with search patterns
        /// </summary>
        /// <param name="rootDirectory">Root directory</param>
        /// <param name="searchPatterns">Search patterns</param>
        /// <param name="zipFileName">Zip archive file name</param>
        public static void CreateZip(string rootDirectory, List<string> searchPatterns, string zipFileName)
        {
            var fileNames = GetFileNames(rootDirectory, searchPatterns, true);
            CreateZipFromFileNames(rootDirectory, zipFileName, fileNames);
        }
        /// <summary>
        /// Get file names filtered by search patterns
        /// </summary>
        /// <param name="rootDirectory">Root diirectory</param>
        /// <param name="searchPatterns">Search patterns</param>
        /// <param name="includeSubdirectories">True if it is included files from subdirectories</param>
        /// <returns>List of file names</returns>
        private static IEnumerable<string> GetFileNames(string rootDirectory, List<string> searchPatterns, bool includeSubdirectories)
        {
            var foundFiles = new List<string>();
            var directoriesToSearch = new Queue<string>();
            directoriesToSearch.Enqueue(rootDirectory);
            // Breadth-First Search
            while (directoriesToSearch.Count > 0)
            {
                var path = directoriesToSearch.Dequeue();
                foreach (var searchPattern in searchPatterns)
                {
                    foundFiles.AddRange(Directory.EnumerateFiles(path, searchPattern));
                }
                if (includeSubdirectories)
                {
                    foreach (var subDirectory in Directory.EnumerateDirectories(path))
                    {
                        directoriesToSearch.Enqueue(subDirectory);
                    }
                }
            }
            return foundFiles;
        }
        /// <summary>
        /// Create zip archive from list of file names
        /// </summary>
        /// <param name="rootDirectroy">Root directory (for saving required structure of directories)</param>
        /// <param name="zipFileName">File name of zip archive</param>
        /// <param name="fileNames">List of file names</param>
        private static void CreateZipFromFileNames(string rootDirectroy, string zipFileName, IEnumerable<string> fileNames)
        {
            var rootZipPath = Directory.GetParent(rootDirectroy).FullName;
            using (var zip = new ZipFile(zipFileName))
            {
                foreach (var filePath in fileNames)
                {
                    var directoryPathInArchive = Path.GetFullPath(Path.GetDirectoryName(filePath)).Substring(rootZipPath.Length);
                    zip.AddFile(filePath, directoryPathInArchive);
                }
                zip.Save();
            }
        }
