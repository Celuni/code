        private void button2_Click(object sender, System.EventArgs e)
        {
            var assemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var assemblyParentPath = Path.GetDirectoryName(assemblyPath);
            var imageDir = Path.Combine(assemblyParentPath, "Image");
            if (!Directory.Exists(imageDir))
                Directory.CreateDirectory(imageDir);
             using (Stream s = File.Open(imageDir+"\\"+Path.GetFileName(textBox1.Text), FileMode.CreateNew))
             using (StreamWriter sw = new StreamWriter(s))
             {
                         sw.Write(textBox1.Text);
             }
            
         }
