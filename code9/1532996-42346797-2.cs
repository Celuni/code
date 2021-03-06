            static void Main(string[] args)
          {
            // path to desktop
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //get file extentions by speciging the needed extentions
            var images = GetFilesByExtensions(new DirectoryInfo(desktopPath) ,".png", ".jpg", ".gif");
            // loop thrue the found images and it will copy it to a folder (make sure the folder exists otherwise filenot found exception) 
            foreach (var image in images)
            {
                File.Copy(desktopPath + "\\"+ image.Name, desktopPath + "\\folderr\\" + image.Name, true);
            }
          }
        public static IEnumerable<FileInfo> GetFilesByExtensions(DirectoryInfo dir, params string[] extensions)
        {
            if (extensions == null)
                throw new ArgumentNullException("extensions");
            var files = dir.EnumerateFiles();
            return files.Where(f => extensions.Contains(f.Extension));
        }
