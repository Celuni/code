    using (var reader = File.OpenText(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    foreach (var item in Encoding.UTF8.GetBytes(line))
                    {
                        //do your work here 
                        //break the foreach loop if the condition is not satisfied
                    }
                }
            }
